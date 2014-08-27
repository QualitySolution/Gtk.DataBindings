// project created on 12/6/2007 at 4:14 PM
using System;
using Gtk;

namespace sample2
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