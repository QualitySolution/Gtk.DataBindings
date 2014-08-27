using System;
using GLib;
using Gtk;
using System.Globalization;
using System.Threading;
using System.Data.Bindings;
using System.Reflection;
using Gtk.DataBindings;

namespace CustomWidgetTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			System.Console.WriteLine("1");
			Application.Init ();
			System.Console.WriteLine("2");
			System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo ("sl-SI");
			System.Threading.Thread.CurrentThread.CurrentCulture.SetSlovenian();
			System.Console.WriteLine("3");
			MainWindow win = new MainWindow ();
			System.Console.WriteLine("Init done");
			win.Show ();
			Application.Run ();
		}
	}
}