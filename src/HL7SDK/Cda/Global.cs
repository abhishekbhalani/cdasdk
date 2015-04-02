/******************************************************************************
 * 
 * HL7SDK Utils
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HL7SDK.Cda
{
    [ComVisible(true)]
    [Guid("A5D7FD1C-4CFA-49AC-AF3A-E5ACBE71B28F")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IGlobal
    {
        string CreateGuid();
        string NowToString();
        DateTime TSToDate(string ts);
    }

    [ComVisible(true)]
    [Guid("83FC0B45-FF8A-46E4-820F-F774B822B82F")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(HL7SDK.Cda.IGlobal))]
    public class Global : IGlobal
    {
        public string CreateGuid()
        {
            return Guid.NewGuid().ToString("D");
        }

        public string NowToString()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public DateTime TSToDate(string ts)
        {
            var lts = "" + ts;
            DateTime dt = new DateTime(
               Convert.ToInt32(lts.Substring(0, 4)),
               Convert.ToInt32(lts.Substring(4, 2)),
               Convert.ToInt32(lts.Substring(6, 2))
                );
            return dt;
        }
    }
}
