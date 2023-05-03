using Xunit;

namespace Lab_04;

public class CrossProductTest
{
	[Fact]
	public void PassingCalculationTest()
	{
		int[] vector1 = new int[] { 1, 2, 3 }; // First vector
		int[] vector2 = new int[] { 4, 5, 6 }; // Second vector

		TensorProduct tensorProduct = new(); // Tensor product object
		tensorProduct.SetVectors(vector1, vector2); // Set vectors for tensor product

		Assert.Equal(
			new LinkedList<LinkedList<int>>(new[] { // Expected result
				new LinkedList<int>(new int[] {4, 5, 6}),
				new LinkedList<int>(new int[] {8, 10, 12}),
				new LinkedList<int>(new int[] {12, 15, 18}),
			}),
			tensorProduct.Calculate() // Actual result
		);
	}

	[Fact]
	public void PassingToStringTest()
	{
		int[] vector1 = new int[] { 1, 2, 3 }; // First vector
		int[] vector2 = new int[] { 4, 5, 6 }; // Second vector

		TensorProduct tensorProduct = new(); // Tensor product object
		tensorProduct.SetVectors(vector1, vector2); // Set vectors for tensor product

		Assert.Equal(
			"4 5 6\n8 10 12\n12 15 18", // Expected result
			tensorProduct.ToString() // Actual result
		);
	}
}