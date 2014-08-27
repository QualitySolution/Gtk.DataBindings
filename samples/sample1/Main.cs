// project created on 4/21/2006 at 8:20 PM
using System;
using System.Collections;
using Gtk;
using Gtk.DataBindings;
using System.Data.Bindings;
using System.Data.Bindings.DebugInformation;

namespace TestGtkBinding
{
	class MainClass
	{
		public static void OnPropChange (IVirtualObject a_Object, VirtualProperty a_Property)
		{
			Console.WriteLine ("Changed value in (" + a_Object + "::" + a_Object.ObjectType.Name + ") on " + a_Property.Name); 
		}
		
		public static void Main (string[] args)
		{
Debug.Active = true;
Debug.DevelopmentInfo = true;
ConsoleDebug.Connect();
			// Test case of complex mapping resolving
			string tm = "(CLASS) propname [column name:: prop1>>PROP1; prop2<>PROP2; prop3<>PROP3]>>resultprop";
			SMappedItem mi = new SMappedItem (tm);
			Console.WriteLine (mi);
			
			IVirtualObject nobj = new UniqueVirtualObject ("BLAHBLAH2");
			nobj.AddProperty ("FullName", typeof (string));

			IVirtualObject obj = new UniqueVirtualObject ("BLAHBLAH");
			obj.InheritStrict (nobj);
			obj.AddProperty ("Name", typeof (string));
			obj.AddProperty ("Int", typeof (int));
			obj["FullName"].Value = "FULLNAME";
			obj["Name"].OnChange += OnPropChange;
			obj["Name"].Value = "some string";
			obj["Int"].Value = 123;

			Console.WriteLine ("VirtualObject(" + obj.ObjectType.Name + ") FullName='" + obj["FullName"].Value + "' Name='" + 
			                   obj["Name"].Value + "' Int=" + obj["Int"].Value);
			VirtualObject obj2 = new UniqueVirtualObject ("BLAHBLAH2", obj);

			Console.WriteLine ("VirtualObject(" + obj2.ObjectType.Name + ") FullName='" + obj2["FullName"].Value + "' Name='" + 
			                   obj2["Name"].Value + "' Int=" + obj2["Int"].Value);
			obj = null;

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}