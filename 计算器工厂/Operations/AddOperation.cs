using System.Security.Cryptography.X509Certificates;
using 计算器工厂.Factorys;

namespace 计算器工厂.Operations {
    [Operator('+')]
    public class AddOperation : MyOperation {
        public AddOperation(double num1, double num2) : base(num1, num2) {}
        public AddOperation() {
            OperatorPrecedence = EOperatorPrecedence.AddOrSub;
        }
        // 可以写成 public override double GetResult() => Num1 + Num2;
        public override double GetResult() {
            return Num1 + Num2;
        }
       
    }

}