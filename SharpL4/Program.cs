using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace SharpL4
{

    public class Arr
    {

        public int Value;
        private int CurrentIndex = 0;
        public int CurrentSize = 0;
        public int[] arr;
        private int Length;

        public class Owner
        {
            string Id;
            string Name;
            string Company;

            public Owner(string id, string name, string company)
            {
                this.Id = id;
                this.Name = name;
                this.Company = company;
            }


        }

        public class Date
        {
            string Day;
            string Month;
            string Year;

            public Date(string dd, string mm, string yyyy)
            {
                this.Day = dd;
                this.Month = mm;
                this.Year = yyyy;
            }
        }

        public Arr(int Size)
        {
            arr = new int[Size];
            Length = Size;
        }

        public void Add(int a)
        {
            if (CurrentSize < Length - 1)
            {
                arr[CurrentIndex] = a;
                CurrentIndex++;
                CurrentSize++;
            }
            else Console.WriteLine("Превышен размер массива.");
        }

        // Перегружаем оператор false
        public static bool operator false(Arr obj)
        {
            var counter = 0;
            for (int i = 0; i <= obj.Length; i++)
            {
                if (obj.arr[i] < 0)
                {
                    counter++;
                    break;
                }
            }
            if (counter > 0)
                return true;
            else
                return false;
        }

        // перегружаем оператор true
        public static bool operator true(Arr obj)
        {
            var counter = 0;
            for (int i = 0; i <= obj.Length; i++)
            {
                if (obj.arr[i] < 0)
                {
                    counter++;
                    break;
                }
            }
            if (counter > 0)
                return false;
            else
                return true;
        }

        public static explicit operator int(Arr arr)
        {
            return arr.Length;
        }

        // Перегружаем ==
        public static bool operator ==(Arr arr1, Arr arr2)
        {
            if (arr1.Length == arr2.Length)
                return true;
            else return false;
        }

        // Перегружаем !=
        public static bool operator !=(Arr arr1, Arr arr2)
        {
            if (arr1.Length != arr2.Length)
                return true;
            else return false;
        }

        // Перегружаем <
        public static bool operator <(Arr arr1, Arr arr2)
        {
            if (arr1.Length < arr2.Length)
                return true;
            else return false;
        }

        // Перегружаем >
        public static bool operator >(Arr arr1, Arr arr2)
        {
            if (arr1.Length > arr2.Length)
                return true;
            else return false;
        }

        public void RemoveLast()
        {
            if (CurrentSize > 0)
            {
                CurrentSize--;
                CurrentIndex--;
            }
        }

        public void Print(Arr arr1)
        {
            for (int i = 0; i < arr1.CurrentSize; i++)
            {
                Console.WriteLine(arr1.arr[i]);
            }
        }


        public static Arr operator *(Arr arr1, Arr arr2)
        {
            if (arr1.CurrentSize == arr2.CurrentSize)
            {
                Arr arr3 = new Arr(arr1.CurrentSize);
                for (int i = 0; i <= arr1.CurrentSize; i++)
                {
                    arr3.Add(arr1.arr[i] * arr2.arr[i]);
                }
                return arr3;
            }
            else return null;
        }

    }



    public static class StatisticOperation
    {
        public static int Summ(Arr arr1)
        {
            int sum = 0;
            for (int i = 0; i <= arr1.CurrentSize; i++)
            {
                sum += arr1.arr[i];
            }
            return sum;
        }

        public static int Diff(Arr arr1)
        {
            int max = 0, min = 0;
            for (int i = 0; i < arr1.CurrentSize; i++)
            {
                if (max < arr1.arr[i])
                {
                    max = arr1.arr[i];
                }
                else if (min > arr1.arr[i])
                {
                    min = arr1.arr[i];
                }
            }
            return (int)(max - min);
        }

        public static int Count(Arr arr1)
        {
            return arr1.CurrentSize;
        }

        public static void CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            if (counter > 0)
            {
                Console.WriteLine("строка содержит заданный символ");
            }
            else
            {
                Console.WriteLine("строка не содержит заданный символ");
            }
        }

        public static int[] Delete(Arr arr1)
        {
            for (int i = 0; i <= arr1.CurrentSize; i++)
            {
                if (arr1.arr[i] < 0)
                {
                    for (int k = i; k < arr1.CurrentSize; k++)
                    {
                        arr1.arr[k] = arr1.arr[k + 1];
                    }
                }
            }
            return arr1.arr;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var array1 = new Arr(4);
            array1.Add(1);
            array1.Add(5);
            var array2 = new Arr(3);
            array2.Add(3);
            array2.Add(3);
            var array3 = new Arr(2);
            array3 = array2 * array1;
            array3.Print(array3);

            var array4 = new Arr(3);
            array4.Add(3);
            array4.Add(-3);
            if (array4)
            {
                Console.WriteLine("массив содержит отрицательный элемент");
            }
            else
            {
                Console.WriteLine("массив не содержит отрицательных элементов");
            }

            Console.WriteLine((int)array1);

            if (array1 == array2)
            {
                Console.WriteLine("Массивы равны");
            }
            else
            {
                Console.WriteLine("Массивы не равны");
            }

            if (array1 > array2)
            {
                Console.WriteLine("Первый массив больше");
            }
            else
            {
                Console.WriteLine("Второй массив больше");
            }

            Arr.Owner Kolya = new Arr.Owner("1", "Kolya", "BSTU");
            Arr.Date today = new Arr.Date("10", "12", "2020");


            var array5 = new Arr(4);
            array5.Add(17);
            array5.Add(2);
            array5.Add(9);
            Console.WriteLine(StatisticOperation.Summ(array5));
            Console.WriteLine(StatisticOperation.Diff(array5));
            Console.WriteLine(StatisticOperation.Count(array5));
            StatisticOperation.CharCount("коля", 'й');
            var array6 = new Arr(5);
            array6.Add(17);
            array6.Add(-2);
            array6.Add(9);
            array6.Add(3);
            StatisticOperation.Delete(array6);
            array6.Print(array6);
        }
    }
}
