using System;
using Gtk;
using Gtk.DataBindings;
using System.Data;
using System.Data.Bindings;
using System.Data.Bindings.Collections;

public partial class MainWindow: Gtk.Window
{	
	static System.Data.DataTable table = new System.Data.DataTable();
	static DbObservableList ob_list = new DbObservableList(table);

	static int i=3;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		System.Console.WriteLine(DatabaseProvider.IsValidType(typeof(DbObservableList)));
		ob_list.ElementAdded += HandleElementAdded;
		ob_list.ElementChanged += HandleElementChanged;
		ob_list.ElementRemoved += HandleElementRemoved;
		ob_list.ElementsSorted += HandleElementsSorted; //should come to this
		
		table.Columns.Add("ID", typeof(int));
		table.Columns.Add("Title", typeof(string));
		
		table.Rows.Add(new object[] { 1, "Title 1" });
		table.Rows.Add(new object[] { 2, "Title 2" });
		
		table.Rows[0][0] = 66;
		
		table.AcceptChanges();
		
//		table.Rows[0].Delete();
//		System.Console.WriteLine(table.Rows.Count);
//		table.Rows.RemoveAt(1); //you'll notice that Removed event
					//for this one gets fired before the Removed event
					//of element 0 (because it auto-commits it)
//		table.AcceptChanges();
		datatreeview1.ItemsDataSource = table;
//		datatreeview1.ItemsDataSource = ob_list;
		datacombobox1.ItemsDataSource = ob_list;
		datacomboboxentry1.ItemsDataSource = ob_list;
	}

	void HandleElementsSorted(object aObject, int[] aIdx)
	{
		Console.WriteLine("Elements sorted");
	}

	void HandleElementRemoved(object aList, int[] aIdx, object aObject)
	{
		DataRow row = (aObject as DataRow);
		Console.WriteLine("Element removed " + aIdx[0]); // + "; " + row[0, DataRowVersion.Original]);
	}

	void HandleElementChanged(object aList, int[] aIdx)
	{
		Console.WriteLine("Elements changed "+ aIdx[0]);
	}

	void HandleElementAdded(object aList, int[] aIdx)
	{
		Console.WriteLine("Element added " + aIdx[0]);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
	{
		table.Rows.Add(new object[] { i, "Title " + i.ToString() });
		i++;
	}

	protected virtual void OnDatatreeview1CellDescription (Gtk.TreeViewColumn aColumn, object aObject, Gtk.CellRenderer aCell)
	{
		System.Console.WriteLine("HEEEEEREE");
		aCell.CellBackground = "red";
	}
}