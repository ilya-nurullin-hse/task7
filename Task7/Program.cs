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
            Console.WriteLine("Сгенерировать все размещения из N элементов по K без повторений и выписать их в " +
                              "лексикографическом порядке.\n");
            while (true) {

                int N = readInt("Введите N", x => x > 0, "N должно быть больше 0!");
                int K = readInt("Введите K", x => x > 0, "K должно быть больше 0!");


                if (K > N)
                {
                    Console.WriteLine("K не может быть больше чем N!");
                    continue;
                }

                WriteCombination1(K, generateChars(N));
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

        static int readInt(string msg, Func<int, bool> filter, string errFilter)
        {
            int n = 0;
            bool ok = true;

            do
            {
                try
                {
                    Console.Write("{0}: ", msg);
                    n = Int32.Parse(Console.ReadLine());
                    if (!filter(n))
                    {
                        Console.WriteLine(errFilter);
                        ok = false;
                    }
                    else
                        ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число");
                    ok = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Вы ввели слишком большое число");
                    ok = false;
                }
            } while (!ok);
            return n;
        }
    }
}
