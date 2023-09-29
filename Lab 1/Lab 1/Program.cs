using System.Text;

Console.OutputEncoding = Encoding.UTF8;

//Завдання 1

//Console.WriteLine("Введіть значення x:");
//double x = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine("Введіть значення a:");
//double a = Convert.ToDouble(Console.ReadLine());

//double numerator = Math.Pow(x, 3) + 2 * a * x + 3;
//double denominator = Math.Pow((x - 1), 2);
//double firstTerm = numerator / denominator;

//double secondTerm = Math.Cos(Math.Pow(x, 2)) / (a + 2);

//double result = firstTerm + secondTerm;

//Console.WriteLine($"Результат виразу: {result}");

//Завдання 2

//Console.WriteLine("Введіть натуральне число n:");
//int n = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine("Числа, які задовольняють умову:");

//for (int i = 1; i <= n; i++)
//{
//    int square = i * i;
//    string numberStr = i.ToString();
//    string squareStr = square.ToString();
//    //Порівнюємо останні цифри числа і його квадрату
//    if (numberStr.EndsWith(squareStr.Substring(Math.Max(0, squareStr.Length - numberStr.Length))))
//    {
//        Console.WriteLine(i);
//    }
//}

//Завдання 3

//static double H(double a, double b)
//{
//    return (a / (1 + b * b)) + (b / (1 + a * a)) - Math.Pow((a - b), 3);
//}

//Console.WriteLine("Введіть число s:");
//double s = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine("Введіть число t:");
//double t = Convert.ToDouble(Console.ReadLine());

//double h1 = H(s, t);
//double h2 = H(s - t, s * t);
//double h3 = H(s - t, s + t);
//double h4 = H(1.1, 0);

//double result = h1 + Math.Max(Math.Pow(h2, 2), h3) + h4;

//Console.WriteLine($"Результат: {result}");