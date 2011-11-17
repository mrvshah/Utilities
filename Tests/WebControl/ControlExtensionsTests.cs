using System.Linq;
using System.Web.UI;
using NUnit.Framework;
using Utilities.WebControl;

namespace Tests.WebControl
{
	[TestFixture]
	public class ControlExtensionsTests
	{
		[Test]
		public void AllChildControlsReturnsNullWhenPageIsNull()
		{
			Page page = null;
			Assert.That(page.AllChildControls(), Is.Null);
		}

		[Test]
		public void AllChildControlsReturnsNullWhenControlIsNull()
		{
			Control control = null;
			Assert.That(control.AllChildControls(), Is.Null);
		}

		[Test]
		public void AllChildControlsReturnsNullWhenControlCollectionIsNull()
		{
			// ControlsCollection in control is never null
		}

		[Test]
		public void ZeroReturnedWhenPageControlCollectionIsEmpty()
		{
			Assert.That(new Page().AllChildControls().Count(), Is.EqualTo(0));
		}

		[Test]
		public void ZeroReturnedWhenControlsControlCollectionIsEmpty()
		{
			Assert.That(new Page().AllChildControls().Count(), Is.EqualTo(0));
		}

		[Test]
		public void ZeroReturnedWhenControlCollectionIsEmpty()
		{
			Assert.That(new Control().AllChildControls().Count(), Is.EqualTo(0));
		}

		[Test]
		public void AllChildControlsLoopThroughEachChildControlsInPageControlsTree()
		{
			var page = new Page();
			var control = new Control();
			var childControl = new Control();
			control.Controls.Add(childControl);
			page.Controls.Add(control);

			Assert.That(page.AllChildControls().Count(), Is.EqualTo(2));
		}

		[Test]
		public void AllChildControlsLoopThroughEachChildControlsInControlCollectionTree()
		{
			var page = new Page();
			var controlCollection = new ControlCollection(page);
			var control1 = new Control();
			var control2 = new Control();
			var childControl1 = new Control();
			var childControl2 = new Control();
			controlCollection.Add(control1);
			controlCollection.Add(control2);
			control2.Controls.Add(childControl1);
			control2.Controls.Add(childControl2);

			Assert.That(controlCollection.AllChildControls().Count(), Is.EqualTo(4));
		}

		[Test]
		public void AllChildControlsLoopThroughEachChildControlsInControlControlsTree()
		{
			var control = new Control();
			var control1 = new Control();
			var control2 = new Control();
			var childControl1 = new Control();
			var childControl2 = new Control();
			var childChildControl = new Control();
			control.Controls.Add(control1);
			control.Controls.Add(control2);
			control2.Controls.Add(childControl1);
			control2.Controls.Add(childControl2);
			childControl1.Controls.Add(childChildControl);

			Assert.That(control.AllChildControls().Count(), Is.EqualTo(5));
		}
	}

	class TestPage : Page
	{

	}

	class TestControl : Control
	{

	}
}