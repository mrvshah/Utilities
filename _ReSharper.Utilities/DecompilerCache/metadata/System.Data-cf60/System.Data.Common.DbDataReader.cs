// Type: System.Data.Common.DbDataReader
// Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Data.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace System.Data.Common
{
	public abstract class DbDataReader : MarshalByRefObject, IDataReader, IDisposable, IDataRecord, IEnumerable
	{
		public abstract bool HasRows { get; }
		public virtual int VisibleFieldCount { get; }

		#region IDataReader Members

		public abstract void Close();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose();

		public abstract string GetDataTypeName(int ordinal);

		public abstract Type GetFieldType(int ordinal);
		public abstract string GetName(int ordinal);
		public abstract int GetOrdinal(string name);
		public abstract DataTable GetSchemaTable();
		public abstract bool GetBoolean(int ordinal);
		public abstract byte GetByte(int ordinal);
		public abstract long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length);
		public abstract char GetChar(int ordinal);
		public abstract long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length);

		IDataReader IDataRecord.GetData(int ordinal);
		public abstract DateTime GetDateTime(int ordinal);
		public abstract decimal GetDecimal(int ordinal);
		public abstract double GetDouble(int ordinal);
		public abstract float GetFloat(int ordinal);
		public abstract Guid GetGuid(int ordinal);
		public abstract short GetInt16(int ordinal);
		public abstract int GetInt32(int ordinal);
		public abstract long GetInt64(int ordinal);

		public abstract string GetString(int ordinal);
		public abstract object GetValue(int ordinal);
		public abstract int GetValues(object[] values);
		public abstract bool IsDBNull(int ordinal);
		public abstract bool NextResult();
		public abstract bool Read();
		public abstract int Depth { get; }
		public abstract int FieldCount { get; }
		public abstract bool IsClosed { get; }
		public abstract int RecordsAffected { get; }
		public abstract object this[int ordinal] { get; }
		public abstract object this[string name] { get; }

		#endregion

		#region IEnumerable Members

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract IEnumerator GetEnumerator();

		#endregion

		protected virtual void Dispose(bool disposing);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbDataReader GetData(int ordinal);

		protected virtual DbDataReader GetDbDataReader(int ordinal);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual Type GetProviderSpecificFieldType(int ordinal);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual object GetProviderSpecificValue(int ordinal);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int GetProviderSpecificValues(object[] values);
	}
}
