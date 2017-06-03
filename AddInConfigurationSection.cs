using System;
using System.Configuration;

namespace Sample01
{
    class AddInConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("AddIns", IsDefaultCollection = true, IsRequired = true)]
        public AddInSectionValueCollection SectionValues
        {
            get { return (AddInSectionValueCollection)this["AddIns"] ?? new AddInSectionValueCollection(); }
            set { base[""] = value; }
        }
    }
}
