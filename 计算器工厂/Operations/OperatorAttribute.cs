
namespace 计算器工厂.Operations {
    [AttributeUsage(AttributeTargets.Class)]
    internal class OperatorAttribute : Attribute {
        public char Operator {
            get;
        }
        public OperatorAttribute(char op) => Operator = op;
    }
}