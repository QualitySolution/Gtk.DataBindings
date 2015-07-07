using System;
using System.Linq.Expressions;
using System.Data.Bindings.Utilities;
using System.Collections.Generic;
using System.Data.Bindings;
using System.Linq;

namespace Gtk.DataBindings
{
	public class RowMapping<TNode>
	{
		FluentMappingConfig<TNode> myConfig;

		public RowMapping (FluentMappingConfig<TNode> parentConfig)
		{
			this.myConfig = parentConfig;
		}

		public RowMapping<TNode> AddSetter<TCellRenderer>(Action<TCellRenderer, TNode> setter) where TCellRenderer : class
		{
			foreach(var cell in myConfig.ConfiguredColumns.OfType<ColumnMapping<TNode>> ()
				.SelectMany (c => c.ConfiguredRenderersGeneric))
			{
				cell.SetCommonSetter<TCellRenderer> (setter);
			}
			return this;
		}

		public IMappingConfig Finish()
		{
			return myConfig.Finish ();
		}
	}
}

