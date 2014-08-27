using System;
using Gtk.DataBindings;
using System.Data.Bindings;
using System.Data.Bindings.Collections;

namespace sample5
{
	public class AddressGroup : ObserveableArrayList
	{
		private string name;
		public string FullName {
			get { return (name); }
			set { 
				name = value;
				System.Data.Bindings.Notificator.ObjectChangedNotification (this);
			}
		}

		public AddressGroup(string aName)
			: base ()
		{
			name = aName;
		}
	}
}