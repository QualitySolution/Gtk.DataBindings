// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.VBox vbox1;
    
    private Gtk.DataBindings.DataEntry dataentry1;
    
    private Gtk.DataBindings.DataEntry dataentry2;
    
    private Gtk.HBox hbox2;
    
    private Gtk.Button button1;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("MainWindow");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new Gtk.VBox();
        this.vbox1.Name = "vbox1";
        this.vbox1.Spacing = 4;
        this.vbox1.BorderWidth = ((uint)(8));
        // Container child vbox1.Gtk.Box+BoxChild
        this.dataentry1 = new Gtk.DataBindings.DataEntry();
        this.dataentry1.CanFocus = true;
        this.dataentry1.Name = "dataentry1";
        this.dataentry1.IsEditable = true;
        this.dataentry1.InvisibleChar = '•';
        this.dataentry1.InheritedDataSource = false;
        this.dataentry1.Mappings = "Text";
        this.dataentry1.InheritedBoundaryDataSource = false;
        this.vbox1.Add(this.dataentry1);
        Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.dataentry1]));
        w1.Position = 0;
        w1.Expand = false;
        w1.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.dataentry2 = new Gtk.DataBindings.DataEntry();
        this.dataentry2.CanFocus = true;
        this.dataentry2.Name = "dataentry2";
        this.dataentry2.IsEditable = true;
        this.dataentry2.InvisibleChar = '•';
        this.dataentry2.InheritedDataSource = false;
        this.dataentry2.Mappings = "Text";
        this.dataentry2.InheritedBoundaryDataSource = false;
        this.dataentry2.BoundaryMappings = "";
        this.vbox1.Add(this.dataentry2);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.dataentry2]));
        w2.Position = 1;
        w2.Expand = false;
        w2.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbox2 = new Gtk.HBox();
        this.hbox2.Name = "hbox2";
        // Container child hbox2.Gtk.Box+BoxChild
        this.button1 = new Gtk.Button();
        this.button1.CanFocus = true;
        this.button1.Name = "button1";
        this.button1.UseUnderline = true;
        this.button1.Label = Mono.Unix.Catalog.GetString("Close");
        this.hbox2.Add(this.button1);
        Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox2[this.button1]));
        w3.Position = 2;
        w3.Expand = false;
        w3.Fill = false;
        this.vbox1.Add(this.hbox2);
        Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
        w4.Position = 2;
        w4.Expand = false;
        w4.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 400;
        this.DefaultHeight = 357;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.button1.Clicked += new System.EventHandler(this.OnButton1Clicked);
    }
}