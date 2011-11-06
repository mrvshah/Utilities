using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Utilities.AppStartupValidators;
using Utilities.Arguments;

namespace Utilities.AppStartupValidation
{
	///<summary>
	/// Database connection validator
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
		public DatabaseConnectionValidator(IEnumerable<string> connectionStringNames)
		{
			connectionStringNames.ThrowIfNull();

			this.connectionStringNames = connectionStringNames;
		}

		/// <summary>
		/// Validate connection strings
		/// </summary>
		public void Validate()
		{
			foreach (var connectionStringName in connectionStringNames)
			{
				var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

				if (connectionStringSettings == null)
				{
					throw new ConfigurationErrorsException(string.Format("Connection string with name {0} not found", connectionStringName));
				}

				using (var conn = new SqlConnection(connectionStringSettings.ConnectionString))
				{
					conn.Open();
				}
			}
		}
	}
}