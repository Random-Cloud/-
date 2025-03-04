using 计算器工厂.ContextPackages;

namespace 计算器工厂.FormulaHandlers {
    public abstract class FormulaHandler {
        protected FormulaHandler _next;

        public FormulaHandler SetNext(FormulaHandler next) {
            _next = next;
            return this;
        }

        public virtual void Handle(char ch, int index) {
            if (_next != null) {
                _next.Handle(ch, index);
            }
            else {
                throw new InvalidOperationException($"不支持的运算符:{ch}");
            }
        }
    }
}
