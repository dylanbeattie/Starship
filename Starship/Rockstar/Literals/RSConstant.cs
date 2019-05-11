using System;
using System.Text;

namespace Starship {
    namespace Rockstar {
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