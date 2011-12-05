using System.Collections.Generic;
using NUnit.Framework;
using Utilities.Serialization;

namespace Tests.Serialization
{
	[TestFixture]
	public class XmlSerializationHelperTests
	{
		[Test]
		public void CanSerializeAndDeserializeException()
		{
			var strings = new List<string>();
			strings.Add("First");
			strings.Add("Second");

			var serializedData = XmlSerializationHelper.Serialize<List<string>>(strings);

			var deserializedStrings = XmlSerializationHelper.Deserialize<List<string>>(serializedData);

			Assert.That(deserializedStrings.Count, Is.EqualTo(2));
		}
	}
}