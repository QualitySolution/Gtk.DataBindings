// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Gtk.ExtraWidgets {
    
    
    public partial class DatePickerWindow {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Calendar calendar;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget Gtk.ExtraWidgets.DatePickerWindow
            this.Name = "Gtk.ExtraWidgets.DatePickerWindow";
            this.Title = "";
            this.TypeHint = ((Gdk.WindowTypeHint)(2));
            this.Resizable = false;
            this.AllowGrow = false;
            this.Decorated = false;
            this.DestroyWithParent = true;
            // Container child Gtk.ExtraWidgets.DatePickerWindow.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            this.vbox2.BorderWidth = ((uint)(1));
            // Container child vbox2.Gtk.Box+BoxChild
            this.calendar = new Gtk.Calendar();
            this.calendar.CanFocus = true;
            this.calendar.Name = "calendar";
            this.calendar.DisplayOptions = ((Gtk.CalendarDisplayOptions)(35));
            this.vbox2.Add(this.calendar);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox2[this.calendar]));
            w1.Position = 0;
            this.Add(this.vbox2);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 279;
            this.DefaultHeight = 231;
            this.Show();
            this.ButtonPressEvent += new Gtk.ButtonPressEventHandler(this.OnButtonPressEvent);
            this.calendar.DaySelectedDoubleClick += new System.EventHandler(this.OnCalendar2DaySelectedDoubleClick);
            this.calendar.DaySelected += new System.EventHandler(this.OnCalendar2DaySelected);
            this.calendar.KeyReleaseEvent += new Gtk.KeyReleaseEventHandler(this.OnCalendarKeyReleaseEvent);
        }
    }
}