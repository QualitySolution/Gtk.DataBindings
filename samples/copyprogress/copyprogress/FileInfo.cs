// FileInfo.cs created with MonoDevelop
// User: matooo at 10:05 PM 3/26/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace copyprogress
{
	
	
	public class FileInfo
	{
		private string name = "";
		public string Name {
			get { return (name); }
		}

		private int size = new System.Random().Next (10, 100);
		public int Size {
			get { return (size); }
		}

		public FileInfo (string aName)
		{
			name = aName;
		}
	}
}
