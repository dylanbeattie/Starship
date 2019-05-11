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
        Action<object> Output = o => Console.WriteLine(o == null ? "(null)" : o.ToString());
        public RSResult Evaluate(RSStatement statement) {
            RSResult result = null;
            switch (statement) {
                case RSProgram p:
                    foreach (var s in p.Statements) {
                        result = Evaluate(s);
                        if (result.Returnable) return (result);
                    }
                    return result;
                case RSNumber n: return RSResult.FromValue(n.Value);
                case RSString s: return RSResult.FromValue(s.Value);
                case RSOutput o:
                    result = Evaluate(o.Expression);
                    Output(result.Value);
                    return (result);
            }
            throw (new Exception($"I don't know how to evaluate {statement.GetType()} statements"));
        }
    }
}