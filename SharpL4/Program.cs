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
        int[] arr;
        private int Length;

        public Arr(int Size)
        {
            arr = new int[Size];
            Length = Size;
        }

        public void Add(int a)
        {
            if (CurrentSize < Length-1)
            {
                arr[CurrentIndex] = a;
                CurrentIndex++;
                CurrentSize++;
                Console.WriteLine("Элемент добавлен.");
            }
            else Console.WriteLine("Превышен размер массива.");
        }

        // Перегружаем оператор false
        public static bool operator false(Arr obj)
        {
            var counter = 0;
            for (int i =0; i <= obj.Length; i++)
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

        // Обязательно перегружаем оператор true
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
            for (int i=0;i< arr1.CurrentSize;i++)
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


        }

    }
}
