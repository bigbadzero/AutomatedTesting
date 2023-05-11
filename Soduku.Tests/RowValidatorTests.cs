using Shouldly;

namespace Soduku.Tests;

public class RowValidatorTests
{
    [Theory]
    [InlineData(0, true)]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, true)]
    [InlineData(5, true)]
    [InlineData(6, true)]
    [InlineData(7, true)]
    [InlineData(8, true)]
    public void Should_ReturnTrue_When_AllRowsValid(int rowIndex, bool expected)
    {
        // Arrange
        var sudokuValidator = new SudokuValidator();
        var validator = new RowValidator();
        var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\ValidSudoku.txt";
        var board = sudokuValidator.ReadSudokuFromFile(file);

        // Act
        var result = validator.Validate(board, rowIndex);

        // Assert
        result .ShouldBe(expected);
    }

    [Fact]
    public void Should_ReturnFalse_When_InvalidRow()
    {
        // Arrange
        var sudokuValidator = new SudokuValidator();
        var validator = new RowValidator();
        var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\NotValidSudoku.txt";
        var board = sudokuValidator.ReadSudokuFromFile(file);
        List<bool> rowResults = new List<bool>();

        for (int i = 0; i < 9; i++)
        {
            // Act
            var result = validator.Validate(board, i);
            rowResults.Add(result);
        }

        // Assert
        rowResults.ShouldContain(false);
    }

    [Fact]
    public void ShouldReturnFalse_When_BoardContains_NumberGreaterThan9()
    {
        var sudokuValidator = new SudokuValidator();
        var validator = new RowValidator();
        var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\SudokuWithNumGreaterThan9.txt";
        List<bool> boxResults = new List<bool>();
        var board = sudokuValidator.ReadSudokuFromFile(file);

        for (int i = 0; i < 9; i++)
        {
            // Act
            var result = validator.Validate(board, i);
            boxResults.Add(result);
        }

        // Assert
        boxResults.ShouldContain(false);
    }
}
