namespace Lab_02;

class ArraySort<T>
{
	/// <summary>
	/// Linear sort algorithm implementation (O(n^2))
	/// Stable: Yes
	/// </summary>
	/// <param name="array">Array to sort</param>
	/// <param name="comparer">Comparer function</param>
	/// <returns>Sorted array</returns>
	/// <exception cref="ArgumentNullException">Thrown when array or comparer is null</exception>
	/// <exception cref="ArgumentException">Thrown when array is empty</exception>
	public static T[] LinearSort(in T[] array, in Func<T, T, Boolean> comparer)
	{
		if (array == null) // Якщо масив пустий
		{
			throw new ArgumentNullException(nameof(array));
		}
		if (comparer == null) // Якщо функція порівняння пуста
		{
			throw new ArgumentNullException(nameof(comparer));
		}

		T[] result = new T[array.Length];
		array.CopyTo(result, 0);

		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i + 1; j < array.Length; j++)
			{
				if (!comparer(result[i], result[j]))
				{
					T temp = result[i];
					result[i] = result[j];
					result[j] = temp;
				}
			}
		}

		return result;
	}

	/// <summary>
	/// Selection sort algorithm implementation
	/// Worst case: O(n^2) O(n) swaps - when array is sorted in reverse order
	/// Best case: O(n^2) O(1) swaps - when array is sorted in correct order
	/// Stable: No (because of swapping) but can be made stable
	/// </summary>
	/// <param name="array">Array to sort</param>
	/// <param name="comparer">Comparer function</param>
	/// <returns>Sorted array</returns>
	/// <exception cref="ArgumentNullException">Thrown when array or comparer is null</exception>
	/// <exception cref="ArgumentException">Thrown when array is empty</exception>
	public static T[] SelectionSort(in T[] array, in Func<T, T, Boolean> comparer)
	{
		if (array == null) // Якщо масив пустий
		{
			throw new ArgumentNullException(nameof(array));
		}
		if (comparer == null) // Якщо функція порівняння пуста
		{
			throw new ArgumentNullException(nameof(comparer));
		}

		T[] result = new T[array.Length];
		array.CopyTo(result, 0);

		for (int i = 0; i < array.Length; i++) // Проходимо по масиву
		{
			int min = i; // Запам'ятовуємо індекс мінімального елемента

			for (int j = i + 1; j < array.Length; j++) // Проходимо по масиву починаючи з наступного елемента
			{
				if (comparer(result[j], result[min])) // Якщо відповідає умові порівняння з мінімальним елементом
				{
					min = j; // Запам'ятовуємо індекс мінімального елемента
				}
			}

			// Міняємо місцями мінімальний елемент з поточним
			T temp = result[i];
			result[i] = result[min];
			result[min] = temp;
		}

		return result;
	}

	/// <summary>
	/// Bubble sort algorithm implementation
	/// Worst case: O(n^2) O(n^2) swaps - when array is sorted in reverse order
	/// Best case: O(n) O(1) swaps - when array is sorted in correct order
	/// Stable: Yes
	/// </summary>
	/// <param name="array">Array to sort</param>
	/// <param name="comparer">Comparer function</param>
	/// <returns>Sorted array</returns>
	/// <exception cref="ArgumentNullException">Thrown when array or comparer is null</exception>
	/// <exception cref="ArgumentException">Thrown when array is empty</exception>
	public static T[] BubbleSort(in T[] array, in Func<T, T, Boolean> comparer)
	{
		if (array == null) // Якщо масив пустий
		{
			throw new ArgumentNullException(nameof(array));
		}
		if (comparer == null) // Якщо функція порівняння пуста
		{
			throw new ArgumentNullException(nameof(comparer));
		}

		T[] result = new T[array.Length];
		array.CopyTo(result, 0);

		for (int i = 0; i < array.Length; i++) // Проходимо по масиву
		{
			for (int j = 0; j < array.Length - i - 1; j++) // Проходимо по масиву починаючи з наступного елемента
			{
				if (!comparer(result[j], result[j + 1])) // Якщо не відповідає умові порівняння з наступним елементом
				{
					// Міняємо місцями поточний елемент з наступним
					T temp = result[j];
					result[j] = result[j + 1];
					result[j + 1] = temp;
				}
			}
		}

		return result;
	}

	/// <summary>
	/// Insertion sort algorithm implementation
	/// Worst case: O(n^2) O(n^2) swaps - when array is sorted in reverse order
	/// Best case: O(n) O(1) swaps - when array is sorted in correct order
	/// Stable: Yes
	/// </summary>
	/// <param name="array">Array to sort</param>
	/// <param name="comparer">Comparer function</param>
	/// <returns>Sorted array</returns>
	/// <exception cref="ArgumentNullException">Thrown when array or comparer is null</exception>
	/// <exception cref="ArgumentException">Thrown when array is empty</exception>
	public static T[] InsertionSort(in T[] array, in Func<T, T, Boolean> comparer)
	{
		if (array == null) // Якщо масив пустий
		{
			throw new ArgumentNullException(nameof(array));
		}
		if (comparer == null) // Якщо функція порівняння пуста
		{
			throw new ArgumentNullException(nameof(comparer));
		}

		T[] result = new T[array.Length];
		array.CopyTo(result, 0);

		for (int i = 1; i < array.Length; i++) // Проходимо по масиву починаючи з другого елемента
		{
			T temp = result[i]; // Запам'ятовуємо поточний елемент
			int j = i - 1; // Запам'ятовуємо індекс попереднього елемента

			while (j >= 0 && !comparer(result[j], temp)) // Поки індекс попереднього елемента не менший за нуль і не виконується умова порівняння з поточним елементом
			{
				result[j + 1] = result[j]; // Переміщуємо попередній елемент на один індекс вправо
				j--; // Зменшуємо індекс попереднього елемента
			}

			result[j + 1] = temp; // Переміщуємо поточний елемент на один індекс вліво
		}

		return result;
	}

	/// <summary>
	/// Quick sort algorithm implementation
	/// Worst case: O(n^2)
	/// Best case: O(n log n)
	/// Stable: No
	/// </summary>
	/// <param name="array"></param>
	/// <param name="comparer"></param>
	/// <returns></returns>
	public static T[] QuickSort(in T[] array, in Func<T, T, Boolean> comparer)
	{
		T[] result = new T[array.Length];
		array.CopyTo(result, 0);

		QuickSort(result, 0, result.Length - 1, comparer); // Викликаємо рекурсивну функцію

		return result;
	}

	private static void QuickSort(T[] array, int left, int right, in Func<T, T, Boolean> comparer)
	{
		if (left < right) // Якщо ліва межа менша за праву
		{
			int pivot = Partition(array, left, right, comparer); // Розбиваємо масив на дві частини

			QuickSort(array, left, pivot - 1, comparer); // Рекурсивно викликаємо функцію для лівої частини
			QuickSort(array, pivot + 1, right, comparer); // Рекурсивно викликаємо функцію для правої частини
		}
	}

	private static int Partition(T[] array, int left, int right, in Func<T, T, Boolean> comparer)
	{
		T pivot = array[right]; // Вибираємо опорний елемент
		int i = left - 1; // Індекс меншого елемента

		for (int j = left; j < right; j++) // Проходимо по масиву
		{
			if (comparer(array[j], pivot)) // Якщо відповідає умові порівняння з опорним елементом
			{
				i++; // Збільшуємо індекс меншого елемента

				T temp = array[i]; // Міняємо місцями поточний елемент з меншим елементом
				array[i] = array[j]; // Міняємо місцями поточний елемент з меншим елементом
				array[j] = temp; // Міняємо місцями поточний елемент з меншим елементом
			}
		}

		T temp2 = array[i + 1];
		array[i + 1] = array[right];
		array[right] = temp2;

		return i + 1;
	}

	/// <summary>
	/// Shell sort algorithm implementation
	/// Worst case: O(n^2)
	/// Best case: O(n log n)
	/// Stable: No
	/// </summary>
	/// <param name="array"></param>
	/// <param name="comparer"></param>
	/// <returns></returns>
	public static T[] ShellSort(in T[] array, in Func<T, T, Boolean> comparer)
	{
		T[] result = new T[array.Length];

		array.CopyTo(result, 0);

		int n = result.Length; // Запам'ятовуємо довжину масиву

		for (int gap = n / 2; gap > 0; gap /= 2) // Зменшуємо інтервал між елементами
		{
			for (int i = gap; i < n; i++) // Проходимо по масиву починаючи з елемента з інтервалом
			{
				T temp = result[i]; // Запам'ятовуємо поточний елемент

				int j; // Запам'ятовуємо індекс попереднього елемента
				for (j = i; j >= gap && comparer(temp, result[j - gap]); j -= gap) // Поки індекс попереднього елемента не менший за нуль і виконується умова порівняння з поточним елементом
				{
					result[j] = result[j - gap]; // Переміщуємо попередній елемент на інтервал
				}

				result[j] = temp; // Переміщуємо поточний елемент
			}
		}

		return result;
	}

	/// <summary>
	/// Heap sort algorithm implementation
	/// Worst case: O(n log n)
	/// Best case: O(n)
	/// Stable: No
	/// </summary>
	/// <param name="array"></param>
	/// <param name="comparer"></param>
	/// <returns></returns>
	public static T[] HeapSort(in T[] array, in Func<T, T, Boolean> comparer)
	{
		T[] result = new T[array.Length];

		array.CopyTo(result, 0);

		int n = result.Length; // Запам'ятовуємо довжину масиву

		for (int i = n / 2 - 1; i >= 0; i--) // Починаємо з середини масиву
		{
			Heapify(result, n, i, comparer); // Перевіряємо чи відповідає умовам порівняння з батьківським елементом
		}

		for (int i = n - 1; i >= 0; i--) // Проходимо по масиву
		{
			// Переміщуємо корінь в кінець
			T temp = result[0];
			result[0] = result[i];
			result[i] = temp;

			Heapify(result, i, 0, comparer); // Перевіряємо чи відповідає умовам порівняння з батьківським елементом
		}

		return result;
	}

	private static void Heapify(T[] array, int n, int i, in Func<T, T, Boolean> comparer)
	{
		int largest = i; // Індекс найбільшого елемента
		int left = 2 * i + 1; // Індекс лівого нащадка
		int right = 2 * i + 2; // Індекс правого нащадка

		if (left < n && comparer(array[largest], array[left])) // Якщо лівий нащадок існує і виконується умова порівняння з найбільшим елементом
		{
			largest = left; // То найбільший елемент - лівий нащадок
		}

		if (right < n && comparer(array[largest], array[right])) // Якщо правий нащадок існує і виконується умова порівняння з найбільшим елементом
		{
			largest = right; // То найбільший елемент - правий нащадок
		}

		if (largest != i) // Якщо найбільший елемент не є поточним елементом
		{
			// Міняємо місцями поточний елемент з найбільшим елементом
			T swap = array[i];
			array[i] = array[largest];
			array[largest] = swap;

			Heapify(array, n, largest, comparer); // Перевіряємо чи відповідає умовам порівняння з найбільшим елементом
		}
	}
}