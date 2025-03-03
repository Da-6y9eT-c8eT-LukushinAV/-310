using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            int[] array = { 5, 3, 8, 6, 2, 7, 4, 1 };

            Console.WriteLine("Исходный массив:");
            Console.WriteLine(SortingAlgorithms.PrintArray(array));

            int[] combSorted = SortingAlgorithms.CombSort((int[])array.Clone());
            Console.WriteLine("Отсортировано методом расческой:");
            Console.WriteLine(SortingAlgorithms.PrintArray(combSorted));

            int[] shellSorted = SortingAlgorithms.ShellSort((int[])array.Clone());
            Console.WriteLine("Отсортировано методом Шелла:");
            Console.WriteLine(SortingAlgorithms.PrintArray(shellSorted));

            int[] bubbleSorted = SortingAlgorithms.BubbleSort((int[])array.Clone());
            Console.WriteLine("Отсортировано пузырьковой сортировкой:");
            Console.WriteLine(SortingAlgorithms.PrintArray(bubbleSorted));

            int target = 6;
            int? found = SortingAlgorithms.SelectId(array, target);
            Console.WriteLine(found.HasValue
                ? $"Элемент {target} найден."
                : $"Элемент {target} не найден.");
        }
    }
}
