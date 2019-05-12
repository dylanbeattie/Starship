using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public class RSBlock : RSToken {

            public override string ToString() {
                var sb = new StringBuilder();
                sb.AppendLine("program:");
                foreach (var s in Tokens) s.Render(sb, 2);
                return (sb.ToString());
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(this.ToString());
            }

            public List<RSToken> Tokens { get; } = new List<RSToken>();
            public RSBlock(IEnumerable<RSToken> tokens) {
                this.Tokens = tokens.ToList();
            }
            public RSBlock(RSToken token) {
                this.Tokens = new List<RSToken> { token };
            }
            public RSBlock(RSToken head, IEnumerable<RSToken> tail) {
                this.Tokens = new List<RSToken>();
                this.Tokens.Add(head);
                this.Tokens.AddRange(tail);
            }
        }
    }
}