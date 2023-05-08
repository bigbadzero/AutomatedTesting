using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku.Tests
{
    public class ColumnValidatorTests
    {
        [Fact]
        public void Should_ReturnTrue_When_AllColumnsValid()
        {
            // Arrange
            var sudokuValidator = new SudokuValidator();
            var validator = new ColumnValidator();
            var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\ValidSudoku.txt";
            var board = sudokuValidator.ReadSudokuFromFile(file);
            List<bool> columnResults = new List<bool>();

            for (int i = 0; i < 9; i++)
            {
                // Act
                var result = validator.Validate(board, i);
                columnResults.Add(result);
            }

            // Assert
            columnResults.ShouldBeEquivalentTo(new List<bool> { true, true, true, true, true, true, true, true, true });
        }

        [Fact]
        public void Should_ReturnFalse_When_InvalidColumn()
        {
            // Arrange
            var sudokuValidator = new SudokuValidator();
            var validator = new ColumnValidator();
            var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\NotValidSudoku.txt";
            var board = sudokuValidator.ReadSudokuFromFile(file);
            List<bool> columnResults = new List<bool>();

            for (int i = 0; i < 9; i++)
            {
                // Act
                var result = validator.Validate(board, i);
                columnResults.Add(result);
            }

            // Assert
            columnResults.ShouldContain(false);
        }

    }
}
