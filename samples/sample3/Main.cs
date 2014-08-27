// project created on 12/8/2007 at 10:11 PM
using System;
using Gtk;

namespace sample3
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