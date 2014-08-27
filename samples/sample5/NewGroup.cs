using System;
using Gtk.DataBindings;

namespace sample5
{
	public partial class NewGroup : Gtk.Dialog
	{
		private AddressGroup ag = null;

		private NewGroup()
		{
			this.Build();
		}

		public NewGroup (AddressGroup aGroup)
		{
			this.Build();
			ag = aGroup;
			dataentry1.DataSource = ag;
		}

		protected virtual void OnButton56Clicked(object sender, System.EventArgs e)
		{
			this.Hide();
		}
	}
}
