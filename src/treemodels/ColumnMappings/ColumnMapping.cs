using System;
using System.Linq.Expressions;
using System.Data.Bindings.Utilities;
using System.Collections.Generic;
using System.Data.Bindings;

namespace Gtk.DataBindings
{
	public class ColumnMapping<TNode> : IColumnMapping
	{
		FluentMappingConfig<TNode> myConfig;

		public string Title { get; set;}

		public string DataPropertyName { get; set;}

		public bool IsEditable { get; set;}

		private List<IRendererMapping> Renderers = new List<IRendererMapping> ();

		public IEnumerable<IRendererMapping> ConfiguredRenderers {
			get { return Renderers;	}
		}

		public ColumnMapping (FluentMappingConfig<TNode> parentConfig, string title)
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
			Type properyType = typeof(TNode).GetProperty (DataPropertyName).PropertyType;
			if(TypeValidator.IsNumeric(properyType))
			{
				AddNumericRenderer (propertyRefExpr);
			}
			else 
			{
				throw new NotSupportedException (String.Format ("Type {0} isn't supports.", properyType));
			}
			return this;
		}

		public ColumnMapping<TNode> SetDataProperty (Expression<Func<TNode, string>> propertyRefExpr)
		{
			//DataPropertyName = PropertyUtil.GetName (propertyRefExpr);
			AddTextRenderer (propertyRefExpr);
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

		#region Renderers

		public TextRendererMapping<TNode> AddTextRenderer(Expression<Func<TNode, string>> dataProperty, bool expand = true)
		{
			var render = new TextRendererMapping<TNode> (this, dataProperty);
			render.IsExpand = expand;
			Renderers.Add (render);
			return render;
		}

		public TextRendererMapping<TNode> AddTextRenderer()
		{
			var render = new TextRendererMapping<TNode> (this);
			Renderers.Add (render);
			return render;
		}

		public NumberRendererMapping<TNode> AddNumericRenderer(Expression<Func<TNode, object>> dataProperty, bool expand = true)
		{
			var render = new NumberRendererMapping<TNode> (this, dataProperty);
			render.IsExpand = expand;
			Renderers.Add (render);
			return render;
		}

		#endregion
	}
}

