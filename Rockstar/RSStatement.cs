using System.Text;

namespace Starship {
    namespace Rockstar {
        public abstract class RSStatement {
            public abstract void Render(StringBuilder sb, int depth = 0);

        }
    }
}