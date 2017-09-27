﻿
namespace DevelopmentSimplyPut.ExtensionMethods.DecimalEM
{
    /// <summary>
    /// Decimal Extensions
    /// </summary>
    public static class DecimalExtensionMethods
    { 
        /// <summary>
		/// The numbers percentage
        /// </summary>
		/// <param name="number">The number.</param>
		/// <param name="percent">The percent.</param>
        /// <returns>The result</returns>
        public static decimal ext_PercentageOf(this decimal number, int percent)
        {
			return (decimal)(number * percent / 100);
        }
		/// <summary>
		/// Percentage of the number.
		/// </summary>
		/// <param name="percent">The percent</param>
		/// <param name="number">The Number</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentOf(this decimal position, int total)
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
        public static decimal ext_PercentageOf(this decimal number, decimal percent)
        {
            return (decimal)(number * percent / 100);
        }
		/// <summary>
		/// Percentage of the number.
		/// </summary>
		/// <param name="percent">The percent</param>
		/// <param name="number">The Number</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentOf(this decimal position, decimal total)
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
        public static decimal ext_PercentageOf(this decimal number, long percent)
        {
			return (decimal)(number * percent / 100);
        }
		/// <summary>
		/// Percentage of the number.
		/// </summary>
		/// <param name="percent">The percent</param>
		/// <param name="number">The Number</param>
		/// <returns>The result</returns>
        public static decimal ext_PercentOf(this decimal position, long total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)position / (decimal)total * 100;
            return result;
		}
    }
}
