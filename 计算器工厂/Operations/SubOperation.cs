namespace 计算器工厂.Operations {
    [Operator('-')]
    public class SubOperation : MyOperation {
        public SubOperation(double num1, double num2) {
            Num1 = num1;
            Num2 = num2;
        }
        public override double GetResult() {
            return Num1 - Num2;
        }
    }
}