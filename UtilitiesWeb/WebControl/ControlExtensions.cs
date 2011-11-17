using System.Collections.Generic;
using System.Web.UI;

namespace Utilities.WebControl
{
	/// <summary>
	/// Extension methods on <see cref="Control"/>
	/// </summary>
	public static class ControlExtensions
	{

		/// <summary>
		/// Return all the child controls of control collection
		/// </summary>
		/// <param name="controlCollection">The control collection</param>
		/// <returns>List of all child controls</returns>
		public static IEnumerable<Control> AllChildControls(this ControlCollection controlCollection)
		{
			if (controlCollection != null)
			{
				foreach (Control control in controlCollection)
				{
					yield return control;

					if (control != null && control.HasControls())
					{
						foreach (Control childControl in control.Controls.AllChildControls())
						{
							yield return childControl;
						}
					}
				}
			}
			else
			{
				yield return null;
			}
		}

		/// <summary>
		/// Return all the child controls of the page
		/// </summary>
		/// <param name="page">The page</param>
		/// <returns>List of all child controls</returns>
		public static IEnumerable<Control> AllChildControls(this Page page)
		{
			if (page == null) return null;
			return page.Controls.AllChildControls();
		}

		/// <summary>
		/// Return all the child controls of the control
		/// </summary>
		/// <param name="control">The control</param>
		/// <returns>List of all child controls</returns>
		public static IEnumerable<Control> AllChildControls(this Control control)
		{
			if (control == null) return null;
			return control.Controls.AllChildControls();
		}
	}
}