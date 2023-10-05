using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введіть текстовий рядок:");
        string input = Console.ReadLine();

        // Підрахунок кількості слів у тексті
        string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        int wordCount = words.Length;
        Console.WriteLine($"Кількість слів у тексті: {wordCount}");

        // Знаходження слова з найбільшою кількістю голосних літер
        string wordWithMostVowels = FindWordWithMostVowels(words);
        Console.WriteLine($"Слово з найбільшою кількістю голосних літер: {wordWithMostVowels}");

        // Видалення непотрібних пробілів
        string cleanedText = input.Replace("  ", " ");
        Console.WriteLine($"Текст без непотрібних пробілів: {cleanedText}");
    }
    static string FindWordWithMostVowels(string[] words)
    {
        int maxVowelCount = 0;
        string wordWithMostVowels = "";

        foreach (string word in words)
        {
            int vowelCount = CountVowels(word);
            if (vowelCount > maxVowelCount)
            {
                maxVowelCount = vowelCount;
                wordWithMostVowels = word;
            }
        }

        return wordWithMostVowels;
    }

    static int CountVowels(string word)
    {
        string vowels = "aeiouAEIOU";
        int vowelCount = 0;

        foreach (char letter in word)
        {
            if (vowels.Contains(letter))
            {
                vowelCount++;
            }
        }

        return vowelCount;
    }
}