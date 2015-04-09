using System;
using Livet;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MatIDE.ViewModels.Dock
{
	public class PaneViewModel : ViewModel
	{
		private string	_title = null;
		private string	_contentId = null;
		private bool _isSelected = false;
		private bool _isActive = false;
		private ImageSource _icon = null;

		/// <summary>
		/// 
		/// </summary>
		public PaneViewModel()
		{
		}

		#region ===== Title =====

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
		#endregion

		#region ===== IconSource =====
		public ImageSource Icon
		{
			get {
				return _icon;
			}
			protected set {
				if ( _icon != value ){
					_icon = value;
					RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region ===== ContentId =====
		public string ContentId
		{
			get {
				return _contentId;
			}
			set {
				if ( _contentId != value ){
					_contentId = value;
					RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region ===== IsSelected =====

		public bool IsSelected
		{
			get {
				return _isSelected;
			}
			set {
				if ( _isSelected != value ){
					_isSelected = value;
					RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region ===== IsActive =====

		public bool IsActive
		{
			get {
				return _isActive;
			}
			set {
				if ( _isActive != value ){
					_isActive = value;
					RaisePropertyChanged();
				}
			}
		}

		#endregion

	}
}
