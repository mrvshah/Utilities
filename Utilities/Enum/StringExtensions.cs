using System;
using System.ComponentModel;

namespace Utilities.Enum
{
	/// <summary>
	/// String extensions around enum type
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Convert string to an enumeration type
		/// </summary>
		/// <typeparam name="T">Enumeration type to convert to</typeparam>
		/// <param name="value">String to convert</param>
		/// <param name="isDescription">Is string to check description or name of enum</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="OverflowException"></exception>
		/// <returns>Enumeration type</returns>
		public static T ToEnumOfType<T>(this string value, bool isDescription = false)
		{
			if (!isDescription)
			{
				return (T)System.Enum.Parse(typeof(T), value);
			}

			var type = typeof(T);
			if (!type.IsEnum)
			{
				throw new ArgumentException("Type specified is not enum");
			}
			var fields = type.GetFields();
			foreach (var field in fields)
			{
				var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

				if (attribute != null)
				{
					if (attribute.Description == value)
					{
						return (T)field.GetValue(null);
					}
				}
			}

			throw new ArgumentException("Unable to convert description to enum");
		}
	}
}