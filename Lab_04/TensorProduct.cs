namespace Lab_04;

public class TensorProduct
{
	private int[]? _vector1;
	private int[]? _vector2;

    /// <summary>
    /// Set vectors for tensor product
    /// </summary>
    /// <param name="vector1">First vector</param>
    /// <param name="vector2">Second vector</param>
	public void SetVectors(int[] vector1, int[] vector2)
	{
		_vector1 = vector1;
		_vector2 = vector2;
	}

    /// <summary>
    /// Calculate tensor product of two vectors
    /// </summary>
    /// <returns>Matrix of tensor product</returns>
	public LinkedList<LinkedList<int>> Calculate()
	{
        if (_vector1 is null || _vector2 is null) // Check if vectors are set
            throw new NullReferenceException("Vectors are not set!");

        LinkedList<LinkedList<int>> result = new(); // Matrix of tensor product

        foreach (int item1 in _vector1) // Loop for each item in first vector
        {
            LinkedList<int> row = new(); // Row of matrix
            foreach (int item2 in _vector2) // Loop for each item in second vector
            {
                row.AddLast(item1 * item2); // Add product of two items to row
            }
            result.AddLast(row); // Add row to matrix
        }

        return result; // Return matrix
	}

    /// <summary>
    /// Method for output matrix of tensor product
    /// </summary>
    /// <returns>String with matrix</returns>
	public override string ToString()
	{
        return string.Join("\n", Calculate().Select(row => string.Join(" ", row)));
	}
}
