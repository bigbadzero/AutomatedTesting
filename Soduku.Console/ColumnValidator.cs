public class ColumnValidator : IValidator
{
    public bool Validate(int[][] board, int index)
    {
        var set = new HashSet<int>();

        for (int i = 0; i < 9; i++)
        {
            int num = board[i][index];
            if (num != 0 && !set.Add(num))
            {
                return false;
            }
        }

        return true;
    }
}