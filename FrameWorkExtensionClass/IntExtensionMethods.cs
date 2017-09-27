
namespace DevelopmentSimplyPut.ExtensionMethods.IntEM
{
    /// <summary>
    /// Integer Extensions
    /// </summary>
    public static class IntExtensionMethods
    {
		/// <summary>
		/// The numbers percentage
		/// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentageOf(this int number, int percent)
        {
			return (decimal)(number * percent / 100);
        }
		/// <summary>
		/// Percentage of the number.
		/// </summary>
		/// <param name="percent">The percent</param>
		/// <param name="number">The Number</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentOf(this int position, int total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)position / (decimal)total * 100;
            return result;
		}
        /// <summary>
        /// Gets the percentage of the number
        /// </summary>
        /// <param name="position">The percent</param>
        /// <param name="total">The number</param>
        /// <returns></returns>
        public static decimal ext_PercentOf(this int? position, int total)
        {
            if (position == null) return 0;
            
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
        }
		/// <summary>
		/// The numbers percentage
		/// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentageOf(this int number, float percent)
        {
			return (decimal)(number * percent / 100);
        }
		/// <summary>
		/// Percentage of the number.
		/// </summary>
		/// <param name="percent">The percent</param>
		/// <param name="number">The Number</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentOf(this int position, float total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
		}
		/// <summary>
		/// The numbers percentage
		/// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentageOf(this int number, double percent)
        {
			return (decimal)(number * percent / 100);
        }
		/// <summary>
		/// Percentage of the number.
		/// </summary>
		/// <param name="percent">The percent</param>
		/// <param name="number">The Number</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentOf(this int position, double total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
		}
        /// <summary>
		/// The numbers percentage
		/// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentageOf(this int number, decimal percent)
        {
			return (decimal)(number * percent / 100);
        }
		/// <summary>
		/// Percentage of the number.
		/// </summary>
		/// <param name="percent">The percent</param>
		/// <param name="number">The Number</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentOf(this int position, decimal total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)position / (decimal)total * 100;
            return result;
		}
		/// <summary>
		/// The numbers percentage
		/// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentageOf(this int number, long percent)
        {
			return (decimal)(number * percent / 100);
        }
		/// <summary>
		/// Percentage of the number.
		/// </summary>
		/// <param name="percent">The percent</param>
		/// <param name="number">The Number</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentOf(this int position, long total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)position / (decimal)total * 100;
            return result;
		}
        /// <summary>
        /// Gets the string representation of the number or a default value
        /// </summary>
        /// <param name="value">Int</param>
        /// <param name="defaultvalue">Default value</param>
        /// <returns></returns>
        public static string ext_ToString(this int? value, string defaultvalue)
        {
            if (value == null) return defaultvalue;
            return value.Value.ToString();
        }
    }
}
