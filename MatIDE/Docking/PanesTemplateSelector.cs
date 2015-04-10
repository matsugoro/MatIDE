using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;
using MatIDE.ViewModels;
using MatIDE.ViewModels.Dock;

namespace MatIDE.Docking
{
	public class PanesTemplateSelector : DataTemplateSelector
	{
		public PanesTemplateSelector()
		{
		}

		public DataTemplate LocalExplorerViewTemplate	{ get; set; }
		public DataTemplate ProjectExplorerViewTemplate	{ get; set; }
		public DataTemplate FileViewTemplate			{ get; set; }

		public override DataTemplate SelectTemplate( object item, DependencyObject container )
		{
			var	itemAsLayoutContent = item as LayoutContent;

			if ( item is LocalExplorerVM )
				return LocalExplorerViewTemplate;

			if ( item is ProjectExplorerVM )
				return ProjectExplorerViewTemplate;

			if ( item is FileViewModel )
				return FileViewTemplate;

			return base.SelectTemplate( item, container );
		}
	}
}
