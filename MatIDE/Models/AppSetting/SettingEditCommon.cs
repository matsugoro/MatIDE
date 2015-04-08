using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.Models.AppSetting
{
	public enum CaretType
	{
		Windows,				// WindowsType
		MSDos					// DOS Type
	}

	public enum ActMouseWheel
	{
		MW_NONE,
		MW_MIDDLEBUTTON,
		MW_SIDEBUTTON1,
		MW_SIDEBUTTON2,
		MW_CONTROLKEY,
		MW_SHIFTKEY
	}

	[Serializable]
	public class SettingEditCommon
	{
		#region ====== PROPERTIES =====
		public bool				FreeCursor				{ get; set; }
		public bool				StopsBothEndsWord		{ get; set; }
		public bool				StopsBothEndsPara		{ get; set; }
		public bool				NoActivateMoveMouse		{ get; set; }
		public CaretType		CaretType				{ get; set; }
		public bool				ShowBookmarkArea		{ get; set; }
		public bool				ShowChangeArea			{ get; set; }
		public bool				ShowVScroll				{ get; set; }
		public bool				ShowHScroll				{ get; set; }
		public bool				ShowRuler				{ get; set; }
		public int				RulerHeight				{ get; set; }
		public int				RulerBottomSpace		{ get; set; }
		public int				RptScrollLineNum		{ get; set; }
		public bool				RptScroll_Smooth		{ get; set; }
		public ActMouseWheel	PageScrollAct			{ get; set; }
		public ActMouseWheel	HorzScrollAct			{ get; set; }
		public bool				UseDrawCache			{ get; set; }
		public string			FontName				{ get; set; }
		public int				FontSize				{ get; set; }
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public SettingEditCommon()
		{
			FreeCursor			= false;
			StopsBothEndsWord	= true;
			StopsBothEndsPara	= false;
			NoActivateMoveMouse	= false;
			CaretType			= CaretType.Windows;
			ShowBookmarkArea	= true;
			ShowChangeArea		= true;
			ShowVScroll			= true;
			ShowHScroll			= false;
			ShowRuler			= false;
			RulerHeight			= 10;
			RulerBottomSpace	= 10;
			RptScrollLineNum	= 1;
			RptScroll_Smooth	= false;
			PageScrollAct		= ActMouseWheel.MW_NONE;
			HorzScrollAct		= ActMouseWheel.MW_SHIFTKEY;
			UseDrawCache		= false;
			FontName			= "ＭＳ ゴシック";
			FontSize			= 10;
		}


	}
}
