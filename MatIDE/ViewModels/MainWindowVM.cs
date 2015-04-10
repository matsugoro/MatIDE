using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using Livet;
using Livet.Commands;
using Livet.Messaging;

using Microsoft.WindowsAPICodePack.Dialogs;

using MatIDE.ViewModels.Dock;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Data;

namespace MatIDE.ViewModels
{
	//=========================================================================
	/// <summary>
	/// 
	/// </summary>
	//=========================================================================
	public class MainWindowVM : ViewModel
	{
		public static MainWindowVM Instance { get; private set; }



		private ObservableCollection<ToolViewModel>	_tools;
		private ObservableCollection<FileViewModel> _files = new ObservableCollection<FileViewModel>();
		private ReadOnlyObservableCollection<FileViewModel> _readonyFiles = null;
		private LocalExplorerVM _localExplorer;
		private ProjectExplorerVM _projectExplorer;
		private FileViewModel _activeDocument = null;

		/// <summary>
		/// 
		/// </summary>
		public MainWindowVM()
		{
			Instance = this;
		}

		#region ===== Visibility Functionkeys =====
		public bool IsVisibleFunckyBar
		{
			get {
				return ((App)Application.Current).AppSet.General.ShowFunctionKeys;
			}
			set {
				if ( IsVisibleFunckyBar != value ){
					((App)Application.Current).AppSet.General.ShowFunctionKeys = value;
					RaisePropertyChanged();
					RaisePropertyChanged("VisibilityFunckeyBar");
				}
			}
		}


		public Visibility VisibilityFunckeyBar
		{
			get {
				return ((App)Application.Current).AppSet.General.ShowFunctionKeys ? Visibility.Visible : Visibility.Collapsed;
			}
			set {
				if ( VisibilityFunckeyBar != value ){
					if ( value == Visibility.Visible )
						((App)Application.Current).AppSet.General.ShowFunctionKeys = true;
					else
						((App)Application.Current).AppSet.General.ShowFunctionKeys = false;
					RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region ===== Visibility Statusbar =====

		public bool IsVisibleStatusbar
		{
			get {
				return ((App)Application.Current).AppSet.General.ShowStatusBar;
			}
			set {
				if ( IsVisibleStatusbar != value ){
					((App)Application.Current).AppSet.General.ShowStatusBar = value;
					RaisePropertyChanged();
					RaisePropertyChanged("VisibilityStatusbar");
				}
			}
		}

		public Visibility VisibilityStatusbar
		{
			get {
				return ((App)Application.Current).AppSet.General.ShowStatusBar ? Visibility.Visible : Visibility.Collapsed;
			}
			set {
				if ( VisibilityStatusbar != value ){
					if ( value == Visibility.Visible )
						((App)Application.Current).AppSet.General.ShowStatusBar = true;
					else
						((App)Application.Current).AppSet.General.ShowStatusBar = false;
					RaisePropertyChanged();
				}
			}
		}





		#endregion









		public ObservableCollection<ToolViewModel> Tools
		{
			get {
				if ( _tools == null ){
					_tools = new ObservableCollection<ToolViewModel>();
					_tools.Add( LocalExplorer );
					_tools.Add( ProjectExplorer );
				}
				return _tools;
			}
		}

		public ReadOnlyObservableCollection<FileViewModel> Files
		{
			get {
				if ( _readonyFiles == null )
					_readonyFiles = new ReadOnlyObservableCollection<FileViewModel>(_files);
				return _readonyFiles;
			}
		}

		public FileViewModel ActiveDocument
		{
			get {
				return _activeDocument;
			}
			set {
				if ( _activeDocument != value ){
					_activeDocument = value;

					RaisePropertyChanged();
					if ( ActiveDocumentChanged != null )
						ActiveDocumentChanged( this, EventArgs.Empty );
					CloseCommand.RaiseCanExecuteChanged();
				}
			}
		}

		public LocalExplorerVM LocalExplorer
		{
			get {
				if ( _localExplorer == null )
					_localExplorer = new LocalExplorerVM();
				return _localExplorer;
			}
		}

		public ProjectExplorerVM ProjectExplorer
		{
			get {
				if ( _projectExplorer == null )
					_projectExplorer = new ProjectExplorerVM();
				return _projectExplorer;
			}
		}




		public event EventHandler ActiveDocumentChanged;

		#region ===== COMMANDS =====

		#region ===== NewCommand =====
		private ViewModelCommand	_newCommand = null;

		public ViewModelCommand NewCommand
		{
			get {
				if ( _newCommand == null )
					_newCommand = new ViewModelCommand( OnNew, CanNew );
				return _newCommand;
			}
		}

		private bool CanNew()
		{
			return true;
		}

		private void OnNew()
		{
			_files.Add( new FileViewModel() );
			ActiveDocument = _files.Last();
		}

		#endregion 

		#region  ===== OpenCommand =====

		private ViewModelCommand	_openCommand = null;

		public ViewModelCommand OpenCommand
		{
			get {
				if ( _openCommand == null )
					_openCommand = new ViewModelCommand(OnOpen, CanOpen);
				return _openCommand;
			}
		}

		private bool CanOpen()
		{
			return true;
		}

		private void OnOpen()
		{
			var dlg = new OpenFileDialog();
			if ( dlg.ShowDialog().GetValueOrDefault() ){
				var fileViewModel = Open(dlg.FileName);
				ActiveDocument = fileViewModel;
			}
		}

		public FileViewModel Open(string filepath)
		{
			var fileViewModel = _files.FirstOrDefault(fm => fm.FilePath == filepath);

			if ( fileViewModel != null )
				return fileViewModel;
			fileViewModel = new FileViewModel(filepath);
			_files.Add(fileViewModel);
			return fileViewModel;
		}

		#endregion

		#region ===== CloseCommand =====

		private ViewModelCommand	_closeCommand = null;

		public ViewModelCommand CloseCommand
		{
			get {
				if ( _closeCommand == null )
					_closeCommand = new ViewModelCommand( OnClose, CanClose );
				return _closeCommand;
			}
		}

		private bool CanClose()
		{
			if ( _activeDocument == null )
				return false;
			return true;
		}

		private void OnClose()
		{
			Close(ActiveDocument);
		}




		#endregion

		#region ===== TestCommand =====

		private ViewModelCommand	_TestCommand;

		public ViewModelCommand TestWinCommand
		{
			get {
				if ( _TestCommand == null )
					_TestCommand = new ViewModelCommand(DoTest);
				return _TestCommand;
			}
		}

		private void DoTest()
		{
			MatIDE.Views.testview view = new Views.testview();
			view.Show();
		}
		#endregion

		#region ===== SettingCommand =====
		private ViewModelCommand _SettingCommand;

		public ViewModelCommand SettingCommand
		{
			get {
				if ( _SettingCommand == null ){
					_SettingCommand =new ViewModelCommand(DoSetting);
				}
				return _SettingCommand;
			}
		}

		public void DoSetting()
		{
			Messenger.Raise(new TransitionMessage(new SettingViewModel(), "ShowCommand"));
		}
		#endregion

		#region ===== QUIT COMMAND =====
		private ListenerCommand<Window>	_quitCommand;

		public ListenerCommand<Window> QuitCommand
		{
			get {
				if ( _quitCommand == null )
					_quitCommand = new ListenerCommand<Window>(ExcetuteQuit);
				return _quitCommand;
			}
		}

		private void ExcetuteQuit( Window x )
		{
			if ( x == null )
				return;

			var	dialog = new TaskDialog();
			dialog.Caption	= "終了確認";
			dialog.InstructionText = "MatIDEを終了します。";
			dialog.Text = "保存されていないドキュメントは内容が破棄されます。";
			dialog.Icon = TaskDialogStandardIcon.Information;
			dialog.StandardButtons = TaskDialogStandardButtons.Ok|TaskDialogStandardButtons.Cancel;
			dialog.FooterCheckBoxText = "次回から確認しない";

			if ( dialog.Show() == TaskDialogResult.Cancel )
				return;
			x.Close();
		}
		#endregion

		#endregion

		public void Initialize()
		{
		}


		internal void Close( FileViewModel fileToClose )
		{
			if ( fileToClose.IsDirty ){
				/*
				var res = MessageBox.Show(string.Format("Save changes for file '{0}'?", fileToClose.FileName), "AvalonDock Test App", MessageBoxButton.YesNoCancel);
				if (res == MessageBoxResult.Cancel)
					return;
				if (res == MessageBoxResult.Yes)
				{
					Save(fileToClose);
				}
				*/
			}
			_files.Remove( fileToClose );
			if ( _files.Count() == 0 )
				ActiveDocument = null;
		}
	}
}
