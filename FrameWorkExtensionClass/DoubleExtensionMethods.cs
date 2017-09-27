
namespace DevelopmentSimplyPut.ExtensionMethods.DoubleEM
{
    /// <summary>
    /// Double Extensions
    /// </summary>
    public static class DoubleExtensionMethods
    {
        /// <summary>
        /// The numbers percentage
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="percent">The percent</param>
        /// <returns></returns>
        public static decimal ext_PercentageOf(this double number, int percent)
        {
            return (decimal)(number * percent / 100);
        }
        /// <summary>
        /// The numbers percentage
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="percent">The percent</param>
        /// <returns></returns>
        public static decimal ext_PercentageOf(this double number, float percent)
        {
			return (decimal)(number * percent / 100);
        }
        /// <summary>
        /// The numbers percentage
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="percent">The percent</param>
        /// <returns></returns>
        public static decimal ext_PercentageOf(this double number, double percent)
        {
			return (decimal)(number * percent / 100);
        }
        /// <summary>
        /// The numbers percentage
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="percent">The percent</param>
        /// <returns></returns>
        public static decimal ext_PercentageOf(this double number, long percent)
        {
			return (decimal)(number * percent / 100);
        }
        /// <summary>
        /// Gets the percentage of the number
        /// </summary>
        /// <param name="position">The percent</param>
        /// <param name="total">The number</param>
        /// <returns></returns>
        public static decimal ext_PercentOf(this double position, int total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
		}
        /// <summary>
        /// Gets the percentage of the number
        /// </summary>
        /// <param name="position">The percent</param>
        /// <param name="total">The number</param>
        /// <returns></returns>
        public static decimal ext_PercentOf(this double position, float total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
		}
        /// <summary>
        /// Gets the percentage of the number
        /// </summary>
        /// <param name="position">The percent</param>
        /// <param name="total">The number</param>
        /// <returns></returns>
        public static decimal ext_PercentOf(this double position, double total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
		}
        /// <summary>
        /// Gets the percentage of the number
        /// </summary>
        /// <param name="position">The percent</param>
        /// <param name="total">The number</param>
        /// <returns></returns>
        public static decimal ext_PercentOf(this double position, long total)
		{
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
		}
    }
}
