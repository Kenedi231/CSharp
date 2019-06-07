using System;

namespace EncryptionByKey
{
    public class Common
    {
        private static string alphabeth = "abcdefghijklmnopqrstuvwxyz";

        private static int[] getPos(string key)
        {
            int[] pos = new int[key.Length];
            int[] result = new int[key.Length];
            int Min;
            int indexMin;
            for (var i = 0; i < key.Length; i++)
            {
                for (var j = 0; j < alphabeth.Length; j++)
                {
                    if (alphabeth[j] == key[i])
                    {
                        pos[i] = j;
                    }
                    
                }
            }

            for (var i = 0; i < pos.Length; i++)
            {
                Min = 200;
                indexMin = -1;
                for (var j = 0; j < pos.Length; j++)
                {
                    if (Min > pos[j])
                    {
                        indexMin = j;
                        Min = pos[j];
                    }
                }
                result[indexMin] = i + 1;
                pos[indexMin] = 1000;
            }
            
            return result;
        }
        public static string getKey(string NameKey)
        {
            if (NameKey[0] >= '0' && NameKey[0] <= '9')
            {
                return NameKey;
            }
            string result = "";
            int[] pos = getPos(NameKey);
            for (var i = 0; i < pos.Length; i++)
            {
                result += Convert.ToString(pos[i]);
            }
            return result;
        }
        public static string AddedSpace(string str, string key)
        {
            string result = str;
            var lenStr = str.Length;
            var lenKey = key.Length;
            while (lenKey < lenStr)
            {
                lenKey += lenKey;
            }

            for (var i = lenStr; i < lenKey; i++)
            {
                result += " ";
            }
            
            return result;
        }

        public static bool CheckDuplicate(string key)
        {
            for (var i = 0; i < key.Length; i++)
            {
                for (var j = 0; j < key.Length; j++)
                {
                    if (key[i] >= '0' && key[i] <= '9')
                    {
                        if (j != i)
                        {
                            if (key[i] == key[j])
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CheckDuplicateChar(string key)
        {
            if (key.Length == 0)
            {
                return true;
            }
            if (key[0] >= 'a' && key[0] <= 'z')
            {
                for (var i = 0; i < key.Length; i++)
                {
                    for (var j = 0; j < key.Length; j++)
                    {
                        if (key[j] >= 'a' && key[j] <= 'z')
                        {
                            if (i != j && key[i] == key[j])
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
    public class Encryption
    {
        public static string Main(string str, string key)
        {
            string result = "";
            int len = str.Length / key.Length;
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < key.Length; j++)
                {
                    result += str[(Convert.ToInt16(new String(key[j], 1)) - 1) + (i * 3)];
                }
            }
            Console.WriteLine("Encryption...");
            Console.WriteLine($"{result}");
            return result;
        }
    }

    public class Decryption
    {
        public static string Main(string str, string key)
        {
            string result = "";
            int len = str.Length / key.Length;
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < key.Length; j++)
                {
                    result += str[(Convert.ToInt16(new String(key[j], 1)) - 1) + (i * 3)];
                }
            }
            Console.WriteLine("Decryption...");
            Console.WriteLine($"{result}");

            return result;
        }
        
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your string: ");
            string str = Console.ReadLine();
            Console.Write("Enter key: ");
            string key = Console.ReadLine();
            if (Common.CheckDuplicateChar(key))
            {
                Console.WriteLine("Enter valid key!");
                Environment.Exit(0);
            }
            key = Common.getKey(key);
            if (Common.CheckDuplicate(key))
            {
                Console.WriteLine("Enter valid key!");
                Environment.Exit(0);
            }
            str = Common.AddedSpace(str, key);
            Console.Write("Choose algoritm: \n1. Encryption\n2. Decryption\nEnter your choice: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                string enc = Encryption.Main(str, key);   
            }
            else
            {
                string dec = Decryption.Main(str, key);
            }
        }
    }
}