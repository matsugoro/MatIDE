using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.Models.AppSetting
{
	[Flags]
	public enum StatusBarItem
	{
		CurrentRowCol	= 0x0001,
		CurrentLinePos	= 0x0002,
		CharLineSet		= 0x0004,
		Clock			= 0x0008,
		CapsLock		= 0x0010,
		InsMode			= 0x0020,
	}

	[Serializable]
	public class SettingGeneral
	{
		#region Fields
		private MRUList	_mruFileList = null;
		private MRUList _mruProjectList = null;
		#endregion
		
		#region Properties

		/// <summary>
		/// MatIDEの概観
		/// </summary>
		public UInt32 VisualStyle { get; set; }

		/// <summary>
		/// Ribbonの使用
		/// </summary>
		public bool UseRibbon { get; set; }

		/// <summary>
		/// ファンクションキーバーの使用
		/// </summary>
		public bool ShowFunctionKeys { get; set; }

		/// <summary>
		/// ファンクションキーバーの表示位置
		/// </summary>
		public bool FunckeyPosUpper { get; set; }

		/// <summary>
		/// ステータスバーの表示
		/// </summary>
		public bool ShowStatusBar { get; set; }

		/// <summary>
		/// ステータスバー表示項目
		/// </summary>
		public StatusBarItem StatusBarFlags { get; set; }

		/// <summary>
		/// MRU(ファイル)の最大表示数
		/// </summary>
		public Int32 MaxMruFileNum { get; set; }

		/// <summary>
		/// MRU(ファイル)リスト
		/// </summary>
		public MRUList MruFileList
		{
			get {
				if ( _mruFileList == null )
					_mruFileList = new MRUList();
				return _mruFileList;
			}
		}

		/// <summary>
		/// MRU(プロジェクト)の最大表示数
		/// </summary>
		public Int32 MaxMruProjectNum { get; set; }

		/// <summary>
		/// MRU(プロジェクト）リスト
		/// </summary>
		public MRUList MruProjectList
		{
			get {
				if ( _mruProjectList == null )
					_mruProjectList = new MRUList();
				return _mruProjectList;
			}
		}

		/// <summary>
		/// 終了確認表示
		/// </summary>
		public bool ShowExitConfirm { get; set; }
		#endregion

		public SettingGeneral()
		{
			VisualStyle = 0;
			UseRibbon = true;
			ShowFunctionKeys = false;
			FunckeyPosUpper = false;
			ShowStatusBar = true;
			StatusBarFlags = StatusBarItem.CurrentRowCol|StatusBarItem.CurrentLinePos|StatusBarItem.InsMode;
			MaxMruFileNum = 10;
			MaxMruProjectNum = 10;
			ShowExitConfirm = true;
		}
	}
}
