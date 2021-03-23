using System.Collections.Generic;
using Chronos.Utilities.EvaluatorUtility;
using Chronos.Utilities.EvaluatorUtility.Enum;
using Xunit;

namespace Chronos.Utilities.UnitTests
{
    public class EvaluatorTest
    {
        private readonly Evaluator _evaluator;

        public EvaluatorTest()
        {
            _evaluator = new Evaluator();
        }

        [Fact]
        public void Evaluate_ConstantsInExpression_ValidTotalValue()
        {
            var input = new List<Variable>
            {
                new Variable
                {
                    Type = VariableType.Variable,
                    Name = "a",
                    Value = "1"
                },
                new Variable
                {
                    Type = VariableType.Variable,
                    Name = "b",
                    Value = "2"
                },
                new Variable
                {
                    Type = VariableType.Expression,
                    Name = "total",
                    Value = "a+b"
                },
            };

            var result = _evaluator.Evaluate(input);

            Assert.Contains("total", result.Keys);
            Assert.Equal(3, result["total"]);
        }

        [Fact]
        public void Evaluate_ExpressionDependency_ValidTotalValue()
        {
            var input = new List<Variable>
            {
                new Variable
                {
                    Type = VariableType.Variable,
                    Name = "a",
                    Value = "1"
                },
                new Variable
                {
                    Type = VariableType.Variable,
                    Name = "b",
                    Value = "2"
                },
                new Variable
                {
                    Type = VariableType.Expression,
                    Name = "total",
                    Value = "c*2"
                },
                new Variable
                {
                    Type = VariableType.Expression,
                    Name = "c",
                    Value = "a+b"
                },
            };

            var result = _evaluator.Evaluate(input);

            Assert.Contains("c", result.Keys);
            Assert.Contains("total", result.Keys);
            Assert.Equal(3, result["c"]);
            Assert.Equal(6, result["total"]);
        }
    }
}
