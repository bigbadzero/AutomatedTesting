﻿using Shouldly;
using System.Runtime.CompilerServices;

namespace Soduku.Tests;

public class BoxValidatorTests
{
    [Fact]
    public void Should_ReturnTrue_When_AllBoxesValid()
    {
        // Arrange
        var sudokuValidator = new SudokuValidator();
        var validator = new BoxValidator();
        var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\ValidSudoku.txt";
        var board = sudokuValidator.ReadSudokuFromFile(file);
        List<bool> boxResults = new List<bool>();

        for (int i = 0; i < 9; i++)
        {
            // Act
            var result = validator.Validate(board, i);
            boxResults.Add(result);
        }

        // Assert
        boxResults.ShouldBeEquivalentTo(new List<bool> { true, true, true, true, true, true, true, true, true });
    }

    [Fact]
    public void Should_ReturnFalse_When_InvalidBox()
    {
        // Arrange
        var sudokuValidator = new SudokuValidator();
        var validator = new BoxValidator();
        var file = "G:\\projects\\AutomatedTesting\\Soduku.Tests\\NotValidSudoku.txt";
        var board = sudokuValidator.ReadSudokuFromFile(file);
        List<bool> boxResults = new List<bool>();

        for (int i = 0; i < 9; i++)
        {
            // Act
            var result = validator.Validate(board, i);
            boxResults.Add(result);
        }

        // Assert
        boxResults.ShouldContain(false);
    }

    [Fact]
    public void ShouldReturnFalse_When_BoardContains_NumberGreaterThan9()
    {
        var sudokuValidator = new SudokuValidator();
        var validator = new BoxValidator();
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
