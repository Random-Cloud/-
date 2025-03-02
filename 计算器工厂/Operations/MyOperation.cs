namespace 计算器工厂.Operations {

    public class MyOperation {

        private double _num1;
        private double _num2;
        private int _priority;
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
        public int Priority {
            get {
                return _priority;
            }
            protected set {
                _priority = value;
            }
        }

        public virtual double GetResult() {
            double result = 0;
            return result;
        }

    }

}