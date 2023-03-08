namespace Lab_02;

class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.Title = "Лабораторна робота №2";

		Console.WriteLine("1) Завдання 1");
		Console.WriteLine("2) Завдання 2\n");

		Console.Write("Уведіть номер пункту: ");

		if (!int.TryParse(Console.ReadLine(), out int taskNumber)) // Якщо введено не число
		{
			Console.Clear();
			Console.WriteLine("Уведіть число!\n");
			Main(args);
		}

		switch (taskNumber)
		{
			case 1:
				Console.Clear();
				Task1.Run();
				break;
			case 2:
				Console.Clear();
				Task2.Run();
				break;
			default:
				Console.Clear();
				Console.WriteLine("Уведіть число від 1 до 2!\n");
				Main(args);
				break;
		}
	}
}