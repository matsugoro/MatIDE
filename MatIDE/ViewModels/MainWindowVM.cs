using Livet;
using Livet.Commands;
using Livet.Messaging;
using MatIDE.ViewModels.Dock;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;


namespace MatIDE.ViewModels
{
	public class MainWindowVM : ViewModel
	{
		private ObservableCollection<ToolContent>	_tools;

		public MainWindowVM()
		{
			Initialize();
		}

		public ObservableCollection<ToolContent> Tools
		{
			get {
				if ( _tools == null )
					_tools = new ObservableCollection<ToolContent>();
				return _tools;
			}
		}



		/*

51         protected abstract void InitializeTools(); 
52 
 
53         protected DocumentContent GetDocumentByContentId(String contentId) 
54         { 
55             return Documents.FirstOrDefault(d => d.ContentId == contentId); 
56         } 
57 
		*/


		#region ===== COMMANDS =====

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

		#region DoCommand
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
			Tools.Add( new LocalExplorerVM() );
		}
	}
}
