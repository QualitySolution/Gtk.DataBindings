using System;
using Gtk;
using sample5;

//TODO
// Resolve
//   - auto updating of non specified type in TreeView
public partial class MainWindow: Gtk.Window
{
	public static AddressGroup list = new AddressGroup ("GLOBAL");
	public static AddressGroup ng = null;
	public static Address na = new Address();
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build (); 
		AddressGroup dg = new AddressGroup ("Dummy group"); 
		list.Add (dg);
		Address p = new Address ("John", "S", "Smith", "234 2 234324", "http://www.somesite.com", "john@somesite.com");
		dg.Add (p);
		addressview.ItemsDataSource = list;
		p = new Address ("newJohnds", "Ssd", "Smithddf", "234 2 234324", "http://www.somesite.com", "john@somesite.com");
		dg.Add (p);
		p = new Address ("downJohnds", "Ssd", "Smithddf", "234 2 234324", "http://www.somesite.com", "john@somesite.com");
		list.Add (p);
		datavbox1.DataSource = addressview.CurrentSelection;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnNewaddressClicked(object sender, System.EventArgs e)
	{
		na = new Address();
		NewAddress dlg = new NewAddress (na);
		dlg.Run();
		list.Add (na);
		dlg = null;
	}

	protected virtual void OnNewgroupClicked(object sender, System.EventArgs e)
	{
		ng = new AddressGroup("untitled");
		NewGroup dlg = new NewGroup (ng);
		dlg.Run();
		list.Add (ng);
		dlg = null;
	}

	protected virtual void OnDeleteClicked(object sender, System.EventArgs e)
	{
	}

	protected virtual void OnCloseClicked(object sender, System.EventArgs e)
	{
		Application.Quit ();
	}

	protected virtual void OnPropertiesClicked(object sender, System.EventArgs e)
	{
		object cur = addressview.GetCurrentObject();
		if (cur == null)
			return;
		if (cur is Address) {
			na = (Address) cur;
			NewAddress dlg = new NewAddress (na);
			dlg.Run();
			dlg = null;
		}
		else {
			ng = (AddressGroup) cur;
			NewGroup dlg = new NewGroup (ng);
			dlg.Run();
			dlg = null;
		}
	} 

	protected virtual void OnButton163Clicked(object sender, System.EventArgs e)
	{
		addressview.ItemsDataSource = null;
		addressview.ItemsDataSource = list;
	}
}
