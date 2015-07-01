using System;

namespace Gtk.DataBindings
{
	public interface IRendererMapping
	{
		INodeCellRenderer GetRenderer();
		bool IsExpand { get;}
	}

	public interface INodeCellRenderer
	{
		void RenderNode(object node);
		string DataPropertyName { get;}
	}

}

