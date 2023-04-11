namespace Lab_03;
public interface INumbers
{
    /// <summary>
    /// Append number to list
    /// </summary>
    /// <param name="number">Number for append</param> 
    void AddNumber(int number);

    /// <summary>
    /// Remove first element equal to number
    /// </summary>
    /// <param name="number">Number for remove</param>
    /// <exception cref="Exception">If number not found</exception>
    /// <exception cref="Exception">If list is empty</exception>
    void RemoveNumber(int number);

    /// <summary>
    /// Find number in list and return index
    /// </summary>
    /// <param name="number">Number for search</param>
    /// <returns>Index of element</returns>
    /// <exception cref="Exception">If number not found</exception>
    /// <exception cref="Exception">If list is empty</exception>
    int FindNumber(int number);

}