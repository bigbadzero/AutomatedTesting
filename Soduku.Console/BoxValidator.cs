public class BoxValidator : IValidator
{
    public bool Validate(int[][] board, int index)
    {
        var set = new HashSet<int>();
        int row = (index / 3) * 3;
        int col = (index % 3) * 3;

        for (int i = row; i < row + 3; i++)
        {
            for (int j = col; j < col + 3; j++)
            {
                int num = board[i][j];
                if (num > 9)
                    return false;
                if (num != 0 && !set.Add(num))
                {
                    return false;
                }
            }
        }

        return true;
    }
}