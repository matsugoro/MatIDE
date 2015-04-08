using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatIDE.Behaviors
{
	public class SettingTVBehavior
	{
		public static ICommand GetOnSelectedItemChanged( DependencyObject d )
		{
			return (ICommand)d.GetValue( OnSelectedItemChangedProperty );
		}

		public static void SetOnSelectedItemChanged( DependencyObject d, ICommand value )
		{
			d.SetValue( OnSelectedItemChangedProperty, value );
		}

		public static readonly DependencyProperty OnSelectedItemChangedProperty =
			DependencyProperty.RegisterAttached(
									"OnSelectedItemChanged",
									typeof(ICommand),
									typeof(SettingTVBehavior),
									new UIPropertyMetadata( null, OnSelectedItemChangedPropertyChanged));

		static void OnSelectedItemChangedPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs args )
		{
			var treeView = d as TreeView;
			if (treeView == null)
				return;

			if (args.NewValue is ICommand)
				treeView.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object> (OnTreeViewSelectedItemChanged);
			else
				treeView.SelectedItemChanged -= new RoutedPropertyChangedEventHandler<object> (OnTreeViewSelectedItemChanged);
		}

		static void OnTreeViewSelectedItemChanged (object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var treeView = e.OriginalSource as TreeView;
			if (treeView == null)
				return;

			var command = GetOnSelectedItemChanged (treeView);
			if (command == null)
				return;

			command.Execute (treeView.SelectedItem);
		}
	}
}
