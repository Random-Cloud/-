namespace 计算器工厂.Operations {
    public class OperationFactorySwitch {
        // 运算工厂，使用Switch判断初始化对象,扩展时违反开放封闭原则，未使用
       
        /* !!!注意!!!
         * 由于pop取出的是栈顶的数字
         * 因此首先被传进来的是第二个操作数
         * 写反num2和num1会导致不符合交换律的公式错误
         */
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