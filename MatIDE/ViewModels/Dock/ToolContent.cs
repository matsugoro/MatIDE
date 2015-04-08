using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using System.Windows;
using MatIDE.Models;
using MatIDE.Attributes;
using System.Windows.Data;

namespace MatIDE.ViewModels.Dock
{
	public class ToolContent : ViewModel
	{
		private string		_contentId;
		private string		_title;
		private Visibility	_visibility;
	
		public ToolContent( string contentId, string title=null )
		{
			_contentId	= contentId;
			_title		= string.IsNullOrEmpty(title) ? contentId : title;
		}

		[ContentProperty]
		public string ContentId
		{
			get{
				return _contentId;
			}
			set {
				if ( _contentId != value ){
					_contentId = value;
					RaisePropertyChanged();
				}
			}
		}

		[ContentProperty]
		public string Title
		{
			get {
				return _title;
			}
			set {
				if ( _title != value ){
					_title = value;
					RaisePropertyChanged();
				}
			}
		}

		[ContentProperty]
		public string Name	{ get; set; }

		/*
		private bool	_isSelected;
		private bool	_isActive;
		private ImageSource Icon	{ get; private set; }
		*/

		[ContentProperty(BindingMode=BindingMode.TwoWay)]
		public Visibility Visibility
		{
			get {
				return _visibility;
			}
			set {
				if ( _visibility != value ){
					_visibility = value;
					RaisePropertyChanged();
					RaisePropertyChanged("IsVisible");
				}
			}
		}

		public bool IsVisible
		{
			get {
				return Visibility == Visibility.Visible;
			}
			set {
				if ( IsVisible == value )
					return;
				Visibility = value ? Visibility.Visible : Visibility.Hidden;
			}
		}
	}
}
