using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                try
                {
                    Console.Write("Введите N: ");
                    int N = int.Parse(Console.ReadLine());

                    if (N < 1)
                    {
                        Console.WriteLine("N должно быть больше 0!");
                        continue;
                    }

                    Console.Write("Введите K: ");
                    int K = int.Parse(Console.ReadLine());

                    if (K < 1)
                    {
                        Console.WriteLine("K должно быть больше 0!");
                        continue;
                    }
                    if (K > N)
                    {
                        Console.WriteLine("K не может быть больше чем N!");
                        continue;
                    }

                    WriteCombination1(K, generateChars(N));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ожидалось натуральное число");
                }
            }
        }

        static void WriteCombination1(int K, List<char> chars, string prefix = "")
        {
            if (prefix.Length == K - 1)
                foreach (char c in chars)
                    Console.WriteLine(prefix + c);
            else
                for (var i = 0; i < chars.Count; i++)
                {
                    var newList = new List<char>(chars);
                    newList.RemoveAt(i);
                    WriteCombination1(K, newList, prefix + chars[i]);
                }
        }

        static List<char> generateChars(int count)
        {
            var temp = new List<char>();
            for (int i = 0; i < count; i++)
            {
                temp.Add((char)(i+65));
            }
            return temp;
        }
    }
}
