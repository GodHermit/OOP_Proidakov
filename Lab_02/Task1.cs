namespace Lab_02;

public class Task1
{
	private static void PrintError(string errorMessage, Action? callback = null)
	{
		Console.Clear();
		Console.WriteLine($"{errorMessage}\n");
		callback?.Invoke();
	}

	private static void PrintArray(double[] array)
	{
		for (int i = 0; i < array.Length; i++) // Проходимо по масиву
		{
			Console.Write($"{array[i]}"); // Виводимо число
			if (i != array.Length - 1) // Якщо не останнє число
			{
				Console.Write(", "); // Виводимо кому
			}
		}
		Console.WriteLine("\n");
	}

	private static void InputNumbers(out double[] numbers, out int n, Action? callback = null)
	{
		Console.Write("Уведіть кількість чисел: ");

		if (!int.TryParse(Console.ReadLine(), out n) || n <= 0) // Якщо введено не число
		{
			PrintError("Уведіть число!", callback);
		}

		// Генерувати числа чи вводити вручну?
		Console.WriteLine("\n1) Ввести вручну");
		Console.WriteLine("2) Згенерувати випадково\n");

		Console.Write("Уведіть номер пункту: ");

		if (!int.TryParse(Console.ReadLine(), out int generateNumber)) // Якщо введено не число
		{
			PrintError("Уведіть число!", callback);
		}

		numbers = new double[n];

		switch (generateNumber)
		{
			case 1: // Вводити вручну
				for (int i = 0; i < n; i++)
				{
					Console.Write($"Уведіть число {i + 1}: ");

					if (!double.TryParse(Console.ReadLine(), out numbers[i])) // Якщо введено не число 
					{
						PrintError("Уведіть число!", callback);
					}
				}
				break;
			case 2: // Генерувати випадково
				Random random = new Random();

				for (int i = 0; i < n; i++)
				{
					numbers[i] = random.Next(1, 100);
				}
				break;
			default:
				PrintError("Виберіть коректний пункт меню!", callback);
				break;
		}
	}

	private static void Menu()
	{
		Console.WriteLine("1) Завдання 1.1");
		Console.WriteLine("2) Завдання 1.2");
		Console.WriteLine("3) Завдання 1.3");
		Console.WriteLine("4) Вихід");

		Console.Write("\nУведіть номер завдання: ");

		if (!int.TryParse(Console.ReadLine(), out int taskNumber))
		{
			PrintError("Уведіть число!", Menu);
		}

		switch (taskNumber)
		{
			case 1:
				Console.Clear();
				Task1_1();
				break;
			case 2:
				Console.Clear();
				Task1_2();
				break;
			case 3:
				Console.Clear();
				Task1_3();
				break;
			case 4:
				Environment.Exit(0);
				break;
			default:
				Console.WriteLine("Невірний ввід!");
				break;
		}
		Menu();
	}

	private static void Task1_1()
	{
		// Дано n дійсних чисел: x1, x2, ..., xn. Знайти середнє геометричне значення цих чисел.
		InputNumbers(out double[] numbers, out int n, Task1_1);

		double result = 1; // Результат обчислення середнього геометричного

		for (int i = 0; i < n; i++)
		{
			result *= numbers[i]; // Обчислюємо добуток всіх компонент.
		}

		result = Math.Pow(result, 1.0 / n); // Обчислюємо корінь зі степеню, яка рівна кількості компонент вектора.

		Console.Clear();
		Console.WriteLine("Введені числа: ");
		PrintArray(numbers);
		Console.WriteLine($"Середнє геометричне значення: {Math.Round(result, 4)}\n");
	}

	private static void Task1_2()
	{
		// Дано вектор x∈R^n і число a∈R. Знайти добуток вектора на число.
		InputNumbers(out double[] numbers, out int n, Task1_2);

		Console.Write("\nУведіть число a: ");
		if (!double.TryParse(Console.ReadLine(), out double a)) // Якщо введено не число 
		{
			PrintError("Уведіть число!", Task1_2);
		}

		double[] result = new double[n]; // Результат обчислення добутку вектора на число

		for (int i = 0; i < n; i++) // Проходимо по всіх компонентах вектора
		{
			result[i] = numbers[i] * a; // Обчислюємо добуток вектора на число.
		}

		Console.Clear();
		Console.WriteLine("Введені числа: ");
		PrintArray(numbers);
		Console.WriteLine($"Число a: {a}\n");
		Console.WriteLine("Результат: ");
		PrintArray(result);
	}

	private static void Task1_3()
	{
		// Впорядкувати елементи масиву за спаданням.
		InputNumbers(out double[] numbers, out int n, Task1_3);

		double[] result = ArraySort<double>.InsertionSort(
				numbers,
				(double a, double b) => { return a > b; }
			); // Результат сортування

		Console.Clear();
		Console.WriteLine("Введені числа: ");
		PrintArray(numbers);
		Console.WriteLine("Відсортовані числа: ");
		PrintArray(result);
	}

	public static void Run()
	{
		Console.Title = "Лабораторна робота №2 | Завдання 1";
		Menu();
	}
}