using System;
using Gtk;
using Gtk.DataBindings;
using System.IO;
using sample4;
using System.Threading;
using System.Data.Bindings;
using System.Data.Bindings.Collections;

public partial class MainWindow: Gtk.Window
{	
	public static int MaxHeight = 64;
	
	public static Gdk.Pixbuf EmptyPreview = Gdk.Pixbuf.LoadFromResource("file-unknown.png");
	
	public static ObserveableArrayList list = new ObserveableArrayList();
	
    static void ThreadProc(System.Object stateInfo) {
		for (int i=list.Count-1; i>=0; i--) {
			PictureInfoClass ic = (PictureInfoClass) list[i]; 
			if (ic.LoadPreview() == false)
				list.Remove (i);
			Thread.Sleep (500);
		}
    }
    
    public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		datatreeview1.ItemsDataSource = list;
		// Mapping for this widget wasa defined in stetic
		//
		// {sample4.PictureInfoClass} Preview[Preview]<<; Name[File Name]<<; Size[Size]<<
		//
		// where there are two important things to consider
		// mapping is complex SOOOO.... IT HAS TO DEFINE BASE TYPE
		// BASE TYPE HAS TO BE SPECIFIED WITH NAMESPACE
		string[] files = Directory.GetFiles(Environment.GetFolderPath (Environment.SpecialFolder.MyPictures));
		foreach (string s in files) {
			list.Add (new PictureInfoClass (s));
			Console.WriteLine (s);
		}
		
		ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}