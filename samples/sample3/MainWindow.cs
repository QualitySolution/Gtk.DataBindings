using System;
using Gtk;
using Gtk.DataBindings;
using sample3;

public partial class MainWindow: Gtk.Window
{	
	// DataSource could simply show directly to object, but since this is the demo 
	// of binding multiplication across windows adaptor is needed to simplify process
	public static GtkAdaptor Cursor = new GtkAdaptor();
	public static Person man = new Person ("Joe", "Schmoe");
	public static Person man2 = new Person ("Helluva", "Guy");
	public static CursoredDataWindow info = new CursoredDataWindow();
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		System.Data.Bindings.DebugInformation.Debug.Active = true;
		System.Data.Bindings.DebugInformation.Debug.Level = 10;
		System.Data.Bindings.DebugInformation.ConsoleDebug.Connect();
		
		Build ();
		Cursor.Target = man2;
		datatable1.DataSource = Cursor;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButton3Clicked(object sender, System.EventArgs e)
	{
		(Cursor.Target as Person).LastName += " click"; 
	}

	protected virtual void OnButton1Clicked(object sender, System.EventArgs e)
	{
		Application.Quit ();
	}

	protected virtual void OnButton2Clicked(object sender, System.EventArgs e)
	{
		if (Cursor.Target == man)
			Cursor.Target = man2;
		else
			Cursor.Target = man;
	}

	protected virtual void OnCheckbutton1Activated(object sender, System.EventArgs e)
	{
		info.Visible = checkbutton1.Active;
	}
}