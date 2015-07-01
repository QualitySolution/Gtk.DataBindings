using System;

namespace Gtk.DataBindings
{
	public interface IRendererMapping
	{
		INodeCellRenderer GetRenderer();
	}

	public interface INodeCellRenderer
	{
		void RenderNode(object node);

	}

}

