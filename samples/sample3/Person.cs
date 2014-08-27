
using System;

namespace sample3
{
	public class Person
	{
		private string name = "";
		public string Name {
			get { return (name); }
			set { name = value; }
		}
		
		private string lastname = "";
		public string LastName {
			get { return (lastname); }
			set { 
				lastname = value; 
				Gtk.DataBindings.Notificator.ObjectChangedNotification (this);
			}
		}
		
		public string FullName {
			get { return (Name + " " + LastName); }
		}
		
		private DateTime birthdate = DateTime.Now;
		public DateTime BirthDate {
			get { return (birthdate); }
			set { birthdate = value; }
		}
		
		private Person()
		{
		}

		public Person (string aName, string aLastName)
		{
			Name = aName;
			LastName = aLastName;
		}
	}
}
