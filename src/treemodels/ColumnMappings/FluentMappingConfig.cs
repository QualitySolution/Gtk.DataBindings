using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gtk.DataBindings
{
	public class FluentMappingConfig<TNode> : IMappingConfig
	{

		List<ColumnMapping<TNode>> Columns = new List<ColumnMapping<TNode>>();

		public IEnumerable<IColumnMapping> ConfiguredColumns {
			get { return Columns.OfType<IColumnMapping> ();	}
		}

		public FluentMappingConfig ()
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

		public static FluentMappingConfig<TNode> Create()
		{
			return new FluentMappingConfig<TNode> ();
		}

		public ColumnMapping<TNode> AddColumn(string title)
		{
			var column = new ColumnMapping<TNode> (this, title);
			Columns.Add (column);
			return column;
		}

		public IMappingConfig Finish()
		{
			return this;
		}
	}
}

