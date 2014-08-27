// MainWindow.cs - Field Attribute to assign additional information for Gtk#Databindings
//
// Author: m. <ml@arsis.net>
//
// Copyright (c) 2006 m.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of version 2 of the Lesser GNU General 
// Public License as published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this program; if not, write to the
// Free Software Foundation, Inc., 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.

using System;
using Gtk;
using dbsample2;
using System.Collections;
using System.Data.Bindings.Database;

public partial class MainWindow: Gtk.Window
{	
	TestData testdata = new TestData();
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
//		table1.DataSource = testdata.Connection;
		WindowBox.DataSource = testdata.Connection;
		DriversCB.ItemsDataSource = System.Data.Bindings.Database.DatabaseCenter.DriversAdaptor;
		DatasetsCB.ItemsDataSource = testdata.Connection.DatasetsAdaptor;
		TablesCB.ItemsDataSource = testdata.Connection.TablesInDatasetAdaptor;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnDriversCBChanged (object sender, System.EventArgs e)
	{
		testdata.Connection.DatabaseType = (string) DriversCB.CurrentSelection.FinalTarget;
	}

	protected virtual void OnDatasetsCBChanged (object sender, System.EventArgs e)
	{
		testdata.Connection.Dataset = (string) DatasetsCB.ActiveText;
	}

	protected virtual void OnButton11Clicked (object sender, System.EventArgs e)
	{
	}

	protected virtual void OnTablesCBChanged (object sender, System.EventArgs e)
	{
		TableViewBox.Visible = (DriversCB.CurrentSelection.FinalTarget != null);
		//Loadtable
		if (DriversCB.CurrentSelection.FinalTarget != null) {
			DBTable table = new DBTable(testdata.Connection);
			table.Name = (string) DriversCB.CurrentSelection.FinalTarget;
		}
	}
}