using System;

namespace Utilities.Enum
{
	/// <summary>
	/// String extension around enum type
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Convert string to an enumeration type
		/// </summary>
		/// <typeparam name="T">Enumeration type to convert to</typeparam>
		/// <param name="value">String to convert</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="OverflowException"></exception>
		/// <returns>Enumeration type</returns>
		public static T ToEnumOfType<T>(this string value)
		{
			return (T)System.Enum.Parse(typeof(T), value);
		}
	}
}