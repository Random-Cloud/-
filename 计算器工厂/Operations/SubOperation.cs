using 计算器工厂.Factorys;
namespace 计算器工厂.Operations {
    [Operator('-')]
    public class SubOperation : MyOperation {
        public SubOperation(double num1, double num2): base(num1, num2){
        }
        public SubOperation() {
            OperatorPrecedence = EOperatorPrecedence.AddOrSub;
        }
        public override double GetResult() {
            return Num1 - Num2;
        }
    }
}