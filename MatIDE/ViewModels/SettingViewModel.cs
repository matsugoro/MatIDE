using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using Livet.Commands;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MatIDE.ViewModels
{
	public class SettingViewModel : ViewModel
	{
		public class SettingNode : ObservableCollection<SettingNode>
		{
			/// <summary>
			/// 設定項目名
			/// </summary>
			public string		Name			{ get; set; }

			/// <summary>
			/// 
			/// </summary>
			public string		NameOfViewModel	{ get; set; }

			/// <summary>
			/// 設定項目下位項目
			/// </summary>
			public SettingNode	Children		{ get; set; }

			/// <summary>
			/// 
			/// </summary>
			public SettingNode()
			{
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="name"></param>
			public SettingNode( string name, string vm )
			{
				this.Name = name;
				this.NameOfViewModel = vm;
			}
		}

		private Dictionary<string,SettingVMBase>	_ucViewModels = new Dictionary<string,SettingVMBase>();
		private SettingVMBase						_currentVM;
		private ListenerCommand<SettingNode>		_selChangeCommand;

		public SettingNode	Nodes { get; set; }

		public SettingVMBase CurrentViewModel
		{
			get {
				return _currentVM;
			}
			set {
				if ( _currentVM != value ){
					_currentVM = value;
					RaisePropertyChanged();
				}
			}
		}

		private readonly string	VM_GENERAL		= "MatIDE.ViewModels.SettingGeneralVM";
		private readonly string VM_TAB			= "MatIDE.ViewModels.SettingTabVM";
		private readonly string VM_EDITCOMMON	= "MatIDE.ViewModels.SettingEditCommonVM";

		//=====================================================================
		/// <summary>
		/// </summary>
		//=====================================================================
		public SettingViewModel()
		{
			Nodes = new SettingNode() {
				new SettingNode( "環境設定", VM_GENERAL ){
					Children = new SettingNode {
						new SettingNode( "全般", VM_GENERAL ),
						new SettingNode( "タブ設定", VM_TAB ),
						new SettingNode( "エディタ設定", VM_EDITCOMMON ){
							Children = new SettingNode {
								new SettingNode("共通設定", VM_EDITCOMMON ){
									Children = new SettingNode {
										new SettingNode("編集", ""),
										new SettingNode("ファイル制御", "")
									}
								},
								new SettingNode("タイプ別設定", "")
							}
						},
						new SettingNode("端末設定", ""),
						new SettingNode("FTP設定", ""){
							Children = new SettingNode {
								new SettingNode("接続", ""){
									Children = new SettingNode {
										new SettingNode("FTP", ""){
											Children = new SettingNode {
												new SettingNode("アクティブモード", ""),
												new SettingNode("パッシブモード", ""),
												new SettingNode("FTPプロキシ", "")
											}
										},
										new SettingNode("SFTP", ""),
										new SettingNode("汎用プロキシ", "")
									}
								},
								new SettingNode("転送", "") {
									Children = new SettingNode {
										new SettingNode("ファイル転送", "")
									}
								}
							}
						}
					}
				}
			};
		}
	
		
		public ListenerCommand<SettingNode> SelChangeCommand
		{
			get {
				if ( _selChangeCommand == null )
					_selChangeCommand = new ListenerCommand<SettingNode>(ExecuteSelChange);
				return _selChangeCommand;
			}
		}


		private SettingVMBase getOrCreateViewModel( SettingNode sn )
		{
			SettingVMBase	viewModel = null;

			if ( sn == null || string.IsNullOrEmpty(sn.NameOfViewModel) )
				return viewModel;

			if ( ! _ucViewModels.TryGetValue(sn.NameOfViewModel, out viewModel) ){
				Type	t = Type.GetType(sn.NameOfViewModel);
				object	obj;

				obj = Activator.CreateInstance(t);
				viewModel = obj as SettingVMBase;
				_ucViewModels[sn.NameOfViewModel] = viewModel;
			}
			return viewModel;
		}

		private void ExecuteSelChange( SettingNode sn )
		{
			CurrentViewModel = getOrCreateViewModel(sn);
		}
	}
}
