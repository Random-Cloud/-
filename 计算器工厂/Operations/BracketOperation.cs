namespace 计算器工厂.Operations {
    [Operator('(')]
    public class BracketLeftOperation : MyOperation {
        public BracketLeftOperation() {
            OperatorPrecedence = EOperatorPrecedence.Bracket;
        }
        public override double GetResult() {
            throw new NotImplementedException("暂不支持括号参与运算");
        }
    }
    [Operator(')')]
    public class BracketRightOperation : MyOperation {
        public BracketRightOperation() {
            OperatorPrecedence = EOperatorPrecedence.Bracket;
        }
        public override double GetResult() {
            throw new NotImplementedException("暂不支持括号参与运算");
        }
    }
}