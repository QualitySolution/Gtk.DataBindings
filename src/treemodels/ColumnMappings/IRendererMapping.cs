using System;

namespace Gtk.DataBindings
{
	public interface IRendererMapping
	{
		INodeCellRenderer GetRenderer();
		bool IsExpand { get;}
	}

	public interface IRendererMappingGeneric<TNode> : IRendererMapping
	{
		void SetCommonSetter<TCellRenderer>(Action<TCellRenderer, TNode> commonSet) where TCellRenderer : class;
	}

	public interface INodeCellRenderer
	{
		void RenderNode(object node);
		string DataPropertyName { get;}
	}

}

