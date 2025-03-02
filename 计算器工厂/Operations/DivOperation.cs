using 计算器工厂.Operations;

namespace 计算器工厂.Operations {
    [Operator('/')]
    public class DivOperation : MyOperation {
        public DivOperation(double num1, double num2) {
            Num1 = num1;
            Num2 = num2;
        }
        public override double GetResult() {
            if (Num2 == 0) {
                // 除数为0时抛出异常，也可用Console.Writeline()代替。
                throw new DivideByZeroException("除数不能为0！");
            }
            return Num1 / Num2;

        }
    }

}