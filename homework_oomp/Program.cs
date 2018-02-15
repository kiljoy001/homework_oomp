using Scrypt;
using System;

namespace homework_oomp
{
    class Program
    {
        private const string Wet = @"#Wet";
        private const string Time = @"#Time";
        private const string Node = @"#Node";

        static void Main(string[] args)
        {
            ScryptEncoder hashstring = new ScryptEncoder();
            string fakeHeader = hashstring.Encode("somerandomstring");
            Console.WriteLine(fakeHeader);
            Console.ReadLine();
        }
    }
}
