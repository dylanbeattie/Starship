using System;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public class RSOutput : RSStatement {
            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.AppendLine("output:");
                this.expression.Render(sb, depth + 2);
            }
            public readonly RSExpression expression;
            public RSOutput(RSExpression expression) {
                this.expression = expression;
            }
        }
    }
}