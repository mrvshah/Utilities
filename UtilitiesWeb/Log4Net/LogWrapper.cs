using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Utilities.Log4Net
{
	/// <summary>
	/// Singleton to configure <see cref="XmlConfigurator"/> and access <see cref="ILog"/> for specified type
	/// </summary>
	public class LogWrapper
	{
		private readonly Dictionary<string, ILog> map = new Dictionary<string, ILog>();

		/// <summary>
		/// Gets the specified instance from cache if it exists
		/// </summary>
		/// <typeparam name="T">Type for which logging is required</typeparam>
		/// <returns>Instance of <see cref="ILog"/> for requested type</returns>
		public ILog Get<T>()
		{
			ILog log;

			if (!map.TryGetValue(typeof(T).Name, out log))
			{
				log = LogManager.GetLogger(typeof(T));
				map.Add(typeof(T).Name, log);
			}

			return log;
		}

		/// <summary>
		/// Gets the specified instance from cache if it exists
		/// </summary>
		/// <param name="type">Type for which logging is required</param>
		/// <returns>Instance of <see cref="ILog"/> for requested type</returns>
		public ILog Get(Type type)
		{
			ILog log;

			if (!map.TryGetValue(type.Name, out log))
			{
				log = LogManager.GetLogger(type);
				map.Add(type.Name, log);
			}

			return log;
		}

		/// <summary>
		/// Gets the specified instance from cache if it exists
		/// </summary>
		/// <param name="type">Type for which logging is required</param>
		/// <returns>Instance of <see cref="ILog"/> for requested type</returns>
		public ILog Get(string type)
		{
			ILog log;

			if (!map.TryGetValue(type, out log))
			{
				log = LogManager.GetLogger(type);
				map.Add(type, log);
			}

			return log;
		}

		/// <summary>
		/// Gets the specified instance from cache if it exists
		/// </summary>
		/// <param name="repository">The repository to lookup in</param>
		/// <param name="type">Type for which logging is required</param>
		/// <returns>
		/// Instance of <see cref="ILog"/> for requested type
		/// </returns>
		public ILog Get(string repository, Type type)
		{
			ILog log;

			if (!map.TryGetValue(type.Name, out log))
			{
				log = LogManager.GetLogger(repository, type);
				map.Add(type.Name, log);
			}

			return log;
		}

		/// <summary>
		/// Gets the specified instance from cache if it exists
		/// </summary>
		/// <param name="repository">The repository to lookup in</param>
		/// <param name="type">Type for which logging is required</param>
		/// <returns>
		/// Instance of <see cref="ILog"/> for requested type
		/// </returns>
		public ILog Get(string repository, string type)
		{
			ILog log;

			if (!map.TryGetValue(type, out log))
			{
				log = LogManager.GetLogger(repository, type);
				map.Add(type, log);
			}

			return log;
		}

		/// <summary>
		/// Gets the specified instance from cache if it exists
		/// </summary>
		/// <param name="assemblyRepository">The assembly repository to lookup in</param>
		/// <param name="type">Type for which logging is required</param>
		/// <returns>
		/// Instance of <see cref="ILog"/> for requested type
		/// </returns>
		public ILog Get(Assembly assemblyRepository, string type)
		{
			ILog log;

			if (!map.TryGetValue(type, out log))
			{
				log = LogManager.GetLogger(assemblyRepository, type);
				map.Add(type, log);
			}

			return log;
		}

		/// <summary>
		/// Gets the specified instance from cache if it exists
		/// </summary>
		/// <param name="assemblyRepository">The assembly repository to lookup in</param>
		/// <param name="type">Type for which logging is required</param>
		/// <returns>
		/// Instance of <see cref="ILog"/> for requested type
		/// </returns>
		public ILog Get(Assembly assemblyRepository, Type type)
		{
			ILog log;

			if (!map.TryGetValue(type.Name, out log))
			{
				log = LogManager.GetLogger(assemblyRepository, type);
				map.Add(type.Name, log);
			}

			return log;
		}

		private LogWrapper()
		{
			XmlConfigurator.Configure();
		}

		/// <summary>
		/// Lazy instance of <see cref="LogWrapper"/> class
		/// </summary>
		private static readonly Lazy<LogWrapper> instance = new Lazy<LogWrapper>(() => new LogWrapper(), true);

		/// <summary>
		/// Gets the instance.
		/// </summary>
		public static LogWrapper Instance
		{
			get { return instance.Value; }
		}
	}
}