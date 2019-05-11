namespace Starship {
    namespace Rockstar {
        public abstract class RSLiteral<T> : RSExpression {
            public T Value { get; set; }
            public RSLiteral(T value) {
                this.Value = value;
            }
        }
    }
}