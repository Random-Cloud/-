using 计算器工厂.Factorys;
using 计算器工厂.Operations;
using 计算器工厂.ContextPackages;

namespace 计算器工厂.FormulaHandlers {
    /// <summary>
    /// 处理运算符
    /// </summary>
    public class OperatorHandler : FormulaHandler {
        
        public bool CheckPriority(char newOperator, char oldOperator) {

            MyOperation myOldOperation = OperationFactory.CreateOperation(oldOperator);
            if (myOldOperation.OperatorPrecedence == EOperatorPrecedence.Bracket) {
                return false;
            }
            MyOperation myNewOperation = OperationFactory.CreateOperation(newOperator);
            return myNewOperation.OperatorPrecedence <= myOldOperation.OperatorPrecedence ? true : false;
        }
        /// <summary>
        ///  处理右括号：弹出栈内运算符直到遇到左括号
        /// </summary>
        /// <param name="ch"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void FindRightBracket(char ch) {
            while (ContextPackage.operatorsStack.Peek() != '(') {
                ContextPackage.PushResult();
             }
            if (ContextPackage.operatorsStack.Count == 0) {
                throw new ArgumentNullException($"括号不匹配,formula[i]=({ch})");
            }
            ContextPackage.operatorsStack.Pop();
        }
        /// <summary>
        /// 如果满足运算条件则进行计算（数字数量大于等于2，且上一个运算符符合运算优先级）
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="index"></param>
        public override void Handle(char ch, int index) {

            if (OperationFactory.IsOperator(ch)) {
                if (ContextPackage.numbersStack.Count >= 2 && CheckPriority(ch, ContextPackage.operatorsStack.Peek())) {
                    ContextPackage.PushResult();
                }
                if(ch == ')')FindRightBracket(ch);
                else ContextPackage.operatorsStack.Push(ch);
            }
            else {
                base.Handle(ch, index);
            }
            
        }
    }
}
