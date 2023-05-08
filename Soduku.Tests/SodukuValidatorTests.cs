using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku.Tests
{
    public class SodukuValidatorTests
    {
        [Fact]
        public void Should_ReturnTrue_When_ValidSodoku()
        {
            // Arrange
            var sudokuValidator = new SudokuValidator();
            var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\ValidSudoku.txt";
            
            //Act
            var result = sudokuValidator.Validate(file);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void Should_ReturnFalse_When_NotValidSodoku()
        {
            // Arrange
            var sudokuValidator = new SudokuValidator();
            var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\notValidSudoku.txt";

            //Act
            var result = sudokuValidator.Validate(file);

            // Assert
            result.ShouldBeFalse();
        }
    }
}
