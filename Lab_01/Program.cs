namespace Lab_01;

class Program
{
    private static TMComplex? complex1, complex2;

    private static void Menu()
    {
        Console.WriteLine("1) Увести 1 комплексне число");
        Console.WriteLine("2) Увести 2 комплексне число");
        Console.WriteLine("3) Вивести числа");
        Console.WriteLine("4) Виконати дії над комплексними числами");
        Console.WriteLine("5) Визначення квадранта та відстані від початку координат");
        Console.WriteLine("6) Вихід");

        Console.Write("Введіть номер пункту меню: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Некоректне значення!\n");
            Menu();
            return;
        }

        Console.WriteLine();
        Console.Clear();

        switch (choice)
        {
            case 1: // Введення 1 комплексного числа

                Console.WriteLine("Введіть 1 комплексне число\n");
                complex1 = new();
                complex1.Input();
                Console.Clear();

                break;
            case 2: // Введення 2 комплексного числа

                Console.WriteLine("Введіть 2 комплексне число!\n");
                complex2 = new();
                complex2.Input();
                Console.Clear();

                break;
            case 3: // Виведення комплексних чисел

                if (complex1 == null) // Перевірка чи введене 1 комплексне число
                {
                    Console.WriteLine("1 комплексне число не введено!");
                }
                else // Виведення 1 комплексного числа
                {
                    Console.WriteLine($"1 комплексне число: {complex1}");
                }

                if (complex2 == null) // Перевірка чи введене 2 комплексне число
                {
                    Console.WriteLine("2 комплексне число не введено!");
                }
                else // Виведення 2 комплексного числа
                {
                    Console.WriteLine($"2 комплексне число: {complex2}");
                }

                Console.WriteLine();

                break;
            case 4: // Виконання дій над комплексними числами

                if (complex1 == null) // Перевірка чи введене 1 комплексне число
                {
                    Console.WriteLine("1 комплексне число не введено!");
                }
                else if (complex2 == null) // Перевірка чи введене 2 комплексне число
                {
                    Console.WriteLine("2 комплексне число не введено!\n");
                }
                else // Виконання дій над комплексними числами
                {
                    Console.WriteLine($"1 комплексне число: {complex1}");
                    Console.WriteLine($"2 комплексне число: {complex2}\n");

                    Console.WriteLine($"Сума: {complex1 + complex2}");
                    Console.WriteLine($"Різниця: {complex1 - complex2}");
                    Console.WriteLine($"Добуток: {complex1 * complex2}");

                    try // Перевірка чи можна виконати ділення
                    {
                        Console.WriteLine($"Частка: {complex1 / complex2}\n");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Ділення на 0!\n");
                    }
                }

                break;
            case 5: // Визначення квадранта та відстані від початку координат

                if (complex1 == null) // Перевірка чи введене 1 комплексне число
                {
                    Console.WriteLine("1 комплексне число не введено!\n");
                }
                else // Визначення квадранта та відстані від початку координат 1 комплексного числа
                {
                    Console.WriteLine($"1 комплексне число: {complex1}");
                    Console.WriteLine($"Розташування: {changeQuadrantRepresentation(complex1.GetQuadrant())}");
                    Console.WriteLine($"Відстань від початку координат: {Math.Round(complex1.GetModulus(), 2)}\n");
                }

                if (complex2 == null) // Перевірка чи введене 2 комплексне число
                {
                    Console.WriteLine("2 комплексне число не введено!\n");
                }
                else // Визначення квадранта та відстані від початку координат 2 комплексного числа
                {
                    Console.WriteLine($"2 комплексне число: {complex2}");
                    Console.WriteLine($"Розташування: {changeQuadrantRepresentation(complex2.GetQuadrant())}");
                    Console.WriteLine($"Відстань від початку координат: {Math.Round(complex2.GetModulus(), 2)}\n");
                }

                break;
            case 6: // Вихід з програми
                Console.WriteLine("Вихід!\n");
                return;
            default:
                Console.WriteLine("Невірний номер пункту меню\n");
                break;
        }
        Menu();
    }

    private static string changeQuadrantRepresentation(int quadrant)
    {
        switch (quadrant)
        {
            case 1:
                return "I квадрант";
            case 2:
                return "II квадрант";
            case 3:
                return "III квадрант";
            case 4:
                return "IV квадрант";
            case 5:
                return "Точка на осі X (між I та IV квадрантами)";
            case 6:
                return "Точка на осі Y (між I та II квадрантами)";
            case 7:
                return "Точка на осі X (між II та III квадрантами)";
            case 8:
                return "Точка на осі Y (між III та IV квадрантами)";
            case 0:
                return "Точка на початку координат";
            default:
                return quadrant.ToString();
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "Лабораторна робота №1";
        Menu();
    }
}
