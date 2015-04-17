using MatIDE.ViewModels.Dock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Layout;

namespace MatIDE.Docking
{
	public class LayoutInitializer : ILayoutUpdateStrategy
	{
		public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow, ILayoutContainer destinationContainer)
		{
			LayoutAnchorablePane	destPane = destinationContainer as LayoutAnchorablePane;

			if ( destinationContainer != null && destinationContainer.FindParent<LayoutFloatingWindow>() != null)
				return false;

			if ( anchorableToShow.Content is ToolVM ){
				ToolVM	tvm = (ToolVM)anchorableToShow.Content;
				var		toolsPane = layout.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault(d => d.Name == tvm.InitialPane );

				if ( toolsPane != null ){
					toolsPane.Children.Add(anchorableToShow);
					return true;
				}
			}
			return false;
		}


		public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
		{
		}


		public bool BeforeInsertDocument(LayoutRoot layout, LayoutDocument anchorableToShow, ILayoutContainer destinationContainer)
		{
			return false;
		}

		public void AfterInsertDocument(LayoutRoot layout, LayoutDocument anchorableShown)
		{
		}

	}
}
