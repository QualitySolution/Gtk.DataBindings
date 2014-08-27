using System;
using Gtk.DataBindings;

namespace sample5
{
	public partial class NewAddress : Gtk.Dialog
	{
		private NewAddress()
		{
			this.Build();
		}

		public NewAddress (Address aAddress)
		{
			this.Build();
			datatable1.DataSource = aAddress;
		}

		protected virtual void OnButton90Clicked(object sender, System.EventArgs e)
		{
			Hide();
		}
	}
}
