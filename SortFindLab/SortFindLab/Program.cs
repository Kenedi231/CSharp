using System;

namespace SortFindLab
{
    public class Common
    {
        private static bool checkDuplicate(int[] numbers, int len, int newEl)
        {
            for (var i = 0; i < len; i++)
            {
                if (numbers[i] == newEl)
                {
                    return true;
                }
            }

            return false;
        }
        public static int[] Init(int length)
        {
            Random rnd = new Random();
            int[] numbers = new int[length];
            int num;
            for (int i = 0; i < length; i++)
            {
                do
                {
                    num = rnd.Next(0, 100);
                } while (checkDuplicate(numbers, i, num));
                numbers[i] = num;
            }

            return numbers;
        }

        public static int[] Copy(int[] numbers, int length)
        {
            int[] newArr = new int[length];
            for (var i = 0; i < length; i++)
            {
                newArr[i] = numbers[i];
            }

            return newArr;
        }

        public static void Display(int[] numbers)
        {
            var length = numbers.Length;
            for (var i = 0; i < length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.Write("\n");
        }

        public static void Swap(int[] numbers, int i, int j)
        {
            var temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }

        public static void DisplayElement(int el)
        {
            if (el == -1)
            {
                Console.WriteLine("Element not found");
            }
            else
            {
                Console.WriteLine($"Element was found: {el}");
            }
        }
}
    public class SortAlgoritm
    {
        public static void BubbleSort(int[] numbers, int length)
        {
            var work = true;
            while (work)
            {
                work = false;
                for (var i = 0; i < length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Common.Swap(numbers, i, i+1);
                        work = true;
                    }
                }
            }
        }
        private static int Partition(int[] numbers, int start, int end)
        {
            int temp;
            int mark = start;
            for (int i = start; i < end; i++)
            {
                if (numbers[i] < numbers[end])
                {
                    temp = numbers[mark];
                    numbers[mark] = numbers[i];
                    numbers[i] = temp;
                    mark++;
                }
            }
            temp = numbers[mark];
            numbers[mark] = numbers[end];
            numbers[end] = temp;
            return mark;
        }

        public static void QuickSort(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pos = Partition(numbers, start, end);
            QuickSort(numbers, start, pos - 1);
            QuickSort(numbers, pos + 1, end);
        }
    }

    public class FindAlgoritm
    {
        public static int LinearSearch(int[] numbers, int el)
        {
            var count = 0;
            var len = numbers.Length;
            var res = -1;
            for (var i = 0; i < len; i++)
            {
                count++;
                if (numbers[i] == el)
                {
                    res = el;
                    break;
                }
            }
            Console.WriteLine($"Count of check: {count}");
            return res;
        }

        private static string DefineDirection(int center, int el)
        {
            if (center >= el)
            {
                return "left";
            }
            return "right";
        }
        public static int BinarySearch(int[] numbers, int el)
        {
            int count = 0;
            var len = numbers.Length;
            var current = len / 2;
            var res = -1;
            string direct = DefineDirection(numbers[current], el);
            bool work = true;
            while (work)
            {
                count++;
                if (numbers[current] == el)
                {
                    res = el;
                    work = false;
                }
                else
                {
                    if (numbers[current] > el && direct == "left")
                    {
                        current--;
                    } 
                    else if (numbers[current] < el && direct == "right")
                    {
                        current++;
                    } 
                    else
                    {
                        work = false;
                    }
                    
                }
            }
            Console.WriteLine($"Count of check: {count}");
            return res;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter count of number: ");
            int len = Convert.ToInt16(Console.ReadLine());
            
            int[] numbers = Common.Init(len);
            int[] twoArr = Common.Copy(numbers, len);
            
            Console.WriteLine("Initial massive: ");
            Common.Display(numbers);
            
            SortAlgoritm.BubbleSort(numbers, len);
            Console.WriteLine("BubbleSort: ");
            Common.Display(numbers);
            
            SortAlgoritm.QuickSort(twoArr, 0, len - 1);
            Console.WriteLine("QuickSort: ");
            Common.Display(twoArr);
            
            Console.Write("Enter number to search: ");
            int num = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("LinearSearch: ");
            var res = FindAlgoritm.LinearSearch(numbers, num);
            Common.DisplayElement(res);
            
            Console.WriteLine("BinarySearch: ");
            var result = FindAlgoritm.BinarySearch(numbers, num);
            Common.DisplayElement(result);
            
            Console.ReadKey();
        }
    }
}