using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CommonLayer
{
    public static class Extension
    {
        #region " String "

        #region " Nullable, Empty & Whitespace "

        public static string ToSafeString(this object value)
        {
            return value.IsNull() ? string.Empty : value.ToString();
        }

        /// <summary>
        /// This is simply a shorthand method "!string.IsNullOrEmpty(value)"
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>true is the value is not null or it's length != 0</returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Inverse of <see cref="IsNotNullOrEmpty"/> method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return !value.IsNotNullOrEmpty();
        }

        /// <summary>
        /// This is simply a shorthand method "!string.IsNullOrEmpty(value)"
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>true is the value is not null or it's length != 0</returns>
        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Inverse of <see cref="IsNotNullOrWhiteSpace"/> method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return !value.IsNotNullOrWhiteSpace();
        }

        public static bool IsNotNullString(this string value)
        {
            return value.IsNotNullOrWhiteSpace() && value.IsNotNullOrEmpty();
        }
        #endregion

        #region " Lengths "

        /// <summary>
        /// Checks if this string is between the min and max values (inclusive)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min">Inclusive min length</param>
        /// <param name="max">Inclusive max length</param>
        /// <returns></returns>
        public static bool IsBetweenLength(this string value, int min, int max)
        {
            if (value.IsNull() && min == 0)
            {
                return true; // if it's null it has length 0
            }
            else if (value.IsNotNullString())
            {
                return false;
            }
            else
            {
                return value.Length >= min && value.Length <= max;
            }
        }

        /// <summary>
        /// Checks if the string is at least max characters
        /// </summary>
        /// <param name="value"></param>
        /// <param name="max">Inclusive max length</param>
        /// <returns></returns>
        public static bool IsMaxLength(this string value, int max)
        {
            if (value.IsNull())
            {
                return true; // if it's null it has length 0 and that has to be less than max
            }
            else
            {
                return value.Length <= max;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static bool IsMinLength(this string value, int min)
        {
            if (value.IsNull() && min == 0)
            {
                return true; // if it's null it has length 0
            }
            else if (value.IsNull())
            {
                return false;
            }
            else
            {
                return value.Length >= min;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool IsExactLength(this string value, int length)
        {
            return value.IsBetweenLength(length, length);
        }

        #endregion

        #region " Misc "

        /// <summary>
        /// Check if the current value is a valid email address. It uses the following regular expression
        /// ^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$
        /// null values will fail.
        /// Empty strings will fail.
        /// It performs the check from method <see cref="IsNotNullOrEmpty"/>
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>True if the value is a valid email address</returns>
        public static bool IsEmail(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false; // if it's null it cannot possibly be an email
            }
            else
            {
                string exp = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";

                return new Regex(exp, RegexOptions.IgnoreCase).IsMatch(value);
            }
        }

        /// <summary>
        /// Checks if the current value is a password. The password must be at least 8 characters, at least 1 uppercase character, at least 1 lowercase character, at least one number and a maximum of 30 characters.
        /// It uses the following regular expression
        /// ^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPassword(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false; // if it's null it cannot possibly be a password
            }
            else
            {
                string exp = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,30}$";

                return new Regex(exp, RegexOptions.IgnoreCase).IsMatch(value);
            }
        }

        /// <summary>
        /// Validates if the specified object passes the regular expression provided. If the object is null, it will fail. The method calls ToSafeString on the object to get the string value.
        /// </summary>
        /// <param name="value">The value to be evaluated</param>
        /// <param name="exp">The regular expression</param>
        /// <returns></returns>
        public static bool IsRegex(this string value, string exp)
        {
            if (value.IsNotNullOrEmpty())
            {
                return false;
            }

            string check = value.ToSafeString();

            return new Regex(exp, RegexOptions.IgnoreCase).IsMatch(check);
        }

        /// <summary>
        /// Determines if a string is a valid credit card number
        /// Taken from https://github.com/JeremySkinner/FluentValidation/blob/master/src/FluentValidation/Validators/CreditCardValidator.cs
        /// Uses code from: http://www.beachnet.com/~hstiles/cardtype.html
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsCreditCard(this string value)
        {
            if (value.IsNotNullOrEmpty())
            {
                value = value.Replace("-", "").Replace(" ", "");

                int checksum = 0;
                bool evenDigit = false;

                foreach (char digit in value.ToCharArray().Reverse())
                {
                    if (!char.IsDigit(digit))
                    {
                        return false;
                    }

                    int digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                    evenDigit = !evenDigit;

                    while (digitValue > 0)
                    {
                        checksum += digitValue % 10;
                        digitValue /= 10;
                    }
                }

                return (checksum % 10) == 0;
            }
            else
            {
                return false; // a null or empty string cannot be a valid credit card
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this string value, string compare)
        {
            if (value.IsNull() && compare.IsNull())
            {
                return true;
            }
            if (value.IsNull() || compare.IsNull())
            {
                return false;
            }
            return String.Equals(value, compare, StringComparison.Ordinal);
        }

        #endregion

        #endregion

        #region " Object "

        /// <summary>
        /// Check if the current object is not equal to null
        /// </summary>
        /// <param name="value">The object to check</param>
        /// <returns>true is the value is not null</returns>
        public static bool IsNotNull(this object value)
        {
            return (value != null);
        }

        /// <summary>
        /// Check if the current list is not equal to null
        /// </summary>
        /// <param name="value">The object to check</param>
        /// <returns>true is the value is not null</returns>
        public static bool IsNotNullList(this List<object> value)
        {
            return (value != null && value.Count > 0);
        }


        /// <summary>
        /// Inverse of <see cref="IsNotNull"/> method
        /// </summary>
        /// <param name="value">The object to check</param>
        /// <returns>true is the value is null</returns>
        public static bool IsNull(this object value)
        {
            return !value.IsNotNull();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool Is(this object value, Func<bool> func)
        {
            return func();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool IsNot(this object value, Func<bool> func)
        {
            return !func();
        }

        #endregion

        #region " Integer "

        public static bool IsNotZero(this int value)
        {
            return (value != 0);
        }

        public static bool IsNotZero(this double value)
        {
            return (value != 0);
        }

        public static bool IsNotZero(this decimal value)
        {
            return (value != 0);
        }

        public static bool IsPositive(this int value)
        {
            return (value > 0);
        }

        public static bool IsPositive(this double value)
        {
            return (value > 0);
        }

        public static bool IsPositive(this decimal value)
        {
            return (value > 0);
        }

        public static bool Is(this int value, int compare)
        {
            return (value == compare);
        }

        public static bool IsGreaterThan(this int value, int min)
        {
            return (value >= min);
        }

        public static bool IsLessThan(this int value, int max)
        {
            return (value <= max);
        }

        public static bool IsBetween(this int value, int min, int max)
        {
            return (value <= max && value >= min);
        }

        #endregion

        #region " DateTime "

        #region " IsDate "

        public static bool IsMinDate(this DateTime value)
        {
            return value == DateTime.MinValue;
        }

        public static bool IsDate(this object value)
        {
            return value.IsDate(CultureInfo.InvariantCulture);
        }

        public static bool IsDate(this object value, CultureInfo info)
        {
            return value.IsDate(CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        public static bool IsDate(this object value, CultureInfo info, DateTimeStyles styles)
        {
            if (value.IsNotNull())
            {
                DateTime result;

                if (DateTime.TryParse(value.ToSafeString(), info, styles, out result))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false; // if it's null it cannot be a date
            }
        }

        #endregion

        #region " Date Comparisons "

        public static bool IsGreaterThan(this DateTime value, DateTime compare)
        {
            return value > compare;
        }

        public static bool IsGreaterThanOrEqualTo(this DateTime value, DateTime compare)
        {
            return value >= compare;
        }

        public static bool IsLessThan(this DateTime value, DateTime compare)
        {
            return value < compare;
        }

        public static bool IsLessThanOrEqualTo(this DateTime value, DateTime compare)
        {
            return value <= compare;
        }

        public static bool IsEqualTo(this DateTime value, DateTime compare)
        {
            return value == compare;
        }

        public static bool IsBetweenInclusive(this DateTime value, DateTime from, DateTime to)
        {
            return value >= from && value <= to;
        }

        public static bool IsBetweenExclusive(this DateTime value, DateTime from, DateTime to)
        {
            return value > from && value < to;
        }

        #endregion

        #endregion

        #region " Helpers "

        public static string EmptyStringIfNull(this string value)
        {
            if (value.IsNull())
            {
                return string.Empty;
            }
            else
            {
                return value;
            }
        }

        #endregion

        #region " GetName "


        public static string GetName<T>(this T instance, Expression<Func<T, object>> expression)
        {
            return GetName(expression);
        }

        public static string GetName<T>(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(
                    "The expression cannot be null.");
            }

            return GetName(expression.Body);
        }

        public static string GetName<T>(this T instance, Expression<Action<T>> expression)
        {
            return GetName(expression);
        }

        public static string GetName<T>(Expression<Action<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(
                    "The expression cannot be null.");
            }

            return GetName(expression.Body);
        }

        private static string GetName(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(
                    "The expression cannot be null.");
            }

            if (expression is MemberExpression)
            {
                // Reference type property or field
                var memberExpression =
                    (MemberExpression)expression;
                return memberExpression.Member.Name;
            }

            if (expression is MethodCallExpression)
            {
                // Reference type method
                var methodCallExpression =
                    (MethodCallExpression)expression;
                return methodCallExpression.Method.Name;
            }

            if (expression is UnaryExpression)
            {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression)expression;
                return GetName(unaryExpression);
            }

            throw new ArgumentException("Invalid expression");
        }

        private static string GetName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression)
            {
                var methodExpression =
                    (MethodCallExpression)unaryExpression.Operand;
                return methodExpression.Method.Name;
            }

            return ((MemberExpression)unaryExpression.Operand)
                .Member.Name;
        }

        #endregion

        #region " Type Test "

        public static bool Is<T>(this object value)
        {
            if (value == null)
            {
                return false;
            }

            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));

            try
            {
                T result = (T)converter.ConvertFromString(value.ToSafeString());
                return result != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsInt(this object value)
        {
            return value.Is<int>();
        }

        public static bool IsShort(this object value)
        {
            return value.Is<short>();
        }

        public static bool IsLong(this object value)
        {
            return value.Is<long>();
        }

        public static bool IsDouble(this object value)
        {
            return value.Is<Double>();
        }

        public static bool IsDecimal(this object value)
        {
            return value.Is<Decimal>();
        }

        public static bool IsBool(this object value)
        {
            return value.Is<bool>();
        }

        public static bool IsNumber(this object value)
        {
            return
                value.IsLong() ||
                value.IsDouble() ||
                value.IsDecimal() ||
                value.IsDouble();
        }

        #endregion

        #region " To "

        public static T To<T>(this object value)
        {
            return value.To<T>(default(T));
        }

        public static T To<T>(this object value, T fallback)
        {
            if (value == null)
            {
                return fallback;
            }

            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                try
                {
                    return (T)converter.ConvertFromString(value.ToSafeString());
                }
                catch (Exception)
                {
                    return fallback;
                }

            }
            return fallback;
        }

        public static int ToInt(this object value, int fallback = default(int))
        {
            return value.To<int>(fallback);
        }

        public static short ToShort(this object value, short fallback = default(short))
        {
            return value.To<short>(fallback);
        }

        public static long ToLong(this object value, long fallback = default(long))
        {
            return value.To<long>(fallback);
        }

        public static double ToDouble(this object value, double fallback = default(double))
        {
            return value.To<double>(fallback);
        }

        public static decimal ToDecimal(this object value, decimal fallback = default(decimal))
        {
            return value.To<decimal>(fallback);
        }

        public static bool ToBool(this object value, bool fallback = default(bool))
        {
            return value.To<bool>(fallback);
        }

        public static DateTime ToDateTime(this string value, string formate = "dd/MM/yy hh:mm tt")
        {
            return DateTime.ParseExact(value, formate, CultureInfo.InvariantCulture);
        }
        #endregion


        /// <summary>
        /// The hexadecimal color match regex variable.
        /// </summary>
        private static readonly Regex HexColorMatchRegex = new Regex("^#?(?<a>[a-z0-9][a-z0-9])?(?<r>[a-z0-9][a-z0-9])(?<g>[a-z0-9][a-z0-9])(?<b>[a-z0-9][a-z0-9])$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// The format variable. variable.
        /// </summary>
        private static readonly string[] Format =
        {
        "dd/M/yyyy",
        "dd/MMM/yyyy",
        "dd/MMM/yy",
        "dd/MMM/yyyy",
        "dd/MMMM/yy",
        "dd/MMMM/yyyy",
        "MM/dd/yyyy",
        "dddd, dd MMMM yyyy",
        "dd/MM/yyyy HH:mm:ss",
        "dddd, dd MMMM yyyy HH:mm",
        "dddd, dd MMMM yyyy hh:mm tt",
        "dddd, dd MMMM yyyy H:mm",
        "dddd, dd MMMM yyyy h:mm tt",
        "dddd, dd MMMM yyyy HH:mm:ss",
        "MM/dd/yyyy HH:mm",
        "MM/dd/yyyy hh:mm tt",
        "MM/dd/yyyy H:mm",
        "MM/dd/yyyy h:mm tt",
        "MM/dd/yyyy HH:mm:ss",
        "MM/dd/yyyy H:mm:ss",
        "MM/dd/yyyy hh:mm:ss",
        "MM/dd/yyyy hh:mm:ss tt",
        "MM/dd/yyyy HH:mm:ss tt",
        "M/d/yyyy HH:mm:ss tt",
        "M/d/yyyy H:mm:ss tt",
        "M/d/yyyy h:m:s tt",
        "MM/dd/yyyy",
        "M/d/yyyy",
        "MMM/dd/yyyy HH:mm",
        "MMM/dd/yyyy hh:mm tt",
        "MMM/dd/yyyy H:mm",
        "MMM/dd/yyyy h:mm tt",
        "MMM/dd/yyyy HH:mm:ss tt",
        "MMM/d/yyyy HH:mm:ss tt",
        "MMM/d/yyyy H:mm:ss tt",
        "MMM/d/yyyy h:m:s tt",
        "MMMM/dd/yyyy HH:mm",
        "MMMM/dd/yyyy hh:mm tt",
        "MMMM/dd/yyyy H:mm",
        "MMMM/dd/yyyy h:mm tt",
        "MMMM/dd/yyyy HH:mm:ss tt",
        "MMMM/d/yyyy HH:mm:ss tt",
        "MMMM/d/yyyy H:mm:ss tt",
        "MMMM/d/yyyy h:m:s tt",
        "MMM/dd/yyyy",
        "MMMM/dd/yyyy",
        "yyyy/MM/dd HH:mm:ss tt",
        "yyyy/MM/dd hh:mm tt",
        "yyyy/MM/dd h:mm tt",
        "yyyy/MM/dd h:mm",
        "yyyy/MM/dd hh:mm:ss tt",
        "yyyy-MM-dd HH:mm:ss",
        "yyyy/MM/dd",
        "dd/MM/yyyy hh:mm tt",
        "dd/MM/yyyy h:mm:ss tt",
        "dd/MM/yyyy hh:mm:ss tt",
        "dd/MM/yyyy HH:mm:ss",
        "dd/MM/yyyy H:mm:ss",
    };

        ///// <summary>
        ///// To the date time.
        ///// </summary>
        ///// <param name="str">The string parameter.</param>
        ///// <returns>DateTime to date time.</returns>
        //public static DateTime ToDateTime(this string str)
        //{
        //    return DateTime.Parse(str, CultureInfo.InvariantCulture);
        //}

        /****String****/

        #region String

        /// <summary>
        /// Uppercases the first letter.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns>System.String uppercase first letter.</returns>
        public static string UppercaseFirstLetter(this string value)
        {
            ////if (value.Length > 0)
            ////{
            ////    char[] array = value.ToCharArray();
            ////    array[0] = char.ToUpper(array[0]);
            ////    return new string(array);
            ////}
            ////return value;
            //// Check for empty string.
            if (value.IsNotNullString())
            {
                return string.Empty;
            }

            //// Return char and concat substring.

            return char.ToUpper(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// Extracts from string.
        /// </summary>
        /// <param name="text">The text parameter.</param>
        /// <param name="startString">The start string parameter.</param>
        /// <param name="endString">The end string parameter.</param>
        /// <returns>List&lt;System.String&gt; extract from string.</returns>
        public static List<string> ExtractFromString(this string text, string startString, string endString)
        {
            List<string> matched = new List<string>();
            int indexStart = 0, indexEnd = 0;
            bool exit = false;
            while (!exit)
            {
                indexStart = text.IndexOf(startString);
                indexEnd = text.IndexOf(endString);
                if (indexStart != -1 && indexEnd != -1)
                {
                    matched.Add(text.Substring(indexStart + startString.Length, indexEnd - indexStart - startString.Length));
                    text = text.Substring(indexEnd + endString.Length);
                }
                else
                {
                    exit = true;
                }
            }

            return matched;
        }

        /// <summary>
        /// Pads the left.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <param name="paddedCount">The padded count parameter.</param>
        /// <returns>System.String pad left.</returns>
        public static string PadLeft(this int value, int paddedCount = 5)
        {
            string strPadded = "D" + paddedCount;
            string strValue = value.ToString(strPadded);
            return strValue;
        }

        /// <summary>
        /// URIs the safe.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns>System.String URI safe.</returns>
        public static string UriSafe(this object value)
        {
            string strUri = string.Empty;
            strUri = Uri.EscapeDataString(value.ToSafeString());
            return strUri;
        }

        /// <summary>
        /// To the URI.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns>Uri to URI.</returns>
        public static Uri ToUri(this string value)
        {
            if (value.IsNull() || value.ToSafeString().IsNotNullString())
            {
                return new Uri(string.Empty, UriKind.RelativeOrAbsolute);
            }
            else
            {
                return new Uri(value.ToSafeString(), UriKind.RelativeOrAbsolute);
            }
        }

        /// <summary>
        /// Extensions the specified value.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns>System.String extension.</returns>
        public static string GetExtension(this string value)
        {
            string strExtension = string.Empty;
            if (value.IsUrl())
            {
                strExtension = Path.GetExtension(value);
            }

            return strExtension;
        }

        /// <summary>
        /// Encodes the specified string to encode.
        /// </summary>
        /// <param name="stringToEncode">The string to encode parameter.</param>
        /// <returns>System.String encode.</returns>
        public static string Encode(this string stringToEncode)
        {
            try
            {
                byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(stringToEncode);
                string encode = Convert.ToBase64String(encbuff);
                return encode;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Decodes the specified string to decode.
        /// </summary>
        /// <param name="stringToDecode">The string to decode parameter.</param>
        /// <returns>System.String decode.</returns>
        public static string Decode(this string stringToDecode)
        {
            try
            {
                stringToDecode = stringToDecode.Replace("%3d", "=");
                byte[] decbuff = Convert.FromBase64String(stringToDecode);
                string decode = System.Text.Encoding.UTF8.GetString(decbuff, 0, decbuff.Count());
                return decode;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Encrypt
        /// From : www.chapleau.info/blog/2011/01/06/usingsimplestringkeywithaes256encryptioninc.html
        /// </summary>
        public static string EncryptString(this string iPlainStr, string iCompleteEncodedKey, int iKeySize)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = iKeySize;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;
            aesEncryption.IV = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(iCompleteEncodedKey)).Split(',')[0]);
            aesEncryption.Key = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(iCompleteEncodedKey)).Split(',')[1]);
            byte[] plainText = ASCIIEncoding.UTF8.GetBytes(iPlainStr);
            ICryptoTransform crypto = aesEncryption.CreateEncryptor();
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }

        /// <summary>
        /// Decrypt
        /// From : www.chapleau.info/blog/2011/01/06/usingsimplestringkeywithaes256encryptioninc.html
        /// </summary>
        public static string DecryptString(this string iEncryptedText, string iCompleteEncodedKey, int iKeySize)
        {
            try
            {
                RijndaelManaged aesEncryption = new RijndaelManaged();
                aesEncryption.KeySize = iKeySize;
                aesEncryption.BlockSize = 128;
                aesEncryption.Mode = CipherMode.CBC;
                aesEncryption.Padding = PaddingMode.PKCS7;
                aesEncryption.IV = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(iCompleteEncodedKey)).Split(',')[0]);
                aesEncryption.Key = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(iCompleteEncodedKey)).Split(',')[1]);
                ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
                byte[] encryptedBytes = Convert.FromBase64CharArray(iEncryptedText.ToCharArray(), 0, iEncryptedText.Length);
                return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion String

        /****Validation****/

        #region Validation

        /// <summary>
        /// Determines whether the specified value has extension.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns><c>true</c> if the specified value has extension; otherwise, <c>false</c>.</returns>
        public static bool HasExtension(this string value)
        {
            bool strExtension = false;
            if (value.IsUrl())
            {
                strExtension = Path.HasExtension(value);
            }

            return strExtension;
        }

        /// <summary>
        /// Determines whether the specified value is URL.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns><c>true</c> if the specified value is URL; otherwise, <c>false</c>.</returns>
        public static bool IsUrl(this string value)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(value, UriKind.Absolute, out uriResult);
            return result;
        }

        /// <summary>
        /// Determines whether [is valid email] [the specified string email].
        /// </summary>
        /// <param name="strEmail">The string email parameter.</param>
        /// <returns><c>true</c> if [is valid email] [the specified string email]; otherwise, <c>false</c>.</returns>
        public static bool IsValidEmail(this string strEmail)
        {
            bool c = Regex.IsMatch(strEmail, @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,3}))$");
            return c;
        }

        /// <summary>
        /// Determines whether the specified number is digit.
        /// </summary>
        /// <param name="number">The number parameter.</param>
        /// <returns><c>true</c> if the specified number is digit; otherwise, <c>false</c>.</returns>
        public static bool IsDigit(this string number)
        {
            return number.All(char.IsDigit);
        }

        /// <summary>
        /// Determines whether the specified check string is number.
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <returns><c>true</c> if the specified check string is number; otherwise, <c>false</c>.</returns>
        public static bool IsNumber(this string checkString)
        {
            foreach (char c in checkString)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether [is valid mobile no] [the specified check string].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <returns><c>true</c> if [is valid mobile no] [the specified check string]; otherwise, <c>false</c>.</returns>
        public static bool IsValidMobileNo(this object checkString)
        {
            int length = 10;
            string pattern = @"^[0-9]{" + length + "," + length + "}$";

            Regex phoneRegex = new Regex(pattern);

            bool isMatched = phoneRegex.IsMatch(checkString.ToSafeString());

            return isMatched;
        }

        /// <summary>
        /// Determines whether [is number with length] [the specified minimum length].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <param name="minLength">The minimum length parameter.</param>
        /// <param name="maxLength">The maximum length parameter.</param>
        /// <returns><c>true</c> if [is number with length] [the specified minimum length]; otherwise, <c>false</c>.</returns>
        public static bool IsNumberWithLength(this string checkString, int minLength = 0, int maxLength = 10)
        {
            string pattern = @"^[0-9]{" + minLength + "," + maxLength + "}$";

            Regex phoneRegex = new Regex(pattern);

            bool isMatched = phoneRegex.IsMatch(checkString);

            return isMatched;
        }

        /// <summary>
        /// Determines whether [is number with maximum length] [the specified maximum length].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <param name="maxLength">The maximum length parameter.</param>
        /// <returns><c>true</c> if [is number with maximum length] [the specified maximum length]; otherwise, <c>false</c>.</returns>
        public static bool IsNumberWithMaxLength(this string checkString, int maxLength = 10)
        {
            int minLength = 0;
            string pattern = @"^[0-9]{" + minLength + "," + maxLength + "}$";

            Regex phoneRegex = new Regex(pattern);

            bool isMatched = phoneRegex.IsMatch(checkString);

            return isMatched;
        }

        /// <summary>
        /// Determines whether [is number with exact length] [the specified length].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <param name="length">The length parameter.</param>
        /// <returns><c>true</c> if [is number with exact length] [the specified length]; otherwise, <c>false</c>.</returns>
        public static bool IsNumberWithExactLength(this string checkString, int length = 10)
        {
            string pattern = @"^[0-9]{" + length + "," + length + "}$";

            Regex phoneRegex = new Regex(pattern);

            bool isMatched = phoneRegex.IsMatch(checkString);

            return isMatched;
        }

        /// <summary>
        /// Determines whether [is number with minimum length] [the specified minimum length].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <param name="minLength">The minimum length parameter.</param>
        /// <returns><c>true</c> if [is number with minimum length] [the specified minimum length]; otherwise, <c>false</c>.</returns>
        public static bool IsNumberWithMinLength(this string checkString, int minLength = 0)
        {
            string pattern = @"^[0-9]{" + minLength + ",}$";

            Regex phoneRegex = new Regex(pattern);

            bool isMatched = phoneRegex.IsMatch(checkString);

            return isMatched;
        }

        /// <summary>
        /// Determines whether [is string with length] [the specified minimum length].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <param name="minLength">The minimum length parameter.</param>
        /// <param name="maxLength">The maximum length parameter.</param>
        /// <returns><c>true</c> if [is string with length] [the specified minimum length]; otherwise, <c>false</c>.</returns>
        public static bool IsStringWithLength(this string checkString, int minLength, int maxLength)
        {
            bool isMatched = !checkString.IsNotNullString() && checkString.Length >= minLength && checkString.Length <= maxLength;
            return isMatched;
        }

        /// <summary>
        /// Determines whether [is string with maximum length] [the specified maximum length].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <param name="maxLength">The maximum length parameter.</param>
        /// <returns><c>true</c> if [is string with maximum length] [the specified maximum length]; otherwise, <c>false</c>.</returns>
        public static bool IsStringWithMaxLength(this string checkString, int maxLength = 10)
        {
            bool isMatched = !checkString.IsNotNullString() && checkString.Length <= maxLength;

            return isMatched;
        }

        /// <summary>
        /// Determines whether [is string with exact length] [the specified length].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <param name="length">The length parameter.</param>
        /// <returns><c>true</c> if [is string with exact length] [the specified length]; otherwise, <c>false</c>.</returns>
        public static bool IsStringWithExactLength(this string checkString, int length = 10)
        {
            bool isMatched = !checkString.IsNotNullString() && checkString.Length == length;

            return isMatched;
        }

        /// <summary>
        /// Determines whether [is string with minimum length] [the specified minimum length].
        /// </summary>
        /// <param name="checkString">The check string parameter.</param>
        /// <param name="minLength">The minimum length parameter.</param>
        /// <returns><c>true</c> if [is string with minimum length] [the specified minimum length]; otherwise, <c>false</c>.</returns>
        public static bool IsStringWithMinLength(this string checkString, int minLength = 0)
        {
            bool isMatched = !checkString.IsNotNullString() && checkString.Length >= minLength;

            return isMatched;
        }

        /// <summary>
        /// Determines whether the specified double string is negative.
        /// </summary>
        /// <param name="doubleStr">The double string parameter.</param>
        /// <returns><c>true</c> if the specified double string is negative; otherwise, <c>false</c>.</returns>
        public static bool IsNegative(this double doubleStr)
        {
            if (doubleStr >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified decimal string is negative.
        /// </summary>
        /// <param name="decimalStr">The decimal string parameter.</param>
        /// <returns><c>true</c> if the specified decimal string is negative; otherwise, <c>false</c>.</returns>
        public static bool IsNegative(this decimal decimalStr)
        {
            if (decimalStr >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified int string is negative.
        /// </summary>
        /// <param name="intStr">The int string parameter.</param>
        /// <returns><c>true</c> if the specified int string is negative; otherwise, <c>false</c>.</returns>
        public static bool IsNegative(this int intStr)
        {
            if (intStr >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified long string is negative.
        /// </summary>
        /// <param name="longStr">The long string parameter.</param>
        /// <returns><c>true</c> if the specified long string is negative; otherwise, <c>false</c>.</returns>
        public static bool IsNegative(this long longStr)
        {
            if (longStr >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified float string is negative.
        /// </summary>
        /// <param name="floatStr">The float string parameter.</param>
        /// <returns><c>true</c> if the specified float string is negative; otherwise, <c>false</c>.</returns>
        public static bool IsNegative(this float floatStr)
        {
            if (floatStr >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion Validation


        /****Converter****/

        #region Converter

        /// <summary>
        /// Determines whether the specified value is null. Something like SQL function IsNull.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <param name="replaceValue">The replace value parameter.</param>
        /// <returns>Returns Object.</returns>
        public static object IsNull(this object value, object replaceValue)
        {
            return value.IsNull() ? replaceValue : value;
        }

        /// <summary>
        /// Check list is null or having no record.
        /// </summary>
        /// <typeparam name="T">Any type of object.</typeparam>
        /// <param name="list">List of any type of object.</param>
        /// <returns>If list is null or having no record then true else false.</returns>
        public static bool IsNullList<T>(this List<T> list)
        {
            return list.IsNull() || list.Count == 0;
        }

        /// <summary>
        /// Check list is null or having no record.
        /// </summary>
        /// <typeparam name="T">Any type of object.</typeparam>
        /// <param name="list">List of any type of object.</param>
        /// <returns>If list is null or having no record then false else true.</returns>
        public static bool IsNotNullList<T>(this List<T> list)
        {
            return !list.IsNullList();
        }

        /// <summary>
        /// To the observable collection.
        /// </summary>
        /// <typeparam name="T">Type of T.</typeparam>
        /// <param name="original">The original parameter.</param>
        /// <returns>ObservableCollection Type of T to observable collection.</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }

        /// <summary>
        /// To the double.
        /// </summary>
        /// <param name="doubleStr">The double string parameter.</param>
        /// <returns>System.Double to double.</returns>
        public static double ToDouble(this object doubleStr)
        {
            double ret = 0;
            double.TryParse(doubleStr.ToSafeString(), out ret);
            return ret;
        }

        /// <summary>
        /// To the decimal.
        /// </summary>
        /// <param name="doubleStr">The double string parameter.</param>
        /// <returns>System.Decimal to decimal.</returns>
        public static decimal ToDecimal(this object doubleStr)
        {
            decimal ret = 0;
            decimal.TryParse(doubleStr.ToSafeString(), out ret);
            return ret;
        }

        /// <summary>
        /// To the long.
        /// </summary>
        /// <param name="longStr">The long string parameter.</param>
        /// <returns>System.Int64 to long.</returns>
        public static long ToLong(this object longStr)
        {
            long ret = 0;
            long.TryParse(longStr.ToSafeString(), out ret);
            return ret;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="str">The string parameter.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="stream">The stream parameter.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public static string ToSafeString(this Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// To the positive float.
        /// </summary>
        /// <param name="floatStr">The float string parameter.</param>
        /// <returns>System.Single to positive float.</returns>
        public static float ToPositiveFloat(this object floatStr)
        {
            float ret = 0;

            ret = Math.Abs(ret.ToFloat());
            return ret;
        }

        /// <summary>
        /// To the positive double.
        /// </summary>
        /// <param name="doubleStr">The double string parameter.</param>
        /// <returns>System.Double to positive double.</returns>
        public static double ToPositiveDouble(this object doubleStr)
        {
            double ret = 0;
            ret = Math.Abs(doubleStr.ToDouble());
            return ret;
        }

        /// <summary>
        /// To the positive long.
        /// </summary>
        /// <param name="doubleStr">The double string parameter.</param>
        /// <returns>System.Int64 to positive long.</returns>
        public static long ToPositiveLong(this object doubleStr)
        {
            long ret = 0;
            ret = Math.Abs(doubleStr.ToLong());
            return ret;
        }

        /// <summary>
        /// To the positive int.
        /// </summary>
        /// <param name="doubleStr">The double string parameter.</param>
        /// <returns>System.Int32 to positive int.</returns>
        public static int ToPositiveInt(this object doubleStr)
        {
            int ret = 0;
            ret = Math.Abs(doubleStr.ToInt());
            return ret;
        }

        /// <summary>
        /// To the float.
        /// </summary>
        /// <param name="floatStr">The float string parameter.</param>
        /// <returns>System.Single to float.</returns>
        public static float ToFloat(this object floatStr)
        {
            float ret = 0;
            float.TryParse(floatStr.ToSafeString(), out ret);
            return ret;
        }

        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="intStr">The int string parameter.</param>
        /// <returns>System.Int32 to int.</returns>
        public static int ToInt(this object intStr)
        {
            int ret = 0;
            int.TryParse(intStr.ToSafeString().Split('.')[0], out ret);
            return ret;
        }

        /// <summary>
        /// To the bool.
        /// </summary>
        /// <param name="boolStr">The bool string parameter.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ToBool(this object boolStr)
        {
            bool bl = false;
            bool.TryParse(boolStr.ToSafeString(), out bl);
            return bl;
        }

        /// <summary>
        /// To the bool.
        /// </summary>
        /// <param name="intValue">The int value parameter.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ToBool(this int intValue)
        {
            bool bl = intValue != 0;
            return bl;
        }

        /// <summary>
        /// Rounds to lowest hundreds.
        /// </summary>
        /// <param name="i">The i parameter.</param>
        /// <returns>System.Int32 round to lowest hundreds.</returns>
        public static int RoundToLowestHundreds(this int i)
        {
            return (int)Math.Floor(i / 100.0) * 100;
        }

        /// <summary>
        /// To the encode.
        /// </summary>
        /// <param name="str">The string parameter.</param>
        /// <returns>System.String to encode.</returns>
        public static string ToEncode(this string str)
        {
            try
            {
                byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
                string encode = Convert.ToBase64String(encbuff);
                return encode;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// To the decode.
        /// </summary>
        /// <param name="str">The string parameter.</param>
        /// <returns>System.String to decode.</returns>
        public static string ToDecode(this string str)
        {
            try
            {
                str = str.Replace("%3d", "=");
                byte[] decbuff = Convert.FromBase64String(str);
                string decode = System.Text.Encoding.UTF8.GetString(decbuff, 0, decbuff.Count());
                return decode;
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion Converter

        /****Stream****/

        #region Stream

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="fromStream">From stream parameter.</param>
        /// <param name="toStream">To stream parameter.</param>
        /// <exception cref="System.ArgumentNullException">
        /// FromStream
        /// or
        /// ToStream.
        /// </exception>
        public static void CopyTo(this Stream fromStream, Stream toStream)
        {
            if (fromStream == null)
            {
                throw new ArgumentNullException("fromStream");
            }

            if (toStream == null)
            {
                throw new ArgumentNullException("toStream");
            }

            var bytes = new byte[8092];
            int dataRead;
            while ((dataRead = fromStream.Read(bytes, 0, bytes.Length)) > 0)
            {
                toStream.Write(bytes, 0, dataRead);
            }
        }

        /// <summary>
        /// To the stream.
        /// </summary>
        /// <param name="str">The string parameter.</param>
        /// <returns>Stream to stream.</returns>
        public static Stream ToStream(this string str)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            return new MemoryStream(byteArray);
        }

        #endregion Stream

        /****Remove String****/

        #region Remove String

        /// <summary>
        /// Gets the number from string.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns>System.String get number from string.</returns>
        public static string GetNumberFromString(this string value)
        {
            value = Regex.Replace(value, @"[^0-9]+", string.Empty);
            return value;
        }

        /// <summary>
        /// Removes the special.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns>System.String remove special.</returns>
        public static string RemoveSpecial(this string value)
        {
            value = Regex.Replace(value, @"[^0-9,a-z,A-Z]+", string.Empty);
            return value;
        }

        /// <summary>
        /// Removes the last character.
        /// </summary>
        /// <param name="intstr">The int string parameter.</param>
        /// <returns>System.String remove last character.</returns>
        public static string RemoveLastCharacter(this string intstr)
        {
            return intstr.Substring(0, intstr.Length - 1);
        }

        /// <summary>
        /// Removes the last.
        /// </summary>
        /// <param name="intstr">The int string parameter.</param>
        /// <param name="number">The number parameter.</param>
        /// <returns>System.String remove last.</returns>
        public static string RemoveLast(this string intstr, int number)
        {
            return intstr.Substring(0, intstr.Length - number);
        }

        /// <summary>
        /// Removes the first character.
        /// </summary>
        /// <param name="intstr">The int string parameter.</param>
        /// <returns>System.String remove first character.</returns>
        public static string RemoveFirstCharacter(this string intstr)
        {
            return intstr.Substring(1);
        }

        /// <summary>
        /// Removes the first.
        /// </summary>
        /// <param name="intstr">The int string parameter.</param>
        /// <param name="number">The number parameter.</param>
        /// <returns>System.String remove first.</returns>
        public static string RemoveFirst(this string intstr, int number)
        {
            return intstr.Substring(number);
        }

        #endregion Remove String

        /****Date and Time****/

        #region Date and Time

        /// <summary>
        /// Totals the seconds.
        /// </summary>
        /// <param name="dateTime">The date time parameter.</param>
        /// <returns>System.Double total seconds.</returns>
        public static double TotalSeconds(this DateTime dateTime)
        {
            var age = DateTime.Now - dateTime;

            return age.TotalSeconds;
        }

        /// <summary>
        /// Totals the minutes.
        /// </summary>
        /// <param name="dateTime">The date time parameter.</param>
        /// <returns>System.Double total minutes.</returns>
        public static double TotalMinutes(this DateTime dateTime)
        {
            var age = DateTime.Now - dateTime;

            return age.TotalMinutes;
        }

        /// <summary>
        /// Totals the hours.
        /// </summary>
        /// <param name="dateTime">The date time parameter.</param>
        /// <returns>System.Double total hours.</returns>
        public static double TotalHours(this DateTime dateTime)
        {
            var age = DateTime.Now - dateTime;

            return age.TotalHours;
        }

        /// <summary>
        /// Totals the year.
        /// </summary>
        /// <param name="dateTime">The date time parameter.</param>
        /// <returns>System.Int32 total year.</returns>
        public static int TotalYear(this DateTime dateTime)
        {
            var age = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now < dateTime.AddYears(age))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// To the readable time.
        /// </summary>
        /// <param name="value">The value parameter.</param>
        /// <returns>System.String to readable time.</returns>
        public static string ToReadableTime(this DateTime value)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - value.Ticks);
            double delta = ts.TotalSeconds;
            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }

            if (delta < 120)
            {
                return "a minute ago";
            }

            if (delta < 2700)
            {
                //// 45 * 60
                return ts.Minutes + " minutes ago";
            }

            if (delta < 5400)
            {
                //// 90 * 60
                return "an hour ago";
            }

            if (delta < 86400)
            {
                //// 24 * 60 * 60
                return ts.Hours + " hours ago";
            }

            if (delta < 172800)
            {
                //// 48 * 60 * 60
                return "yesterday";
            }

            if (delta < 2592000)
            {
                //// 30 * 24 * 60 * 60
                return ts.Days + " days ago";
            }

            if (delta < 31104000)
            {
                //// 12 * 30 * 24 * 60 * 60
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }

        /// <summary>
        /// Workings the day.
        /// </summary>
        /// <param name="date">The date parameter.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool WorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determines whether the specified date is weekend.
        /// </summary>
        /// <param name="date">The date parameter.</param>
        /// <returns><c>true</c> if the specified date is weekend; otherwise, <c>false</c>.</returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Next the workday.
        /// </summary>
        /// <param name="date">The date parameter.</param>
        /// <returns>DateTime next workday.</returns>
        public static DateTime NextWorkday(this DateTime date)
        {
            var nextDay = date;
            while (!nextDay.WorkingDay())
            {
                nextDay = nextDay.AddDays(1);
            }

            return nextDay;
        }

        /// <summary>
        /// Starts the of week.
        /// </summary>
        /// <param name="dt">The date parameter.</param>
        /// <returns>DateTime start of week.</returns>
        public static DateTime StartOfWeek(DateTime dt)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Sunday;

            int diff = (int)dt.DayOfWeek;
            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Ends the of week.
        /// </summary>
        /// <param name="dt">The date parameter.</param>
        /// <returns>DateTime end of week.</returns>
        public static DateTime EndOfWeek(DateTime dt)
        {
            int diff = 6 - (int)dt.DayOfWeek;
            return dt.AddDays(diff).Date;
        }

        /// <summary>
        /// Determines whether the specified start date is between.
        /// </summary>
        /// <param name="dt">The date parameter.</param>
        /// <param name="startDate">The start date parameter.</param>
        /// <param name="endDate">The end date parameter.</param>
        /// <param name="compareTime">The compare time parameter.</param>
        /// <returns>Boolean is between.</returns>
        public static bool IsBetween(this DateTime dt, DateTime startDate, DateTime endDate, bool compareTime = false)
        {
            return compareTime ? dt >= startDate && dt <= endDate : dt.Date >= startDate.Date && dt.Date <= endDate.Date;
        }

        #endregion Date and Time

        /****Linq****/


        /// <summary>
        /// To the list.
        /// </summary>
        /// <typeparam name="T">List Type of T.</typeparam>
        /// <param name="dataTable">The data table parameter.</param>
        /// <returns>List Type of T to list.</returns>
        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            var dataList = new List<T>();

            ////Define what attributes to be read from the class
            const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance;

            ////Read Attribute Names and Types
            var objFieldNames = typeof(T).GetProperties(Flags).Cast<PropertyInfo>().Select(item => new
            {
                Name = item.Name,
                Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
            }).ToList();

            ////Read Datatable column names and types
            var dtlFieldNames = dataTable.Columns.Cast<DataColumn>().Select(item => new
            {
                Name = item.ColumnName,
                Type = item.DataType
            }).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var classObj = new T();

                foreach (var dtField in dtlFieldNames)
                {
                    PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);

                    var field = objFieldNames.Find(x => x.Name == dtField.Name);

                    if (field != null)
                    {
                        if (propertyInfos.PropertyType == typeof(DateTime))
                        {
                            propertyInfos.SetValue(classObj, dataRow[dtField.Name].ToSafeString().ToDateTime(), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(int))
                        {
                            propertyInfos.SetValue(classObj, dataRow[dtField.Name].ToInt(), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(long))
                        {
                            propertyInfos.SetValue(classObj, dataRow[dtField.Name].ToLong(), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(decimal))
                        {
                            propertyInfos.SetValue(classObj, dataRow[dtField.Name].ToDecimal(), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(bool))
                        {
                            propertyInfos.SetValue(classObj, dataRow[dtField.Name].ToBool(), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(string))
                        {
                            if (dataRow[dtField.Name].GetType() == typeof(DateTime))
                            {
                                propertyInfos.SetValue(classObj, dataRow[dtField.Name].ToSafeString().ToDateTime(), null);
                            }
                            else
                            {
                                propertyInfos.SetValue(classObj, dataRow[dtField.Name].ToSafeString(), null);
                            }
                        }
                    }
                }

                dataList.Add(classObj);
            }

            return dataList;
        }

        /// <summary>
        /// Distinct the by.
        /// </summary>
        /// <typeparam name="TSource">The  Type of The t source.</typeparam>
        /// <typeparam name="TKey">The  Type of The t key.</typeparam>
        /// <param name="source">The source parameter.</param>
        /// <param name="keySelector">The key selector parameter.</param>
        /// <returns>IEnumerable&lt;TSource&gt; distinct by.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Gets the color from hexa. Pass hexa color which give rgb color.
        /// </summary>
        /// <param name="hexColorString">The hexadecimal color string.</param>
        /// <returns>Drawing Color.</returns>
        /// <exception cref="System.NullReferenceException">Hex string can't be null.</exception>
        /// <exception cref="System.InvalidCastException">Invalid Cast Exception.</exception>
        /// <exception cref="NullReferenceException">Hex string can't be null.</exception>
        /// <exception cref="InvalidCastException">Invalid Cast Exception.</exception>
        public static Color ToColor(this string hexColorString)
        {
            if (hexColorString == null)
            {
                throw new NullReferenceException("Hex string can't be null.");
            }

            //// Regex match the string
            var match = HexColorMatchRegex.Match(hexColorString);

            if (!match.Success)
            {
                throw new InvalidCastException(string.Format("Can't convert string \"{0}\" to argb or rgb color. Needs to be 6 (rgb) or 8 (argb) hex characters long. It can optionally start with a #.", hexColorString));
            }

            //// a value is optional
            byte a = 255, r = 0, b = 0, g = 0;
            if (match.Groups["a"].Success)
            {
                a = System.Convert.ToByte(match.Groups["a"].Value, 16);
            }

            //// r,b,g values are not optional
            r = System.Convert.ToByte(match.Groups["r"].Value, 16);
            b = System.Convert.ToByte(match.Groups["b"].Value, 16);
            g = System.Convert.ToByte(match.Groups["g"].Value, 16);
            return Color.FromArgb(a, r, g, b);
        }

        #region Json 
        public static string ToJson(this object val)
        {
            return JsonConvert.SerializeObject(val);
        }

        public static object FromJson(this string val)
        {
            return JsonConvert.DeserializeObject(val);
        }
        #endregion Json
    }
}
