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
using Gdk;
using Gtk;
using System.Data.Bindings;
using Gtk.DataBindings;
using System.Threading;

namespace AutoLayoutTest
{
	public class TestClass : BaseNotifyPropertyChanged
	{
		private string name = "";
		[PropertyDescription ("Name", Hint="Enter name")]
		public string Name {
			get { return (name); }
			set {
				if (name == value)
					return;
				name = value;
				OnPropertyChanged ("Name");
			}
		}
		
		private DateTime birth = DateTime.Now;
		[PropertyDescription ("Date of birth", Hint="Enter date of birth", DataTypeHandler="date")]
		public DateTime Birth {
			get { return (birth); }
			set {
				if (birth.Equals(value) == true)
					return;
				birth = value;
				OnPropertyChanged("Birth");
			}
		}
		
		private float percent = 0.1222f;
		[PropertyDescription ("Percents", Hint="Percent hint", DataTypeHandler="percent")]
		public float Percent {
			get { return (percent); }
			set {
				if (percent == value)
					return;
				percent = value;
				OnPropertyChanged ("Percent");
			}
		}
		
		
		private float money = 12323.22f;
		[PropertyDescription ("Money", Hint="Money hint", DataTypeHandler="currency")]
		public float Money {
			get { return (money); }
			set {
				if (money == value)
					return;
				money = value;
				OnPropertyChanged ("Money");
			}
		}
	}
	
	class MainClass
	{
		public static void Main (string[] args)
		{
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sl-SI");
			Thread.CurrentThread.CurrentCulture.SetSlovenian();
			
			Gdk.Color c = new Gdk.Color(255,125,0);
			System.Console.WriteLine(c.ToHtmlColor());
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}