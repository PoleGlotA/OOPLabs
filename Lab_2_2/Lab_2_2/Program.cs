using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введіть кількість рядків матриці: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введіть кількість стовпців матриці: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        // Заповнення матриці користувацькими значеннями
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Елемент [{i + 1},{j + 1}]: ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Знаходимо добуток елементів в рядках, які не містять від'ємних елементів
        int productOfRowsWithoutNegatives = 1;
        for (int i = 0; i < rows; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                for (int j = 0; j < cols; j++)
                {
                    productOfRowsWithoutNegatives *= matrix[i, j];
                }
            }
        }

        // Знаходимо максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці
        int maxSumOfDiagonalElements = int.MinValue;
        for (int i = 0; i < cols; i++)
        {
            int sumDiagonal = 0;
            for (int j = 0; j < rows && i + j < cols; j++)
            {
                sumDiagonal += matrix[j, i + j];
            }
            if (sumDiagonal > maxSumOfDiagonalElements)
            {
                maxSumOfDiagonalElements = sumDiagonal;
            }
        }

        // Виводимо результати
        Console.WriteLine($"Добуток елементів в рядках без від'ємних елементів: {productOfRowsWithoutNegatives}");
        Console.WriteLine($"Максимум серед сум елементів діагоналей, паралельних головній діагоналі: {maxSumOfDiagonalElements}");
    }
}