using Shouldly;
using Soduku.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku.Tests
{
    public class GridTests
    {
        [Fact]
        public void Grid_Validates_WhenBoardIs_9x9()
        {
            var sudokuValidator = new SudokuValidator();
            var board = sudokuValidator.ReadSudokuFromFile("G:\\projects\\AutomatedTesting\\Soduku.Tests\\NotValidSudoku.txt");
            GridValidator gridValidator = new GridValidator();

            var result = gridValidator.IsValid(board);

            result.ShouldBeTrue();
        }

        [Fact]
        public void Grid_DoesNotValidate_WhenBoardIs_9x10()
        {
            var sudokuValidator = new SudokuValidator();
            var board = sudokuValidator.ReadSudokuFromFile("G:\\projects\\AutomatedTesting\\Soduku.Tests\\9x10Grid.txt");
            GridValidator gridValidator = new GridValidator();

            var result = gridValidator.IsValid(board);

            result.ShouldBeFalse();
        }

        [Fact]
        public void Grid_DoesNotValidate_WhenBoardIs_10x9()
        {
            var sudokuValidator = new SudokuValidator();
            var board = sudokuValidator.ReadSudokuFromFile("G:\\projects\\AutomatedTesting\\Soduku.Tests\\10x9Grid.txt");
            GridValidator gridValidator = new GridValidator();

            var result = gridValidator.IsValid(board);

            result.ShouldBeFalse();
        }

        [Fact]
        public void Grid_DoesNotValidate_WhenBoardIs_7x7()
        {
            var sudokuValidator = new SudokuValidator();
            var board = sudokuValidator.ReadSudokuFromFile("G:\\projects\\AutomatedTesting\\Soduku.Tests\\10x9Grid.txt");
            GridValidator gridValidator = new GridValidator();

            var result = gridValidator.IsValid(board);

            result.ShouldBeFalse();
        }
    }
}
