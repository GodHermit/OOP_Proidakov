namespace Lab_04;

class Program
{

	private static void PrintError(string errorMessage, Action? callback = null)
	{
		Console.Clear();
		Console.WriteLine($"{errorMessage}\n");
		callback?.Invoke();
	}

	private static void InputNumberList(out int[]? result)
	{
		Console.Write("\nУведіть розмір вектора: ");

		if (!int.TryParse(Console.ReadLine(), out int size) && size <= 0)
		{
			Console.Clear();
			Console.WriteLine("Уведіть число!\n");
			InputNumberList(out result);
			return;
		}

		result = new int[size];
		Console.Write("Згенерувати випадкові числа? (y/n): ");

		switch (Console.ReadLine())
		{
			case "y":
				Random random = new();

				for (int i = 0; i < size; i++)
				{
					result[i] = random.Next(1, 10);
				}
				break;
			case "n":
				for (int i = 0; i < size; i++)
				{
					Console.Write($"Уведіть {i + 1} число: ");

					if (!int.TryParse(Console.ReadLine(), out int number))
					{
						Console.Clear();
						Console.WriteLine("Уведіть число!\n");
						InputNumberList(out result);
						return;
					}

					result[i] = number;
				}
				break;
			default:
				Console.Clear();
				Console.WriteLine("Уведіть 'y' або 'n'!\n");
				InputNumberList(out result);
				return;
		}
	}

	static void Main(string[] args)
	{
		Console.Title = "Лабораторна робота №4";
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		InputNumberList(out int[]? vector1);
		InputNumberList(out int[]? vector2);

		if (vector1 is null || vector2 is null)
		{
			Main(args);
			return;
		}

		TensorProduct tensorProduct = new();
		tensorProduct.setVectors(vector1, vector2);
		tensorProduct.Calculate();

		Console.Clear();
		Console.WriteLine($"Вектор 1:\n{string.Join("\n", vector1)}");
		Console.WriteLine($"\nВектор 2:\n{string.Join(" ", vector2)}");
		Console.WriteLine($"\nРезультат:\n{tensorProduct.ToString()}");

		Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
		Console.ReadKey();

		Console.Clear();
		Main(args);
	}
}