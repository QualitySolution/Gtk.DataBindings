using System;

namespace Gtk.DataBindings
{
	public interface IColumnMapping
	{
		string Title { get;}

		bool IsEditable { get;}

		string DataPropertyName { get;}
	}
}

