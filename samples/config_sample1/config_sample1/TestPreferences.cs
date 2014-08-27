//TestPreferences.cs - Description
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

namespace config_sample1
{
	[Serializable]
	public class TestPreferences
	{
		private int intValue = 1;
		public int IntValue {
			get { return (intValue); }
			set { 
				if (intValue == value)
					return;
				intValue = value;
//				Gtk.DataBindings.Notificator.Notify_ReloadObject (this);
			}
		}

		private string strValue = "blabla";
		public string StrValue {
			get { return (strValue); }
			set { 
				if (strValue == value)
					return;
				strValue = value; 
//				Gtk.DataBindings.Notificator.Notify_ReloadObject (this);
			}
		}
		
		public override string ToString()
		{
			return ("Config: IntValue=" + IntValue + "  StrValue=" + StrValue);
		}
	}
}
