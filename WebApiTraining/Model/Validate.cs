using System;
using System.Linq;

namespace WebApiTraining.Model
{
    public class Validate
    {
        public static bool IsBlankOrWhiteSpace(string value)
        {
            return value == null || value.All(char.IsWhiteSpace) || value == "";
        }

        public static bool IsPositiveInt<T>(T value)
        {
            if (IsInt(value))
            {
                if (IsPositive(Convert.ToInt32(value)))
                    return true;
            }
            return false;
        }

        private static bool IsPositive(int value)
        {
            return value >= 0;
        }

        private static bool IsInt<T>(T value)
        {
            return value.GetType() == typeof(int);
        }

        public static bool ContainsNumbers(string value)
        {
            return value.Any(char.IsDigit);
        }
    }
}
