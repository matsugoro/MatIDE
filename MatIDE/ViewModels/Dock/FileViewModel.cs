using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows;
using Livet.Commands;


namespace MatIDE.ViewModels.Dock
{
	public class FileViewModel : PaneViewModel
	{
		static ImageSourceConverter ISC = new ImageSourceConverter();

		private string	_filePath = null;
		private string	_textContent = string.Empty;
		private bool _isDirty = false;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		public FileViewModel( string filePath )
		{
			FilePath = filePath;
			Title = FileName;
			Icon = ((App)Application.Current).GetImageFromExt( FilePath );
		}

		/// <summary>
		/// 
		/// </summary>
		public FileViewModel()
		{
			IsDirty = false;
			Title = FileName;
			Icon = ISC.ConvertFromInvariantString(@"pack://application:,,/Images/document.png") as ImageSource;
		}

		#region ===== IsDirty =====

		public bool IsDirty
		{
			get {
				return _isDirty;
			}
			set {
				if ( _isDirty != value ){
					_isDirty = value;
					RaisePropertyChanged();
					RaisePropertyChanged("FileName");
				}
			}
		}
		#endregion

		#region ===== FilePath =====

		public string FilePath
		{
			get {
				return _filePath;
			}
			set {
				if ( _filePath != value ){
					_filePath = value;
					RaisePropertyChanged();
					RaisePropertyChanged("FileName");
					RaisePropertyChanged("Title");

					if ( File.Exists(_filePath) ){
						_textContent = File.ReadAllText(_filePath);
						ContentId = _filePath;
					}
				}
			}
		}
		#endregion

		public string FileName
		{
			get {
				if ( string.IsNullOrEmpty(FilePath) )
					return "Noname" + (IsDirty ? "*" : "");
				return Path.GetFileName(FilePath) + (IsDirty ? "*" : ""); 
			}
		}

		#region ===== TextContent =====

		public string TextContent
		{
			get {
				return _textContent;
			}
			set {
				if ( _textContent != value ){
					_textContent = value;
					RaisePropertyChanged();
					IsDirty = true;
				}
			}
		}

		#endregion

		#region SaveCommand
		/*
        RelayCommand _saveCommand = null;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand((p) => OnSave(p), (p) => CanSave(p));
                }

                return _saveCommand;
            }
        }

        private bool CanSave(object parameter)
        {
            return IsDirty;
        }

        private void OnSave(object parameter)
        {
            Workspace.This.Save(this, false);
        }
		*/
        #endregion

		#region SaveAsCommand
		/*
		RelayCommand _saveAsCommand = null;
		public ICommand SaveAsCommand
		{
			get
			{
				if (_saveAsCommand == null)
				{
					_saveAsCommand = new RelayCommand((p) => OnSaveAs(p), (p) => CanSaveAs(p));
				}

				return _saveAsCommand;
			}
		}

		private bool CanSaveAs(object parameter)
		{
			return IsDirty;
		}

		private void OnSaveAs(object parameter)
		{
			Workspace.This.Save(this, true);
		}
		*/
		#endregion

		/*
		#region CloseCommand

		private ViewModelCommand	_closeCommand = null;

		public ViewModelCommand CloseCommand
		{
			get {
				if ( _closeCommand == null )
					_closeCommand = new ViewModelCommand(OnClose, CanClose);
				return _closeCommand;
			}
		}

		private bool CanClose()
		{
			return true;
		}

		private void OnClose()
		{
			MainWindowVM.Instance.Close(this);
		}

		#endregion
		*/


	}
}
