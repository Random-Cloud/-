using 计算器工厂.Factorys;
namespace 计算器工厂.Operations {
    [Operator(')')]
    public class BracketRightOperation : MyOperation {
        public BracketRightOperation():base() {
            // OperatorPrecedence = EOperatorPrecedence.Bracket;
        }
        public override double GetResult() {
            throw new NotImplementedException("暂不支持括号参与运算");
        }
    }
}