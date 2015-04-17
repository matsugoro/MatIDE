using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MatIDE
{
	public class AppCommands
	{
		#region Fields
		private static RoutedUICommand _loadFile;
		#endregion
	
		static AppCommands()
		{
			_loadFile = new RoutedUICommand("Open...", "LoadFile", typeof(AppCommands), new InputGestureCollection());
		}

		public static RoutedUICommand LoadFile
		{
			get {
				return _loadFile;
			}
		}


	
	
	}
}
