using System;
using System.IO;
using CarContract;

namespace Sample01
{
    public class BMW : MarshalByRefObject, ICarContract
    {
        public void WriteString(string name)
        {
            try
            {
                Console.WriteLine("\nBMW: WriteString()");
                File.WriteAllText(@"C:\Test.txt", name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
