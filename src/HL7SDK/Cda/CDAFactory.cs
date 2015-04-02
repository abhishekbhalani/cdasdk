/******************************************************************************
 * 
 * HL7SDK Factory class definition for interop
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
    [Guid("3695B267-E65A-449F-A63A-473524DBD7EB")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public partial interface IFactory
    {
    }

    [ComVisible(true)]
    [Guid("2C880CB3-B871-4E7D-BA01-71C956B4D7DF")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(HL7SDK.Cda.IFactory))]
    public partial class Factory : IFactory
    {
    }
}
