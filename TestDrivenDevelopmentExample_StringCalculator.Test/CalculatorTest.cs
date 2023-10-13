
namespace TestDrivenDevelopmentExample_StringCalculator.Test
{
    public class CalculatorTest
    {
        [Theory, InlineData("", 0), InlineData("1", 1), InlineData("1,2", 3)]
        public void Add_AddsUpToTwoNumbers_WhenStringIsValid(string calculation, int expected)
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var res = sut.Add(calculation);

            // Assert
            res.Should().Be(expected);
        }

        [Theory, InlineData("1,2,3", 6), InlineData("10,90,10,20", 130)]
        public void Add_AddsUpToAnyNumbers_WhenStringIsValid(string calculation, int expected)
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var res = sut.Add(calculation);

            // Assert
            res.Should().Be(expected);
        }

        [Theory, InlineData("//;\n1;2;", 3), InlineData("//;\n1;2;4;", 7)]
        public void Add_AddsNumbersUsingCustomDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var res = sut.Add(calculation);

            // Assert
            res.Should().Be(expected);
        }

        [Theory, InlineData("1,2,-1", "-1"), InlineData("//;\n1;-2;-4;", "-2,-4")]
        public void Add_ShouldThrowException_WhenNegativeNumbersAreUsed(string calculation, string negativeNumbers)
        {
            // Arrange
            var sut = new Calculator();

            // Act
            Action action = () => sut.Add(calculation);

            // Assert
            action.Should().Throw<Exception>().WithMessage("Negatives not allowed: " + negativeNumbers);
        }
    }
}
