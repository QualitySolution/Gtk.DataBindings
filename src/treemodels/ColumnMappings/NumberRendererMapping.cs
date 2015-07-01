using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Bindings.Utilities;

namespace Gtk.DataBindings
{
	public class NumberRendererMapping<TNode> : RendererMappingBase<TNode>
	{
		List<Action<NodeCellRendererSpin<TNode>, TNode>> LambdaSetters = new List<Action<NodeCellRendererSpin<TNode>, TNode>>();

		public uint DigitsValue { get; set;}
		public bool IsEditable { get; set;}
		public string DataPropertyName { get; set;}
		public Adjustment Adjustment { get; set;}

		public NumberRendererMapping (ColumnMapping<TNode> column, Expression<Func<TNode, object>> dataProperty)
			: base(column)
		{
			DataPropertyName = PropertyUtil.GetName<TNode> (dataProperty);
			LambdaSetters.Add ((c, n) => c.Text = String.Format ("{0:" + String.Format ("F{0}", c.Digits) + "}", dataProperty.Compile ().Invoke (n)));
		}

		public NumberRendererMapping (ColumnMapping<TNode> column)
			: base(column)
		{

		}

		#region implemented abstract members of RendererMappingBase

		public override INodeCellRenderer GetRenderer ()
		{
			var cell = new NodeCellRendererSpin<TNode> ();
			cell.DataPropertyName = DataPropertyName;
			cell.LambdaSetters = LambdaSetters;
			cell.Digits = DigitsValue;
			cell.Adjustment = Adjustment;
			cell.Editable = IsEditable;
			return cell;
		}

		#endregion

		public NumberRendererMapping<TNode> AddSetter(Action<NodeCellRendererSpin<TNode>, TNode> setter)
		{
			LambdaSetters.Add (setter);
			return this;
		}

		public NumberRendererMapping<TNode> Digits(uint digits)
		{
			this.DigitsValue = digits;
			return this;
		}

		public NumberRendererMapping<TNode> WithAdjustment(Adjustment adjustment)
		{
			this.Adjustment = adjustment;
			return this;
		}

		public NumberRendererMapping<TNode> Editing ()
		{
			IsEditable = true;
			return this;
		}

	}
}

