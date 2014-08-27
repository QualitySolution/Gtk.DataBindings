using System;
using Gtk.DataBindings;
using System.Data.Bindings;

namespace sample5
{
	public class Address : Observeable
	{
		private string name = "";
		public string Name {
			get { return (name); }
			set { name = value; }
		}
		
		private string middlename = "";
		public string MiddleName {
			get { return (middlename); }
			set { middlename = value; }
		}
		
		private string lastname = "";
		public string LastName {
			get { return (lastname); }
			set { lastname = value; }
		}
		
		public string FullName {
			get {
				if (MiddleName == "")
					return (Name + " " + LastName);
				else
					if (MiddleName.Length == 1)
						return (Name + " " + MiddleName + ". " + LastName);
					else
						return (Name + " " + MiddleName + " " + LastName);
			}
		}
		
		private string webpage = "";
		public string WebPage {
			get { return (webpage); }
			set { webpage = value; } 
		}
		
		private string email = "";
		public string Email {
			get { return (email); }
			set { email = value; } 
		}
		
		private string phone = "";
		public string Phone {
			get { return (phone); }
			set { phone = value; } 
		}
		
		public Address()
		{
		}

		public Address(string aFN, string aM, string aLN, string aPhone, string aSite, string aMail)
		{
			Name = aFN;
			MiddleName = aM;
			LastName = aLN;
			Phone = aPhone;
			WebPage = aSite;
			Email = aMail;
		}
	}
}
