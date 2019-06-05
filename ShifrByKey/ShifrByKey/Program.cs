using System;

namespace ShifrByKey
{
    public class Transposition
    {
        private int[] key = null;

        public void SetKey(int[] _key)
        {
            key = new int[_key.Length];

            for (int i = 0; i < _key.Length; i++)
                key[i] = _key[i];
        }

        public void SetKey(string[] _key)
        {
            key = new int[_key.Length];

            for (int i = 0; i < _key.Length; i++)
                key[i] = Convert.ToInt32(_key[i]);
        }

        public void SetKey(string _key)
        {
            SetKey(_key.Split(' '));
        }

        public string Encrypt(string input)
        {
            for (int i = 0; i < input.Length % key.Length; i++)
                input += input[i];

            string result = "";

            for (int i = 0; i < input.Length; i += key.Length)
            {
                char[] transposition = new char[key.Length];

                for (int j = 0; j < key.Length; j++)
                    transposition[key[j] - 1] = input[i + j];

                for (int j = 0; j < key.Length; j++)
                    result += transposition[j];
            }

            return result;
        }

        public string Decrypt(string input)
        {
            string result = "";

            for (int i = 0; i < input.Length; i += key.Length)
            {
                char[] transposition = new char[key.Length];

                for (int j = 0; j < key.Length; j++)
                    transposition[j] = input[i + key[j] - 1];

                for (int j = 0; j < key.Length; j++)
                    result += transposition[j];
            }

            return result;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Transposition t;
            t = new Transposition();
            Console.WriteLine("Введите исходный текст");
            String b = Console.ReadLine();
            Console.WriteLine("Введите ключ шифрования (каждую цифру через пробел)");
            String a = Console.ReadLine();
            t.SetKey(a);
            String f = t.Encrypt(b);
            Console.WriteLine(f);
            Console.WriteLine("Хотите расшифровать это говно? (Yes/No)");
            String g = Console.ReadLine().ToLower();
            String l;
            if (g == "yes")
            {
                l = t.Decrypt(f);
                Console.WriteLine(l);
            }
            Console.ReadLine();
        }
    }
}