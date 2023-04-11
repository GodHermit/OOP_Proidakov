namespace Lab_03;

public class QueueOfNumbers : INumbers
{
    private Queue<int> _numbers = new Queue<int>();
	public int Count => _numbers.Count;

	public void AddNumber(int number)
    {
        _numbers.Enqueue(number); // Додаємо елемент в чергу
    }

    public int FindNumber(int number)
    {
        int index = -1; // Індекс елемента, який потрібно знайти

        for (int i = 0; i < _numbers.Count; i++) // Для кожного елемента в черзі
        {
            if (_numbers.ToArray()[i] == number) // Якщо елемент є тим, що потрібно знайти
            {
                index = i; // Записуємо його індекс
                break;
            }
        }

        if (index == -1) // Якщо індекс не змінився
        {
            throw new Exception("Число не знайдено в черзі!"); // Викидаємо помилку
        }

        return index; // Повертаємо індекс
    }

    public void RemoveNumber(int number)
    {
        Queue<int> temp = new();

		FindNumber(number); // Перевіряємо чи є елемент в черзі
        
        int count = _numbers.Count; // Записуємо кількість елементів в черзі
		for (int i = 0; i < count; i++) // Для кожного елемента в черзі
        {
            if (_numbers.Peek() == number) // Якщо елемент є тим, що потрібно видалити
            {
                _numbers.Dequeue(); // Видаляємо його
            }
            else // Якщо ні
            {
                temp.Enqueue(_numbers.Dequeue()); // Додаємо його в тимчасову чергу та видаляємо з основної
            }
        }

        _numbers = temp; // Перезаписуємо основну чергу
    }

	override public string ToString()
	{
		return string.Join(", ", _numbers);
	}
}