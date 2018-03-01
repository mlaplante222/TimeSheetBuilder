using System;

namespace TimeSheetBuilder
{
    public static class ConversionUtils
    {
        public static int GetInt(object obj)
        {
            try
            {
                if (obj is string)
                {
                    int val;
                    if (int.TryParse((string)obj, out val))
                        return val;
                    return 0;
                }
                return Convert.ToInt32(obj);
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public static decimal GetDecimal(object obj, int precision)
        {
            if (precision <= 0) return 0;//sanity check... should never happen
            try
            {
                decimal temp = Convert.ToDecimal(obj);
                return Decimal.Round(temp, precision);
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public static double GetDouble(object obj)
        {
            try
            {
                return Convert.ToDouble(obj);
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public static double GetDouble(object obj, int precision)
        {
            try
            {
                var temp = Convert.ToDouble(obj);
                return Math.Round(temp, precision);
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (FormatException)
            {
                return 0;
            }
        }
    }
}
