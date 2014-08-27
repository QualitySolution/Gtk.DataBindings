// TestData.cs - Field Attribute to assign additional information for Gtk#Databindings
//
// Author: m. <ml@arsis.net>
//
// Copyright (c) 2006 m.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of version 2 of the Lesser GNU General 
// Public License as published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this program; if not, write to the
// Free Software Foundation, Inc., 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data.Bindings.Database;

namespace dbsample2
{
	public class TestData
	{
		private StringCollection drivers = null;
		public StringCollection Drivers {
			get { 
				if (drivers == null)
					drivers = DatabaseCenter.EnumDatabaseTypes();
				return (drivers); 
			}
		}

		private DatabaseConnection connection = new DatabaseConnection ("localhost", "root", "blabla");
		public DatabaseConnection Connection {
			get { return (connection); }
		}
		
		private string tableName = "";
		public string TableName {
			get { return (tableName); }
			set { tableName = value; } 
		}

		private string select = "*";
		public string Select {
			get { return (select); }
			set { 
				select = value;
				System.Data.Bindings.Notificator.ObjectChangedNotification (this);
			} 
		}

		private string where = "";
		public string Where {
			get { return (where); }
			set { 
				where = value;
				System.Data.Bindings.Notificator.ObjectChangedNotification (this);
			} 
		}

		public string Query {
			get {
				string q = "SELECT " + Select + " FROM " + TableName + ".*";
				if (Where != "")
					q += " WHERE " + Where;
				q += ";";
				System.Console.WriteLine(q);
				return (q); 
			}
		}

		public TestData()
		{
			System.Data.Bindings.Database.ByteFxMySqlDriver.Register();
			System.Data.Bindings.Database.NpgsqlDriver.Register();
		}
	}
}
