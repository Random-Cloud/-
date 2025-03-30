using 计算器工厂.ContextPackages;
using 计算器工厂.FormulaHandlers;

namespace 计算器工厂.Logic {
    public class Calculator {

        private static FormulaHandler BuildHandlerChain() {
            // 初始化处理器链
            /*错误的初始化方式：SetNext方法返回当前处理器实例，而非下一个处理器。因此，连续调用SetNext会覆盖之前的设置，导致链式结构断裂
             * var handlerChain = new DigitHandler()
                .SetNext(new BracketHandler())
                .SetNext(new NegativeSignHandler())
                .SetNext(new OperatorHandler());
            */
            // 正确构建处理链
            var digitHandler = new DigitHandler();
            var bracketHandler = new BracketHandler();
            var negativeHandler = new NegativeSignHandler();
            var operatorHandler = new OperatorHandler();
            digitHandler.SetNext(bracketHandler);
            bracketHandler.SetNext(negativeHandler);
            negativeHandler.SetNext(operatorHandler);
            return digitHandler;
        }
        
        public static double GetResult(string str) {
            try {
                char[] formula = ContextPackage.InitFormula(str);
                var handlerChain = BuildHandlerChain();

                // 遍历字符时调用
                for (int i = 0; i < formula.Length; i++) {
                    handlerChain.Handle(formula[i], i);
                }
                ContextPackage.PushNumberToStack();
                if (ContextPackage.operatorsStack.Count > 0) {
                    ContextPackage.PushResult();
                }
                return ContextPackage.numbersStack.Pop();
            }
            // 作者偷懒，不想处理大数运算，直接抛出异常
            catch (OverflowException e) {
                throw new OverflowException("计算结果溢出", e);
            }
        }

        public static void clearAll() {
            ContextPackage.clearAll();
        }

    }
}