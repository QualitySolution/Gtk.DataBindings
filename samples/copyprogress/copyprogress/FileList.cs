// FileList.cs created with MonoDevelop
// User: matooo at 10:06 PM 3/26/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections;
using System.Threading;

namespace copyprogress
{
	public class FileList
	{
		private ArrayList list = new ArrayList();
		
		public FileInfo Current {
			get { 
				if ((Pos < 0) || (Pos >= list.Count))
					return (null);
				return ((FileInfo) list[Pos]);
			}
		}

		public string Name {
			get {
				if (Current == null)
					return ("");
				return ("<b>" + Current.Name + "</b>"); 
			}
		}

		private int pos = -1;
		public int Pos {
			get { return (pos); }
			set { 
				if (pos == value)
					return;
				pos = value;
				Gtk.DataBindings.Notificator.ObjectChangedNotification (this);
			}
		}

		public double FilePos {
			get {
				if (Current == null)
					return (0);
				return (System.Convert.ToDouble(Pos)/System.Convert.ToDouble(list.Count));
			}
		}

		public double CopyPos {
			get {
				if (Current == null)
					return (0);
				return (System.Convert.ToDouble(cPos)/System.Convert.ToDouble(Current.Size));
			}
		}

		private double cPos = 0;
		public double CPos {
			set {
				double pcp = CopyPos;
				cPos = value;
				if (pcp != CopyPos)
					Gtk.DataBindings.Notificator.ObjectChangedNotification (this);
			}
		}
		
		private void DoCopy (System.Object aObj)
		{
			for (int i=0; i<list.Count; i++) {
				Pos = i;
				for (int j=0; j<=Current.Size; j++) {
					CPos = j;
					Thread.Sleep (50);
				}
			}
			Pos = -1;
		}
		
		public void Copy()
		{
			ThreadPool.QueueUserWorkItem (new WaitCallback (DoCopy));
		}
		
		public FileList()
		{
			list.Add (new FileInfo ("File1"));
			list.Add (new FileInfo ("File2"));
			list.Add (new FileInfo ("File3"));
			list.Add (new FileInfo ("File4"));
			list.Add (new FileInfo ("File5"));
			list.Add (new FileInfo ("File6"));
			list.Add (new FileInfo ("File7"));
			list.Add (new FileInfo ("File8"));
			list.Add (new FileInfo ("File9"));
			list.Add (new FileInfo ("File10"));
		}
	}
}
