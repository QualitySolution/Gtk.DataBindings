//SampleData.cs - Field Attribute to assign additional information for Gtk#Databindings
//
//Author: m. <ml@arsis.net>
//
//Copyright (c) at 9:03 PM 12/24/2008
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

using System;
using System.ComponentModel;

namespace msevent_sample1
{
	/// <summary>
	/// Sample specifying I
	/// </summary>
	public class SampleData : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string firstname = "";
		/// <value>
		/// Property defined as usual property according to MS.DataBinding
		/// </value>
		public string FirstName {
			get { return (firstname); }
			set {
				if (firstname == value)
					return;
				firstname = value;
				if (PropertyChanged != null)
					PropertyChanged (this, new PropertyChangedEventArgs("FirstName"));
			}
		}
		
		private string lastname = "";
		/// <value>
		/// Property defined as usual property according to MS.DataBinding
		/// </value>
		public string LastName {
			get { return (lastname); }
			set {
				if (lastname == value)
					return;
				lastname = value;
				if (PropertyChanged != null)
					PropertyChanged (this, new PropertyChangedEventArgs("LastName"));
			}
		}

		/// <summary>
		/// This is read only property, but it will act alive same as others
		/// </summary>
		public string Name {
			get { return (FirstName + " " + LastName); }
		}
		
		public SampleData()
		{
		}
		
		public SampleData (string fname, string lname)
		{
			FirstName = fname;
			LastName = lname;
		}
	}
}
