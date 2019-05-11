using System;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public enum RSOperator {
            Add,
            Subtract,
            Multiply,
            Divide
        }

        public class RSBinary : RSExpression {

            public RSExpression Lhs { get; set; }
            public RSExpression Rhs { get; set; }
            public RSOperator Operator { get; set; }
            public RSBinary(RSOperator op, RSExpression lhs, RSExpression rhs) {
                this.Operator = op;
                this.Lhs = lhs;
                this.Rhs = rhs;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.AppendLine(Enum.GetName(typeof(RSOperator), this.Operator).ToLowerInvariant());
                this.Lhs.Render(sb, depth + 2);
                this.Rhs.Render(sb, depth + 2);
            }
        }

        public class RSConstant : RSExpression {
            public object Value { get; }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.Append("constant: ");
                if (this.Value == null) {
                    sb.AppendLine("(null)");
                } else {
                    sb.AppendLine(this.Value.GetType().Name + " : " + this.Value.ToString());
                }
            }
            public RSConstant(object value) {
                this.Value = value;
            }
        }
    }
}