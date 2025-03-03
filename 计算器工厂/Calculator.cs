using 计算器工厂.Operations;

namespace 计算机工厂 {
    class Calculator {
        
        private static bool IsLeftBracket(char ch) {
            return ch == '(';
        }
        private static bool IsRightBracket(char ch) {
            return ch == ')';
        }
        // 初始化两个栈，用于存储计算结果和运算符
        private static Stack<double> numbersStack = new Stack<double>();
        private static Stack<char> operatorsStack = new Stack<char>();

        // 存放转换前数字
        private static List<char> numCharsList = new List<char>();

        public static bool CheckPriority(char newOperator, char oldOperator) {
            
            MyOperation myOldOperation = OperationFactory.CreateOperation(oldOperator);
            if (myOldOperation.OperatorPrecedence == EOperatorPrecedence.Bracket) {
                return false;
            }
            MyOperation myNewOperation = OperationFactory.CreateOperation(newOperator);
            return myNewOperation.OperatorPrecedence <= myOldOperation.OperatorPrecedence ? true: false ;
        }


        /// <summary>
        /// 将list中的字符转化为数字并压入栈中，压栈后清空list
        /// </summary>
        /// <param name="numCharsList"></param>
        private static void PushNumberToStack(List<char> numCharsList) {
            if (numCharsList.Count == 0)
                return;
            double number = double.Parse(new string(numCharsList.ToArray()));
            numbersStack.Push(number);
            numCharsList.Clear();
        }
        public static double GetResult(string str) {
            char[] formula = str.ToCharArray();
            
            // 转化算式
            for (int i = 0; i < formula.Length; i++) {
                // 读取数字
                if (char.IsDigit(formula[i]) || formula[i] == '.') {
                    numCharsList.Add(formula[i]);
                    continue;
                }
                if (formula[i] == '(') {
                    operatorsStack.Push(formula[i]);
                    continue;
                }
                // 处理负号（仅在正确位置解析为数字符号）
                if (formula[i] == '-' && IsNegativeSign(formula, i)) {
                    numCharsList.Add('-');
                    i++; // 跳过负号，继续解析数字
                    while (i < formula.Length && (char.IsDigit(formula[i]) || formula[i] == '.')) {
                        numCharsList.Add(formula[i]);
                        i++;
                    }
                    i--; // 回退索引
                    continue;
                }

                // 检测到运算符，或者遍历完字符串时，存储数字
                if (numCharsList.Count != 0 || i == (formula.Length - 1)) {
                    PushNumberToStack(numCharsList);
                }
                // 检测运算符合法性
                if (!OperationFactory.IsOperator(formula[i])) {
                    throw new InvalidOperationException($"不支持的运算符:{formula[i]}");
                }

                // 如果该字符非括号,且满足运算优先级,则立即运算；反之存储符号
                if (numbersStack.Count >= 2 && CheckPriority(formula[i], operatorsStack.Peek())) {
                    PushResult();
                }
                if (IsRightBracket(formula[i])) {
                    // 处理右括号：弹出栈内运算符直到遇到左括号
                    while (!IsLeftBracket(operatorsStack.Peek())) {
                        PushResult();
                    }
                    if (operatorsStack.Count == 0) {
                        throw new ArgumentNullException($"括号不匹配,formula[i]=({formula[i]},{i})");
                    }
                    operatorsStack.Pop();
                    continue;
                }
                operatorsStack.Push(formula[i]);

            }
            PushNumberToStack(numCharsList);
            if (operatorsStack.Count > 0) {
                PushResult();
            }
            return numbersStack.Pop();
        }
        private static void PushResult() {
            double num2 = numbersStack.Pop(); // 第二个元素
            double num1 = numbersStack.Pop(); // 第一个元素
            MyOperation myOperation = OperationFactory.CreateOperation(operatorsStack.Pop(), num1, num2);
            double results = myOperation.GetResult();
            numbersStack.Push(results);
            if (operatorsStack.Count > 0 && !IsLeftBracket(operatorsStack.Peek())) {
                PushResult();
            }
        }
        private static bool IsNegativeSign(char[] formula, int index) {
            // 负号位于开头，或前一个字符是运算符/左括号
            return index == 0 ||
                   ((formula[index -1] != ')' && 
                    OperationFactory.IsOperator(formula[index - 1])));
        }
    }
}