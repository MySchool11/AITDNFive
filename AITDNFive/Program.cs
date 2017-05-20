using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITDNFive
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteAsBytes(1000);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void WriteAsBytes(int value)
        {
            var bytes = BitConverter.GetBytes(value);

            Console.Write("original number: {0}\n", value);
            Console.Write("number as hex (bytes): ");
            foreach (var b in bytes)
            {           
                Console.Write("0x{0:X2} ", b);
            }
            Console.Write("\n");
        }
    }
}
