using StringCalculatorKata.Console;
using Shouldly;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyString_ReturnsSumOf0()
        {
            var stringCalculator = new StringCalculator();
            var emptyString = String.Empty;

            var result = stringCalculator.Add(emptyString);

            result.ShouldBe(0);
        }

        [Fact]
        public void AddMethod_AddsNumbers_With1_Number()
        {
            var stringCalculator = new StringCalculator();
            var ZeroNumbers = "1";

            var result = stringCalculator.Add(ZeroNumbers);

            result.ShouldBe(1);
        }

        [Fact]
        public void AddMethod_AddsNumbers_With2_Numbers()
        {
            var stringCalculator = new StringCalculator();
            var ZeroNumbers = "1,2";

            var result = stringCalculator.Add(ZeroNumbers);

            result.ShouldBe(3);
        }

        [Fact]
        public void AddMethod_AddsNumbers_WithMixOfNumbers()
        {
            var stringCalculator = new StringCalculator();
            var ZeroNumbers = "1, ,4";

            var result = stringCalculator.Add(ZeroNumbers);

            result.ShouldBe(5);
        }

        [Fact]
        public void AddMethod_IgnoresNewLines()
        {
            var stringCalculator = new StringCalculator();
            var ZeroNumbers = "1\n2,3";

            var result = stringCalculator.Add(ZeroNumbers);

            result.ShouldBe(6);
        }

        [Fact] 
        public void AddMethod_CanUseAnotherDelimiter()
        {
            var stringCalculator = new StringCalculator();
            var ZeroNumbers = "//;\n1;2";

            var result = stringCalculator.Add(ZeroNumbers);

            result.ShouldBe(3);
        }

        [Fact]
        public void AddMethod_ThrowsExceptionIfNegativeNumbersPresent()
        {
            var stringCalculator = new StringCalculator();
            var negativeNumberString = "-1,2";

            Should.Throw<SystemException>(() => stringCalculator.Add(negativeNumberString)).Message.ShouldBe("Negatives not allowed: -1");
        }

        [Fact]
        public void AddMethod_IgnoresNumbersGreaterThan1000()
        {
            var stringCalculator = new StringCalculator();
            var NumberStringWithNumberOver1000 = "1001,2";

            var result = stringCalculator.Add(NumberStringWithNumberOver1000);

            result.ShouldBe(2);

        }

        [Fact]
        public void AddMethod_DelimitersCanBeAnyLength()
        {
            var stringCalculator = new StringCalculator();
            var crazyDelmiter = "//[|||]\n1|||2|||3";

            var result = stringCalculator.Add(crazyDelmiter);

            result.ShouldBe(6);
        }

        [Fact]
        public void AddMethod_AllowsMultipleDelimiters()
        {
            var stringCalculator = new StringCalculator();
            var MultipleDelimiters = "//[|][%]\n1|2%3";

            var result = stringCalculator.Add(MultipleDelimiters);

            result.ShouldBe(6);
        }

        [Fact]
        public void AddMethod_AllowsMultipleDelimitersOfAnyLength()
        {
            var stringCalculator = new StringCalculator();
            var MultipleDelimiters = "//[||][%%]\n1||2%%3";

            var result = stringCalculator.Add(MultipleDelimiters);

            result.ShouldBe(6);
        }
    }
}