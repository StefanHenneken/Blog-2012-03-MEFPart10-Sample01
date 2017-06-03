using System;
using System.Configuration;

namespace Sample01
{
    class AddInSectionValue : ConfigurationElement
    {
        [ConfigurationProperty("id", DefaultValue = "1", IsRequired = true, IsKey = true)]
        public int Id
        {
            get { return (base["id"] == null) ? (int)0 : (int)base["id"]; }
            set { base["id"] = value; }
        }

        [ConfigurationProperty("contract", IsRequired = true, IsKey = false)]
        public string Contract
        {
            get { return base["contract"] as string; }
            set { base["contract"] = value; }
        }

        [ConfigurationProperty("assemblyName", IsRequired = true, IsKey = false)]
        public string AssemblyName
        {
            get { return base["assemblyName"] as string; }
            set { base["assemblyName"] = value; }
        }

        [ConfigurationProperty("typeName", IsRequired = true, IsKey = false)]
        public string TypeName
        {
            get { return base["typeName"] as string; }
            set { base["typeName"] = value; }
        }
    }
}
