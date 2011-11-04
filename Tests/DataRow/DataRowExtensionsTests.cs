using System;
using System.Data;
using NUnit.Framework;
using Utilities.DataRow;

namespace Tests.DataRow
{
	[TestFixture]
	public class DataRowExtensionsTests
	{
		private const string COLUMN_ID = "Id";
		private const string COLUMN_BOOL = "Bool";

		[Test]
		public void CanRetrieveValueFromDataRowForRequestedType()
		{
			var dr = GetDataRow();

			Assert.That(dr.GetValue<int>(COLUMN_ID), Is.EqualTo(1));
		}

		[Test]
		public void CanRetrieveValueFromDataRowForRequestedTypeWithDbNull()
		{
			var dr = GetDataRow();

			Assert.That(dr.GetValueOrDefault(COLUMN_BOOL, false), Is.False);
		}

		private System.Data.DataRow GetDataRow()
		{
			var dt = new DataTable();
			dt.Columns.Add(new DataColumn(COLUMN_ID, typeof(int)));
			dt.Columns.Add(new DataColumn(COLUMN_BOOL, typeof(bool)));

			var dr = dt.NewRow();
			dr[COLUMN_ID] = 1;
			dr[COLUMN_BOOL] = DBNull.Value;

			return dr;
		}
	}
}