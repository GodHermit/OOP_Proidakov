namespace Lab_03;

class Program
{
	static StackOfNumbers _stack = new();
	static QueueOfNumbers _queue = new();

	private static void PrintError(string errorMessage, Action? callback = null)
	{
		Console.Clear();
		Console.WriteLine($"{errorMessage}\n");
		callback?.Invoke();
	}

	static void Menu()
	{
		if (_stack.Count > 0)
		{
			Console.WriteLine("Стек: " + _stack);
		}
		if (_queue.Count > 0)
		{
			Console.WriteLine("Черга: " + _queue + "\n");
		}

		Console.WriteLine("1) Додати елемент в стек та чергу");
		Console.WriteLine("2) Видалити елемент зі стеку та черги");
		Console.WriteLine("3) Знайти елемент в стеку та черзі");
		Console.WriteLine("5) Вихід");

		Console.Write("\nУведіть номер пункту меню: ");

		if (!int.TryParse(Console.ReadLine(), out int menuOption))
		{
			PrintError("Уведіть число!", Menu);
		}

		switch (menuOption)
		{
			case 1:
				AddNumber();
				break;
			case 2:
				if (_stack.Count == 0 || _queue.Count == 0) PrintError("Стек або черга порожні!", Menu);
				RemoveNumber();
				break;
			case 3:
				if (_stack.Count == 0 || _queue.Count == 0) PrintError("Стек або черга порожні!", Menu);
				FindNumber();
				break;
			case 5:
				Environment.Exit(0);
				break;
			default:
				PrintError("Уведіть число від 1 до 4!", Menu);
				break;
		}

		Menu();
	}

	static void AddNumber()
	{
		Console.Clear();

		Console.Write("Уведіть число: ");
		if (!int.TryParse(Console.ReadLine(), out int number))
		{
			PrintError("Уведіть число!\n", Menu);
		}

		_stack.AddNumber(number);
		_queue.AddNumber(number);

		Console.Clear();
		Console.WriteLine("Число "+ number +" додано в стек та чергу!\n");
	}

	static void RemoveNumber() {
		Console.Clear();

		Console.Write("Уведіть число: ");
		if (!int.TryParse(Console.ReadLine(), out int number))
		{
			PrintError("Уведіть число!\n", Menu);
		}

		try
		{
			_stack.RemoveNumber(number);
			_queue.RemoveNumber(number);

			Console.Clear();
			Console.WriteLine("Число " + number + " видалено зі стеку та черги!\n");
		}
		catch (System.Exception e)
		{
			Console.Clear();
			Console.WriteLine(e.Message + "\n");
		}
	}

	static void FindNumber() {
		Console.Clear();

		Console.Write("Уведіть число: ");
		if (!int.TryParse(Console.ReadLine(), out int number))
		{
			PrintError("Уведіть число!\n", Menu);
		}

		try
		{
			int indexInStack = _stack.FindNumber(number);
			int indexIntStack = _queue.FindNumber(number);

			Console.Clear();
			Console.WriteLine("Число " + number + " знайдено в стеку та черзі!\n");
			Console.WriteLine("Індекс числа " + number + " в стеку: " + indexInStack);
			Console.WriteLine("Індекс числа " + number + " в черзі: " + indexIntStack + "\n");
		}
		catch (System.Exception)
		{
			Console.Clear();
			Console.WriteLine("Число " + number + " не знайдено в стеку та черзі!\n");
		}
	}

	static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.Title = "Лабораторна робота №3";
		Menu();
	}
}