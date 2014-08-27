// Timer.cs - Field Attribute to assign additional information for Gtk#Databindings
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
using System.Xml;
using System.Threading;
using System.Data.Bindings;

namespace stopwatch
{
	[Serializable()]
	public class Timer : BaseNotifyPropertyChanged
	{
		private bool wasactive = false;
		private Gdk.Pixbuf ok = Gdk.Pixbuf.LoadFromResource ("ok.png");
		private Gdk.Pixbuf inactive = Gdk.Pixbuf.LoadFromResource ("inactive.png");
		private Gdk.Pixbuf elapsed = Gdk.Pixbuf.LoadFromResource ("elapsed.png");
		private Gdk.Pixbuf elapsedinactive = Gdk.Pixbuf.LoadFromResource ("elapsed_inactive.png");

		private string name = "";
		public string Name {
			get { return (name); }
			set { 
				name = value; 
				OnPropertyChanged ("Name");
			} 
		}

		private TimeSpan elapsedTime = TimeSpan.Zero;
		public TimeSpan ElapsedTime {
			get { return (elapsedTime); }
			set { 
				elapsedTime = value; 
				OnPropertyChanged ("ElapsedTime");
			} 
		}

		private TimeSpan maxTime = TimeSpan.Zero;
		public TimeSpan MaxTime {
			get { return (maxTime); }
			set { 
				maxTime = value; 
				OnPropertyChanged ("MaxTime");
			}
		}

		private DateTime startTime = DateTime.MinValue;
		public DateTime StartTime {
			get { return (startTime); }
			set { startTime = value; } 
		}

		private DateTime thisSession = DateTime.MinValue;
		public DateTime ThisSession {
			get { return (thisSession); }
			set { thisSession = value; } 
		}

		public int MaxHours {
			get { return (MaxTime.Hours); }
			set {
				MaxTime = new TimeSpan(value, MaxTime.Minutes, MaxTime.Seconds); 
			}
		}
				
		public int MaxMinutes {
			get { return (MaxTime.Minutes); }
			set { 
				MaxTime = new TimeSpan(MaxTime.Hours, value, MaxTime.Seconds); 
			}
		}
				
		public int MaxSeconds {
			get { return (MaxTime.Seconds); }
			set { 
				MaxTime = new TimeSpan(MaxTime.Hours, MaxTime.Minutes, value); 
			}
		}
				
		public bool Elapsed {
			get { return (MaxTime < ElapsedTime); }
		}
		
		private bool active = false;
		public bool Active {
			get { return (active); }
			set { 
				if (active == value)
					return;
				active = value;
				if (active == true) {
					if (wasactive == false) {
						StartTime = DateTime.Now;
						wasactive = true;
					}
					else { 
						StartTime = DateTime.Now.AddHours(0-ElapsedTime.Hours).AddMinutes(0-ElapsedTime.Minutes).AddSeconds(0-ElapsedTime.Seconds);
					}
//					ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
					StartClock();
				}
				Gtk.DataBindings.Notificator.ObjectChangedNotification (this);
			} 
		}
		
		public string StringValue {
			get { 
				return (string.Format ("{0:00}:{1:00}:{2:00}", ElapsedTime.Days*24 + 
				                       ElapsedTime.Hours, ElapsedTime.Minutes, ElapsedTime.Seconds));
			}
		}

		public string MaxTimeStringValue {
			get { 
				return (string.Format ("{0:00}:{1:00}:{2:00}", MaxTime.Days*24 + 
				                       MaxTime.Hours, MaxTime.Minutes, MaxTime.Seconds));
			}
		}

		public Gdk.Pixbuf Status {
			get {
				if (Elapsed == true) {
					if (Active == true)
						return (elapsed);
					else
						return (elapsedinactive);
				}
				if (Active == true)
					return (ok);
				else
					return (inactive);
			}
		}

		private void StartClock () 
		{
			GLib.Timeout.Add(1000, new GLib.TimeoutHandler(TimerProc));
		}
		
		private bool TimerProc()
		{
			ElapsedTime = DateTime.Now.Subtract(StartTime);
			return (Active);
		}

		public void ThreadProc(System.Object stateInfo) 
		{
			// condition
			while (Active == true) {
				// work
				ElapsedTime = DateTime.Now.Subtract(StartTime);
				Thread.Sleep (1000);
			}
		}		    

		public override string ToString ()
		{
			return ("Name=" + Name + " TimeLeft=" + StringValue + " Active=" + Active + " Elapsed=" + ElapsedTime);
		}

		public Timer()
		{
		}

		public Timer (string aName, int aHours, int aMin, int aSec)
		{
			Name = aName;
			MaxTime = new TimeSpan (aHours, aMin, aSec);
		}
	}
}
