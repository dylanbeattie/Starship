using System;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public class RSString : RSLiteral<System.String> {
            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.Append("string: \"").Append(this.Value).AppendLine("\"");
            }

            public RSString(string value) : base(value) {
            }
        }
    }
}