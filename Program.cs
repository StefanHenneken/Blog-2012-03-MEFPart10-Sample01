using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using CarContract;

namespace Sample01
{     
    public class Program
    {
        [ImportMany(typeof(ICarContract))]
        private IEnumerable<Lazy<ICarContract>> CarParts { get; set; }
      
        static void Main(string[] args)
        {
            new Program().Run();
        }

        void Run()
        {
            CompositionContainer container = null;

            var provider = new ConfigExportProvider();
            container = new CompositionContainer(provider);
            container.ComposeParts(this);

            foreach (Lazy<ICarContract> carPart in CarParts)
                carPart.Value.WriteString("Test");

            container.Dispose();
        }
    }
}
