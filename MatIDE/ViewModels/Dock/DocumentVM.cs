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
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Utils;
using ICSharpCode.AvalonEdit.Highlighting;


namespace MatIDE.ViewModels.Dock
{
	public class DocumentVM : PaneVM
	{
		static ImageSourceConverter ISC = new ImageSourceConverter();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		public DocumentVM( string filePath )
		{
			FilePath = filePath;
			Title = FileName;
			Icon = ((App)Application.Current).GetImageFromExt( FilePath );
		}

		/// <summary>
		/// 
		/// </summary>
		public DocumentVM()
		{
			IsDirty = false;
			Title = FileName;
			Icon = ISC.ConvertFromInvariantString(@"pack://application:,,/Images/document.png") as ImageSource;
		}

		#region TextContent

		private TextDocument _document = null;

		public TextDocument Document
		{
			get {
				return _document;
			}
			set {
				if ( _document != value ){
					_document = value;
					RaisePropertyChanged("Document");
					IsDirty = true;
				}
			}
		}

		#endregion

		#region HighlightingDefinition

		private IHighlightingDefinition _highlightdef = null;

		public IHighlightingDefinition HighlightDef
		{
			get {
				return this._highlightdef;
			}
			set {
				if ( this._highlightdef != value ){
					this._highlightdef = value;
					RaisePropertyChanged("HighlightDef");
					IsDirty = true;
				}
			}
		}

		#endregion

		#region ===== IsDirty =====

		private bool _isDirty = false;

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

		private string _filePath = null;

		/// <summary>
		/// 
		/// </summary>
		public string FilePath
		{
			get {
				return _filePath;
			}
			set {
				if ( _filePath != value ){
					_filePath = value;
	
					RaisePropertyChanged("FilePath");
					RaisePropertyChanged("FileName");
					RaisePropertyChanged("Title");
					if ( File.Exists( _filePath ) ){
						string	ext = Path.GetExtension(_filePath);

						_document = new TextDocument();
						this.HighlightDef = HighlightingManager.Instance.GetDefinitionByExtension(ext);
						this._isDirty = false;
//						this.IsReadOnly = false;

						using ( var fs = new FileStream( _filePath, FileMode.Open, FileAccess.Read, FileShare.Read )){
							using ( StreamReader sr = FileReader.OpenStream( fs, Encoding.UTF8 )){
								_document = new TextDocument(sr.ReadToEnd());
							}
						}
						ContentId = _filePath;
					}
				}
			}
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			get {
				if ( string.IsNullOrEmpty(FilePath) )
					return "Noname" + (IsDirty ? "*" : "");
				return Path.GetFileName(FilePath) + (IsDirty ? "*" : ""); 
			}
		}


		#region CloseCommand

		private ViewModelCommand _closeCommand;

		public ViewModelCommand CloseCommand
		{
			get {
				if ( _closeCommand == null )
					_closeCommand = new ViewModelCommand(OnClose);
				return _closeCommand;
			}
		}

		private void OnClose()
		{
			MainWindowVM.Instance.Close(this);
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
			get {
				if ( _saveAsCommand == null ){
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


	}
}
