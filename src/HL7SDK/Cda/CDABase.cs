/******************************************************************************
 * 
 * HL7SDK CDA base objects
 * 
 *****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.ComponentModel;

namespace HL7SDK.Cda
{
    /// <summary>
    /// Base collection interface
    /// </summary>
    [Guid("7E7F752E-51BD-4F0A-B5C1-0AC0C0C7021B")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public partial interface ICDACollection : IEnumerable
    {
        [DispId(1)]
        int Count { get; }

        [DispId(2)]
        bool Delete(Object index);

        [DispId(5)]
        void Clear();
    }

    /// <summary>
    /// Base interface for CDA document elements (ClinicalDocument, RecordTarget etc)
    /// </summary>
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("B3FE3C69-791E-438D-9C71-8F91C41824E8")]
    public interface ICDAElement : ICDAObject
    {
        [DispId(0)]
        new string ToString();

        [DispId(1002)]
        new bool Lazy { get; set; }

        [DispId(1001)]
        new string Xml { get; }

        [DispId(1000)]
        new bool Equals([MarshalAs(UnmanagedType.IDispatch)] Object obj);

        [DispId(2000)]
        new IHL73ObjectCollection ChildObjects { get; }

        [DispId(3000)]
        String NullFlavor { get; set; }

        [DispId(3001)]
        ICSCollection RealmCode { get; }

        [DispId(3002)]
        IIICollection TemplateId { get; }

        [DispId(3003)]
        IInfrastructureRoottypeId TypeId { get; set; }
    }

    /// <summary>
    /// Base interface for all CDA elements (datatypes, document elements and narrative elements)
    /// </summary>
    [Guid("EDAF1C9F-2359-4FAA-B9AD-A8AC3213C861")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ICDAObject : IHL73Object
    {
        [DispId(0)]
        new string ToString();

        [DispId(1002)]
        new bool Lazy { get; set; }

        [DispId(1001)]
        new string Xml { get; }

        [DispId(1000)]
        new bool Equals([MarshalAs(UnmanagedType.IDispatch)] Object obj);

        [DispId(2000)]
        new IHL73ObjectCollection ChildObjects { get; }
    }

    /// <summary>
    /// Base interface for CDA datatypes (ANY, CD, II etc.)
    /// </summary>
    [ComVisible(true)]
    [Guid("0D726238-F4E0-4C2C-B454-082C604B6FA3")]
    public partial interface IDataTypeElement : ICDAObject
    {
        string NullFlavor { get; set; }
    }

    /// <summary>
    /// Base interface for narrative elements
    /// </summary>
    [ComVisible(true)]
    [Guid("6609E721-22A0-4EB1-B68E-52423A02B5B2")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public partial interface IStrucDocElement : ICDAObject
    {
        
    }

    /// <summary>
    /// Base interface for narrative block untyped collections
    /// </summary>
    [ComVisible(true)]
    [Guid("261E4907-499B-477E-982C-7485904BF208")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public partial interface IStrucDocElementCollection : ICDACollection, IEnumerable
    {
        /// <summary>
        /// Gets the narrative element at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [DispId(0)]
        Object this[int index] { get; }

        /// <summary>
        /// Gets the number of elements 
        /// </summary>
        [DispId(1)]
        new int Count { get; }

        /// <summary>
        /// Removes an element at the specified index
        /// </summary>
        /// <param name="index"></param>
        [DispId(2)]
        new bool Delete(Object index);

        /// <summary>
        /// Adds a narrative element to the end of collection
        /// </summary>
        /// <param name="item"></param>
        [DispId(3)]
        void Add(Object item);

        /// <summary>
        /// Removes all elements from collection
        /// </summary>
        [DispId(5)]
        new void Clear();

        [DispId(-4)]
        new IEnumerator GetEnumerator();
    }

    /// <summary>
    /// Abstract collection implementation
    /// </summary>
    [DefaultProperty("Item")]
    public class CDACollection<T, TPOCD, IT>: ICDACollection //, IEnumerable<IT>
        where T : CDAObject, IT
        where TPOCD : class
        where IT : class
    {
        protected internal CDAObject parent;
        protected internal Object parentElement;

        protected Func<TPOCD[]> getProp;
        protected Action<TPOCD[]> setProp;

        private TPOCD Unwrap(IT value)
        {
            if (value == null)
                return null;
            T pValue = value as T;
            if (pValue == null)
                throw new ArgumentException("Specified value is not an instance of type " + typeof(IT).Name + ".");
            return pValue.element as TPOCD;
        }

        protected List<TPOCD> GetList()
        {
            if (getProp() == null)
                setProp(new TPOCD[0]);
            return new List<TPOCD>(getProp());
        }

        public bool Contains(IT value)
        {
            if (value == null)
                return false;

            TPOCD pElement = Unwrap(value);
            return GetList().Contains(pElement);
        }

        public int IndexOf(IT value)
        {
            if (value == null)
                return -1;

            TPOCD a = Unwrap(value);
            return GetList().IndexOf(a);
        }

        public void Exchange(IT a, IT b)
        {
            TPOCD a1 = Unwrap(a);
            TPOCD b1 = Unwrap(b);

            List<TPOCD> list = GetList();
            int idxA = IndexOf(a);
            if (idxA == -1)
                throw new IndexOutOfRangeException("Collection does not contain item A.");

            int idxB = IndexOf(b);
            if (idxB == -1)
                throw new IndexOutOfRangeException("Collection does not contain item B.");

            list[idxA] = b1;
            list[idxB] = a1;

            setProp(list.ToArray());
        }

        public CDACollection(CDAObject parent, Func<TPOCD[]> GetProp, Action<TPOCD[]> SetProp)
        {
            this.parent = parent;
            this.getProp = GetProp;
            this.setProp = SetProp;
            if (this.getProp() == null)
            {
                this.setProp(new TPOCD[0]);
            }
        }

        // Dispid 1
        public virtual int Count
        {
            get
            {
                return GetList().Count;
            }
        }

        // Dispid 0
        public virtual IT this[int index]
        {
            get
            {
                var list = GetList();
                return ElementFactory.Wrap(list[index], parent) as IT;
            }
        }

        // Dispid 3
        public virtual void Add(IT value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var a = Unwrap(value);
            var pValue = value as T;
            var list = GetList();

            list.Add(a);
            pValue.parent = this.parent;

            setProp(list.ToArray());
        }

        // Dispid 4
        public virtual void Clear()
        {
            setProp(new TPOCD[0]);
        }

        // Dispid 2
        public virtual bool Delete(Object Index)
        {
            bool result = false;

            var list = GetList();

            if (Index is HL73Object)
            {
                var pIndex = Index as HL73Object;
                if (!(pIndex.element is TPOCD))
                {
                    throw new ArgumentException("Invalid object type.");
                }
                result = list.Remove(pIndex.element as TPOCD);
            }
            else
            {
                int lIndex = Convert.ToInt32(Index);
                list.RemoveAt(lIndex);
                result = true;
            }
            setProp(list.ToArray());
            return result;
        }

        public IEnumerator<IT> GetEnumerator()
        {
            var list = GetList();
            foreach (var t in list)
            {
                yield return ElementFactory.Wrap(t, parent) as IT;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var list = GetList();
            foreach (var t in list)
            {
                yield return ElementFactory.Wrap(t, parent) as IT;
            }
        }
    }


    public abstract class CDAElement : CDAObject, ICDAElement
    {
        public abstract String NullFlavor { get; set; }

        public abstract ICSCollection RealmCode { get; }

        public abstract IIICollection TemplateId { get; }

        public abstract IInfrastructureRoottypeId TypeId { get; set; }
    }

    public class CDAFactoryCollection<T, TPOCD, IT> : CDACollection<T, TPOCD, IT>
        where T : CDAObject, IT, new()
        where TPOCD : class, new()
        where IT : class
    {
        public CDAFactoryCollection(CDAObject owner, Func<TPOCD[]> GetProp, Action<TPOCD[]> SetProp) :
            base(owner, GetProp, SetProp)
        {
        }

        public virtual IT Append()
        {
            var list = GetList();
            var item = new TPOCD();
            list.Add(item);
            setProp(list.ToArray());

            return ElementFactory.Wrap(item, parent) as IT;
        }
    }

    partial class ElementFactory
    {
        private static Dictionary<Type, Type> typeCache;
        private static Dictionary<Type, XmlSerializer> serialzerCache;

        static ElementFactory()
        {
            typeCache = new Dictionary<Type, Type>();
            serialzerCache = new Dictionary<Type, XmlSerializer>();
            LoadTypes();
        }

        public static XmlSerializer GetSerializerFor(Object value)
        {
            // Serializer assembly is required for fast serialization
            if (value == null)
                return null;
            if (serialzerCache.ContainsKey(value.GetType()))
                return serialzerCache[value.GetType()];
            var ser = new Microsoft.Xml.Serialization.GeneratedAssembly.XmlSerializerContract().GetSerializer(value.GetType());
            serialzerCache.Add(value.GetType(), ser);
            return ser;
        }

        public static bool CanWrap(object element)
        {
            if (element == null)
                return false;
            return typeCache.ContainsKey(element.GetType());
        }

        public static HL73Object Wrap(Object element, HL73Object parent)
        {
            if (element == null)
                return null;

            // Get cached wrapper type
            if (!typeCache.ContainsKey(element.GetType()))
                throw new ArgumentException("Cannot find wrapper type for " + element.GetType());
            
            var factoryType = typeCache[element.GetType()];
            var result = Activator.CreateInstance(factoryType) as CDAObject;
            result.element = element;
            result.parent = parent;

            // Done
            return result;
        }
    }

    /// <summary>
    /// Base CDA class
    /// </summary>
    public abstract class CDAObject : HL73Object, ICDAObject
    {
        public override IHL73ObjectCollection ChildObjects
        {
            get
            {
                List<IHL73Object> list = new List<IHL73Object>();
                var propertyInfos = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                foreach (var propertyInfo in propertyInfos)
                {
                    var iHL7Object = propertyInfo.PropertyType.GetInterface("IHL73Object");
                    if (iHL7Object != null)
                    {
                        Object propertyValue = null;
                        try
                        {
                            propertyValue = propertyInfo.GetValue(this, new Object[0]);
                        }
                        catch
                        {
                            continue;
                        }

                        if (propertyValue != null)
                        {
                            list.Add(propertyValue as IHL73Object);
                        }
                    }

                    var iCDACollection = propertyInfo.PropertyType.GetInterface("ICDACollection");
                    if (iCDACollection != null)
                    {
                        ICDACollection collection = propertyInfo.GetValue(this, new Object[0]) as ICDACollection;
                        foreach (Object collectionItem in collection)
                        {
                            if (collectionItem is IHL73Object)
                            {
                                list.Add(collectionItem as IHL73Object);
                            }
                        }
                    }
                }
                return new HL73ObjectCollection(list);
            }
        }


        protected ClinicalDocument Document
        {
            get
            {
                if (this is HL7SDK.Cda.ClinicalDocument)
                    return (ClinicalDocument)this;

                if (this.parent == null)
                    return null;

                if (this.parent is ClinicalDocument)
                    return (ClinicalDocument)this.parent;

                return (this.parent as CDAObject).Document;
            }
        }

        protected virtual void InternalLazyInitElement()
        {
        }

        public override string Xml
        {
            get
            {
                if (element == null)
                    return String.Empty;
                XmlSerializer ser = ElementFactory.GetSerializerFor(element);
                StringBuilder sb = new StringBuilder();
                using (var w = XmlWriter.Create(sb, new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true }))
                {
                    ser.Serialize(w, element);
                    w.Flush();
                }
                return sb.ToString();
            }
        }
    }

    /// <summary>
    /// Base class for CDA R2 DataType classes (from datatypes.xsd and datatypes-base.xsd)
    /// </summary>
    public abstract class DataTypeElement : CDAObject, IDataTypeElement
    {
        public abstract String NullFlavor { get; set; }
    }

    /// <summary>
    /// Base class for CDA R2 narrative classes (from NarrativeBlock.xsd)
    /// </summary>
    public abstract class StrucDocElement : CDAObject, IStrucDocElement
    {
        public override string ToString()
        {
            if (element == null)
                return String.Empty;

            XmlDocument doc = new XmlDocument();
            
            XmlSerializer ser = new XmlSerializer(this.element.GetType(), Constants.URN_HL7);
            using (var stream = new System.IO.StringWriter())
            {
                ser.Serialize(stream, element);
                doc.LoadXml(stream.ToString());
            }
            return doc.DocumentElement.InnerXml;
        }
    }

    /// <summary>
    /// Base class for CDA R2 snarrative block elements collection
    /// </summary>
    internal class StrucDocElementCollection : IStrucDocElementCollection
    {
        private Func<Object[]> getProp;
        private CDAObject owner;
        private List<Type> pocdAcceptableTypes; // List of acceptable collection types
        private Action<Object[]> setProp;

        protected List<Object> GetList()
        {
            if (getProp() == null)
                setProp(new object[0]);
            return new List<object>(getProp());
        }

        public StrucDocElementCollection(CDAObject owner, Func<Object[]> getProp, Action<Object[]> setProp, Type[] pocdAcceptableTypes)
        {
            this.owner = owner;
            this.getProp = getProp;
            this.setProp = setProp;
            if (pocdAcceptableTypes == null)
                this.pocdAcceptableTypes = new List<Type>();
            else
                this.pocdAcceptableTypes = new List<Type>(pocdAcceptableTypes);
        }

        public int Count
        {
            get
            {
                return GetList().Count;
            }
        }

        public Object this[int Index]
        {
            get
            {
                Object item = GetList()[Index];
                if (item is String)
                    return item;
                return ElementFactory.Wrap(getProp()[Index], owner) as IStrucDocElement;
            }
        }

        public void Add(Object Value)
        {
            if (Value == null)
                throw new ArgumentNullException("Value");

            var list = GetList();

            if (Value is String)
            {
                list.Add(Value);
                setProp(list.ToArray());
                return;
            }

            if (!(Value is IStrucDocElement))
                throw new InvalidCastException("Value");

            var sdElement = Value as StrucDocElement;
            if (sdElement == null)
                throw new InvalidCastException("Value must be of type IStrucDocElement");

            if (pocdAcceptableTypes.Count == 0)
            {
                list.Add(sdElement.element);
                setProp(list.ToArray());
            }
            else
            {
                var elementType = sdElement.element.GetType();
                foreach (var acceptableType in pocdAcceptableTypes)
                {
                    if (elementType == acceptableType)
                    {
                        list.Add(sdElement.element);
                        setProp(list.ToArray());
                        return;
                    }
                }
                throw new ArgumentException("Cannot accept argument of type " + elementType.Name + ".");
            }
        }

        public void Clear()
        {
            setProp(new object[0]);
        }

        public bool Delete(Object Index)
        {
            bool result = false;
            
            List<Object> list = GetList();

            if (Index is StrucDocElement)
            {
                StrucDocElement pElement = Index as StrucDocElement;
                result = list.Remove(pElement.element);
            }
            else if (Index is String)
            {
                result = list.Remove(Index);
            }
            else
            {
                list.RemoveAt(Convert.ToInt32(Index));
                result = true;
            }

            setProp(list.ToArray());
            return result;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            var list = GetList();
            foreach (var t in list)
            {
                if (t is String)
                    yield return t;
                else
                    yield return ElementFactory.Wrap(t, owner);
            }
        }
    }
}
