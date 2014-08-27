// MainWindow.cs created with MonoDevelop
// User: matooo at 5:56 PM 3/26/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	testsample1.TestPerson tp = new testsample1.TestPerson ("Joe", "schmoe", 17);
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		MainBox.DataSource = tp; 
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
	{
		tp.Age++;
		tp.LastName += "a";
		tp.Name += "b";
	}
}