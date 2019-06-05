using System;

namespace NumberSystems
{
    public class Common
    {
        public static string Alphabet = "abcdefghijklmnopqrstuvwxyz"; 
        public static int GetNumber(char ch)
        {
            var number = 10;
            foreach (var el in Alphabet)
            {
                if (el == ch)
                {
                    return number;
                }

                number++;
            }

            return -1;
        }
        public static bool CheckInput(string input, int nsi)
        {
            foreach (var el in input)
            {
                if (el >= '0' && el <= '9')
                {
                    var num = Convert.ToInt16(new String(el, 1));
                    if (num >= nsi)
                    {
                        return true;
                    }
                }
                else
                {
                    var num = Common.GetNumber(el);
                    if (num == -1 || num >= nsi)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public class ConvertNumberSystems
    {
        private static int CharSystem(char ch)
        {
            foreach (var el in Common.Alphabet)
            {
                if (el == ch)
                {
                    return Common.GetNumber(ch);
                }
            }

            return 10;
        }

        private static char IntToChar(double num)
        {
            var number = Convert.ToInt16(num - 10);
            return Common.Alphabet[number];
        }
        private static int CharToDec(char ch)
        {
            var num = 10;
            if (ch >= '0' && ch <= '9')
            {
                num = Convert.ToInt16(new String(ch, 1));
            }
            else
            {
                num = CharSystem(ch);
            }

            return num;
        }
        public static double ToDec(string input, int system)
        {
            double result = 0;
            var degree = input.Length - 1;
            foreach (var element in input)
            {
                var num = CharToDec(element);
                result += num * Math.Pow(system, degree);
                degree--;
            }
            return result;
        }

        private static string Invert(string str)
        {
            var result = str.ToCharArray();
            Array.Reverse(result);
            return new String(result);
        }

        public static string ConvertDecToAnother(double decNumber, int system)
        {
            int number = Convert.ToInt16(decNumber);
            bool work = true;
            var ns = system;
            string result = "";
            while (work)
            {
                if (number < ns)
                {
                    work = false;
                }
                var waste = number % ns;
                if (waste >= 0 && waste <= 9)
                {
                    result += Convert.ToString(waste);
                }
                else
                {
                    result += IntToChar(waste);
                }
                number = number / ns;
            }
            
            return Invert(result);
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter input number of systems: ");
            int nsi = Convert.ToInt16(Console.ReadLine());
            if (nsi > 36)
            {
                Console.WriteLine("This number of systems is not supported!");
                return;
            }
            Console.Write("Enter number: ");
            double decNumber;
            string number = Console.ReadLine().ToLower();
            if (Common.CheckInput(number, nsi))
            {
                Console.WriteLine("Enter valid number!");
                return;
            }
            if (nsi != 10)
            {
                decNumber = ConvertNumberSystems.ToDec(number, nsi);
            }
            else
            {
                decNumber = Convert.ToDouble(number);
            }
            Console.Write("Enter output number of systems: ");
            int nso = Convert.ToInt16(Console.ReadLine());
            if (nso > 36)
            {
                Console.WriteLine("This number of systems is not supported!");
                return;
            }

            string result = ConvertNumberSystems.ConvertDecToAnother(decNumber, nso);
            Console.WriteLine($"{result.ToUpper()}");
        }
    }
}