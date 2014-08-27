// MainWindow.cs created with MonoDevelop
// User: matooo at 5:44 PM 2/24/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using Gtk;
using dbsample1;

public partial class MainWindow: Gtk.Window
{
	SQLData sql = null;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
//		System.Data.Bindings.DebugInformation.Debug.Active = true;
//		System.Data.Bindings.DebugInformation.Debug.DevelopmentInfo = true;
		System.Data.Bindings.DebugInformation.ConsoleDebug.Connect();
		System.Data.Bindings.DebugInformation.Debug.DevelInfo("test");
		Build ();
		sql = new SQLData();
		datatreeview1.ItemsDataSource = sql.DemoTable;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}