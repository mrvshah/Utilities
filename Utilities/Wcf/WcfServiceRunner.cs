using System;
using System.Diagnostics;
using System.ServiceModel;

namespace Utilities.Wcf
{
	/// <summary>
	/// Wrapper to centralise logic for starting and stopping service
	/// </summary>
	/// <typeparam name="T">Type of service to start</typeparam>
	public sealed class WcfServiceRunner<T> : IDisposable where T : class
	{
		/// <summary>
		/// Gets the service host
		/// </summary>
		public ServiceHost Host { get; private set; }

		private bool disposed;

		/// <summary>
		/// Initializes a new instance of the <see cref="WcfServiceRunner&lt;T&gt;"/> class
		/// </summary>
		public WcfServiceRunner()
		{
			Trace.WriteLine(string.Format("Creating service of type {0}", typeof(T)));
			Host = new ServiceHost(typeof(T));
			disposed = false;
			Trace.WriteLine(string.Format("Service created"));
		}

		/// <summary>
		/// Starts the service
		/// </summary>
		public void Start()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Object was disposed");
			}

			Trace.WriteLine("Opening service host");
			Host.Open();
			Trace.WriteLine("Service host opened successfully");
		}

		public void Dispose()
		{
			Dispose(true);

			// Use SupressFinalize in case a subclass of this type implements a finalizer.
			// class is sealed
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				Trace.WriteLine("Service is not disposed");
				if (disposing)
				{
					Trace.WriteLine("Service is in process of disposing");
					if (Host != null)
					{
						Trace.WriteLine("Closing service host");
						Host.Close();
						Trace.WriteLine("Service host closed successfully");
						Trace.WriteLine("Disposing service host");
						((IDisposable)Host).Dispose();
						Trace.WriteLine("Service host disposed successfully");
						Host = null;
						disposed = true;
					}
					else
					{
						Trace.WriteLine("Service host is null");
					}
				}
			}
			else
			{
				Trace.WriteLine("Service already disposed");
			}
		}
	}
}