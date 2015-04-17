using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MatIDE.ViewModels;
using MatIDE.ViewModels.Dock;

namespace MatIDE.Docking
{
	public class PanesStyleSelector : StyleSelector
	{
		public Style ToolStyle
		{
			get;
			set;
		}

		public Style FileStyle
		{
			get;
			set;
		}

		public override Style SelectStyle( object item, DependencyObject container )
		{
			if ( item is ToolVM )
				return ToolStyle;

			if ( item is DocumentVM )
				return FileStyle;

			return base.SelectStyle( item, container );
		}
	
	}
}
