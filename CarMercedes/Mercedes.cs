using System;
using System.IO;
using CarContract;

namespace Sample01
{
    public class Mercedes : MarshalByRefObject, ICarContract
    {
        public void WriteString(string name)
        {
            try
            {
                Console.WriteLine("\nMercedes: WriteString()");
                File.WriteAllText(@"C:\Test.txt", name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
