using System;
using System.Linq;

namespace ConsoleApp1
{
    public class SortingAlgorithms
    {
        private int[] _array;
        public int Index { get; private set; }

        private SortingAlgorithms() { }

        private SortingAlgorithms(int[] array, int index)
        {
            _array = array;
            Index = index;
        }

        private static void Swap(ref int value1, ref int value2)
        {
            (value1, value2) = (value2, value1);
        }

        private static int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }

        public static int[] CombSort(int[] array)
        {
            int length = array.Length;
            int step = length - 1;

            while (step > 1)
            {
                for (int i = 0; i + step < length; i++)
                {
                    if (array[i] > array[i + step])
                    {
                        Swap(ref array[i], ref array[i + step]);
                    }
                }
                step = GetNextStep(step);
            }

            for (int i = 1; i < length; i++)
            {
                bool swapped = false;
                for (int j = 0; j < length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
            return array;
        }

        public static int? SelectId(int[] array, int target)
        {
            return array.Contains(target) ? target : (int?)null;
        }

        public static int[] ShellSort(int[] array)
        {
            int size = array.Length;
            for (int gap = size / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < size; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
            return array;
        }

        public static int[] BubbleSort(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
            return array;
        }

        public static string PrintArray(int[] array)
        {
            return string.Join(" ", array);
        }
    }
}
