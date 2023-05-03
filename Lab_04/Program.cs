namespace Lab_04;

class Program
{
	private static void InputNumberList(out int[]? result)
	{
		Console.Write("Згенерувати випадкові числа? (y/n): ");
		result = new int[0];

		switch (Console.ReadLine())
		{
			case "y":
				Console.Write("Уведіть розмір вектора: ");

				if (!int.TryParse(Console.ReadLine(), out int size) && size <= 0)
				{
					Console.Clear();
					Console.WriteLine("Уведіть число!\n");
					InputNumberList(out result);
					return;
				}

				result = new int[size];

				Random random = new();

				for (int i = 0; i < size; i++)
				{
					result[i] = random.Next(1, 10);
				}
				break;
			case "n":
				try
				{
					Console.Write("Уведіть ім'я файлу: ");
					string vector1 = File.ReadAllText($@"{Environment.CurrentDirectory}/{Console.ReadLine()}");

					result = new int[vector1.Split(' ').Length];

					for (int i = 0; i < vector1.Split(' ').Length; i++)
					{
						result[i] = int.Parse(vector1.Split(' ')[i]);
					}
				}
				catch (System.Exception)
				{
					Console.Clear();
					Console.WriteLine("Файл не знайдено!\n");
					InputNumberList(out result);
					return;
				}
				break;
			default:
				Console.Clear();
				Console.WriteLine("Уведіть 'y' або 'n'!\n");
				InputNumberList(out result);
				return;
		}
		Console.WriteLine();
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
		tensorProduct.SetVectors(vector1, vector2);

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