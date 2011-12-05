using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Utilities.Serialization
{
	/// <summary>
	/// Helper class to serialize and deserialize using <see cref="XmlSerializer"/>
	/// </summary>
	public class XmlSerializationHelper
	{
		/// <summary>
		/// Converts string representation to requested object type
		/// </summary>
		/// <typeparam name="T">Requested object type</typeparam>
		/// <param name="data">Data to deserialize</param>
		/// <returns>Instance of type</returns>
		public static T Deserialize<T>(string data)
		{
			var xmlSerializer = new XmlSerializer(typeof(T));

			using (var stringReader = new StringReader(data))
			{
				using (var xmlTextReader = new XmlTextReader(stringReader))
				{
					return (T)xmlSerializer.Deserialize(xmlTextReader);
				}
			}
		}

		/// <summary>
		/// Serializes the specified data into string representation
		/// </summary>
		/// <param name="data">Data to serialize</param>
		/// <returns>String representation of serialized object</returns>
		public static string Serialize<T>(object data)
		{
			var xmlSerializer = new XmlSerializer(typeof(T));

			using (var stringWriter = new StringWriter())
			{
				xmlSerializer.Serialize(stringWriter, data);
				return stringWriter.ToString();
			}
		}
	}
}