/******************************************************************************
 *
 * HL7SDK document elements partial extensions
 *
 *****************************************************************************/
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace HL7SDK.Cda
{

    [ComVisible(true)]
    [Guid("935D710D-32DB-46B8-9BBB-7F9B345F6015")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ICCDClinicalDocument : IClinicalDocument, IHL73Object, ICDAObject, ICDAElement
    {
        [DispId(1001)]
        new string Xml {get;}

        [DispId(1002)]
        new bool Lazy {get;set;}
        [DispId(2000)]

        new void Load(Object source);
        new void LoadXml(string value);
        new void Save(Object source);
        new IHL73ObjectCollection ChildObjects {get;}
        new ICSCollection RealmCode {get;}
        new IInfrastructureRoottypeId TypeId {get;set;}
        new IIICollection TemplateId { get; }
        new III Id {get;set;}
        new ICE Code {get;set;}
        new IST Title {get;set;}
        new ITS EffectiveTime {get;set;}
        new ICE ConfidentialityCode {get;set;}
        new ICS LanguageCode {get;set;}
        new III SetId {get;set;}
        new IINT VersionNumber {get;set;}
        new ITS CopyTime {get;set;}
        new IRecordTargetCollection RecordTarget {get;}
        new IAuthorCollection Author {get;}
        new IDataEnterer DataEnterer {get;set;}
        new IInformant12Collection Informant {get;}
        new ICustodian Custodian {get;set;}
        new IInformationRecipientCollection InformationRecipient {get;}
        new ILegalAuthenticator LegalAuthenticator {get;set;}
        new IAuthenticatorCollection Authenticator {get;}
        new IParticipant1Collection Participant {get;}
        new IInFulfillmentOfCollection InFulfillmentOf {get;}
        new IDocumentationOfCollection DocumentationOf {get;}
        new IRelatedDocumentCollection RelatedDocument {get;}
        new IAuthorizationCollection Authorization { get; }
        new IComponent1 ComponentOf {get;set;}
        new IComponent2 Component { get; set; }
        new string NullFlavor {get;set;}
        new HL7SDK.Cda.ActClinicalDocument ClassCode {get;set;}
        new bool ClassCodeSpecified { get; set; }
        new string MoodCode { get;set;}
        new string ToString();
        new bool Equals([MarshalAs(UnmanagedType.IDispatch)] Object obj);
        IComponent3 AdvanceDirectives { get; }
        IComponent3 Alerts { get; }
        IComponent3 Encounters { get; }
        IComponent3 FamilyHistory { get; }
        IComponent3 FunctionalStatus { get; }
        IComponent3 Immunizations { get; }
        IComponent3 MedicalEquipment { get; }
        IComponent3 Medications { get; }
        IComponent3 Payers { get; }
        IComponent3 PlanOfCare { get; }
        IComponent3 Problems { get; }
        IComponent3 Procedures { get; }
        IComponent3 Results { get; }
        IComponent3 SocialHistory { get; }
        IComponent3 VitalSigns { get; }
    }

    partial interface IClinicalDocument
    {
        void Load(Object source);

        void LoadXml(string value);

        void Save(Object source);
    }

    partial interface IComponent3Collection
    {
        IComponent3 FindBySectionId(string sectionId);
    }

    partial interface ICriterion
    {
        IANY Value
        {
            get;
            set;
        }
    }

    partial interface IObservationMedia
    {
        void Load(Object source);

        void Save(Object destination);
    }

    partial interface IObservationRange
    {
        IANY Value
        {
            get;
            set;
        }
    }

    [ComVisible(true)]
    [Guid("E97EFD73-34AF-41AB-91ED-1713088FACE7")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ICCDClinicalDocument))]
    public partial class CCDClinicalDocument : ClinicalDocument, ICCDClinicalDocument
    {
        public CCDClinicalDocument()
        {
            if (this.TypeId == null)
                this.TypeId = new InfrastructureRoottypeId();
            this.TypeId.Extension = "POCD_HD000040";
            this.TypeId.Root = "2.16.840.1.113883.1.3";
            this.TemplateId.Add(new II() { Root = "2.16.840.1.113883.10.20.1" });
        }

        private class CCDID
        {
            public string codeSystemName = "LOINC";
            public string codeSystem = Constants.LOINC;
            public string code;
            public string templateId1;
        }

        static Dictionary<string, CCDID> IDs;

        static CCDClinicalDocument()
        {
            IDs = new Dictionary<string, CCDID>();
            IDs.Add("Payers", 
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.9", code = "48768-6" });
            IDs.Add("Advance Directives",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.1", code = "42348-3" });
            IDs.Add("Functional Status",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.5", code = "47420-5" });
            IDs.Add("Problems",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.11", code = "11450-4" });
            IDs.Add("Family History",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.4", code = "10157-6" });
            IDs.Add("Social History",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.15", code = "29762-2" });
            IDs.Add("Alerts",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.2", code = "48765-2" });
            IDs.Add("Medications",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.8", code = "10160-0" });
            IDs.Add("Medical Equipment",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.7", code = "46264-8" });
            IDs.Add("Immunizations",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.6", code = "11369-6" });
            IDs.Add("Vital Signs",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.16", code = "8716-3" });
            IDs.Add("Results",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.14", code = "30954-2" });
            IDs.Add("Procedures",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.12", code = "47519-4" });
            IDs.Add("Encounters",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.3", code = "46240-8" });
            IDs.Add("Plan of Care",
                    new CCDID() { templateId1 = "2.16.840.1.113883.10.20.1.10", code = "18776-5" });
        }

        public IComponent3 PlanOfCare
        {
            get
            {
                var comp = FindOrCreateComponent("Plan Of Care");
                return comp;
            }
        }

        public IComponent3 Encounters
        {
            get
            {
                var comp = FindOrCreateComponent("Encounters");
                return comp;
            }
        }

        public IComponent3 Procedures
        {
            get
            {
                var comp = FindOrCreateComponent("Procedures");
                return comp;
            }
        }

        public IComponent3 Results
        {
            get
            {
                var comp = FindOrCreateComponent("Results");
                return comp;
            }
        }

        public IComponent3 VitalSigns
        {
            get
            {
                var comp = FindOrCreateComponent("Vital Signs");
                return comp;
            }
        }

        public IComponent3 Immunizations
        {
            get
            {
                var comp = FindOrCreateComponent("Immunizations");
                return comp;
            }
        }

        public IComponent3 MedicalEquipment
        {
            get
            {
                var comp = FindOrCreateComponent("Medical Equipment");
                return comp;
            }
        }

        public IComponent3 Medications
        {
            get
            {
                var comp = FindOrCreateComponent("Medications");
                return comp;
            }
        }

        public IComponent3 Alerts
        {
            get
            {
                var comp = FindOrCreateComponent("Alerts");
                return comp;
            }
        }

        public IComponent3 SocialHistory
        {
            get
            {
                var comp = FindOrCreateComponent("Social History");
                return comp;
            }
        }

        public IComponent3 FamilyHistory
        {
            get
            {
                var comp = FindOrCreateComponent("Family History");
                return comp;
            }
        }

        public IComponent3 Problems
        {
            get
            {
                var comp = FindOrCreateComponent("Problems");
                return comp;
            }
        }

        public IComponent3 Payers
        {
            get
            {
                var comp = FindOrCreateComponent("Payers");
                return comp;
            }
        }

        public IComponent3 AdvanceDirectives
        {
            get
            {
                var comp = FindOrCreateComponent("Advance Directives");
                return comp;
            }
        }

        public IComponent3 FunctionalStatus
        {
            get
            {
                var comp = FindOrCreateComponent("Functional Status");
                return comp;
            }
        }

        private IComponent3 FindOrCreateComponent(string id)
        {
            if (!IDs.ContainsKey(id))
                return null;
            var cid = IDs[id];

            if (!this.Lazy)
            {
                if (this.Component == null)
                    return null;
                if (this.Component.Item == null)
                    return null;
                if (!(this.Component.Item is StructuredBody))
                    return null;
                foreach (IComponent3 item in this.Component.AsStructuredBody.Component)
                {
                    if (item.Section != null && item.Section.Code != null && item.Section.Code.CodeSystemName == cid.code)
                    {
                        return item;
                    }
                }
                return null;
            }
            else
            {
                var comp = this.Component.AsStructuredBody.Component.Where(row => row.Section.Code.Code == cid.code).FirstOrDefault();

                if (comp == null)
                {
                    comp = this.Component.AsStructuredBody.Component.Append();
                    comp.Section = new Section();
                    comp.Section.Title = new ST();
                    comp.Section.Title.Text = id;
                    comp.Section.Code = new CE();
                    if (!string.IsNullOrEmpty(cid.code))
                        comp.Section.Code.Code = cid.code;
                    if (!string.IsNullOrEmpty(cid.codeSystem))
                        comp.Section.Code.CodeSystem = cid.codeSystem;
                    if (!string.IsNullOrEmpty(cid.codeSystemName))
                        comp.Section.Code.CodeSystemName = cid.codeSystemName;
                    if (!string.IsNullOrEmpty(cid.templateId1))
                    {
                        var ii = new II() { Root = cid.templateId1 };
                        comp.Section.TemplateId.Add(ii);
                    }
                }
                return comp;
            }
        }
    }

    partial class ClinicalDocument
    {
        public void Load(Object source)
        {
            XmlSerializer ser = ElementFactory.GetSerializerFor(element);

            if (source is string)
            {
                using (XmlTextReader rdr = new XmlTextReader((string)source))
                {
                    this.element = ser.Deserialize(rdr) as HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument;
                }
            }

            else if (source is System.IO.Stream)
            {
                var stream = source as System.IO.Stream;
                this.element = ser.Deserialize(stream) as HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument;
            }

            else if (source is System.IO.TextReader)
            {
                var reader = source as System.IO.TextReader;
                this.element = ser.Deserialize(reader) as HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument;
            }

            else if (source is System.Xml.XmlReader)
            {
                var reader = source as System.Xml.XmlReader;
                this.element = ser.Deserialize(reader) as HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument;
            }

            else if (source is System.Runtime.InteropServices.ComTypes.IStream)
            {
                var comStream = source as System.Runtime.InteropServices.ComTypes.IStream;
                System.Runtime.InteropServices.ComTypes.STATSTG s = default(System.Runtime.InteropServices.ComTypes.STATSTG);
                comStream.Stat(out s, 0);
                byte[] b = new byte[s.cbSize];
                IntPtr pcbRead = default(IntPtr);
                comStream.Read(b, b.Length, pcbRead);

                using (var stream = new System.IO.MemoryStream(b))
                {
                    this.element = ser.Deserialize(stream) as HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument;
                    stream.Close();
                }
            }

            else
            {
                throw new ArgumentException("Unsupported type.");
            }
        }

        public void LoadXml(string value)
        {
            XmlSerializer ser = ElementFactory.GetSerializerFor(element);
            using (System.IO.StringReader rdr = new System.IO.StringReader(value))
            {
                this.element = ser.Deserialize(rdr);
            }
        }

        public void Save(Object source)
        {
            if (source is string)
            {
                XmlSerializer ser = ElementFactory.GetSerializerFor(element);
                using (var rtr = XmlWriter.Create(source as String, new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true, Encoding = System.Text.Encoding.UTF8 }))
                {
                    ser.Serialize(rtr, this.element);
                }
            }

            else if (source is System.IO.Stream)
            {
                var stream = source as System.IO.Stream;
                XmlSerializer ser = new XmlSerializer(typeof(HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument));
                ser.Serialize(stream, this.element);
            }

            else if (source is System.IO.TextWriter)
            {
                var writer = source as System.IO.TextWriter;
                XmlSerializer ser = new XmlSerializer(typeof(HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument));
                ser.Serialize(writer, this.element);
            }

            else if (source is System.Xml.XmlWriter)
            {
                var writer = source as System.Xml.XmlWriter;
                XmlSerializer ser = new XmlSerializer(typeof(HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument));
                ser.Serialize(writer, this.element);
            }

            else if (source is System.Runtime.InteropServices.ComTypes.IStream)
            {
                var stream = new System.IO.MemoryStream();
                XmlSerializer ser = new XmlSerializer(typeof(HL7SDK.Xml.Cda.POCD_MT000040ClinicalDocument));
                ser.Serialize(stream, this.element);

                stream.Position = 0;
                byte[] b = new byte[stream.Length];
                stream.Read(b, 0, Convert.ToInt32(stream.Length));

                var comStream = source as System.Runtime.InteropServices.ComTypes.IStream;

                // comStream.Seek(0, 0, new IntPtr(0));
                IntPtr pbWritten = default(IntPtr);
                comStream.Write(b, b.Length, pbWritten);

                stream.Close();
            }

            else
            {
                throw new ArgumentException("Unsupported type.");
            }
        }
    }

    partial class Component3Collection
    {
        public IComponent3 FindBySectionId(string sectionId)
        {
            foreach (IComponent3 item in this)
            {
                if (item.Section != null && item.Section.Id != null &&
                    item.Section.Id.Extension == sectionId)
                    return item;
            }
            return null;
        }
    }

    partial class Criterion
    {
        public virtual IANY Value
        {
            get
            {
                if (Element.value == null)
                    return null;
                return ElementFactory.Wrap(Element.value, this) as IANY;
            }
            set
            {
                ANY t = value as ANY;
                Element.value = t.Element;
            }
        }
    }

    partial class ObservationMedia
    {
        public void Load(Object source)
        {
            if (source is string)
            {
                if (Element.value == null)
                    Element.value = new Xml.Cda.ED();
                byte[] b = System.IO.File.ReadAllBytes((string)source);
                Element.value.Text = new String[]
                {
                    Convert.ToBase64String(b)
                };
                Element.value.representation = HL7SDK.Xml.Cda.BinaryDataEncoding.B64;
            }
            else if (source is Array)
            {
                if (Element.value == null)
                    Element.value = new Xml.Cda.ED();
                Element.value.Text = new String[]
                {
                    Convert.ToBase64String((source as Array).Cast<byte>().ToArray())
                };
                Element.value.representation = HL7SDK.Xml.Cda.BinaryDataEncoding.B64;
            }
            else
            {
                // TODO:
                throw new NotImplementedException();
            }
        }

        public void Save(Object destination)
        {
            if (destination is string)
            {
                byte[] content = new byte[0];
                if (Element.value != null && Element.value.Text != null)
                {
                    content = Convert.FromBase64String(String.Join("", Element.value.Text));
                }
                System.IO.File.WriteAllBytes((string)destination, content);
            }
            else
            {
                // TODO:
                throw new NotSupportedException();
            }
        }
    }

    partial class ObservationRange
    {
        public virtual IANY Value
        {
            get
            {
                if (Element.value == null)
                    return null;
                return ElementFactory.Wrap(Element.value, this) as IANY;
            }
            set
            {
                ANY t = value as ANY; Element.value = t.Element;
            }
        }
    }
}