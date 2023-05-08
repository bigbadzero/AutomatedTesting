
public class RowValidator : IValidator
{
    public bool Validate(int[][] board, int index)
    {
        var set = new HashSet<int>();

        for (int j = 0; j < 9; j++)
        {
            int num = board[index][j];
            if (num != 0 && !set.Add(num))
            {
                return false;
            }
        }

        return true;
    }
}
