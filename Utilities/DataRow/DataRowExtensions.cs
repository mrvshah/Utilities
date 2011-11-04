using System;

namespace Utilities.DataRow
{
	/// <summary>
	/// DataRow extensions
	/// </summary>
	public static class DataRowExtensions
	{
		/// <summary>
		/// Get column value for requested data type
		/// </summary>
		/// <typeparam name="T">Requested data type</typeparam>
		/// <param name="dr">DataRow to get value from</param>
		/// <param name="columnName">Column name</param>
		/// <returns>Column value</returns>
		public static T GetValue<T>(this System.Data.DataRow dr, string columnName)
		{
			return (T)dr[columnName];
		}

		/// <summary>
		/// Get column value for requested data type. If <see cref="DBNull"/> return default value provided.
		/// </summary>
		/// <typeparam name="T">Requested data type</typeparam>
		/// <param name="dr">DataRow to get value from</param>
		/// <param name="columnName">Column name</param>
		/// <param name="defalutValue">Default value in case column contains <see cref="DBNull"/></param>
		/// <returns>Column value</returns>
		public static T GetValueOrDefault<T>(this System.Data.DataRow dr, string columnName, T defalutValue)
		{
			var dbValue = dr[columnName];

			return (dbValue == DBNull.Value ? defalutValue : (T)dbValue);
		}
	}
}