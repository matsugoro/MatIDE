﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.ViewModels.Dock
{

	public class ToolViewModel : PaneViewModel
	{
		private bool _isVisible = true;

		public ToolViewModel( string name )
		{
			Name = name;
			Title = name;
		}

		public string Name
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