using System;
using System.Collections.Generic;
using Starship.Rockstar;
namespace Starship.Rockstar.Interpreter {
    public class RSResult {
        public static RSResult FromValue(object value) {
            return new RSResult { Value = value };
        }

        public object Value { get; set; }
        public bool Returnable { get; set; }
    }

    public class RSEnvironment {
        public Action<object> Output = o => Console.WriteLine(o == null ? "(null)" : o.ToString());
        public RSResult Evaluate(RSToken statement) {
            RSResult result = null;
            switch (statement) {
                case RSBlock p:
                    foreach (var s in p.Tokens) {
                        result = Evaluate(s);
                        if (result.Returnable) return (result);
                    }
                    return result;
                case RSConstant c: return RSResult.FromValue(c.Value);
                case RSBinary b: return Binary(b);
                case RSNumber n: return RSResult.FromValue(n.Value);
                case RSString s: return RSResult.FromValue(s.Value);
                case RSOutput o:
                    result = Evaluate(o.Expression);
                    Output(result.Value);
                    return (result);
            }
            throw (new Exception($"I don't know how to evaluate {statement.GetType()} statements"));
        }

        public RSResult Binary(RSBinary binary) {
            switch (binary.Operator) {
                case RSOperator.Add: return Apply(binary.Lhs, binary.Rhs, (a, b) => a + b);
                case RSOperator.Subtract: return Apply(binary.Lhs, binary.Rhs, (a, b) => a - b);
                case RSOperator.Multiply: return Apply(binary.Lhs, binary.Rhs, (a, b) => a * b);
                case RSOperator.Divide: return Apply(binary.Lhs, binary.Rhs, (a, b) => a / b);
            }
            throw (new NotImplementedException($"I don't know how to evaluate {binary.Operator} operations"));
        }

        public RSResult Apply(RSExpression lhs, RSExpression rhs, Func<dynamic, dynamic, dynamic> f) {
            var lhsValue = Evaluate(lhs).Value as dynamic;
            var rhsValue = Evaluate(rhs).Value as dynamic;
            return RSResult.FromValue(f(lhsValue, rhsValue));
        }
    }
}