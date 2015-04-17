using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.ViewModels.Dock
{
	public class ToolVM : PaneVM
	{
		private bool _isVisible = true;

		public ToolVM( string name, string initialPane )
		{
			Name = name;
			InitialPane = initialPane;
			Title = name;
		}

		public string Name
		{
			get;
			private set;
		}

		public string InitialPane
		{
			get;
			private set;
		}



		public bool IsVisible
		{
			get {
				return _isVisible;
			}
			set {
				if ( _isVisible != value ){
					_isVisible = value;
					RaisePropertyChanged();
				}
			}
		}
	}
}
