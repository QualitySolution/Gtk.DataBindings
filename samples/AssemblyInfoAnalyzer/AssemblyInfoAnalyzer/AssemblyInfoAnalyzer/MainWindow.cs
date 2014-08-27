//  
//  Copyright (C) 2009 matooo
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
using System;
using Gtk;
using System.Reflection;
using System.Data.Bindings;

public partial class MainWindow: Gtk.Window
{	
	private AssemblyList assemblies = null;
	
	private string inspectedAssembly = "";
	public string InspectedAssembly {
		get { return (inspectedAssembly); }
		set { 
			if (inspectedAssembly == value)
				return;
			inspectedAssembly = value; 
			assemblies = new AssemblyList (inspectedAssembly);
			AssemblyListTree.ItemsDataSource = assemblies.Assemblies;
		}
	}
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButtonOpenClicked (object sender, System.EventArgs e)
	{
		FileChooserDialog dlg = new FileChooserDialog ("Open assembly", this, FileChooserAction.Open, "Open", ResponseType.Accept);
		FileFilter filter = new FileFilter();
		filter.Name = "Exe and Dll files";
//		filter.AddMimeType("image/png");
		filter.AddPattern("*.dll");
//		filter.AddMimeType("image/jpeg");
		filter.AddPattern("*.exe");
		dlg.AddFilter(filter);
		
		if (dlg.Run() == (int)ResponseType.Accept) {
			System.Console.WriteLine (dlg.Filename);
			InspectedAssembly = dlg.Filename;
		}
		//Don't forget to call Destroy() or the FileChooserDialog window won't get closed.
		dlg.Destroy();
	}

	protected virtual void OnAssemblyListTreeCursorChanged (object sender, System.EventArgs e)
	{
		TypeTree.ItemsDataSource = (AssemblyListTree.CurrentSelection.FinalTarget as AssemblyDescription).DevelopmentInformation;
		if (TypeTree.ItemsDataSource != null)
			TypeTree.ExpandAll();
		InfoTree.ItemsDataSource = (AssemblyListTree.CurrentSelection.FinalTarget as AssemblyDescription).DevelopmentInformation.DevelopmentDescriptions;
		if (InfoTree.ItemsDataSource != null)
			InfoTree.ExpandAll();
		InfoLabel.Markup = "<b>Assembly</b> development information";
		DescriptionBox.DataSource = null;
		DescriptionBox.Visible = false;
	}

	protected virtual void OnTypeTreeCursorChanged (object sender, System.EventArgs e)
	{
		InfoTree.ItemsDataSource = (TypeTree.CurrentSelection.FinalTarget as IDevelopmentInformation).DevelopmentDescriptions;
		if (InfoTree.ItemsDataSource != null)
			InfoTree.ExpandAll();
		InfoLabel.Markup = "<b>Type</b> development information";
		DescriptionBox.DataSource = null;
		DescriptionBox.Visible = false;
	}

	protected virtual void OnTypeTreeCellDescription (Gtk.TreeViewColumn aColumn, object aObject, Gtk.CellRenderer aCell)
	{
		if (aObject is TypeDevelopmentInformation) {
			aCell.CellBackgroundGdk = new Gdk.Color (225, 225, 225);
			if (aCell is CellRendererText)
				(aCell as CellRendererText).Font = "Bold";
		}
		else {
			aCell.CellBackgroundGdk = new Gdk.Color (255, 255, 255);
			if (aCell is CellRendererText)
				(aCell as CellRendererText).Font = "Normal";
		}
	}

	protected virtual void OnInfoTreeCellDescription (Gtk.TreeViewColumn aColumn, object aObject, Gtk.CellRenderer aCell)
	{
		if (aObject is DevelopmentInformationItem) {
			aCell.CellBackgroundGdk = new Gdk.Color (255, 255, 255);
			if (aCell is CellRendererText)
				(aCell as CellRendererText).Font = "Normal";
		}
		else {
			aCell.CellBackgroundGdk = new Gdk.Color (225, 225, 225);
			if (aCell is CellRendererText)
				(aCell as CellRendererText).Font = "Bold";
		}
	}

	protected virtual bool OnAssemblyListTreeIsVisibleInFilter (object aObject)
	{
		return (true);
	}

	protected virtual void OnAssemblyListTreeCellDescription (Gtk.TreeViewColumn aColumn, object aObject, Gtk.CellRenderer aCell)
	{
		if (aObject is System.Data.Bindings.AssemblyDescription) {
			AssemblyDevelopmentInformation ad = (aObject as System.Data.Bindings.AssemblyDescription).DevelopmentInformation;
			if ((ad.Count > 0) || 
			    ((ad.DevelopmentDescriptions != null) &&
			     (ad.DevelopmentDescriptions.Count > 0))) {
				if (aCell is CellRendererText)
					(aCell as CellRendererText).Font = "Bold";
			}
			else 
				if (aCell is CellRendererText)
					(aCell as CellRendererText).Font = "Normal";
		}
		else
			if (aCell is CellRendererText)
				(aCell as CellRendererText).Font = "Normal";
	}

	protected virtual void OnInfoTreeCursorChanged (object sender, System.EventArgs e)
	{
		DescriptionBox.DataSource = InfoTree.CurrentSelection.Target;
		DescriptionBox.Visible = (DescriptionBox.DataSource != null);
	}
}