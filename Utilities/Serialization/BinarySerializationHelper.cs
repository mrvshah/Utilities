using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utilities.Serialization
{
	/// <summary>
	/// Helper class to serialize and deserialize using <see cref="BinaryFormatter"/>
	/// </summary>
	public static class BinarySerializationHelper
	{
		/// <summary>
		/// Converts string representation to requested object type
		/// </summary>
		/// <typeparam name="T">Requested object type</typeparam>
		/// <param name="data">Data to deserialize</param>
		/// <returns>Instance of type</returns>
		public static T Deserialize<T>(string data)
		{
			var bytes = Convert.FromBase64String(data);
			using (var memoryStream = new MemoryStream(bytes))
			{
				var binaryFormatter = new BinaryFormatter();
				memoryStream.Seek(0, SeekOrigin.Begin);
				return (T)binaryFormatter.Deserialize(memoryStream);
			}
		}

		/// <summary>
		/// Serializes the specified data into string representation
		/// </summary>
		/// <param name="data">Data to serialize</param>
		/// <returns>String representation of serialized object</returns>
		public static string Serialize(object data)
		{
			using (var memoryStream = new MemoryStream())
			{
				var binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, data);
				memoryStream.Flush();
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}
	}
}