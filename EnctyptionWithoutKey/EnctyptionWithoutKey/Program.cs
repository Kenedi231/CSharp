using System;

namespace EnctyptionWithoutKey
{
    public class Common
    {
        public static string AddedSpace(string str, int pil, int row)
        {
            string res = str;
            int count = pil * row;
            for (var i = str.Length; i < count; i++)
            {
                res += " ";
            }
            
            return res;
        }
        public static int GetRows(string str, int pil)
        {
            int result = 1;
            for (int i = 1; result < str.Length; i++)
            {
                if ((i * pil) >= str.Length)
                {
                    result = i;
                    break;
                }
            }
            
            return result;
        }

        public static void DisplayMatrix(string[,] matrix, int pil, int row)
        {
            Console.WriteLine();
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < pil; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    public class Encryption
    {
        public static string[,] CreateMatrix(string str, int pil, int row)
        {
            string[,] matrix = new string[row, pil];
            int k = 0;
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < pil; j++)
                {
                    matrix[i, j] = new String(str[k], 1);
                    k++;
                }
            }

            return matrix;
        }
        public static void Main(string str, int pil, int row)
        {
            string result = "";
            string[,] Matrix = CreateMatrix(str, pil, row);
            Common.DisplayMatrix(Matrix, pil, row);
            for (var j = 0; j < pil; j++)
            {
                for (var i = 0; i < row; i++)
                {
                    result += Matrix[i, j];
                }
            }
            Console.WriteLine($"Result: {result}");
        }
    }

    public class Decryption
    {
        public static string[,] CreateMatrix(string str, int pil, int row)
        {
            string[,] matrix = new string[row, pil];
            int k = 0;
            for (var j = 0; j < pil; j++)
            {
                for (var i = 0; i < row; i++)
                {
                    matrix[i, j] = new String(str[k], 1);
                    k++;
                }
            }

            return matrix;
        }
        public static void Main(string str, int pil, int row)
        {
            string result = "";
            string[,] Matrix = CreateMatrix(str, pil, row);
            Common.DisplayMatrix(Matrix, pil, row);
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < pil; j++)
                {
                    result += Matrix[i, j];
                }
            }
            
            Console.WriteLine($"Result: {result}");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your string: ");
            string str = Console.ReadLine();
            Console.Write("Enter count of pillars: ");
            int pil = Convert.ToInt16(Console.ReadLine());
            if (pil < 0 && pil >= str.Length)
            {
                Console.WriteLine("Enter the number of columns less than the length of the string!");
                Environment.Exit(0);
            }
            int row = Common.GetRows(str, pil);
            str = Common.AddedSpace(str, pil, row);
            Console.WriteLine("Choose: \n1. Encryption\n2. Decryption");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            if (choice == "1") 
            {
                Encryption.Main(str, pil, row);
            }
            else
            {
                Decryption.Main(str, pil, row);
            }
        }
    }
}