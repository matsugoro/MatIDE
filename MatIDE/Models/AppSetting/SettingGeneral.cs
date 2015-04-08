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
		#region ===== PROPERTIES =====
		public UInt32			VisualStyle			{ get; set; }
		public bool				UseRibbon			{ get; set; }
		public bool				ShowFunctionKeys	{ get; set; }
		public bool				FunckeyPosUpper		{ get; set; }
		public bool				ShowStatusBar		{ get; set; }
		public StatusBarItem	StatusBarFlags		{ get; set; }
		public Int32			MruFileNum			{ get; set; }
		public Int32			MruProjectNum		{ get; set; }
		public bool				ShowExitConfirm		{ get; set; }
		#endregion

		public SettingGeneral()
		{
			VisualStyle			= 0;
			UseRibbon			= true;
			ShowFunctionKeys	= false;
			FunckeyPosUpper		= false;
			ShowStatusBar		= true;
			StatusBarFlags		= StatusBarItem.CurrentRowCol|StatusBarItem.CurrentLinePos|StatusBarItem.InsMode;
			MruFileNum			= 10;
			MruProjectNum		= 10;
			ShowExitConfirm		= true;
		}
	}
}
