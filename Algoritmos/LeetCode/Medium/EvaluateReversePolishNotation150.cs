namespace Algoritmos.LeetCode.Medium
{
    public static class EvaluateReversePolishNotation150
    {
        public static void Call()
        {
            string[] tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            int result = EvalRPN(tokens);
        }

        public static int EvalRPN(string[] tokens)
        {
            List<string> operators = new() { "-", "+", "/", "*" };

            var stack = new Stack<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                string value = tokens[i];
                bool isAOperator = operators.Contains(value);

                if (!isAOperator)
                {
                    stack.Push(Convert.ToInt32(value));
                    continue;
                }

                int num2 = stack.Pop();
                int num1 = stack.Pop();

                int result = Calculate(num1, num2, value);
                stack.Push(result);
            }

            return Convert.ToInt32(stack.Pop());
        }

        public static int Calculate(int num1, int num2, string operatorType)
        {
            if (operatorType == "+")
                return num1 + num2;

            if (operatorType == "-")
                return num1 - num2;

            if (operatorType == "*")
                return num1 * num2;
            else
                return num1 / num2;
        }
    }
}
