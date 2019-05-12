using System;
using System.Collections.Generic;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public abstract class RSToken {
            public abstract void Render(StringBuilder sb, int depth = 0);

        }
        public abstract class RSFlowControl : RSToken {


        }
        public class RSBreak : RSFlowControl {
            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.Append("break");
            }
        }
        public class RSContinue : RSFlowControl {
            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' '));
                sb.Append("continue");
            }
        }

        public class RSFunction : RSToken {
            public RSVariable Name { get; set; }
            public RSBlock Body { get; set; }
            public List<RSVariable> Args { get; set; }

            public RSFunction(RSVariable name, List<RSVariable> args, RSBlock body) {
                this.Name = name;
                this.Args = args;
                this.Body = body;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                string pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).AppendLine("function definition:");
                Name.Render(sb, depth + 2);
                sb.Append(pad).AppendLine("arguments:");
                foreach (var arg in Args) arg.Render(sb, depth + 2);
                sb.Append(pad).AppendLine("body:");
                Body.Render(sb, depth + 2);


            }
        }
        public class RSCall : RSExpression {
            public RSVariable Name { get; set; }
            public List<RSExpression> Args { get; set; }
            public RSCall(RSVariable name, List<RSExpression> args) {
                this.Name = name;
                this.Args = args;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' ')).AppendLine("function call");
                Name.Render(sb, depth + 2);
                sb.Append(String.Empty.PadLeft(depth, ' ')).AppendLine("arguments:");
                foreach (var arg in Args) arg.Render(sb, depth + 2);
            }
        }

        public static class RSBuiltIn {
            public static readonly RSVariable Unite = new RSVariable("__unite__");
        }

        public class RSVariable : RSToken {
            public string Name { get; set; }
            public RSVariable(string name) {
                this.Name = name;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' ')).Append("variable: ").AppendLine(Name);
            }
        }

        public class RSReturn : RSToken {
            public RSReturn(RSExpression expr) {
                this.Expression = expr;
            }

            public RSExpression Expression { get; }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' ')).AppendLine("return");
                this.Expression.Render(sb, depth + 2);
            }
        }

        public class RSWhile : RSToken {
            public RSExpression Condition { get; set; }
            public RSBlock Body { get; set; }
            public RSWhile(RSExpression condition, RSBlock body) {
                Condition = condition;
                Body = body;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                string pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).AppendLine("while-loop");
                sb.Append(pad).AppendLine("expression");
                Condition.Render(sb, depth + 2);
                sb.Append(pad).AppendLine("body");
                Body.Render(sb, depth + 2);
            }
        }


        public class RSUntil : RSToken {
            public RSExpression Condition { get; set; }
            public RSBlock Body { get; set; }
            public RSUntil(RSExpression condition, RSBlock body) {
                Condition = condition;
                Body = body;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                string pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).AppendLine("until-loop");
                sb.Append(pad).AppendLine("expression");
                Condition.Render(sb, depth + 2);
                sb.Append(pad).AppendLine("body");
                Body.Render(sb, depth + 2);
            }
        }
        public class RSConditional : RSToken {
            public RSExpression Condition { get; set; }
            public RSBlock Consequent { get; set; }
            public RSBlock Alternate { get; set; }
            public RSConditional(RSExpression condition, RSBlock consequent, RSBlock alternate = null) {
                this.Condition = condition;
                this.Consequent = consequent;
                this.Alternate = alternate;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                string pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).AppendLine("conditional");
                sb.Append(pad).AppendLine("expression");
                Condition.Render(sb, depth + 2);
                sb.Append(pad).AppendLine("consequent");
                Consequent.Render(sb, depth + 2);
                sb.Append(pad).AppendLine("alternate");
                Alternate.Render(sb, depth + 2);
            }
        }
    }
}