
using System;

namespace sample3
{
	public partial class CursoredDataWindow : Gtk.Window
	{
		public CursoredDataWindow() : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			datatable1.DataSource = MainWindow.Cursor;
		}
	}
}
