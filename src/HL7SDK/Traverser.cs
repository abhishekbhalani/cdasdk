/******************************************************************************
 * 
 * HL73 element traverser
 * 
 *****************************************************************************/
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace HL7SDK
{
    internal delegate void TraverserEventHandler(HL73Object item);

    internal class Traverser
    {
        private Func<object, bool> canWrap;

        private HL73Object sender;

        private Func<object, HL73Object, HL73Object> wrapper;

        internal event TraverserEventHandler OnItemFound;

        internal Traverser(HL73Object sender, Func<object, HL73Object, HL73Object> wrapper, Func<object, bool> canWrap)
        {
            this.sender = sender;
            this.wrapper = wrapper;
            this.canWrap = canWrap;
        }

        internal void Run()
        {
            InternalTraverse(sender);
        }

        private void InternalTraverse(HL73Object parent)
        {
            var item = parent.element;

            var props = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var propType = prop.PropertyType;
                if (propType.IsValueType)
                    continue;
                if (prop.GetIndexParameters() != null && prop.GetIndexParameters().Count() != 0)
                    continue;
                if (prop.PropertyType == typeof(String))
                    continue;

                if (propType.GetInterface("IEnumerable") != null)
                {
                    if (propType.GetElementType() != null && propType.GetElementType().IsValueType)
                        continue;
                    var propValue = prop.GetValue(item, new object[0]) as IEnumerable;
                    if (propValue != null)
                    {
                        foreach (var propItem in propValue)
                        {
                            if (!canWrap(propItem))
                                continue;
                            HL73Object propItemWrapper = wrapper(propItem, parent);
                            RaiseItemFound(propItemWrapper);
                            InternalTraverse(propItemWrapper);
                        }
                    }
                }
                else
                {
                    var propValue = prop.GetValue(item, new object[0]);
                    if (propValue == null)
                        continue;
                    if (!canWrap(propValue))
                        continue;
                    HL73Object propValueWrapper = wrapper(propValue, parent);
                    RaiseItemFound(propValueWrapper);
                    InternalTraverse(propValueWrapper);
                }
            }
        }

        private void RaiseItemFound(HL73Object item)
        {
            if (OnItemFound != null)
                OnItemFound(item); 
        }
    }
}
