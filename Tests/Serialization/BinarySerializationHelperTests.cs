using System;
using NUnit.Framework;
using Utilities.Serialization;

namespace Tests.Serialization
{
	[TestFixture]
	public class BinarySerializationHelperTests
	{
		[Test]
		public void CanSerializeAndDeserializeException()
		{
			const string exMessage = "Message";
			const string dataKey = "CustomerId";
			const int dataValue = 101;

			var innerEx = new ArgumentException("SomeArgument");
			innerEx.Data.Add(dataKey, dataValue);
			var ex = new Exception(exMessage, innerEx);

			string serializedException = BinarySerializationHelper.Serialize(ex);

			var deserializedException = BinarySerializationHelper.Deserialize<Exception>(serializedException);

			Assert.That(deserializedException, Is.Not.Null);
			Assert.That(deserializedException.Message, Is.EqualTo(exMessage));
			Assert.That(deserializedException.InnerException, Is.Not.Null);
			Assert.That(deserializedException.InnerException.Data.Count, Is.EqualTo(1));
			Assert.That(deserializedException.InnerException.Data[dataKey], Is.EqualTo(dataValue));
		}
	}
}