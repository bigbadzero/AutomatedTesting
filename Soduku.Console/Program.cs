
var file = "G:\\projects\\AutomatedTesting\\Soduku.Console\\input.txt";
var validator = new SudokuValidator();
var validSodoku = validator.Validate(file);
Console.WriteLine(validSodoku);