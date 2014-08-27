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

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		DoubleBuffered = true;
		
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnCheckbutton1Toggled (object sender, System.EventArgs e)
	{
		vbox1.Sensitive = checkbutton1.Active;
	}

	protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
	{
//		image303.Pixbuf = timeentry1.GetDragPixbuf();
	}

	protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
	{
		System.Console.WriteLine("Total:{0}", GC.GetTotalMemory(true));
		GC.Collect();
		System.Console.WriteLine("Total:{0}", GC.GetTotalMemory(true));
	}

	protected virtual void OnCheckbutton2Toggled (object sender, System.EventArgs e)
	{
		timeentry1.HasDropDown = checkbutton2.Active;
	}
}