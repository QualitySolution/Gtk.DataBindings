using System;

namespace Gtk.DataBindings
{
	public abstract class RendererMappingBase<TNode> : IRendererMapping
	{
		ColumnMapping<TNode> myColumn;

		protected RendererMappingBase (ColumnMapping<TNode> parentColumn)
		{
			myColumn = parentColumn;
		}
			
		public abstract INodeCellRenderer GetRenderer ();

		public ColumnMapping<TNode> AddColumn(string title)
		{
			return myColumn.AddColumn (title);
		}

		public IMappingConfig Finish()
		{
			return myColumn.Finish ();
		}
	}
}

