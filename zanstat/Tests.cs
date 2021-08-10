using System;
using System.Text;

namespace Zanstat
{
    public static class Tests
    {
        private static void PrintArray(byte[] input)
        {
            var startIndex = 0;
            while (startIndex < input.Length)
            {
                // Draw bytes.
                int count = 0;
                for (var i = 0; i < 24; i++)
                {
                    var index = startIndex + i;
                    if (index < input.Length)
                    {
                        Console.Write(input[index].ToString("X2"));
                        Console.Write(" ");
                        count++;
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }

                Console.Write("  ");

                // Draw ascii.
                for (var i = 0; i < count; i++)
                {
                    var index = startIndex + i;
                    var c = Convert.ToChar(input[index]);
                    if (char.IsControl(c))
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }

                startIndex += count;
                Console.WriteLine();
            }
        }

        private static void PrintMessage(byte[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                Console.Write(Convert.ToChar(input[i]));
            }
        }

        private static void DoTest(string message)
        {
            var bytes = Encoding.ASCII.GetBytes(message);

            var compressed = Zanlib.Huffman.Encode(bytes);
            Console.WriteLine($"Compressed data (length is {compressed.Length}):");
            PrintArray(compressed);
            Console.WriteLine();

            var uncompressed = Zanlib.Huffman.Decode(compressed);
            Console.WriteLine($"Uncompressed data (length is {uncompressed.Length}):");
            PrintMessage(uncompressed);
            Console.WriteLine("\n\n");
        }

        public static void TestUncompressed()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("TestUncompressed");
            Console.WriteLine("----------------\n");

            var message = "Hello, World!";
            DoTest(message);
        }

        public static void TestCompressed()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("TestCompressed");
            Console.WriteLine("--------------\n");

            var message = "";
            for (var i = 0; i < 100; i++)
                message += "Hello, World! ";
            DoTest(message);
        }
    }
}
