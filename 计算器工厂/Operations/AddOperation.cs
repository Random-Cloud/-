namespace 计算器工厂.Operations {
    [Operator('+')]
    public class AddOperation : MyOperation {
        
        public override double GetResult() {
            return Num1 + Num2;
        }
        public AddOperation(double num1, double num2) {
            Num1 = num1;
            Num2 = num2;
        }
    }

}