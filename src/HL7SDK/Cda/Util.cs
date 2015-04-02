/******************************************************************************
 * 
 * HL7SDK Utilities (COM visible)
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace HL7SDK.Cda
{
    [ComVisible(true)]
    [Guid("DCA3D417-49CB-4D97-97B1-B4F8C75C4B97")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IUtil
    {
        /// <summary>
        /// Creates new Guid 
        /// </summary>
        /// <param name="format">Specifies how to format the value of the Guid. Default value is 'D'</param>
        /// <returns></returns>
        string CreateGuid(string format = "D");

        /// <summary>
        /// Parses CDA narrative block
        /// </summary>
        /// <param name="html">Well-formed narrative XML</param>
        /// <returns></returns>
        IStrucDocText ParseNarrative(string html);
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(HL7SDK.Cda.IUtil))]
    [Guid("0A0DEB9A-FD79-40FB-BE96-1F6D9193D935")]
    public class Util : IUtil
    {
        public static List<string> DATE_PARSE_STRINGS;
        public static CultureInfo DEFAULT_CULTURE_INFO = null;
        static Util()
        {
            DEFAULT_CULTURE_INFO = CultureInfo.InvariantCulture;
            DATE_PARSE_STRINGS = new List<string>(new[] 
                { 
                    "yyyyMMddHHmmss.f",
                    "yyyyMMddHHmmss.fz",
                    "yyyyMMddHHmmss.fzz",
                    "yyyyMMddHHmmss.fzzz",

                    "yyyyMMddHHmmss.ff",
                    "yyyyMMddHHmmss.ffz",
                    "yyyyMMddHHmmss.ffzz",
                    "yyyyMMddHHmmss.ffzzz",

                    "yyyyMMddHHmmss.fff",
                    "yyyyMMddHHmmss.fffz",
                    "yyyyMMddHHmmss.fffzz",
                    "yyyyMMddHHmmss.fffzzz",

                    "yyyyMMddHHmmss.ffff",
                    "yyyyMMddHHmmss.ffffz",
                    "yyyyMMddHHmmss.ffffzz",
                    "yyyyMMddHHmmss.ffffzzz",

                    "yyyyMMddHHmmss", 
                    "yyyyMMddHHmm",
                    "yyyyMMddHH",
                    "yyyyMMdd",
                    "yyyyMM",
                    "yyyy"
                }
            );
        }

        public Util()
        {

        }

        public string CreateGuid(string format = "D")
        {
            return Guid.NewGuid().ToString(format);
        }

        public IStrucDocText ParseNarrative(string html)
        {
            if (html == null)
                return new StrucDocText();

            var shtml = String.Format("<?xml version='1.0' encoding='utf-16'?><StrucDoc.Text xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>{0}</StrucDoc.Text>", html);

            var ser = new Microsoft.Xml.Serialization.GeneratedAssembly.StrucDocTextSerializer();
            Object t = ser.Deserialize(new System.IO.StringReader(shtml));
            if (t == null)
                return null;
            return new StrucDocText(t as HL7SDK.Xml.Cda.StrucDocText, null);
        }

        internal static string ListToString(List<string> value)
        {
            if (value == null)
                return String.Empty;
            return String.Join("", value.ToArray());
        }

        internal static DateTime? StringToDateTime(string value)
        {
            var sValue = ("" + value).Trim();
            DateTime dt;
            if (DateTime.TryParseExact(sValue, DATE_PARSE_STRINGS.ToArray(), DEFAULT_CULTURE_INFO, DateTimeStyles.AssumeLocal, out dt))
                return dt;
            return null;

        }
        internal static List<string> StringToList(string value)
        {
            return new List<string>(new[] { value });
        }
    }
}
