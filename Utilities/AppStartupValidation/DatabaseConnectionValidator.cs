using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Utilities.Arguments;
using Utilities.Stopwatch;

namespace Utilities.AppStartupValidation
{
	///<summary>
	/// Validates by checking if database connection string exists and then by establishing connection
	///</summary>
	public class DatabaseConnectionValidator : IValidator
	{
		/// <summary>
		/// List of connection string names to validate
		/// </summary>
		private readonly IEnumerable<string> connectionStringNames;

		/// <summary>
		/// Initializes a new instance of type <see cref="DatabaseConnectionValidator"/>
		/// </summary>
		/// <param name="connectionStringNames">List of connection string names to validate</param>
		/// <exception cref="ArgumentNullException"/>
		public DatabaseConnectionValidator(IEnumerable<string> connectionStringNames)
		{
			connectionStringNames.ThrowIfNull();

			this.connectionStringNames = connectionStringNames;
		}

		/// <summary>
		/// Loop through each connection string names and validates by checking if it exists and then by establishing connection
		/// </summary>
		/// <exception cref="ConfigurationErrorsException"/>
		/// <exception cref="SqlException"/>
		public void Validate()
		{
			Trace.WriteLine("Starting DatabaseConnection validation");

			foreach (var connectionStringName in connectionStringNames)
			{
				var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

				if (connectionStringSettings == null)
				{
					throw new ConfigurationErrorsException(string.Format("Connection string with name {0} not found", connectionStringName));
				}

				using (var conn = new SqlConnection(connectionStringSettings.ConnectionString))
				{
					using (new ExecutionTimeTracer())
					{
						//var t = new Task(conn.Open);
						//t.Start();
						//t.Wait(new TimeSpan(0, 0, 0, 5));

						conn.Open();
					}
				}
			}

			Trace.WriteLine("DatabaseConnection validation complete");
		}
	}
}