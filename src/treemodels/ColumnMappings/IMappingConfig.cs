using System;
using System.Collections.Generic;

namespace Gtk.DataBindings
{
	public interface IMappingConfig
	{
		string GetColumnMappingString();

		IEnumerable<IColumnMapping> ConfiguredColumns { get;}
	}
}

