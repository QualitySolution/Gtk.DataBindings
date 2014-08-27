using System;
using Gtk;
using Gtk.DataBindings;
using System.Data.Bindings;

namespace sample4
{
	public class PictureInfoClass : Observeable     
	// if observeable is defined then you can use
	// GetRequest() and PostRequest() or invoking DataSourceController directly
	// otherwise
	// DataSourceController.SendAdaptorMessage (this, EActionType.GetRequest);
	// is the solution
	{
		private string filename = "";
		
		private string name = "";
		public string Name {
			get { return (name); }
			set { name = value; }
		}
		
		private string size = "";
		public string Size {
			get { 
				if (preview == null)
					return ("Inspecting");
				return (size); 
			}
		}
		
		private Gdk.Pixbuf preview = null;
		public Gdk.Pixbuf Preview {
			get {
				if (preview != null)
					return (preview);
				return (MainWindow.EmptyPreview);
			}
		}
		
		public bool LoadPreview()
		{
			try {
				if (preview == null) {
					int w,h = 0;
					Gdk.Pixbuf.GetFileInfo(filename, out w, out h);
					size = w + "x" + h;
					preview = new Gdk.Pixbuf (filename, MainWindow.MaxHeight * 4, MainWindow.MaxHeight, true);
					System.Data.Bindings.Notificator.ObjectChangedNotification (this);
				}
			} catch {
				return (false);					
			}
			return (true);
		}

		private PictureInfoClass()
		{
		}
		
		public PictureInfoClass (string aFileName)
		{
			filename = aFileName;
			Name = System.IO.Path.GetFileName (aFileName);
		}
	}
}
