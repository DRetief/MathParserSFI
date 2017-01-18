using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SFIMathParser;


namespace SHIMathParserUnitTests
{
    [Collection("SimpleExpressionTests")]
    public class SimpleExpressionTestClass
    {
        [Fact]
        public void GetSimpleIntsTest()
        {
            var intList = SimpleExpressionClass.GetSimpleInts("1 + 2");
            Assert.Equal(new List<int> {1, 2}, intList);
        }

        [Fact]
        public void GetSimpleOperatorTest()
        {
            var mathOperator = SimpleExpressionClass.GetSimpleOperator("1 + 2");
            Assert.Equal("+", mathOperator);
        }

        [Fact]
        public void GetSimpleResultTest()
        {
            var result = SimpleExpressionClass.GetSimpleResult(new List<int> { 1, 2 }, "+");
            Assert.Equal(3, result);
        }
    }

    [Collection("ComplexExpressionTests")]
    public class ComplexExpressionTestClass
    {
        [Fact]
        public void GetComplexIntsTest()
        {
            var intList = ComplexExpressionClass.GetComplexInts("1 + 2 x 6 / 3");
            Assert.Equal(new List<int> { 1, 2, 6, 3 }, intList);
        }

        [Fact]
        public void GetComplexOperatorTest()
        {
            var mathOperators = ComplexExpressionClass.GetComplexOperators("1 + 2 x 6 / 3");
            Assert.Equal(new List<string> { "+", "x", "/" }, mathOperators);
        }

        [Fact]
        public void DetermineComplexOrderTest()
        {
            var numbersToUse = ComplexExpressionClass.DetermineComplexOrder(new List<string> { "+", "x", "/" });
            Assert.Equal(new List<int> { 2, 3 }, numbersToUse);
        }

        [Fact]
        public void GetFirstResultTest()
        {
            var numbers = new List<int> { 1, 2, 6, 3 };
            var mathOperators = new List<string> { "+", "x", "/" };
            var numbersToUse = ComplexExpressionClass.DetermineComplexOrder(new List<string> { "+", "x", "/" });
            var firstResult = SimpleExpressionClass.GetSimpleResult(
                new List<int> { numbers[numbersToUse[0]], numbers[numbersToUse[1]] },
                mathOperators[numbersToUse[0]]);
            Assert.Equal(2, firstResult);
        }

        [Fact]
        public void RestructureNumbersListTest()
        {
            var numbers = new List<int> { 1, 2, 6, 3 };
            var mathOperators = new List<string> { "+", "x", "/" };
            var numbersToUse = ComplexExpressionClass.DetermineComplexOrder(mathOperators);
            var firstResult = SimpleExpressionClass.GetSimpleResult(
                new List<int> { numbers[numbersToUse[0]], numbers[numbersToUse[1]] },
                mathOperators[numbersToUse[0]]);
            numbers = ComplexExpressionClass.RestructureNumberList(numbersToUse, numbers, firstResult);
            Assert.Equal(new List<int> { 1, 2, 2 }, numbers);
        }

        [Fact]
        public void GetSecondResultTest()
        {
            var simpleResult = 0;
            var numbers = new List<int> { 1, 2, 6, 3 };
            var mathOperators = new List<string> { "+", "x", "/" };
            for (var i = 0; i < 2; i++)
            {
                var useIndexes = ComplexExpressionClass.DetermineComplexOrder(mathOperators);
                simpleResult = SimpleExpressionClass.GetSimpleResult(
                    new List<int> { numbers[useIndexes[0]], numbers[useIndexes[1]] },
                    mathOperators[useIndexes[0]]);
                numbers = ComplexExpressionClass.RestructureNumberList(useIndexes, numbers, simpleResult);
                mathOperators.RemoveAt(useIndexes[0]);
            }
            Assert.Equal(4, simpleResult);
            Assert.Equal(new List<int> { 1, 4 }, numbers);
            Assert.Equal(new List<string> { "+" }, mathOperators);
        }
    }

    [Collection("FinalBackEndTests")]
    public class FinalBackEndTestClass
    {
        [Fact]
        public void AllSimpleExpressionsTest()
        {
            var simpleExpressions = new[] { "1 + 2", "3 - 2", "2 x 3", "6 / 2" };
            var results = new List<int>();
            foreach (var simpleExpression in simpleExpressions)
            {
                results.Add(SimpleExpressionClass.CalculateSimpleExpression(simpleExpression));
            }
            Assert.Equal(3, results[0]);
            Assert.Equal(1, results[1]);
            Assert.Equal(6, results[2]);
            Assert.Equal(3, results[3]);
        }

        [Fact]
        public void GetFinalResultTest()
        {
            var expression1 = "1 + 2 x 6 / 3";
            var expression2 = "4 x 3 - 6 / 2";
            var result1 = ComplexExpressionClass.CalculateComplexExpression(expression1);
            var result2 = ComplexExpressionClass.CalculateComplexExpression(expression2);
            Assert.Equal(5, result1);
            Assert.Equal(9, result2);
        }
    }
}
