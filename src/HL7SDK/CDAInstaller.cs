using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Runtime.InteropServices;

namespace HL7SDK.Cda
{
    /// <summary>
    /// Provides COM CCW registration and generation of the type library
    /// </summary>
    [RunInstaller(true)]
    public partial class CDAInstaller : System.Configuration.Install.Installer
    {
        public CDAInstaller()
        {
            InitializeComponent();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary stateSaver)
        {
            base.Commit(stateSaver);

            if (this.Context.Parameters.ContainsKey("hl7sdkregasm"))
            {
                if ("1" == this.Context.Parameters["hl7sdkregasm"])
                {
                    RegistrationServices regsrv = new RegistrationServices();

                    if (!regsrv.RegisterAssembly(GetType().Assembly, AssemblyRegistrationFlags.SetCodeBase))
                    {
                        throw new InstallException("Failed to register HL7SDK.dll for COM Interop.");
                    }

                    this.Context.LogMessage("HL7SDK was registered for COM interop.");
                }
            }
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            RegistrationServices regsrv = new RegistrationServices();
            if (!regsrv.UnregisterAssembly(GetType().Assembly))
            {
                throw new InstallException("Failed to unregister HL7SDK.dll for COM Interop.");
            }
            this.Context.LogMessage("HL7SDK COM deregistration was completed.");
        }
    }
}
