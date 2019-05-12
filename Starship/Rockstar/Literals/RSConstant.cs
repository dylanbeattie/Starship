using System;
using System.Collections.Generic;
using System.Text;

namespace Starship {
    namespace Rockstar {
        public enum RSOperator {
            Add,
            Subtract,
            Multiply,
            Divide,
            And,
            Or,
            Not,
            Nor
        }
        public enum RSComparator {
            Equal,
            NotEqual,
            GreaterThan,
            LessThan,
            GreaterThanOrEqualTo,
            LessThanOrEqualTo

        }

        public class RSPronoun : RSVariable {
            public RSPronoun(string name) : base(name) {
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' ')).AppendLine("pronoun");
            }
        }

        public class RSIncrement : RSExpression {
            public int Multiple { get; set; }
            public RSVariable Variable { get; set; }
            public RSIncrement(RSVariable v, int multiple) {
                this.Variable = v;
                this.Multiple = multiple;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                var pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).AppendLine("increment");
                sb.Append(pad).Append("  ").Append("multiple: ").AppendLine(Multiple.ToString());
                Variable.Render(sb, depth + 2);
            }
        }

        public class RSDecrement : RSExpression {
            public int Multiple { get; set; }
            public RSVariable Variable { get; set; }
            public RSDecrement(RSVariable v, int multiple) {
                this.Variable = v;
                this.Multiple = multiple;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                var pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).AppendLine("increment");
                sb.Append(pad).Append("  ").Append("multiple: ").AppendLine(Multiple.ToString());
                Variable.Render(sb, depth + 2);
            }
        }

        public class RSListen : RSExpression {
            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' ')).AppendLine("readline");
            }
        }

        public class RSLookup : RSExpression {
            public RSLookup(RSVariable variable) {
                Variable = variable;
            }

            public RSVariable Variable { get; }

            public override void Render(StringBuilder sb, int depth = 0) {
                sb.Append(String.Empty.PadLeft(depth, ' ')).AppendLine("lookup");
                Variable.Render(sb, depth + 2);
            }
        }
        public class RSAssign : RSToken {
            public RSVariable Variable { get; }
            public RSExpression Expression { get; }
            public RSAssign(RSVariable v, RSExpression e) {
                this.Variable = v;
                this.Expression = e;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                var pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).Append("assign");
                Variable.Render(sb, depth + 2);
                Expression.Render(sb, depth + 2);
            }
        }

        public class RSEnlist : RSExpression {
            public RSEnlist(RSVariable variable) {
                this.Variable = variable;
            }

            public RSVariable Variable { get; }

            public override void Render(StringBuilder sb, int depth = 0) {
                var pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).Append("enlist");
            }
        }
        public class RSDelist : RSExpression {

            public RSDelist(RSVariable source, List<RSVariable> targets) {
                this.Source = source;
                this.Targets = targets;
            }

            public RSVariable Source { get; }
            public List<RSVariable> Targets { get; }

            public override void Render(StringBuilder sb, int depth = 0) {
                var pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).Append("delist");
            }
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

        public class RSComparison : RSExpression {
            public RSComparator Comparator { get; set; }
            public RSExpression Lhs { get; set; }
            public RSExpression Rhs { get; set; }
            public RSComparison(RSComparator comp, RSExpression lhs, RSExpression rhs) {
                Lhs = lhs;
                Rhs = rhs;
                Comparator = comp;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                var pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).AppendLine(Enum.GetName(typeof(RSComparator), Comparator));
                Lhs.Render(sb, depth + 2);
                Rhs.Render(sb, depth + 2);
            }
        }

        public class RSNegate : RSExpression {

            public RSExpression Expression { get; set; }
            public RSNegate(RSExpression expr) {
                this.Expression = expr;
            }

            public override void Render(StringBuilder sb, int depth = 0) {
                var pad = String.Empty.PadLeft(depth, ' ');
                sb.Append(pad).AppendLine("not");
                Expression.Render(sb, depth + 2);
            }
        }
    }
}
