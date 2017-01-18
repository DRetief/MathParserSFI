using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int16;

namespace SFIMathParser
{
    public class SimpleExpressionClass
    {
        public static int CalculateExpression(string expression)
        {
            if (expression.Length == 5) // simple expression
            {
                return CalculateSimpleExpression(expression);
            }
            else if (expression.Length == 13) // complex expression
            {
                return ComplexExpressionClass.CalculateComplexExpression(expression);
            }
            else // argument error
            {
                throw new ArgumentException("Input error. Expression is wrong length.");
            }
        }

        public static int CalculateSimpleExpression(string expression)
        {
            var numbers = GetSimpleInts(expression);
            var mathOperator = GetSimpleOperator(expression);
            return GetSimpleResult(numbers, mathOperator);
        }
        
        public static List<int> GetSimpleInts(string mathExpression)
        {
            var charList = mathExpression.Split(' ');
            try
            {
                return new List<int> {Parse(charList[0]), Parse(charList[2])};
            }
            catch
            {
                throw new Exception("Numbers not found in correct positions.");
            }
        }

        public static string GetSimpleOperator(string mathExpression)
        {
            return mathExpression.Split(' ')[1];
        }

        public static int GetSimpleResult(List<int> numbers, string mathOperator)
        {
            switch (mathOperator)
            {
                case "+":
                    return numbers[0] + numbers[1];
                case "-":
                    return numbers[0] - numbers[1];
                case "/":
                    return numbers[0]/numbers[1];
                case "x":
                    return numbers[0]*numbers[1];
                default:
                    throw new ArgumentException("Valid math operator not found.");
            }
        }
    }

    public class ComplexExpressionClass
    {
        public static int CalculateComplexExpression(string expression)
        {
            var numbers = GetComplexInts(expression);
            var mathOperators = GetComplexOperators(expression);
            for (var i = 0; i < 2; i++)
            {
                var useIndexes = DetermineComplexOrder(mathOperators);
                var simpleResult = SimpleExpressionClass.GetSimpleResult(
                    new List<int> { numbers[useIndexes[0]], numbers[useIndexes[1]] },
                    mathOperators[useIndexes[0]]);
                numbers = RestructureNumberList(useIndexes, numbers, simpleResult);
                mathOperators.RemoveAt(useIndexes[0]);
            }
            return SimpleExpressionClass.GetSimpleResult(numbers, mathOperators[0]);
        }

        public static List<int> GetComplexInts(string mathExpression)
        {
            var charList = mathExpression.Split(' ');
            try
            {
                return new List<int>
                {
                    Parse(charList[0]),
                    Parse(charList[2]),
                    Parse(charList[4]),
                    Parse(charList[6])
                };
            }
            catch
            {
                throw new Exception("Numbers not found in correct positions.");
            }
        }

        public static List<string> GetComplexOperators(string mathExpression)
        {
            var charList = mathExpression.Split(' ');
            return new List<string> { charList[1], charList[3], charList[5] };
        }

        public static int[] DetermineComplexOrder(List<string> mathOperators)
        {
            // Determine the order for the calculation to proceed. and return 
            var allOperators = new[] { "/", "x", "+", "-" };
            foreach (var testOperator in allOperators)
            {
                if (mathOperators.Contains(testOperator))
                    return new[] { mathOperators.IndexOf(testOperator), mathOperators.IndexOf(testOperator) + 1 };
            }
            throw new ArithmeticException("Error. Incorrect operator.");
        }

        public static List<int> RestructureNumberList(int[] usedIndexes, List<int> numbers, int result)
        {
            numbers[usedIndexes[0]] = result;
            numbers.RemoveAt(usedIndexes[1]);
            return numbers;
        }
    }
}
