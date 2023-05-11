using Soduku.Console;
using System.Text.Json;

public class SudokuValidator
{
    public bool Validate(string file)
    {
        var board = ReadSudokuFromFile(file);
        var rowValidator = new RowValidator();
        var columnValidator = new ColumnValidator();
        var boxValidator = new BoxValidator();
        var gridvalidator = new GridValidator();

        if (!gridvalidator.IsValid(board))
            return false;
        for (int i = 0; i < 9; i++)
        {
            if (!rowValidator.Validate(board, i) ||
                !columnValidator.Validate(board, i) ||
                !boxValidator.Validate(board, i))
                return false;
        }
        return true;
    }

    public int[][] ReadSudokuFromFile(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        var sudoku = JsonSerializer.Deserialize<int[][]>(jsonString);
        return sudoku;
    }
}
