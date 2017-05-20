using System;
using System.Text;
using System.Threading;

namespace AITDNFive
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteAsBytes(1000);                                 // Calls the WriteAsBytes() method passing in the integer 1000
            WriteAsBytes("string");                             // Calls the overloaded WriteAsBytes() method passing in the string "string"
            WriteAsBytes(32.56f);                               // Calls the overloaded WriteAsBytes() method passing in the floating point number 32.56

            Console.WriteLine("Press a key to continue...");    // Pause before next operation which will remove these results from the readable area of the console.
            Console.ReadKey();
            Console.Write("\n");                                // Create a newline after the key press to prevent next line being indented by one space (the keypress).

            // Methods also help with the DRY principle (Do not Repeat Yourself) by allowing an easy way to run the same code over and over again without rewriting it every time.
            // The opposite of DRY is WET (Write Everything Twice). Imagine how much code would be needed for the next five lines of code without methods.

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Iteration " + (i + 1) + " = ");
                WriteAsBytes((i * 100) + 6);
                Thread.Sleep(400);                              // Create a 400 millisecond delay between iterations to make it easier to follow on console output.
            }

            // The answer is 10 x 11 or 110 lines. So would you rather write 110 lines or 5? No brainer, huh?

            Console.Write("\n");                                // Put a space between the last output of the loop and the next line of text for readability.

            var answer = WriteAsBytesReturn(0xba);
            Console.WriteLine("answer contains: 0x{0:X2} ", answer);

            // This method is fairly pointless as it does not achieve much, it passes a byte to a method that reads the byte, adds it to itself, and returns it.
            // It is purely for demonstrative purposes only as this could be achieved with a single line of code and does not really warrant an entire function.

            Console.WriteLine("Press any key to exit...");      // These two lines diplay a message and await a keypress to end the program
            Console.ReadKey();
        }

        /*
         * Every method has four key elements;
         * 1) An access modifier: This determines the scope of the variable (which code can access it)
         * 2) A return type: Every method returns a type even if that is void (a fancy way of saying nothing)
         * 3) Zero or more parameters: Every method must be marked as not taking a parameter, Method(), or list the paramaters it takes, Method(int something, string somethingElse)
         * 4) A signature: Each method generates a signature and this comprises everything after the return type. This aids overloading (having multiple method with the same name that take differing parameters) for example;
         * public static void InputANewCustomer(int age) --> signature is       "InputANewCustomer(int age)"
         * public static void InputANewCustomer(int age, string name) --> signature is      "InputANewCustomer(int age, string name)"
         * public static void InputANewCustomer(string name) --> signature is       "InputANewCustomer(string name)"
         * Lastly the "ref" and "out" qualifiers are included in the signature so MyFunction(int), MyFunction(ref int) and MyFunction(out int) are all different signatures
         */

        public static void WriteAsBytes(int value)              // Declares a method of type void (does not return anything) which is public (accessible by any code), static (does not need instantiation with the new keyword) and expects an integer passed to it
        {
            var bytes = BitConverter.GetBytes(value);           // Creates a bytes[] array and initialises it with the bytes making up the passed numer via the BitConverter.GetBytes() method

            Console.Write("original number: {0}\n", value);     // Writes out the original number to the console
            Console.Write("number as hex (bytes): ");           // Writes out a statement ready to show the converted numbers
            foreach (var b in bytes)                            // Iterates through the bytes[] array and outputs each value held
            {           
                Console.Write("0x{0:X2} ", b);                  // Writes out to the console the current array value (b) to hexidecimal (X) with two places (2)
            }
            Console.Write("\n");                                // Writes a new line after the output from the array
        }

        public static void WriteAsBytes(string value)           // Overloaded method WriteAsBytes that takes a string instead of an integer
        {
            var bytes = Encoding.ASCII.GetBytes(value);         // BitConverter.GetBytes() handles numerical values to Encoding.ASCII.GetBytes() must be used for a string instead

            Console.Write("original string: {0}\n", value);     // The next six lines do exactly the same as the integer accepting version of the method
            Console.Write("string as hex (bytes): ");
            foreach (var b in bytes)
            {
                Console.Write("0x{0:X2} ", b);
            }
            Console.Write("\n");
        }

        public static void WriteAsBytes(float value)
        {
            var bytes = BitConverter.GetBytes(value);           // Can use the BitConverter.GetBytes() method here as it accepts number of all type (except decimal)

            Console.Write("original string: {0}\n", value);     // The next six lines do exactly the same as the integer accepting version of the method
            Console.Write("string as hex (bytes): ");
            foreach (var b in bytes)
            {
                Console.Write("0x{0:X2} ", b);
            }
            Console.Write("\n");
        }

        // Because the signature of a method does not include the return type, if we want a method that returns the value, we need to write a new function with a differing signature
        // public static byte[] WriteAsBytes(byte value)        WILL NOT compile, so

        public static byte WriteAsBytesReturn(byte value)       // To use this method we will have to pass the result into a variable of the type byte, as this is what it returns
        {
            var bytes = BitConverter.GetBytes(value);
            byte byteTotal = 0x00;

            foreach (var b in bytes)
            {
                byteTotal += b;
            }

            byteTotal += bytes[0];
            return byteTotal;
        }
    }
}
