using System;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public class RSMysterious : RSExpression {
            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.AppendLine("mysterious");
            }
        }
    }
}