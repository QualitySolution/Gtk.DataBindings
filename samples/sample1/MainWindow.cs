using System;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;
using Gtk;
using GLib;
using Gtk.DataBindings;
using System.Data.Bindings;
using System.Data.Bindings.Collections;
using System.Data.Bindings.DebugInformation;
using Gtk.ExtraWidgets;

public class CSSLikePreferences : UniqueVirtualObject
{
	public CSSLikePreferences()
		: base ("CSSLike")
	{
		AddProperty ("BoxSpacing", typeof (int));
		AddProperty ("BorderWidth", typeof (int));
		
		this["BoxSpacing"].Value = 4;
		this["BorderWidth"].Value = 4;
	}
}

public class Person : Observeable
{
	private string name;
	private string surname;
	private int number;
	private bool male;
	private double dbl = .5;
	private DateTime dt;
	
	public string FullName
	{
		get { return (Name + " " + Surname); }
	}

	public string Name
	{
		get { return (name); }
		set { name = value; }
	}

	public int Number
	{
		get { return (number); }
		set { number = value; }
	}
	
	public bool Male
	{
		get { return (male); }
		set { male = value; }
	}
	
	public string Surname
	{
		get { return (surname); }
		set { surname = value; }
	}
	
	public double DoubleVal
	{
		get { return (dbl); }
		set { dbl = value; }
	}
	
	public int Percent
	{
		get { return (System.Convert.ToInt32 (DoubleVal*100)); }
	}
	
	public DateTime DTime
	{
		get { return (dt); }
		set { dt = value; }
	}
	
	public Gdk.Color skin = new Gdk.Color(40,60,80);
	public Gdk.Color SkinColor {
		get { return (skin); }
		set { skin = value; }
	}
	
	private ushort alpha = 50000;
	public ushort Alpha {
		get { return (alpha); }
		set { 
			alpha = value;
			if (alpha >= 65535)
				bleedingDesc = "??? No alpha bleeding? where's the fashion sense? C'mon...";
			else
				if (alpha == 0)
					bleedingDesc = "look mama, a hollow-man";
				else
					bleedingDesc = "Ordinary alpha bleeded man, nothing else";
		}
	}
	
	public Gdk.Pixbuf pix = new Gdk.Pixbuf (Assembly.GetEntryAssembly(), "control-center2.png");
	public Gdk.Pixbuf Pix {
		get { return (pix); }
	}
	
	private string bleedingDesc = "Ordinary alpha bleeded man, nothing else";
	public string BleedingDesc {
		get { return (bleedingDesc); }
	}
	
	public Person thisperson {
		get { return (this); }
	}
	
	public override string ToString()
	{
		return (FullName);
	}
	
	public Person ()
	{
	}
	
	public Person (string a_Name, string a_Surname, int a_Number, bool a_Male)
	{
		name = a_Name;
		surname = a_Surname;
		number = a_Number;
		male = a_Male;
		System.Random rnd = new System.Random();
		dt = new DateTime(1960 + rnd.Next(50), rnd.Next(11) + 1, rnd.Next(27) + 1);
		dbl = rnd.NextDouble();
		number = rnd.Next(100);
		skin = new Gdk.Color((byte) rnd.Next(255), (byte) rnd.Next(255), (byte) rnd.Next(255));
		alpha = (ushort) (rnd.Next(34000) + 30000);
		rnd = null;
	}
}

public class Family : ObserveableArrayList
{
	private string name;
	public string Name {
		get { return (name); }
		set { name = value; }
	}

	public Family(string a_Name)
		: base ()
	{
		name = a_Name;
	}
}

public partial class MainWindow : DataWindow
{
	private Adaptor adaptorCursor = new Adaptor();

	private DataTreeView view = new DataTreeView ();
	private DataComboBox combo = new DataComboBox ();
	private DataComboBox combostr = new DataComboBox ();
	private DataComboBoxEntry entrycombo = new DataComboBoxEntry ();
	private DataComboBoxEntry entrycombostr = new DataComboBoxEntry ();
	private DataCheckButton check = new DataCheckButton ();
	private DateEntry entryDate = new DateEntry ();
	private DataEntry entry = new DataEntry ();
	private DataEntry entryS = new DataEntry ();
	private DataProgressBar progress = new DataProgressBar();
	private DataSpinButton spin = new DataSpinButton (0, 100, 10);
	private DataCalendar cal = new DataCalendar();
	private DataColorButton colbtn = new DataColorButton();
	private DataColorSelection colsel = new DataColorSelection();
	private DataLabel lbl = new DataLabel ();
	private DataLabel nlbl = new DataLabel ();
	private DataLabel ducklbl = new DataLabel ();
	private CSSLikePreferences csslike = new CSSLikePreferences();

	private ObserveableStringCollection strings = null;
	private Person person = null;
	private Person person2 = null;
	private Family subpersonlist = null;
	private Family subsubpersonlist = null;
	private Family personlist = null;
	private Family worldlist = null;
	private Family familylist = null;

	private Button add_button = new Button ();
	private Button null_button = new Button ();
	private Button collect_button = new Button ();
	
	public MainWindow() : base ("Test")
	{
System.Data.Bindings.DebugInformation.Debug.Active = false;
System.Data.Bindings.DebugInformation.Debug.Level = 10;
System.Data.Bindings.DebugInformation.ConsoleDebug.Connect();

		ActualListCode();

//		Stetic.Gui.Build(this, typeof(MainWindow));
		Build();
		
		ScrolledWindow scr = new ScrolledWindow ();
		HBox wndbox = new HBox ();
		HBox hbox = new HBox ();
		VBox vbox = new VBox ();

		view.Show();

		scr.Show ();
		scr.Add (view);
		
		wndbox.Add (scr);
		
		check.Show();
		vbox.PackEnd (check, true, false, 0);

		entryDate.Show();
		vbox.PackEnd (entryDate, true, false, 0);

		entryS.Show();
		vbox.PackEnd (entryS, true, false, 0);

		entry.Show();
		vbox.PackEnd (entry, true, false, 0);

		progress.Show();
		vbox.PackEnd (progress, true, false, 0);

		spin.Show();
		vbox.PackEnd (spin, true, false, 0);

		cal.Show();
		vbox.PackEnd (cal, true, false, 0);

		colbtn.Show();
		colbtn.UseAlpha = true;
		vbox.PackEnd (colbtn, true, false, 0);

		colsel.Show();
		colsel.HasOpacityControl = true;
		vbox.PackEnd (colsel, true, false, 0);

		combo.Show();
		vbox.PackEnd (combo, true, false, 0);

		combostr.Show();
		vbox.PackEnd (combostr, true, false, 0);

		entrycombo.Show();
		vbox.PackEnd (entrycombo, true, false, 0);

		entrycombostr.Show();
		vbox.PackEnd (entrycombostr, true, false, 0);

		lbl.Show();
		vbox.PackEnd (lbl, true, false, 0);

		nlbl.Show();
		vbox.PackEnd (nlbl, true, false, 0);

		// Standalone control
		ducklbl.Show();
		vbox.PackEnd (ducklbl, true, false, 0);
		ducklbl.Text = "Ducking mappings, should be enabled and visible";

		vbox.Show ();

		// buttons
		vbox.PackStart (hbox, false, true, 10);
		hbox.PackStart (add_button);
		add_button.Label = "Add a person";
		add_button.Clicked += new EventHandler (AddButtonClickedHandler);
		hbox.PackStart (null_button);
		null_button.Label = "Set NULL Person";
		null_button.Clicked += new EventHandler (NullButtonClickedHandler);
		hbox.PackStart (collect_button);
		collect_button.Label = "GC.Collect()";
		collect_button.Clicked += new EventHandler (CollectButtonClickedHandler);
		
		hbox.ShowAll ();
		
		wndbox.Add(vbox);
		wndbox.ShowAll();
		this.Add (wndbox);
		this.DeleteEvent += new Gtk.DeleteEventHandler (OnDeleteEvent);
		ActualSpecialCellRendererCode();
		ActualMappingCode();
	}

	//<summary>
	/// Generic bolding of some items
	/// Same function is used for both, combo and treeview for more compatibility
	//</summary>
	private void DrawObjectCells (IList a_List, int[] a_Path, object a_Object, Gtk.CellRenderer a_Cell)
	{
		if (a_Cell is MappedCellRendererText) {
			MappedCellRendererText txt = (MappedCellRendererText) a_Cell;
			if ((a_Object is IList) && (txt.MappedTo == "Name"))
				txt.Font = "Bold";
			else
				txt.Font = "Normal";
		}
	}
	
	//<summary>
	/// This is sample code for special case renderer
	//</summary>
	public void ActualSpecialCellRendererCode()
	{
		// if this would be editable CellRenderer then editing and function has to be specified here
		// StartedEditing will be appened automatically, but access to the current object is
		// trough TreeView.CurrentSelection.FinalTarget where one has to call
		//    DataSourceController.GetRequest (TreeView.CurrentSelection.FinalTarget)
		// after modification
		CellRendererProgress progress = new MappedCellRendererProgress();
		view.NamedCellRenderers.Add ("PERCENT", progress, "value");
		view.OnListCellDescription += DrawObjectCells;
		
		progress = new MappedCellRendererProgress();
		combo.NamedCellRenderers.Add ("PERCENT", progress, "value");
		combo.OnListCellDescription += DrawObjectCells;

		entrycombo.OnListCellDescription += DrawObjectCells;
	}
	
	//<summary>
	/// This is sample code needed to create list that handles hierarchy in treeview in this demo
	//</summary>
	public void ActualListCode()
	{
		subsubpersonlist = new Family("subsubpersonlist");
		subpersonlist = new Family("subpersonlist");
		personlist = new Family("Adams family");
		worldlist = new Family("World");
		familylist = new Family("Munchcrunchkins");

		person = new Person ("Joe", "Somebody", 1, true);
		person2 = new Person ("Tomy", "Knokers", 15, false);

		VirtualObject vo = new UniqueVirtualObject ("PERSON", person);
		Console.WriteLine ("Person Name=" + vo["thisperson"].Value);
		subpersonlist.Add (subsubpersonlist);
		personlist.Add (subpersonlist);
		personlist.Add (person);
		personlist.Add (person2);

		familylist.Add (worldlist);
		for (int i=0; i<10; i++)
			familylist.Add (new Person ("familyperson"+i, "familyperson"+i, 1, true));
		worldlist.Add (personlist);
		for (int i=0; i<10; i++)
			worldlist.Add (new Person ("worldperson"+i, "worldperson"+i, 1, true));
		for (int i=0; i<10; i++)
			subpersonlist.Add (new Person ("subperson"+i, "subperson"+i, 1, true));
		for (int i=0; i<10; i++)
			subsubpersonlist.Add (new Person ("subsubperson"+i, "subsubperson"+i, 1, true));

		strings = new ObserveableStringCollection();
		for (int i=0; i<10; i++)
			strings.Add ("String #" + i);
	}
	
	//<summary>
	/// This is the code which would actualy be needed if form would be stetic drawn
	//</summary>
	public void ActualMappingCode()
	{	
		Title = "This demo intentionally doesn't send single notification about update, only sets RAW MAPPINGS";
		// setting form datasource to adaptor cursor, all controls are InheritedDataSource by default
		DataSource = adaptorCursor;

		// setting treeview mappings and datasource  Pix[Icon]<<; 
		entrycombostr.ItemsDataSource = strings;
//		entrycombostr.ColumnMappings = "string[Strings from Stringlist]<<;";

		// setting treeview mappings and datasource  Pix[Icon]<<; 
		entrycombo.ItemsDataSource = worldlist;
		entrycombo.ColumnMappings = "{Person} FullName; Name[First Name]<<; Surname[Last Name]<<; Male[Gender]<<; FullName[Full name]<<";
		
		// setting treeview mappings and datasource  Pix[Icon]<<; 
		combo.ItemsDataSource = worldlist;
		combo.ColumnMappings = "{Person} Pix[Icon]<<; Name[First Name]<<; Surname[Last Name]<<; Percent[Progress]<<PERCENT; Male[Gender]<<; Alpha[Alpha Value]<<; FullName[Full name]<<";

		// setting treeview mappings and datasource, but as simple string list
		combostr.ItemsDataSource = strings;
//		combostr.ColumnMappings = "string[Strings from Stringlist]<<;";

		// setting treeview mappings and datasource
		view.ColumnMappings = "{Person} Pix[First Name::Name<>]<<; Surname[Last Name]<>; Percent[Progress]<<PERCENT; Male[Gender]<>; Alpha[Alpha Value]<>; FullName[Full name]<<";
		view.ItemsDataSource = familylist;
//		view.Mappings = "{Person} Name[First Name]<>;  Pix[Icon]<<; Surname[Last Name]<>; Percent[Progress]<<PERCENT; Male[Gender]<>; Alpha[Alpha Value]<>; FullName[Full name]<<";

		// setting adaptor to follow treeview selection
		adaptorCursor.Target = view.CurrentSelection;
		
		// setting control mappings, all are by default inheriting it from the form
		check.Mappings = "Male";
		entryS.Mappings = "Surname";
		entry.Mappings = "Name";
		progress.Mappings = "DoubleVal";
		spin.Mappings = "Number";
		cal.Mappings = "DTime";
		colbtn.Mappings = "SkinColor; Alpha<>Alpha";
		colsel.Mappings = "SkinColor; Alpha<>CurrentAlpha";
		lbl.Mappings = "BleedingDesc";
		nlbl.Mappings = "FullName";
	}

	protected void AddButtonClickedHandler (object o, EventArgs args)
	{
		familylist.Add (new Person ("Joe #" + (worldlist.Count + 1), "Somebody #" + (worldlist.Count + 1), 1, (worldlist.Count%2) == 0));
		worldlist.Add (new Person ("Joe #" + (worldlist.Count + 1), "Somebody #" + (worldlist.Count + 1), 1, (worldlist.Count%2) == 0));
		personlist.Add (new Person ("Joe #" + (worldlist.Count + 1), "Somebody #" + (worldlist.Count + 1), 1, (worldlist.Count%2) == 0));
		subpersonlist.Add (new Person ("Joe #" + (worldlist.Count + 1), "Somebody #" + (worldlist.Count + 1), 1, (worldlist.Count%2) == 0));
		subsubpersonlist.Add (new Person ("Joe #" + (worldlist.Count + 1), "Somebody #" + (worldlist.Count + 1), 1, (worldlist.Count%2) == 0));
		strings[5] = strings[5] + "A";
	}
	
	protected void NullButtonClickedHandler (object o, EventArgs args)
	{
		if (view.ItemsDataSource == null) {
			view.ItemsDataSource = familylist;
			adaptorCursor.Target = view.CurrentSelection;
		}
		else {
			adaptorCursor.Target = null;
			view.ItemsDataSource = null;
		}
	}
	
	protected void CollectButtonClickedHandler (object o, EventArgs args)
	{
		GC.Collect();
	}
	
	protected void Debug()
	{
		Console.WriteLine ("Setting cursor DataSource count: " + DataSourceController.Count);
		IObserveable observer = null;
		for (int i=0; i<DataSourceController.Count; i++) {
			observer = DataSourceController.GetInfo (i);
			if (observer != null) {
				//Console.WriteLine (observer);
				if (observer is System.Data.Bindings.DataSourceInfo) {
					DataSourceInfo DS = (observer as System.Data.Bindings.DataSourceInfo); 
					//Console.WriteLine ((observer as System.Data.Bindings.DataSourceInfo).Target);
					if (DS.Target is Person) {
						Person p = (Person) (observer as System.Data.Bindings.DataSourceInfo).Target;
						Console.WriteLine (p.Name + " " + p.Surname + " RefCount:" + DS.RefCount);
					}
				}
			}
		}
	}
	
	protected virtual void OnDeleteEvent(object o, Gtk.DeleteEventArgs args)
	{
		Application.Quit();
	}
}
