using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public class RSProgram : RSStatement {

            public override string ToString() {
                var sb = new StringBuilder();
                sb.AppendLine("program:");
                foreach (var s in Statements) s.Render(sb, 2);
                return (sb.ToString());
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(this.ToString());
            }

            public IList<RSStatement> Statements { get; } = new List<RSStatement>();
            public RSProgram(IEnumerable<RSStatement> statements) {
                this.Statements = statements.ToList();
            }
        }
    }
}