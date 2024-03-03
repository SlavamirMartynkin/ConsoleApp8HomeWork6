using System.Linq;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.
            // Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.
            // {}  Console.WriteLine($"{a} + {b} + {c} = {target}");
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int target = 16;

            NumberSearch1(arr, target);
            Console.WriteLine("--------------------");
            NumberSearch2(arr, target);
            Console.WriteLine("--------------------");
            NumberSearch3(arr, target);
        }
        
        public static void NumberSearch1(int[] array, int target) // самый затратный по времени
        {            
            HashSet<List<int>> set = new HashSet<List<int>>();

            for (int i = 0; i < array.Length; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    for(int k = j + 1; k < array.Length; k++)
                    {
                        if(i == j || i == k || j == k) continue;

                        if (array[i] + array[j] + array[k] == target)
                        {                            
                            Console.WriteLine($"{array[i]} + {array[j]} + {array[k]} = {target}");
                        }
                    }
                }
            }
        }
        public static void NumberSearch2(int[] array, int target) //самый затратный по памяти
        {
            // a + b + c = target
            HashSet<int> set = new HashSet<int>();

            for(int i = 0; i < array.Length; i++)
            {
                set.Clear();
                int aAndb = target - array[i]; // a + b = target - c
                int  c = array[i];

                for(int j = i + 1; j < array.Length; j++)
                {
                    int b = aAndb - array[j];
                    int a = array[j];
                    if (set.Contains(b))
                    {
                        Console.WriteLine($"{a} + {b} + {c} = {target}");
                    }
                    set.Add(array[j]);
                }
            }
        }
        public static void NumberSearch3(int[] array, int target) // по времени такой же как и NumberSearch2, но памяти должен требовать поменьше
        {
            Array.Sort(array);
           
            for (int i = 0; i < array.Length; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;

                while (left < right)
                {
                    int summ = array[i] + array[left] + array[right];
                    if (target == summ)
                    {
                        Console.WriteLine($"{array[i]} + {array[left]} + {array[right]} = {target}");
                        left++;
                    }
                    else if (summ < target)
                    {                        
                        left++;                        
                    }
                    else
                    {                        
                        right--;                        
                    }
                }
            }
        }
    }
}
