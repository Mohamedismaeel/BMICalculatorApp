using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculatorApp
{
    internal class task_2
    {
       

public class Calculator<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private Func<T, T, T> add;
        private Func<T, T, T> subtract;
        private Func<T, T, T> multiply;
        private Func<T, T, T> divide;

        public Calculator()
        {
            add = (x, y) => (dynamic)x + y; 
            subtract = (x, y) => (dynamic)x - y;
            multiply = (x, y) => (dynamic)x * y;
            divide = (x, y) => (dynamic)x / y;
        }

        public T Add(T a, T b)
        {
            return add(a, b);
        }

        public T Subtract(T a, T b)
        {
            return subtract(a, b);
        }

        public T Multiply(T a, T b)
        {
            return multiply(a, b);
        }

        public T Divide(T a, T b)
        {
            if (Convert.ToDouble(b) == 0)
            {
                throw new DivideByZeroException("Division by zero error.");
            }
            return divide(a, b);
        }
    }

}
}
