using System;
using System.Text;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введіть розмір масиву N: ");
        int N = Convert.ToInt32(Console.ReadLine());
        if (N <= 0)
        {
            Console.WriteLine("Помилка: N повинно бути більше 0.");
            return;
        }
        double[] arr = new double[N];

        // Заповнення масиву користувацькими значеннями
        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < N; i++)
        {
            Console.Write($"Елемент {i + 1}: ");
            arr[i] = Convert.ToDouble(Console.ReadLine());
        }

        Console.Write("Введіть кількість елементів для перестановки M (M < N): ");
        int M = Convert.ToInt32(Console.ReadLine());
        if (M >= N)
        {
            Console.WriteLine("Помилка: M повинно бути менше за N.");
            return;
        }
        else if(M < 0)
        {
            Console.WriteLine("Помилка: M повинно бути більше 0 або дорівнювати йому.");
            return;
        }

        // Знайдемо суму непарних елементів масиву
        double sumOfOddNumbers = 0;
        foreach (double number in arr)
        {
            if (number % 2 != 0)
            {
                sumOfOddNumbers += number;
            }
        }

        // Знайдемо суму елементів між першим і останнім від'ємними елементами
        double sumBetweenNegatives = 0;
        bool foundFirstNegative = false;
        for (int i = 0; i < N; i++)
        {
            if (arr[i] < 0)
            {
                if (foundFirstNegative)
                {
                    break;
                }
                foundFirstNegative = true;
            }
            else if (foundFirstNegative)
            {
                sumBetweenNegatives += arr[i];
            }
        }

        // Переставимо перші M елементів в кінець масиву
        double[] tempArray = new double[M];
        Array.Copy(arr, tempArray, M);
        Array.Copy(arr, M, arr, 0, N - M);
        Array.Copy(tempArray, 0, arr, N - M, M);

        // Виведемо результати
        Console.WriteLine($"Сума непарних елементів масиву: {sumOfOddNumbers}");
        Console.WriteLine($"Сума елементів між першим і останнім від'ємними елементами: {sumBetweenNegatives}");
        Console.WriteLine("Масив після перестановки перших M елементів в кінець:");
        foreach (double number in arr)
        {
            Console.Write(number + " ");
        }
    }
}