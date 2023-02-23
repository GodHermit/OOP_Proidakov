namespace Lab_02;

public class Task2
{
	private static void PrintError(string errorMessage, Action? callback = null)
	{
		Console.Clear();
		Console.WriteLine($"{errorMessage}\n");
		callback?.Invoke();
	}

	private static void PrintMatrix(double[][] matrix)
	{
		for (int i = 0; i < matrix.Length; i++) // Проходимо по масиву
		{
			for (int j = 0; j < matrix[i].Length; j++) // Проходимо по масиву
			{
				Console.Write($"{matrix[i][j]}"); // Виводимо число
				if (j != matrix[i].Length - 1) // Якщо не останнє число
				{
					Console.Write(", "); // Виводимо кому
				}
			}
			Console.WriteLine();
		}
		Console.WriteLine("\n");
	}

	private static void InputMatrix(out double[][] matrix, bool isSquare = false, Action? callback = null)
	{
		Console.Write("Уведіть кількість рядків: ");

		if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) // Якщо введено не число
		{
			PrintError("Уведіть число!", callback);
		}

		Console.Write("Уведіть кількість стовпців: ");

		if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0) // Якщо введено не число
		{
			PrintError("Уведіть число!", callback);
		}

		if (isSquare && n != m) // Якщо матриця має бути квадратною, але не квадратна
		{
			PrintError("Матриця має бути квадратною!", callback);
		}

		// Генерувати числа чи вводити вручну?
		Console.WriteLine("\n1) Ввести вручну");
		Console.WriteLine("2) Згенерувати випадково\n");

		Console.Write("Уведіть номер пункту: ");

		if (!int.TryParse(Console.ReadLine(), out int generateNumber)) // Якщо введено не число
		{
			PrintError("Уведіть число!", callback);
		}

		matrix = new double[n][];

		switch (generateNumber)
		{
			case 1: // Вводити вручну
				for (int i = 0; i < n; i++)
				{
					matrix[i] = new double[m];
					for (int j = 0; j < m; j++)
					{
						Console.Write($"Уведіть елемент [{i + 1}, {j + 1}]: ");

						if (!double.TryParse(Console.ReadLine(), out double number)) // Якщо введено не число
						{
							PrintError("Уведіть число!", callback);
						}

						matrix[i][j] = number;
					}
				}
				break;
			case 2: // Генерувати випадково
				Random random = new Random();
				for (int i = 0; i < n; i++)
				{
					matrix[i] = new double[m];
					for (int j = 0; j < m; j++)
					{
						matrix[i][j] = random.Next(-50, 100);
					}
				}
				break;
			default:
				PrintError("Виберіть коректний пункт меню!", callback);
				break;
		}
	}

	private static void Menu()
	{
		Console.WriteLine("1) Завдання 2.1");
		Console.WriteLine("2) Завдання 2.2");
		Console.WriteLine("3) Завдання 2.3");
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
				Task2_1();
				break;
			case 2:
				Console.Clear();
				Task2_2();
				break;
			case 3:
				Console.Clear();
				Task2_3();
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

	private static void Task2_1()
	{
		// Дана цілочислова квадратна матриця.
		// Розмістити елементи непарних рядків у порядку зростання.

		InputMatrix(out double[][] matrix, true, Task2_1);

		double[][] resultMatrix = new double[matrix.Length][]; // Створюємо нову матрицю
		Array.Copy(matrix, resultMatrix, matrix.Length); // Копіюємо елементи

		for (int i = 0; i < matrix.Length; i += 2) // Проходимо по рядках
		{
			resultMatrix[i] = ArraySort<double>.QuickSort(
				matrix[i],
				(a, b) => a < b
			); // Сортуємо елементи
		}

		Console.WriteLine("Вхідна матриця:");
		PrintMatrix(matrix);
		Console.WriteLine("Вихідна матриця:");
		PrintMatrix(resultMatrix);

	}

	private static void Task2_2()
	{
		// Дана цілочислова прямокутна матриця.
		// Визначити кількість стовпців, які не містять жодного нульового елемента.

		InputMatrix(out double[][] matrix, false, Task2_2);

		int count = 0;

		for (int i = 0; i < matrix[0].Length; i++) // Проходимо по стовпцях
		{
			bool isZero = false;
			for (int j = 0; j < matrix.Length; j++) // Проходимо по рядках
			{
				if (matrix[j][i] == 0) // Якщо елемент = 0
				{
					isZero = true;
					break;
				}
			}
			if (!isZero) // Якщо нуль не знайдено
			{
				count++;
			}
		}

		Console.WriteLine("Матриця:");
		PrintMatrix(matrix);
		Console.WriteLine($"Кількість стовпців, які не містять жодного нульового елемента: {count}");
	}

	private static void Task2_3()
	{
		// Дана цілочислова прямокутна матриця.
		// Переставляючи рядки даної матриці, розташувати їх у відповідності з ростом характеристик.
		// Характеристикою рядка цілочислової матриці назвемо суму її додатних парних елементів.

		InputMatrix(out double[][] matrix, false, Task2_3);

		double[][] resultMatrix = new double[matrix.Length][]; // Створюємо нову матрицю
		Array.Copy(matrix, resultMatrix, matrix.Length); // Копіюємо елементи

		for (int i = 0; i < resultMatrix.Length; i++) // Проходимо по рядках
		{
			for (int j = 0; j < resultMatrix.Length - 1; j++) // Проходимо по рядках
			{
				if (GetRowSum(resultMatrix[j]) > GetRowSum(resultMatrix[j + 1])) // Якщо сума елементів наступного рядка більша
				{
					double[] temp = resultMatrix[j]; // Міняємо місцями
					resultMatrix[j] = resultMatrix[j + 1];
					resultMatrix[j + 1] = temp;
				}
			}
		}

		Console.WriteLine("Вхідна матриця:");
		PrintMatrix(matrix);
		Console.WriteLine("Вихідна матриця:");
		PrintMatrix(resultMatrix);
	}

	private static double GetRowSum(double[] row)
	{
		double sum = 0;
		for (int i = 0; i < row.Length; i++)
		{
			if (row[i] > 0 && row[i] % 2 == 0)
			{
				sum += row[i];
			}
		}
		return sum;
	}

	public static void Run()
	{
		Console.Title = "Лабораторна робота №2 | Завдання 2";
		Menu();
	}
}