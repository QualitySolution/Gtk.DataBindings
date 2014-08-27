// MainWindow.cs created with MonoDevelop
// User: matooo at 10:01 PM 3/26/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using Gtk;
using copyprogress;

public partial class MainWindow: Gtk.Window
{	
	private FileList fl = new FileList();
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		MainBox.DataSource = fl;
		fl.Copy();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}