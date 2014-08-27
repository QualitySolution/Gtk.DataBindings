// ConnectionDialog.cs created with MonoDevelop
// User: matooo at 6:30 PM 2/24/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Gtk.DataBindings;

namespace dbsample1
{
	public partial class ConnectionDialog : Gtk.Dialog
	{
		public GtkAdaptor pointer = new GtkAdaptor();
		
		public ConnectionDialog (SQLData aData)
		{
			this.Build();
			pointer.Target = aData;
			datatable1.DataSource = pointer;
		}
	}
}
