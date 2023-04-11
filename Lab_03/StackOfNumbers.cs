namespace Lab_03;

public class StackOfNumbers : INumbers
{
	private Stack<int> _numbers = new Stack<int>();
	public int Count => _numbers.Count;

	public void AddNumber(int number)
	{
		_numbers.Push(number); // Додаємо елемент в стек
	}

	public int FindNumber(int number)
	{
		int index = -1; // Індекс елемента, який потрібно знайти

		for (int i = 0; i < _numbers.Count; i++) // Для кожного елемента в стеці
		{
			if (_numbers.ToArray()[i] == number) // Якщо елемент є тим, що потрібно знайти
			{
				index = i; // Записуємо його індекс
				break;
			}
		}

		if (index == -1) // Якщо індекс не змінився
		{
			throw new Exception("Число не знайдено в стеку!"); // Викидаємо помилку
		}

		return index; // Повертаємо індекс
	}

	public void RemoveNumber(int number)
	{
		Stack<int> temp = new(); // Створюємо тимчасовий стек

		FindNumber(number); // Перевіряємо чи є елемент в стеці

		int count = _numbers.Count; // Записуємо кількість елементів в стеці
		for (int i = 0; i < count; i++) // Для кожного елемента в стеці
        {
            if (_numbers.Peek() == number) // Якщо елемент є тим, що потрібно видалити
            {
                _numbers.Pop(); // Видаляємо його
            }
            else // Якщо ні
            {
                temp.Push(_numbers.Pop()); // Додаємо його в тимчасовий стек та видаляємо з основного
            }
        }

        for (int i = 0; i < count - 1; i++) // Для кожного елемента в тимчасовому стеці
        {
            _numbers.Push(temp.Pop()); // Додаємо його в основний стек та видаляємо з тимчасового
        }
	}

	override public string ToString()
	{
		return string.Join(", ", _numbers);
	}

}
