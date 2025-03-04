using 计算器工厂.Factorys;
using 计算器工厂.Operations;

namespace 计算器工厂.ContextPackages {
    public static class ContextPackage {
        public static char[] formula;
        // 初始化两个栈，用于存储计算结果和运算符
        public static Stack<double> numbersStack = new Stack<double>();
        public static Stack<char> operatorsStack = new Stack<char>();
        // 存放转换前数字
        public static List<char> numCharsList = new List<char>();

        public static char[] InitFormula(String str) {
            if (OperationFactory.IsOperator(str[0]) && str[0] != '(' && str[0] != ')') {
                str = "0" + str;
            }
            formula = str.ToCharArray();
            return formula;
        }
        
        public static double ChangeList() {
            
            double dnum = double.Parse(new string(numCharsList.ToArray()));
            numCharsList.Clear();
            return dnum;
        }
        public static void PushList() {
            if (numCharsList.Count == 0)return;
            double num = ChangeList();
            numbersStack.Push(num);
        } 

        public static void clearAll() {
            numCharsList.Clear();
            operatorsStack.Clear();
            numbersStack.Clear();
        }
        /// <summary>
        /// 获取上一个运算符的运算结果并推入结果栈
        /// 需要注意num1与num2的赋值顺序
        /// </summary>
        public static void PushResult() {
            double num2 = numbersStack.Pop();
            double num1 = numbersStack.Pop();
            MyOperation myOperation = OperationFactory.CreateOperation(operatorsStack.Pop(), num1, num2);
            double results = myOperation.GetResult();
            numbersStack.Push(results);
            if (operatorsStack.Count > 0 && (operatorsStack.Peek() != '(')) {
                PushResult();
            }
        }

        public static void PushNumberToStack() {
            if (numCharsList.Count == 0) return;
            double number = double.Parse(new string(numCharsList.ToArray()));
            numbersStack.Push(number);
            numCharsList.Clear();
        }
    }
}
