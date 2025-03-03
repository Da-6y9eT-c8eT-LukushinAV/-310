using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Sorter<T> where T : IComparable<T>
    {
        private T[] _array;
        public int Index { get; private set; }

        public Sorter(T[] array, int index)
        {
            _array = array;
            Index = index;
        }

        private static void Swap(ref T value1, ref T value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }

        private static int GetNextStep(int step) => Math.Max(step * 1000 / 1247, 1);

        public T[] CombSort()
        {
            int step = _array.Length - 1;

            while (step > 1)
            {
                for (int i = 0; i + step < _array.Length; i++)
                {
                    if (_array[i].CompareTo(_array[i + step]) > 0)
                    {
                        Swap(ref _array[i], ref _array[i + step]);
                    }
                }
                step = GetNextStep(step);
            }

            BubbleSort(); // Дополнительное упорядочивание
            return _array;
        }

        public T[] ShellSort()
        {
            int size = _array.Length;
            for (int gap = size / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < size; i++)
                {
                    var temp = _array[i];
                    int j = i;
                    while (j >= gap && _array[j - gap].CompareTo(temp) > 0)
                    {
                        _array[j] = _array[j - gap];
                        j -= gap;
                    }
                    _array[j] = temp;
                }
            }
            return _array;
        }

        private void BubbleSort()
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < _array.Length; i++)
                {
                    if (_array[i - 1].CompareTo(_array[i]) > 0)
                    {
                        Swap(ref _array[i - 1], ref _array[i]);
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        public static string Print(T[] array) => string.Join(" ", array);
    }

    class Program
    {
        static void Main()
        {
            int[] numbers = { 5, 3, 8, 1, 2, 7 };
            Sorter<int> sorter = new Sorter<int>(numbers, 0);

            Console.WriteLine("Original Array: " + Sorter<int>.Print(numbers));

            sorter.CombSort();
            Console.WriteLine("Sorted with CombSort: " + Sorter<int>.Print(numbers));

            sorter.ShellSort();
            Console.WriteLine("Sorted with ShellSort: " + Sorter<int>.Print(numbers));
        }
    }
}