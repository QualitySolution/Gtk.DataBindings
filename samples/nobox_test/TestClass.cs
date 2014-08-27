//TestClass.cs - Description
//
//Author: m. <ml@arsis.net>
//
//Copyright (c) 2008 m.
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
//
//

using System;

namespace nobox_test
{
	public class TestClass
	{
		private string test = "blabla";
		public string Test {
			get { return (test); }
			set { test = value; }
		}

		private string texst2 = "tralala";
		public string Texst2 {
			get { return (texst2); }
			set { texst2 = value; }
		}

		public TestClass()
		{
		}

		public TestClass (string t1, string t2)
		{
			Test = t1;
			Texst2 = t2;
		}
	}
}
