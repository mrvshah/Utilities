using System.ComponentModel;
using System.Linq;

namespace Utilities.Enum
{
	/// <summary>
	/// Enum extensions
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Gets the description of enum
		/// </summary>
		/// <param name="enumToRead">The enum to read</param>
		/// <returns>Description of the enum</returns>
		public static string GetDescription(this System.Enum enumToRead)
		{
			var attribute = enumToRead.GetType().GetField(enumToRead.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault() as DescriptionAttribute;

			return attribute == null ? string.Empty : attribute.Description;
		}
	}
}