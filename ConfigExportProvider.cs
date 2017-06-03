using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Security.Permissions;

namespace Sample01
{
    public class ConfigExportProvider : ExportProvider
    {
        private List<Export> Exports { get; set; }

        public ConfigExportProvider()
        {
            this.Exports = new List<Export>();
            
            AddInConfigurationSection myConfigurationSection = (AddInConfigurationSection)ConfigurationManager.GetSection("AddInSection");
            foreach (AddInSectionValue sectionValue in myConfigurationSection.SectionValues)
            {
                var metadata = new Dictionary<string, object>();
                metadata.Add(CompositionConstants.ExportTypeIdentityMetadataName, sectionValue.Contract);
                var exportDefinition = new ExportDefinition(sectionValue.Contract, metadata);
                string assemblyName = sectionValue.AssemblyName;
                string typeName = sectionValue.TypeName;
                var export = new Export(exportDefinition, () => CreatePart(assemblyName, typeName));
                this.Exports.Add(export);
            }           
        }

        public object CreatePart(string assemblyName, string typeName)
        {
            var info = new AppDomainSetup { ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase };
            var grantSet = new PermissionSet(PermissionState.None);
            grantSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            // soll der Dateizugriff erlaubt sein, so muss die folgende Zeile eingefügt werden
            // grantSet.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
            var appDomain = AppDomain.CreateDomain("AddIn AppDomain",
                                                    AppDomain.CurrentDomain.Evidence,
                                                    info,
                                                    grantSet);
            var instance = appDomain.CreateInstanceAndUnwrap(assemblyName, typeName); 
            return instance;
        }

        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {          
            return this.Exports.Where(x => definition.IsConstraintSatisfiedBy(x.Definition));
        }
    }
}
