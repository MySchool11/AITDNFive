using System;
using System.Security.Claims;

namespace AITDNFive
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteAsBytes(1000);                                 // Calls the WriteAsBytes() method passing in the integer 1000

            Console.WriteLine("Press any key to exit...");      // These two lines diplay a message and await a keypress to end the program
            Console.ReadKey();
        }

        public static void WriteAsBytes(int value)              // Declares a method of type void (does not return anything) which is public (accessible by any code), static (does not need instantiation with the new keyword) and expects an integer passed to it
        {
            var bytes = BitConverter.GetBytes(value);           // Creates a bytes[] array and initialises it with the bytes making up the passed numer via the BitConverter.GetBytes() method

            Console.Write("original number: {0}\n", value);     // Writes out the original number to the console
            Console.Write("number as hex (bytes): ");           // Writes out a statement ready to show the converted numbers
            foreach (var b in bytes)                            // Iterates through the bytes[] array and outputs each value held
            {           
                Console.Write("0x{0:X2} ", b);                  // Writes out to the console the current array value (b) to two places (X2)
            }
            Console.Write("\n");                                // Writes a new line after the output from the array
        }
    }
}
