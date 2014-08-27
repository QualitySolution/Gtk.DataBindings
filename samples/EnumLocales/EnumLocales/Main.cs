//  
//  Copyright (C) 2009 matooo
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
using System;
using Gtk;
using System.Globalization;
using System.Threading;

namespace EnumLocales
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			DateTime d = DateTime.Now;
			System.Console.WriteLine(d);
			foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
				System.Console.WriteLine("{0} - {1}", ci.Name, ci.DisplayName);
			}
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sl-SI");
			System.Console.WriteLine(d);
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}