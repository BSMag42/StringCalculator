using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculator_AddShould
    {
        private Calculator sutCalculator;

        public StringCalculator_AddShould()
        {
            sutCalculator = new Calculator();
        }

        [Fact]
        public void Return0_GivenEmptyString()
        {
            int result = sutCalculator.Add("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(1,"1")]
        [InlineData(2, "2")]
        [InlineData(42, "42")]
        public void ReturnNumber_GivenSingleNumber(int expected, string input)
        {
            int result = sutCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2,"1,1")]
        [InlineData(3, "2,1")]
        [InlineData(13, "2,11")]
        public void ReturnSum_GivenTwoNumbers(int expected, string input)
        {        
            int result = sutCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(18, "2,11,5")]
        public void ReturnSum_GivenMoreThanTwoNumbers(int expected, string input)
        {           
            int result = sutCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(18, "2\n11,5")]
        [InlineData(20, "2\n11,5\n2")]
        public void ReturnSum_GivenNewLineSplit(int expected, string input)
        {           
            int result = sutCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReturnSumOfNumbers_GivenCustomDelimiters()
        {
            var result = sutCalculator.Add("//;\n1;2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void ReturnNegativeNumber_GivenNegativeNumber()
        {
            Exception ex = Assert.Throws<Exception>(() => sutCalculator.Add("2,-1"));
            Assert.Equal("negatives not allowed -1", ex.Message);
        }



    }
}
