using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gtk.DataBindings
{
	public class MappingConfig<TNode> : IMappingConfig
	{

		List<ColumnMapping<TNode>> Columns = new List<ColumnMapping<TNode>>();

		public IEnumerable<IColumnMapping> ConfiguredColumns {
			get { return Columns.OfType<IColumnMapping> ();	}
		}

		public MappingConfig ()
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

		public static MappingConfig<TNode> Create()
		{
			return new MappingConfig<TNode> ();
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

