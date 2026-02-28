public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Create an array of doubles called 'result' using 'length' for its size.
        // 2. Create a for-loop that starts at 1 that goes up to and includes 'length'.
        // 3. Inside the loop, calculate: current loop index * number.
        // 4. Store that calculation in the 'result' array at the correct index (index = loop index - 1).
        // 5. Return the 'result' array after the loop.

        // 1. Create an array of doubles called 'result' using 'length' for its size.
        double[] result = new double[length];

        // 2. Create a for-loop that starts at 1 that goes up to and includes 'length'.
        for (int i = 1; i <= length; i++)
        {
            // 3. Inside the loop, calculate: current loop index * number.
            // 4. Store that calculation in the 'result' array at the correct index (index = loop index - 1).
            result[i - 1] = i * number;
        }

        // 5. Return the 'result' array after the loop.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Do nothing if the list is empty or if the rotation amount is 0.
        // 2. Use module % to adjust the 'amount' to handle cases where 'amount' is larger than the list size.
        // 3. Find the split point by subtracting 'amount' from the total count of the list.
        // 4. Extract the elements from the split point to the end of the list into a temporary list.
        // 5. Remove those same elements from the original list.
        // 6. Insert the temporary list back into the original list starting at index 0.

        // 1. Do nothing if the list is empty or if the rotation amount is 0.
        if (data.Count == 0 || amount == 0) return;

        // 2. Use module % to adjust the 'amount' to handle cases where 'amount' is larger than the list size.
        amount = amount % data.Count;

        // 3. Find the split point by subtracting 'amount' from the total count of the list.
        int splitPoint = data.Count - amount;

        // 4. Extract the elements from the split point to the end of the list into a temporary list.
        List<int> rightSide = data.GetRange(splitPoint, amount);

        // 5. Remove those same elements from the original list.
        data.RemoveRange(splitPoint, amount);

        // 6. Insert the temporary list back into the original list starting at index 0.
        data.InsertRange(0, rightSide);
    }
}
