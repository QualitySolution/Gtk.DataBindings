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
using System.Data.Bindings.Utilities;

public partial class MainWindow: Gtk.Window
{	
	public System.Data.Bindings.Adaptor adaptor = new System.Data.Bindings.Adaptor();
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		datavbox1.DataSource = adaptor;
		adaptor.Target = ApplicationPreferences.GetMasterConfiguration().ConfigAdaptor;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButton5Clicked (object sender, System.EventArgs e)
	{
		datavbox1.DataSource = ApplicationPreferences.GetMasterConfiguration().ConfigAdaptor;
	}

	protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
	{
		System.Data.Bindings.Notificator.ReloadObjectNotification (ApplicationPreferences.GetMasterConfiguration().Configuration, null);
	}

	protected virtual void OnButton3Clicked (object sender, System.EventArgs e)
	{
	}

	protected virtual void OnDataspinbutton2LeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
	{
	}

}