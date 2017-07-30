using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base64encode
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckEncDec();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        private static void CheckEncDec()
        {
            char EncDecResponse;

            Console.Write("Hit e for encode or d for decode Base64: ");
            EncDecResponse = Console.ReadKey().KeyChar;

            if (EncDecResponse == 'e')
            {
                Encode();
            }
            else if (EncDecResponse == 'd')
            {
                try
                {
                    Decode();
                }
                catch (Exception)
                {

                    Console.WriteLine();
                    Console.WriteLine("No valid Base64 text entered!");
                    Console.WriteLine();

                    CheckEncDec();
                }
            }
            else
            {
                Console.WriteLine();
                CheckEncDec();
            }
        }

        private static void Encode()
        {
            string UTF8text, Base64text;

            Console.WriteLine();
            Console.Write("Enter UTF8 text: ");
            UTF8text = Console.ReadLine();

            Base64text = Base64Encode(UTF8text);
            Console.WriteLine();
            Console.WriteLine("Base64 encoded string: {0}", Base64text);
        }

        private static void Decode()
        {
            string UTF8text, Base64text;

            Console.WriteLine();
            Console.Write("Enter Base64 text: ");
            Base64text = Console.ReadLine();

            UTF8text = Base64Decode(Base64text);
            Console.WriteLine();
            Console.WriteLine("UTF8 decoded text: {0}", UTF8text);
        }

        //Encode
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //Decode
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
