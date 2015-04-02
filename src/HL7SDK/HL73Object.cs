/******************************************************************************
 * 
 * HL7SDK Base object/interface definitions
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace HL7SDK
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("263A5B3F-E6D4-4001-91BA-B74AE3AC4D5B")]
    public interface IHL73Object
    {
        [DispId(0)]
        string ToString();

        [DispId(1000)]
        bool Equals([MarshalAs(UnmanagedType.IDispatch)] Object obj);

        [DispId(1001)]
        [Browsable(false)]
        string Xml { get; }

        [DispId(1002)]
        [Browsable(false)]
        bool Lazy { get; set; }

        [DispId(2000)]
        [Browsable(false)]
        IHL73ObjectCollection ChildObjects { get; }

        [ComVisible(false)]
        IHL73Object Clone();

        [ComVisible(false)]
        [Browsable(false)]
        IHL73Object Parent { get; }
    }

    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("47FC5972-E951-433A-A68C-5FC5E84E0E01")]
    public interface IHL73ObjectCollection : IEnumerable
    {
        [DispId(1)]
        int Count { get; }

        [DispId(0)]
        IHL73Object this[int index] { get; }

        [DispId(-4)]
        new IEnumerator GetEnumerator();
    }

    [ComVisible(true)]
    [Guid("7806A891-1FED-48D9-B072-33C071F0D732")]
    [ClassInterface(ClassInterfaceType.None)]
    public abstract class HL73Object : IHL73Object, INotifyPropertyChanged
    {
        internal protected Object element;

        internal protected HL73Object parent;

        bool lazy = true;

        protected HL73Object()
        {
            OnCreate();
        }

        public virtual IHL73Object Clone()
        {
            if (element == null)
                throw new InvalidOperationException("Element is unassigned.");
            if (element.GetType().IsAbstract)
                throw new InvalidOperationException("HL7 data type is abstract and cannot be cloned.");

            var myType = this.GetType();
            var myCopy = Activator.CreateInstance(myType);
            Object elementCopy = null;

            XmlSerializer ser = new XmlSerializer(this.element.GetType(), Constants.URN_HL7);
            using (var stream = new MemoryStream())
            {
                ser.Serialize(stream, this.element);
                stream.Position = 0;
                elementCopy = ser.Deserialize(stream);
            }

            ((HL73Object)myCopy).element = elementCopy;
            ((HL73Object)myCopy).parent = null;
            return myCopy as IHL73Object;
        }

        internal protected virtual void Attach(HL73Object parent)
        {
            this.parent = parent;
        }

        internal protected virtual void Detach()
        {
            this.parent = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [Browsable(false)]
        public virtual IHL73ObjectCollection ChildObjects 
        {
            get
            {
                return new HL73ObjectCollection(new IHL73Object[0]);
            }
        }

        [Browsable(false)]
        public virtual bool Lazy
        {
            get
            {
                if (parent == null)
                    return this.lazy;
                return parent.Lazy;
            }
            set
            {
                lazy = value;
            }
        }

        [Browsable(false)]
        public abstract string Xml { get; }

        [Browsable(false)]
        protected Object Element
        {
            get
            {
                return element;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override bool Equals(object obj)
        {
            if (obj is HL73Object)
                return Object.ReferenceEquals(((HL73Object)obj).element, this.element);
            return base.Equals(obj);
        }

        protected virtual void OnCreate()
        {
        }

        protected void RaisePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, e);
            }
        }

        [Browsable(false)]
        public virtual IHL73Object Parent 
        {
            get
            {
                return this.parent;
            }
        }
    }

    internal class HL73ObjectCollection : IHL73ObjectCollection
    {
        internal HL73ObjectCollection(IEnumerable<IHL73Object> elements)
        {
            this.elements = elements;
        }

        private IEnumerable<IHL73Object> elements;

        public int Count
        {
            get
            {
                return elements.Count();
            }
        }

        public IHL73Object this[int index]
        {
            get
            {
                return elements.ToArray()[index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
