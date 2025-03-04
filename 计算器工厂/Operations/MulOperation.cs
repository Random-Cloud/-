using 计算器工厂.Factorys;
namespace 计算器工厂.Operations {
    [Operator('*')]
    public class MulOperation : MyOperation {
        public MulOperation(double num1, double num2): base(num1, num2) {
        }
        public MulOperation() {
            OperatorPrecedence = EOperatorPrecedence.MulOrDiv;
        }
        public override double GetResult() {
            return Num1 * Num2;
        }

    }

}