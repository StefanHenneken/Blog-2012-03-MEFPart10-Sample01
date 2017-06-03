using System;
using System.Configuration;

namespace Sample01
{
    class AddInSectionValueCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AddInSectionValue();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AddInSectionValue)element).Id;
        }
        protected override string ElementName
        {
            get { return "AddIn"; }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        public AddInSectionValue this[int index]
        {
            get { return base.BaseGet(index) as AddInSectionValue; }
        }
    }
}
