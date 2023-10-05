using System;
using System.Collections.Generic;
using System.Text;

namespace GasCompanyApp
{
    class Program
    {
        public static int MultipleChoice(bool canCancel, Enum userEnum, int spacingPerLine = 18, int optionsPerLine = 2,
    int startX = 1, int startY = 1)
        {
            int currentSelection = 0;
            ConsoleKey key;
            Console.CursorVisible = false;
            int length = Enum.GetValues(userEnum.GetType()).Length;
            do
            {
                Console.Clear();

                for (int i = 0; i < length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(Enum.Parse(userEnum.GetType(), i.ToString()));

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }
        enum ShopMenu
        {
            Obslugovuvanna, Zchutatu, Exit
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Apartment> apartments = new List<Apartment>
                            {
                                new Apartment(101, 3), // квартира №101, 3 проживаючих
                                new Apartment(102, 2),  // квартира №102, 2 проживаючих
                                new Apartment(103, 3), // квартира №101, 3 проживаючих
                                new Apartment(111, 1), // квартира №101, 3 проживаючих
                                new Apartment(112, 2), // квартира №101, 3 проживаючих
                                // Додайте інші квартири за потреби
                            };
            while (true)
            {
                int input = MultipleChoice(true, new ShopMenu());
                switch ((ShopMenu)input)
                {
                    case ShopMenu.Obslugovuvanna:
                        {
                            GasCompanyService.PerformMaintenance(apartments);

                            Console.WriteLine("\nОплата та обслуговування завершено.");
                            break;
                        }
                    case ShopMenu.Zchutatu:
                        {
                            foreach (var apartment in apartments)
                            {
                                Console.Write($"\nВведіть показання лічильника для квартири #{apartment.Number}: ");
                                double gasConsumption = Convert.ToDouble(Console.ReadLine());

                                double payment = apartment.CalculatePayment(gasConsumption);
                                Console.WriteLine($"Плата для квартири #{apartment.Number}: {payment} грн");
                            }
                            break;
                        }
                    case ShopMenu.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

   class Apartment
    {
        public int Number { get; private set; }
        public int Residents { get; private set; }

        public Apartment(int number, int residents)
        {
            Number = number;
            Residents = residents;
        }

        public double CalculatePayment(double gasConsumption)
        {
            // Логіка розрахунку плати за газ (може бути змінена відповідно до вимог)
            const double gasRate = 10; // вартість 1 куб. метра газу в гривнях
            return gasConsumption * gasRate;
        }
    }

    static class GasCompanyService
    {
        public static void PerformMaintenance(List<Apartment> apartments)
        {
            foreach (var apartment in apartments)
            {
                // Логіка обслуговування газових приладів (може бути додана за потреби)
                Console.WriteLine($"\nПроведено обслуговування газових приладів для квартири #{apartment.Number}");
            }
        }
    }
}
