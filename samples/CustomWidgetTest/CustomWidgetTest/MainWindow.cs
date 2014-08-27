using System;
using Gtk;
using System.Data.Bindings;
using System.Data.Bindings.Collections;
using Cairo;

public class ColorClass : BaseNotifyPropertyChanged
{
	private static Random r = new Random();
	
	private Cairo.Color color = new Cairo.Color (0, 0, 0);
	public Cairo.Color Color {
		get { return (color); }
		set {
			if (color.Equals(value) == true)
				return;
			color = value;
			OnPropertyChanged ("Color");
		}
	}
	
	public string Name {
		get {
			if (color.B == 0.0)
				return ("black");
			if (color.B > 0.99)
				return ("white");
			return (string.Format ("gray {0}%", 100-System.Convert.ToInt32(color.B*100)));
		}
	}
	
	private DateTime date = DateTime.Now;
	public DateTime Date {
		get { return (date); }
		set {
			if (date.Equals(value) == true)
				return;
			date = value;
			OnPropertyChanged ("Date");
		}
	}
	
	private DateTime time = DateTime.Now;
	public DateTime Time {
		get { return (time); }
		set {
			if (date.Equals(value) == true)
				return;
			time = value;
			OnPropertyChanged ("Time");
		}
	}
	
	private System.Net.IPAddress ip = null;
	public System.Net.IPAddress Ip {
		get { return (ip); }
		set {
			if (ip == value)
				return;
			ip = value;
			OnPropertyChanged ("Ip");
		}
	}
	
	private decimal money = new decimal(0.0);
	public decimal Money {
		get { return (money); }
		set {
			if (money == value)
				return;
			money = value;
			OnPropertyChanged ("Money");
		}
	}
		
	public override string ToString ()
	{
		return string.Format("[ColorClass: Color={0}, Name={1}]", Color, Name);
	}

	public ColorClass (Cairo.Color aColor)
	{
		color = aColor;
		byte i = System.Convert.ToByte (aColor.B * 199);
		ip = new System.Net.IPAddress (new byte[4] { i,i,i,i });
		Money = new decimal(color.B + r.Next(1000000));
	}
}
	
public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
/*		linklabel1.LinkText = "Google";
		linklabel1.LinkURL = "http://www.google.com";
		linklabel1.Pixbuf = (Gdk.Pixbuf) PictureResourceStore.LoadResource ("calendar.png");
		colorlabel1.Color = new Cairo.Color (1, 0, 0);
		colorlabel1.SmallFonts = true;*/
		ObservableArrayList lst = new ObservableArrayList();
		for (double i=0.0; i<=1.0; i=i+0.1)
			lst.Add (new ColorClass (new Cairo.Color (i, i, i)));
		foreach (ColorClass c in lst)
			System.Console.WriteLine(c);
		datatreeview1.ItemsDataSource = lst;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}