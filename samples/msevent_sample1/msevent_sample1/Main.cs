//Main.cs - Field Attribute to assign additional information for Gtk#Databindings
//
//Author: m. <ml@arsis.net>
//
//Copyright (c) at 8:59 PM 12/24/2008
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
using Gtk;
using System.Data.Bindings;

namespace msevent_sample1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SampleData data = new SampleData ("John", "Smith");
			Adaptor a = new Adaptor();
			Adaptor b = new Adaptor();
			System.Console.WriteLine("Starting connection");
			System.Console.WriteLine("=======================================================");
			System.Console.WriteLine("Connecting 1st adaptor");
			a.Target = data;
			System.Console.WriteLine("=======================================================");
			System.Console.WriteLine("Connecting 2nd adaptor");
			b.Target = data;
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.DataSourceA = a;
			win.DataSourceB = b;
			win.Show ();
			Application.Run ();
			System.Console.WriteLine("=======================================================");
			System.Console.WriteLine("Disconnecting 2nd adaptor");
			b.Target = null;
			System.Console.WriteLine("=======================================================");
			System.Console.WriteLine("Disconnecting 1st adaptor");
			a.Target = null;
		}
	}
}