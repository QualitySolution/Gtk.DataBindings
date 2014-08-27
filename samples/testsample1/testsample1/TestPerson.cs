// TestPerson.cs created with MonoDevelop
// User: matooo at 6:01 PM 3/26/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace testsample1
{
	public class TestPerson
	{
		private string name = "";
		public string Name {
			get { return (name); }
			set { 
				name = value;
				Gtk.DataBindings.Notificator.ObjectChangedNotification (this);
			}
		}

		private string lastName = "";
		public string LastName {
			get { return (lastName); }
			set { 
				lastName = value;
				Gtk.DataBindings.Notificator.ObjectChangedNotification (this);
			}
		}

		private int age = 0;
		public int Age {
			get { return (age); }
			set { 
				age = value;
				Gtk.DataBindings.Notificator.ObjectChangedNotification (this);
			}
		}
		
		public TestPerson()
		{
		}
		
		public TestPerson (string aName, string aLastName, int aAge)
		{
			name = aName;
			lastName = aLastName;
			age = aAge;
		}
	}
}
