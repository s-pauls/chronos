using System.Collections.Generic;
using System.Linq;
using Chronos.Utilities.EvaluatorUtility.Enum;
using CodingSeb.ExpressionEvaluator;

namespace Chronos.Utilities.EvaluatorUtility
{
    public class Evaluator
    {
        public Dictionary<string, double> Evaluate(List<Variable> variables)
        {
            var dictionary = new Dictionary<string, double>();

            if (variables == null || !variables.Any())
                return dictionary;

            var evaluator = new ExpressionEvaluator();
            var keys = new List<string>();

            evaluator.PreEvaluateVariable += (sender, arg) =>
            {
                if (!evaluator.Variables.ContainsKey(arg.Name))
                {
                    evaluator.Variables[arg.Name] = 0;
                }
            };

            foreach (var variable in variables)
            {
                if (variable.Type == VariableType.Variable)
                {
                    evaluator.Variables[variable.Name] = double.Parse(variable.Value);
                }
                else if (variable.Type == VariableType.Expression)
                {
                    evaluator.Variables[variable.Name] = new SubExpression(variable.Value);
                    keys.Add(variable.Name);
                }
            }

            foreach (var key in keys)
            {
                dictionary[key] = (double)evaluator.Evaluate(((SubExpression)evaluator.Variables[key]).Expression);
            }

            return dictionary;
        }
    }
}
