
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action addAction;
	private global::Gtk.Action removeAction;
	private global::Gtk.Action propertiesAction;
	private global::Gtk.Action noAction;
	private global::Gtk.DataBindings.DataVBox datavbox1;
	private global::Gtk.Toolbar toolbar1;
	private global::Gtk.DataBindings.DataTreeView Timers;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.addAction = new global::Gtk.Action ("addAction", null, null, "gtk-add");
		w1.Add (this.addAction, null);
		this.removeAction = new global::Gtk.Action ("removeAction", null, null, "gtk-remove");
		w1.Add (this.removeAction, null);
		this.propertiesAction = new global::Gtk.Action ("propertiesAction", null, null, "gtk-properties");
		w1.Add (this.propertiesAction, null);
		this.noAction = new global::Gtk.Action ("noAction", null, null, "gtk-no");
		w1.Add (this.noAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = "MainWindow";
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.Resizable = false;
		this.AllowGrow = false;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.datavbox1 = new global::Gtk.DataBindings.DataVBox ();
		this.datavbox1.Name = "datavbox1";
		this.datavbox1.Spacing = 6;
		this.datavbox1.InheritedDataSource = false;
		this.datavbox1.InheritedBoundaryDataSource = false;
		this.datavbox1.InheritedDataSource = false;
		this.datavbox1.InheritedBoundaryDataSource = false;
		// Container child datavbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='addAction' action='addAction'/><toolitem name='removeAction' action='removeAction'/><toolitem name='propertiesAction' action='propertiesAction'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.toolbar1.ToolbarStyle = ((global::Gtk.ToolbarStyle)(0));
		this.toolbar1.IconSize = ((global::Gtk.IconSize)(3));
		this.datavbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.datavbox1 [this.toolbar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child datavbox1.Gtk.Box+BoxChild
		this.Timers = new global::Gtk.DataBindings.DataTreeView ();
		this.Timers.CanFocus = true;
		this.Timers.Name = "Timers";
		this.Timers.CursorPointsEveryType = false;
		this.Timers.InheritedDataSource = false;
		this.Timers.Mappings = "";
		this.Timers.InheritedBoundaryDataSource = false;
		this.Timers.InheritedDataSource = false;
		this.Timers.Mappings = "";
		this.Timers.InheritedBoundaryDataSource = false;
		this.Timers.ColumnMappings = "{stopwatch.Timer} Active[Name::Status>>; Name<>]<>; StringValue[Elapsed]>>; MaxTimeStringValue[Max Time]>>;";
		this.datavbox1.Add (this.Timers);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.datavbox1 [this.Timers]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		this.Add (this.datavbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.addAction.Activated += new global::System.EventHandler (this.OnAddActionActivated);
		this.removeAction.Activated += new global::System.EventHandler (this.OnRemoveActionActivated);
		this.propertiesAction.Activated += new global::System.EventHandler (this.OnPropertiesActionActivated);
	}
}
