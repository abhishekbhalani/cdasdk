using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HL7SDK;
using HL7SDK.Cda;
using HL7SDK.Cda.Extensions;
using System.Xml.Serialization;

namespace HL7SDK.Test
{
    /// <summary>
    /// Test cases for CDA elements
    /// </summary>
    [TestClass]
    public class Tests
    {
        private TestContext testContextInstance;

        public Tests()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestAssessment()
        {
            var section = new Section();
            section.Code = new CE();
            section.Code.Code = "11496-7";
            section.Code.CodeSystem = "2.16.840.1.113883.6.1";
            section.Code.DisplayName = "LOINC";
            section.Title = new ST();
            section.Title.Text = "Assessment";
            section.Text = new StrucDocText();

            var list = new StrucDocList();
            list.ListType = StrucDocListListType.ordered;

            var listItem = new StrucDocItem();
            listItem.Items.Add("Asthma, with prior smoking history. Difficulty weaning off steroids. Will try gradual taper.");
            list.Item.Add(listItem);

            listItem = new StrucDocItem();
            listItem.Items.Add("Hypertension, well-controlled.");
            list.Item.Add(listItem);

            listItem = new StrucDocItem();
            listItem.Items.Add("Contact dermatitis on finger.");
            list.Item.Add(listItem);

            section.Text.Items.Add(list);

            var entry = section.Entry.Append();
            entry.AsObservation = new Observation();
            entry.AsObservation.EffectiveTime = new IVL_TS();
            entry.AsObservation.EffectiveTime.Value = "200004071530";

            var entryValue = new CD();
            entryValue.Code = "195967001";
            entryValue.CodeSystem = "2.16.840.1.113883.6.96";
            entryValue.CodeSystemName = "SNOMED CT";
            entryValue.DisplayName = "Asthma";
            var translation = entryValue.Translation.Append();
            translation.Code = "49390";
            translation.CodeSystem = "2.16.840.1.113883.6.2";
            translation.CodeSystemName = "ICD9CM";
            translation.DisplayName = "ASTHMA W/O STATUS ASTHMATICUS";

            entry.AsObservation.Value.Add(entryValue);

            this.TestContext.WriteLine(section.Xml);
        }

        // OK
        [TestMethod]
        public void TestEntry1()
        {
            var entry1 = new Entry();
            entry1.AsObservation = new Observation();
            entry1.AsObservation.MoodCode = x_ActMoodDocumentObservation.EVN;
            entry1.AsObservation.Code = new CD();
            entry1.AsObservation.Code.Code = "251076008";
            entry1.AsObservation.Code.CodeSystem = "2.16.840.1.113883.6.96";

            var er = entry1.AsObservation.EntryRelationship.Append();
            er.AsObservation = new Observation();
            var pq = new PQ();
            pq.Value = 132;
            pq.Unit = "mm[Hg]";
            er.AsObservation.Value.Add(pq);

            this.TestContext.WriteLine(entry1.Xml);
        }

        [TestMethod]
        public void TestIVL_INT()
        {
            var ivl = new IVL_INT();
            IIVXB_INT low = new IVXB_INT().Init(100);
            ivl.Init(width: new INT().Init(2000));
            this.TestContext.WriteLine(ivl.Xml);
        }

        [TestMethod]
        public void TestIVL_TS()
        {
            var ivl = new IVL_TS();
            ivl.Init(low: new IVXB_TS() { AsDateTime = DateTime.Now });
            this.TestContext.WriteLine(ivl.Xml);
            this.TestContext.WriteLine(ivl.Low.Value);
        }

        [TestMethod]
        public void TestObservationLab()
        {
            var obs = new Observation();
            obs.Id.Add(new II().Init("2.16.840.1.113883.2.10.1.4.5", "E157300-466-1"));
            obs.Code.Code = "369";
            obs.Code.CodeSystem = "2.16.840.1.113883.2.10.1.1.3";
            obs.Code.DisplayName = "HEMATOCRITO";
            obs.Code.OriginalText.Reference.Value = "#a1";
            obs.StatusCode.Code = "completed";
            obs.EffectiveTime.Value = "20061106171200";
            obs.Value.Add(new PQ() { Unit = "1", Value = 39 });

            var referenceRange = obs.ReferenceRange.Append();
            var ivl = new IVL_PQ();
            ivl.Init(low: new IVXB_PQ() { Unit = "%", Value = 37.0 });
            referenceRange.ObservationRange.Value = ivl;

            referenceRange = obs.ReferenceRange.Append();
            ivl = new IVL_PQ();
            ivl.Init(high: new IVXB_PQ() { Unit = "%", Value = 47.0 });
            referenceRange.ObservationRange.Value = ivl;

            this.TestContext.WriteLine(obs.Xml);
        }

        [TestMethod]
        public void TestObservationMediaBinary()
        {
            var observationMedia = new ObservationMedia();
            observationMedia.Load(new byte[] { 65, 66, 67 });
            this.TestContext.WriteLine(observationMedia.Xml);
            var b = Convert.FromBase64String(observationMedia.Value.Text);
            var s = System.Text.Encoding.ASCII.GetString(b);
            this.TestContext.WriteLine(s); // ABC
        }

        [TestMethod]
        public void TestObservationRTO_PQ_PQ()
        {
            var obs = new Observation();
            var value = new RTO_PQ_PQ();
            value.Numerator.Value = 260;
            value.Numerator.Unit = "l";
            value.Denominator.Value = 3.5;
            value.Denominator.Unit = "min";
            obs.Value.Add(value);
            this.TestContext.WriteLine(obs.Xml);
        }

        [TestMethod]
        public void TestProcedure()
        {
            var entry = new Entry();
            var proc = entry.AsProcedure;
            proc.Code = new CD() { Code="30549001", CodeSystem="2.16.840.1.113883.6.96", CodeSystemName="SNOMED CT", DisplayName="Suture removal" };
            proc.StatusCode.Code = "completed";
            proc.EffectiveTime.AsDateTime = new DateTime(2000, 04, 07, 14, 30, 0);
            proc.TargetSiteCode.Add(new CD() { Code="66480008", CodeSystem="2.16.840.1.113883.6.96", CodeSystemName="SNOMED CT", DisplayName="Left forearm" });
            TestContext.WriteLine(proc.Xml);
        }

        [TestMethod]
        public void TestObservationTargetSite()
        {
            var obs = new Observation() { ClassCode = "COND", MoodCode = x_ActMoodDocumentObservation.EVN };
            obs.Code = new CD() { Code = "14657009", CodeSystem = "2.16.840.1.113883.6.96", CodeSystemName = "Snomed-CT", DisplayName = "Established diagnosis" };
            obs.StatusCode.Code = "established";
            obs.EffectiveTime.AsDateTime = DateTime.Now;

            var v = new CD() { Code = "40275004", CodeSystem = "2.16.840.1.113883.6.96", CodeSystemName = "Snomed-CT", DisplayName = "Contact dermatitis" };
            v.Translation.Add(new CD() { Code = "692.9", CodeSystem = "2.16.840.1.113883.6.2", CodeSystemName = "ICD9CM", DisplayName = "Contact Dermatitis, NOS" });
            obs.Value.Add(v);

            var targetSiteCode = new CD() { Code = "48856004", CodeSystem = "2.16.840.1.113883.6.96", CodeSystemName = "Snomed-CT", DisplayName = "Skin of palmer surface of index finger" };
            var cr = targetSiteCode.Qualifier.Append();
            cr.Name = new CV() { Code = "78615007", CodeSystem = "2.16.840.1.113883.6.96", CodeSystemName = "Snomed-CT", DisplayName = "with laterality" };
            cr.Value = new CD() { Code = "7771000", CodeSystem = "2.16.840.1.113883.6.96", CodeSystemName = "Snomed-CT", DisplayName = "left" };
            obs.TargetSiteCode.Add(targetSiteCode);

            TestContext.WriteLine(obs.Xml);
        }

        [TestMethod]
        public void TestParseNarrative()
        {
            var text = new Util().ParseNarrative(
@"
<table>
									<tbody>
										<tr>
											<th>Date / Time</th>
											<th>April 7, 2000 14:30</th>
											<th>April 7, 2000 15:30</th>
										</tr>
										<tr>
											<th>Height</th>
											<td>177 cm (69.7 in)</td>
										</tr>
										<tr>
											<th>Weight</th>
											<td>194.0 lbs (88.0 kg)</td>
										</tr>
										<tr>
											<th>BMI</th>
											<td>28.1 kg/m2</td>
										</tr>
										<tr>
											<th>BSA</th>
											<td>2.05 m2</td>
										</tr>
										<tr>
											<th>Temperature</th>
											<td>36.9 C (98.5 F)</td>
											<td>36.9 C (98.5 F)</td>
										</tr>
										<tr>
											<th>Pulse</th>
											<td>86 / minute</td>
											<td>84 / minute</td>
										</tr>
										<tr>
											<th>Rhythm</th>
											<td>Regular</td>
											<td>Regular</td>
										</tr>
										<tr>
											<th>Respirations</th>
											<td>16 / minute, unlabored</td>
											<td>14 / minute</td>
										</tr>
										<tr>
											<th>Systolic</th>
											<td>132 mmHg</td>
											<td>135 mmHg</td>
										</tr>
										<tr>
											<th>Diastolic</th>
											<td>86 mmHg</td>
											<td>88 mmHg</td>
										</tr>
										<tr>
											<th>Position / Cuff</th>
											<td>Left Arm</td>
											<td>Left Arm</td>
										</tr>
									</tbody>
								</table>");
            foreach (var item in text.Items)
            {
                this.TestContext.WriteLine(item.ToString());
            }
        }

        [TestMethod]
        public void TestSupply()
        {
            var entry = new Entry();
            var supply = entry.AsSupply;
            supply.ClassCode = ActClassSupply.SPLY;
            supply.MoodCode = x_DocumentSubstanceMood.EVN;
            supply.Quantity.Unit = "PKG";
            supply.Quantity.Value = 2;
            supply.Product.ManufacturedProduct.AsLabeledDrug.ClassCode = "MMAT";
            supply.Product.ManufacturedProduct.AsLabeledDrug.DeterminerCode = EntityDeterminerDetermined.KIND;
            var drug = supply.Product.ManufacturedProduct.AsLabeledDrug;
            drug.Code = new CE() { Code = "033940014", CodeSystem = "2.16.840.1.113883.2.9.6.1.5", CodeSystemName = "AIC" };
            drug.Code.Translation.Add(new CD() { Code = "78686", CodeSystem = "2.16.840.1.113883.2.9.6.1.12", CodeSystemName = "ATC" });
            TestContext.WriteLine(entry.Xml);
        }

        [TestMethod]
        public void TestTSValues()
        {
            foreach (var str in new[] {
                "2000",
                "200001",
                "200013",
                "20010131",
                "20010132",
                
                "200101011230",
                "20010101123005",
                "20010101123061",

                "20091212172151.035+05"
            })
            {
                var ts = new TS() { Value = str };
                try
                {
                    var dt = ts.AsDateTime;
                    TestContext.WriteLine("Correct TS: " + ts.Value + ", date = " + dt.ToString());
                }
                catch (ArgumentException ex)
                {
                    TestContext.WriteLine("Wrong TS: " + ts.Value + " (" + ex.Message + ")");
                }
                catch (FormatException ex1)
                {
                    TestContext.WriteLine("Wrong TS: " + ts.Value + " (" + ex1.Message + ")");
                }

            }
        }

        [TestMethod]
        public void TestRegionOfInterest()
        {
            IRegionOfInterest v = new RegionOfInterest();
            v.Code.Code = "ELLIPSE";
            v.Value.Append().Value = 3;
            v.Value.Append().Value = 1;
            v.Value.Append().Value = 3;
            v.Value.Append().Value = 7;
            v.Value.Append().Value = 2;
            v.Value.Append().Value = 4;
            v.Value.Append().Value = 4;
            v.Value.Append().Value = 4;
            v.XmlId = "MM1";
            var er = v.EntryRelationship.Append();
            er.AsObservationMedia.Value.MediaType = "image/gif";
            er.AsObservationMedia.Value.Reference.Value = "lefthand.gif";

            TestContext.WriteLine(v.Xml);

            foreach (IRegionOfInterestvalue iv in v.Value)
            {
                TestContext.WriteLine("Value: {0}", iv.Value);
            }

        }

        void Print(string message)
        {
            this.TestContext.WriteLine(message);
        }

        [TestMethod]
        public void TestDOM()
        {
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDelete2()
        {
            // Invalid type
            var pr = new PatientRole();
            pr.Id.Append();
            pr.Id.Delete(pr);
        }

        [TestMethod]
        public void TestDelete()
        {
            var pr = new PatientRole();
            for (var i = 0; i < 100; i++)
            {
                var ii = new II();
                ii.Root = i.ToString();
                ii.Extension = i.ToString();
                pr.Id.Add(ii);
            }

            TestContext.WriteLine("Count: {0}", pr.Id.Count);

            foreach (var x in pr.Id)
            {
                pr.Id.Delete(x);
            }

            TestContext.WriteLine("Count: {0}", pr.Id.Count);

            for (var i = 0; i < 100; i++)
            {
                var ii = new II();
                ii.Root = i.ToString();
                ii.Extension = i.ToString();
                pr.Id.Add(ii);
            }

            TestContext.WriteLine("Count: {0}", pr.Id.Count);

            pr.Id.Delete(99);
            pr.Id.Delete(50);
            pr.Id.Delete(0);

            TestContext.WriteLine("Count: {0}", pr.Id.Count);
        }

        [TestMethod]
        public void TestCCD()
        {
            var ccd = new CCDClinicalDocument();
            Assert.IsNotNull(ccd.Payers);
            Assert.IsNotNull(ccd.FunctionalStatus);
            Assert.IsNotNull(ccd.AdvanceDirectives);
            TestContext.WriteLine(ccd.Xml);
        }

        [TestMethod]
        public void TestTraverser()
        {
        }

        private IClinicalDocument CreateDocument()
        {
            var cd = new ClinicalDocument();
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("HL7SDK.Test.SampleCDADocument.xml");
            stream.Position = 0;
            cd.Load(stream);
            cd.Lazy = false;
            stream.Close();
            return cd;
        }

        [TestMethod]
        public void TestSelect()
        {
            var doc = CreateDocument();
            foreach (Section section in doc.Select(row => row is Section))
            {
                var parent = section.Parent;
                TestContext.WriteLine("{0} : {1}", parent, section.Title.Text);
            }
        }

        [TestMethod]
        public void TestSelect2()
        {
            var doc = CreateDocument();
            foreach (Object item in doc.Select(row => true))
            {
                TestContext.WriteLine("{0}", item);
            }
        }
    }
}
