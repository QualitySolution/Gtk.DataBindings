//MainWindow.cs - Description
//
//Author: m. <ml@arsis.net>
//
//Copyright (c) 2008 m.
//
//This program is free software; you can redistribute it and/or
//modify it under the terms of version 2 of the Lesser GNU General 
//Public License as published by the Free Software Foundation.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//Lesser General Public License for more details.
//
//You should have received a copy of the GNU Lesser General Public
//License along with this program; if not, write to the
//Free Software Foundation, Inc., 59 Temple Place - Suite 330,
//Boston, MA 02111-1307, USA.
//
//
using System;
using Gtk;
using nobox_test;
using System.Data.Bindings;

public partial class MainWindow: Gtk.Window
{	
	public TestClass tst = new TestClass();
	public TestClass tst2 = new TestClass("second", "test");
	public Adaptor adaptor = new Adaptor();
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		adaptor.Target = tst;
		dataentry1.DataSource = adaptor;
		dataentry2.DataSource = adaptor;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
	{
		if (adaptor.Target == tst)
			adaptor.Target = tst2;
		else
			adaptor.Target = tst;
	}
}