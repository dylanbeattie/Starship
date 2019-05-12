using System;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public class RSOutput : RSToken {
            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.AppendLine("output:");
                this.Expression.Render(sb, depth + 2);
            }
            public readonly RSExpression Expression;
            public RSOutput(RSExpression expression) {
                this.Expression = expression;
            }
        }
    }
}