using System.Collections.Generic;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public class RSProgram {

            public override string ToString() {
                var sb = new StringBuilder();
                sb.AppendLine("program:");
                foreach (var s in Statements) s.Render(sb, 2);
                return (sb.ToString());
            }

            public IList<RSStatement> Statements { get; } = new List<RSStatement>();
            public RSProgram(IList<RSStatement> statements) {
                this.Statements = statements;
            }
        }
    }
}