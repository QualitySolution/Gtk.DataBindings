using System;
using System.Collections.Generic;
using System.Text;

namespace Gtk.DataBindings
{
	public class MappingConfigure<TNode> : IMappingConfigure
	{

		List<ColumnMapping<TNode>> Columns = new List<ColumnMapping<TNode>>();

		public MappingConfigure ()
		{
		}

		public string GetColumnMappingString()
		{
			StringBuilder map = new StringBuilder ();
			map.Append ("{").Append (typeof(TNode).FullName).Append ("}");

			foreach(var column in Columns)
			{
				map.Append (" ").Append (column.DataPropertyName)
					.AppendFormat ("[{0}]{1};", column.Title, column.IsEditable ? "<>":"");
			}
			return map.ToString ();
		}

		public static MappingConfigure<TNode> Create()
		{
			return new MappingConfigure<TNode> ();
		}

		public ColumnMapping<TNode> AddColumn(string title)
		{
			var column = new ColumnMapping<TNode> (this, title);
			Columns.Add (column);
			return column;
		}

		public IMappingConfigure Finish()
		{
			return this;
		}
	}
}

