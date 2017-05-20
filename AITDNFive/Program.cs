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
        }

        public static void WriteAsBytes(int value)
        {
            var bytes = BitConverter.GetBytes(value);

            foreach (var b in bytes)
            {
                Console.Write("0x{0:X2} ", b);
            }
        }
    }
}
