namespace 计算器工厂.Operations {
    public class OperationFactorySwitch {
        // 运算工厂，使用Switch判断初始化对象,扩展时违反开放封闭原则，未使用
       
        
        public static MyOperation CreatOperation(char op,double num2, double num1) {
            MyOperation operation = new MyOperation();
            switch (op) {
                case '+':
                    operation = new AddOperation(num1, num2);
                    break;
                case '-':
                    operation = new SubOperation(num1, num2);
                    break;
                case '*':
                    operation = new MulOperation(num1, num2);
                    break;
                case '/':
                    operation = new DivOperation(num1, num2);
                    break;
                default:
                    throw new NotSupportedException($"不支持的运算符！,{num1}{op}{num2}");
            }
            return operation;
        }
    }

}