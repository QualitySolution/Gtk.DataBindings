using System;
using System.Linq.Expressions;

namespace Gtk.DataBindings
{
	public abstract class RendererMappingBase<TNode> : IRendererMapping
	{
		ColumnMapping<TNode> myColumn;

		public bool IsExpand { get; set;}

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

		#region Renderers

		public TextRendererMapping<TNode> AddTextRenderer(Expression<Func<TNode, string>> dataProperty, bool expand = true)
		{
			return myColumn.AddTextRenderer (dataProperty, expand);
		}

		public TextRendererMapping<TNode> AddTextRenderer()
		{
			return myColumn.AddTextRenderer ();
		}

		public NumberRendererMapping<TNode> AddNumericRenderer(Expression<Func<TNode, object>> dataProperty, bool expand = true)
		{
			return myColumn.AddNumericRenderer (dataProperty, expand);
		}

		#endregion
	}
}

