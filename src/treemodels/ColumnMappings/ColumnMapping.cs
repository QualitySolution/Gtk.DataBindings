using System;
using System.Linq.Expressions;
using System.Data.Bindings.Utilities;

namespace Gtk.DataBindings
{
	public class ColumnMapping<TNode> : IColumnMapping
	{
		MappingConfig<TNode> myConfig;

		public string Title { get; set;}

		public string DataPropertyName { get; set;}

		public bool IsEditable { get; set;}

		public ColumnMapping (MappingConfig<TNode> parentConfig, string title)
		{
			this.myConfig = parentConfig;
			Title = title;
		}

		/// <summary>
		/// Set only if it simple column mapping, else using sets from Render.
		/// </summary>
		/// <param name="propertyRefExpr">Property Name expr.</param>
		/// <typeparam name="TVMNode">Node type</typeparam>
		public ColumnMapping<TNode> SetDataProperty (Expression<Func<TNode, object>> propertyRefExpr)
		{
			DataPropertyName = PropertyUtil.GetName (propertyRefExpr);
			return this;
		}

		public ColumnMapping<TNode> Editing ()
		{
			IsEditable = true;
			return this;
		}

		public ColumnMapping<TNode> AddColumn(string title)
		{
			return myConfig.AddColumn (title);
		}

		public IMappingConfig Finish()
		{
			return myConfig.Finish ();
		}
	}
}

