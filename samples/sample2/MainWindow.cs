using System;
using Gtk;
using Gtk.DataBindings;

public class TTestClass/* : Observeable */{
	private string text;
	public string Text {
		get { return (text); }
		set { text = value; }
	}

	public TTestClass()
	{
		text = "blablačšž";
	}
	
}

public partial class MainWindow: Window
{	
	public TTestClass tc = null;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		// Create object for datasource
		tc = new TTestClass();
		Build ();
		// Mapping was assigned from stetic
		dataentry1.DataSource = tc;
		dataentry2.DataSource = tc;
		
		// Adding data aware control by hand
		DataEntry dataentry3 = new DataEntry();
		vbox1.Add (dataentry3);
		dataentry3.Show();
		dataentry3.Mappings = "Text";		
		dataentry3.DataSource = tc;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButton1Clicked(object sender, System.EventArgs e)
	{
		Application.Quit();
	}
}