using System.Collections;

namespace System.Data.Bindings.Collections
{
	public interface ICovarianceList<out T> : IList
	{
		new bool Contains(object aObject);
	}
}