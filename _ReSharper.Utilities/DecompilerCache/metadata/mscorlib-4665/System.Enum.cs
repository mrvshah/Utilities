// Type: System.Enum
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
	[ComVisible(true)]
	[Serializable]
	public abstract class Enum : ValueType, IComparable, IFormattable, IConvertible
	{
		protected Enum();

		#region IComparable Members

		[SecuritySafeCritical]
		public int CompareTo(object target);

		#endregion

		#region IConvertible Members

		[Obsolete("The provider argument is not used. Please use ToString().")]
		public string ToString(IFormatProvider provider);

		public TypeCode GetTypeCode();
		bool IConvertible.ToBoolean(IFormatProvider provider);
		char IConvertible.ToChar(IFormatProvider provider);
		sbyte IConvertible.ToSByte(IFormatProvider provider);
		byte IConvertible.ToByte(IFormatProvider provider);
		short IConvertible.ToInt16(IFormatProvider provider);
		ushort IConvertible.ToUInt16(IFormatProvider provider);
		int IConvertible.ToInt32(IFormatProvider provider);
		uint IConvertible.ToUInt32(IFormatProvider provider);
		long IConvertible.ToInt64(IFormatProvider provider);
		ulong IConvertible.ToUInt64(IFormatProvider provider);
		float IConvertible.ToSingle(IFormatProvider provider);
		double IConvertible.ToDouble(IFormatProvider provider);
		decimal IConvertible.ToDecimal(IFormatProvider provider);
		DateTime IConvertible.ToDateTime(IFormatProvider provider);
		object IConvertible.ToType(Type type, IFormatProvider provider);

		#endregion

		#region IFormattable Members

		[Obsolete("The provider argument is not used. Please use ToString(String).")]
		public string ToString(string format, IFormatProvider provider);

		#endregion

		[SecuritySafeCritical]
		public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct, new();

		[SecuritySafeCritical]
		public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result) where TEnum : struct, new();

		[ComVisible(true)]
		public static object Parse(Type enumType, string value);

		[ComVisible(true)]
		public static object Parse(Type enumType, string value, bool ignoreCase);

		[SecuritySafeCritical]
		[ComVisible(true)]
		public static Type GetUnderlyingType(Type enumType);

		[ComVisible(true)]
		public static Array GetValues(Type enumType);

		[ComVisible(true)]
		public static string GetName(Type enumType, object value);

		[ComVisible(true)]
		public static string[] GetNames(Type enumType);

		[ComVisible(true)]
		public static object ToObject(Type enumType, object value);

		[ComVisible(true)]
		public static bool IsDefined(Type enumType, object value);

		[ComVisible(true)]
		public static string Format(Type enumType, object value, string format);

		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public override bool Equals(object obj);

		public override int GetHashCode();
		public override string ToString();

		[SecuritySafeCritical]
		public string ToString(string format);

		public bool HasFlag(Enum flag);

		[ComVisible(true)]
		[SecuritySafeCritical]
		[CLSCompliant(false)]
		public static object ToObject(Type enumType, sbyte value);

		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, short value);

		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, int value);

		[SecuritySafeCritical]
		[ComVisible(true)]
		public static object ToObject(Type enumType, byte value);

		[CLSCompliant(false)]
		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, ushort value);

		[SecuritySafeCritical]
		[CLSCompliant(false)]
		[ComVisible(true)]
		public static object ToObject(Type enumType, uint value);

		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, long value);

		[CLSCompliant(false)]
		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, ulong value);
	}
}
