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
using Gtk.DataBindings;
using stopwatch;
using System.Data.Bindings;
using System.Data.Bindings.Utilities;

public partial class MainWindow: Gtk.Window
{	
	private ConfigFile configFile = null;
	private stopwatch.Timer timer = null;
	private ActionController cntActive = null;
	private GtkAdaptor selection = new GtkAdaptor();
	
	public TimerList list {
		get { return (configFile.ConfigAdaptor.FinalTarget as stopwatch.TimerList); }
	}
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		ApplicationPreferences.AddMasterConfiguration (typeof(TimerList), false);
		configFile = ApplicationPreferences.GetMasterConfiguration();
		configFile.Load();

		Build ();
		Timers.ItemsDataSource = list;
		selection.Target = Timers.CurrentSelection;
		cntActive = new ActionController (selection, "", "", 
		                                  new ActionMonitor (ActionMonitorType.Sensitivity, removeAction,
		                                                     new ActionMonitorDefaults (ActionMonitorDefaultsType.NotNullTarget)),
		                                  new ActionMonitor (ActionMonitorType.Sensitivity, propertiesAction,
		                                                     new ActionMonitorDefaults (ActionMonitorDefaultsType.NotNullTarget))
		                                  );
		for (int i=1; i<=25; i++) {
			Timer tim = new Timer ("Timer " + i, 0,1,i);
			list.Add (tim);
			tim.Active = true;
		}
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		configFile.Save();
		Application.Quit();
		a.RetVal = true;
	}

	protected virtual void OnAddActionActivated (object sender, System.EventArgs e)
	{
		StopWatchDialog dialog = new StopWatchDialog();
		dialog.Modal = true;
		timer = new stopwatch.Timer ("Untitled", 0, 15, 0);
		dialog.Data = timer;
		dialog.Run();
		list.Add (timer);
		dialog.Data = null;
		Gtk.DataBindings.Notificator.Disconnect (dialog);
		dialog.Destroy();
	}

	protected virtual void OnPropertiesActionActivated (object sender, System.EventArgs e)
	{
		if (Timers.CurrentSelection.FinalTarget == null)
			return;
		Timer tim = (Timer) Timers.CurrentSelection.FinalTarget;
		StopWatchDialog dialog = new StopWatchDialog();
		dialog.Modal = true;
		dialog.Data = tim;
		dialog.Run();
		dialog.Data = null;
		Gtk.DataBindings.Notificator.Disconnect (dialog);
		dialog.Destroy();
	}

	protected virtual void OnRemoveActionActivated (object sender, System.EventArgs e)
	{
		if (Timers.CurrentSelection.FinalTarget == null)
			return;
		(Timers.CurrentSelection.FinalTarget as Timer).Active = false;
		list.Remove (Timers.CurrentSelection.FinalTarget);
	}
}
