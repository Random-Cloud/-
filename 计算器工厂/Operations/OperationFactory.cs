

using System.Reflection;

namespace 计算器工厂.Operations {
    public class OperationFactory {
        // 使用反射生成对应的计算工厂，扩展时仅需新增对应计算类，无需修改工厂逻辑
        private static readonly Dictionary<char, Type> _operatorMap = new Dictionary<char, Type>();

        static OperationFactory() {
            // 程序启动时预加载所有操作类
            var operationTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsSubclassOf(typeof(MyOperation)) && !t.IsAbstract);

            foreach (var type in operationTypes) {
                var attr = type.GetCustomAttribute<OperatorAttribute>();
                if (attr != null) {
                    _operatorMap[attr.Operator] = type;
                }
            }
        }

        public static MyOperation CreatOperation(char op, double num1, double num2) {
            if (!_operatorMap.TryGetValue(op, out Type operationType)) {
                throw new NotSupportedException($"不支持的运算符：{op}");
            }
            return (MyOperation)Activator.CreateInstance(operationType, num1, num2);
        }
    }

}