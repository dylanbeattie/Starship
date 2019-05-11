using System;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public class RSNumber : RSLiteral<System.Decimal> {
            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.Append("number: ").AppendLine(this.Value.ToString());
            }

            public RSNumber(decimal value) : base(value) { }
        }
    }
}