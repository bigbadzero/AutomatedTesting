using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit.Sdk;

namespace Soduku.Tests
{
    public class RowValidatorTests
    {
        [Fact]
        public void Should_ReturnTrue_When_ValidRow()
        {
            // Arrange
            var sudokuValidator = new SudokuValidator();
            var validator = new RowValidator();
            var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\ValidSudoku.txt";
            var board = sudokuValidator.ReadSudokuFromFile(file);
            List<bool> rowResults = new List<bool>();

            for(int i = 0; i < 9; i++)
            {
                // Act
                var result = validator.Validate(board, i);
                rowResults.Add(result);
            }

            // Assert
            rowResults.ShouldBeEquivalentTo(new List<bool> { true, true, true, true, true, true, true, true, true });
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
    }
}
