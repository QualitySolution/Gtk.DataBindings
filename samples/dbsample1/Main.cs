// Main.cs created with MonoDevelop
// User: matooo at 5:44 PM 2/24/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using Gtk;
using ByteFX.Data.MySqlClient;

namespace dbsample1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}