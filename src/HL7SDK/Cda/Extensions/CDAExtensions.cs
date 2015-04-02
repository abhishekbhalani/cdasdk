/******************************************************************************
 * 
 * HL7SDK CDA extensions
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7SDK.Cda.Extensions
{
    public static class CDAExtensions
    {
        /// <summary>
        /// Filters descendant CDA elements using predicate
        /// </summary>
        public static IEnumerable<ICDAObject> Select(this ICDAObject item, Func<Object, bool> predicate)
        {
            List<ICDAObject> result = new List<ICDAObject>();
            Traverser t = new Traverser(item as HL73Object, ElementFactory.Wrap, ElementFactory.CanWrap);
            t.OnItemFound += (e) =>
            {
                if (predicate(e))
                    result.Add(e as ICDAObject);
            };
            t.Run();
            return result;
        }

        public static void Exchange<T>(this ICDACollection collection, T item1, T item2)
            where T: ICDAObject
        {
            // TODO:
        }
    }
}
