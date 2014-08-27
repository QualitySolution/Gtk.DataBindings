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
using System.Reflection;
using System.Data.Bindings;
using System.ComponentModel;
using Gtk;
using Gtk.DataBindings;
using System.Threading;
using System.Globalization;

[assembly: ToDo ("Critical [Test critical assembly attribute] Some description",
                 "NonCritical [Test non critical assembly attribute] Some description",
                 "None [Test assembly attribute] Some description",
                 "WouldBeNice [Test would be nice assembly attribute] Some description",
                 "Normal [Test normal assembly attribute] Some description")]
[assembly: Bug ("Critical [Test critical assembly attribute] Some description",
                 "NonCritical [Test non critical assembly attribute] Some description",
                 "None [Test assembly attribute] Some description",
                 "WouldBeNice [Test would be nice assembly attribute] Some description",
                 "Normal [Test normal assembly attribute] Some description")]
[assembly: RelatedBug ("Critical [Test critical assembly attribute] Some description",
                 "NonCritical [Test non critical assembly attribute] Some description",
                 "None [Test assembly attribute] Some description",
                 "WouldBeNice [Test would be nice assembly attribute] Some description",
                 "Normal [Test normal assembly attribute] Some description")]
[assembly: MissingImplementation ("Critical [Test critical assembly attribute] Some description",
                 "NonCritical [Test non critical assembly attribute] Some description",
                 "None [Test assembly attribute] Some description",
                 "WouldBeNice [Test would be nice assembly attribute] Some description",
                 "Normal [Test normal assembly attribute] Some description")]
[assembly: NeedsOptimization ("Critical [Test critical assembly attribute] Some description",
                 "NonCritical [Test non critical assembly attribute] Some description",
                 "None [Test assembly attribute] Some description",
                 "WouldBeNice [Test would be nice assembly attribute] Some description",
                 "Normal [Test normal assembly attribute] Some description")]
[assembly: NeedsRemoval ("Critical [Test critical assembly attribute] Some description",
                 "NonCritical [Test non critical assembly attribute] Some description",
                 "None [Test assembly attribute] Some description",
                 "WouldBeNice [Test would be nice assembly attribute] Some description",
                 "Normal [Test normal assembly attribute] Some description")]
[assembly: NeedsRewrite ("Critical [Test critical assembly attribute] Some description",
                 "NonCritical [Test non critical assembly attribute] Some description",
                 "None [Test assembly attribute] Some description",
                 "WouldBeNice [Test would be nice assembly attribute] Some description",
                 "Normal [Test normal assembly attribute] Some description")]
[assembly: PlannedImplementation ("Critical [Test critical assembly attribute] Some description",
                 "NonCritical [Test non critical assembly attribute] Some description",
                 "None [Test assembly attribute] Some description",
                 "WouldBeNice [Test would be nice assembly attribute] Some description",
                 "Normal [Test normal assembly attribute] Some description")]

namespace AssemblyInfoAnalyzer
{
	/// <summary>
	/// Specifies attribute which exposes list of bugged items 
	/// </summary>
	public class VeleBugAttribute : DevelopmentInformationAttribute
	{
		public VeleBugAttribute (params string[] aItems)
			: base ("VELEBUG", aItems)
		{
		}
	}
	
	class MainClass
	{
		[VeleBug ("Critical [blabla] tralala")]
		public static void Main (string[] args)
		{
			GtkItemIconAttribute.RegisterDefaultResourceHandler();
			Application.Init ();
			MainWindow win = new MainWindow ();
			if ((args != null) || (args.Length > 0)) { }
			win.Show ();
			Application.Run ();
		}
	}
}
