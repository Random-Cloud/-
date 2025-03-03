namespace 计算器工厂.Operations {
    public class MyOperation {

        private double _num1;
        private double _num2;
        private EOperatorPrecedence _operatorPrecedence;
        
        // 使用属性来确保访问权限
        public double Num1 {
            get {
                return _num1;
            }
            set {
                _num1 = value;
            }
        }
        public double Num2 {
            get {
                return _num2;
            }
            set {
                _num2 = value;
            }
        }
        public EOperatorPrecedence OperatorPrecedence {
            get {
                return _operatorPrecedence;
            }
            protected set {
                _operatorPrecedence = value;
            }
        }



        public MyOperation(double num1, double num2) {
            Num1 = num1;
            Num2 = num2;
        }
        public MyOperation() {
            OperatorPrecedence = EOperatorPrecedence.Bracket;
        }

        public virtual double GetResult() {
            double result = 0;
            return result;
        }

        

    }

}