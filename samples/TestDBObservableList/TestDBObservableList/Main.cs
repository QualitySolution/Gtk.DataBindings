using System;
using Gtk;
using System.Data.Bindings;
using System.Data.Bindings.Collections;

namespace TestDBObservableList
{
	public class Named : BaseNotifyPropertyChanged
	{
		private string name = "";
		public string FName { 
			get { return (name); }
			set {
				if (name == value)
					return;
				name = value;
				OnPropertyChanged ("FName");
			}
		}
		
		private int age = 0;
		public int Age { 
			get { return (Age); }
			set {
				if (age == value)
					return;
				age = value;
				OnPropertyChanged ("Age");
			}
		}
		
		public override string ToString ()
		{
			return string.Format("[Named: Name={0}, Age={1}]", FName, Age);
		}

		public Named (string aName, int aAge)
		{
			name = aName;
			age = aAge;
		}
	}
	
	class MainClass
	{
		public static bool infilter (object obj)
		{
			return (((Named) obj).Age > 15);
		}
		
		public static void Main (string[] args)
		{
			ObservableArrayList arr = new ObservableArrayList();
			ObservableFilterList filter = new ObservableFilterList (arr);
			filter.IsVisibleInFilter += new IsVisibleInFilterEvent(infilter);
/*			delegate(object aObject) {
				if (aObject is Named == false)
					return (false);
				return (((Named) aObject).Age > 15);
			};*/
			filter.ElementAdded += delegate(object aList, int[] aIdx) {
				System.Console.WriteLine("Added({2}): {0} - {1}", aIdx.PathToString(), 0, 0);//filter.Count);
			};
			filter.ElementChanged += delegate(object aList, int[] aIdx) {
				System.Console.WriteLine("Changed({2}): {0} - {1}", aIdx.PathToString(), 0, 0);//filter[aIdx], filter.Count);
			};
			filter.ElementRemoved += delegate(object aList, int[] aIdx, object aObject) {
				System.Console.WriteLine("Removed({2}): {0} - {1}", aIdx.PathToString(), 0, 0);//filter[aIdx], filter.Count);
			};
			filter.Add (new Named ("A", 13));
			filter.Add (new Named ("B", 16));
			filter.Add (new Named ("C", 12));
//			System.Console.WriteLine("ItemCount={0}", arr.Count);
			System.Console.WriteLine("{0}:{1}",filter.Count, arr.Count);
			if (arr[0] is Named)
				System.Console.WriteLine("NAMED");
			(arr[0] as Named).Age = 33;
			return;
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}