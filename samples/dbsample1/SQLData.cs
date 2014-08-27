// SQLData.cs created with MonoDevelop
// User: matooo at 5:47 PM 2/24/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Data;
using ByteFX.Data.MySqlClient;

namespace dbsample1
{
	public class SQLData
	{
		private bool failed = false;
		
		private string server = "localhost";
		public string Server {
			get { return (server); }
			set { server = value; } 
		}
		
		private string username = "root";
		public string Username {
			get { return (username); }
			set { username = value; } 
		}

		private string database = "";
		public string Database {
			get { return (database); }
			set { database = value; } 
		}

		private string password = "";
		public string Password {
			get { return (password); }
			set { password = value; } 
		}

		private DataTable demoTable = null;
		public DataTable DemoTable {
			get { return (demoTable); }
		}
		
		private MySqlConnection connection = null;
		public MySqlConnection Connection {
			get {
				int i = 0;
				if (connection == null) {
					if (Database == "")
						GetConnectionParams();
					string connstr = string.Format("Server={0};User ID={1};Password={2}", Server, Username, Password);
					if (Database != "")
						connstr = string.Format("Server={0};Database={1};User ID={2};Password={3}", Server, Database, Username, Password);
					MySqlConnection conn = new MySqlConnection(connstr);
					while ((connection == null) && (failed == false)) {
						try {
							if (conn.State != ConnectionState.Open)
								conn.Open();
							connection = conn;
						}
						catch {
							i++;
							if (i < 3)
								GetConnectionParams();
							else
								failed = true;
						}
					}
				}
				return (connection);
			}
		}

		public void GetConnectionParams()
		{
			ConnectionDialog dialog = new ConnectionDialog (this);
			dialog.Modal = true;
			dialog.Run();
			dialog.Destroy();
		}

		public SQLData()
		{
			if (Connection != null)
				Console.WriteLine ("Connected to mysql");

			if (failed == false) {
				// Create database if needded
				MySqlCommand command = new MySqlCommand ("show databases;", Connection);
				IDataReader reader = command.ExecuteReader();
				bool found = false;
				while (reader.Read())
					if (reader.GetString(0) == "gtk_binding")
						found = true;
				reader.Close();
				if (found == false) {
					command = new MySqlCommand ("create database gtk_binding", Connection);
					command.ExecuteNonQuery();
				}
				Database = "gtk_binding";
				Connection.Close();
				connection = null;
				
				if (Connection != null)
					Console.WriteLine ("Using database " + Connection.Database);
				
				// Create table if needded
				command = new MySqlCommand ("show tables;", Connection);
				reader = command.ExecuteReader();
				found = false;
				while (reader.Read()) {
					if (reader.GetString(0) == "binding_test")
						found = true;
					Console.WriteLine ("Table: " + reader.GetString(0));
				}
				reader.Close();
				if (found == false) {
					Console.WriteLine ("Creating Table binding_test");
					command = new MySqlCommand ("CREATE TABLE `gtk_binding`.`binding_test` (" +
					                            "`ID` INT  NOT NULL AUTO_INCREMENT PRIMARY KEY," +
					                            "`string_data` TEXT CHARACTER SET utf8 NOT NULL COMMENT 'String Data'," +
					                            "`integer_data` INT  NOT NULL DEFAULT 12 COMMENT 'Integer Value'," +
					                            "`float_data` DOUBLE  NOT NULL DEFAULT 13" +
					                            ")" +
					                            "ENGINE = InnoDB " +
					                            "CHARACTER SET utf8 " +
					                            "COMMENT = 'Table with simple test data';" +
					                            "insert into binding_test (string_data, integer_data, float_data) values ('othervalue1', 5, 4);" +
					                            "insert into binding_test (string_data, integer_data, float_data) values ('othervalue2', 6, 3);" +
					                            "insert into binding_test (string_data, integer_data, float_data) values ('othervalue3', 7, 44);" +
					                            "insert into binding_test (string_data, integer_data, float_data) values ('othervalue4', 8, 45);" +
					                            "insert into binding_test (string_data, integer_data, float_data) values ('somevalue', 3, 7);", Connection);
					command.ExecuteNonQuery();
				}

				Console.WriteLine ("Playground for this demo is set up ;)");
				//			Connection.
				
				Console.WriteLine ("Opening table");

				///get the dataadapter values
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from binding_test", Connection);

				///Initialize, insert, update and delete commands for the database
//				InitializeCommands();

				///fillup the dataset now
				DataSet dataSet = new DataSet();
//				demoTable = new DataTable();

				///fillup the data adapter now
				dataAdapter.Fill(dataSet,"binding_test");

				demoTable = dataSet.Tables["binding_test"];
				Console.WriteLine ("Read {0} rows successfully", demoTable.Rows.Count);
			}
			else
				Console.WriteLine ("Not connected & exiting!");
		}
	}
}
