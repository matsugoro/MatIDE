using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.Models.AppSetting
{
	[Serializable]
	public class SettingTab : NotificationObject
	{
		#region ===== PROPERTIES ======
		public bool	ShowCloseButton		{ get; set; }
		public bool	ShowIcon			{ get; set; }
		public bool	ShowDocMenu			{ get; set; }
		public bool	SortDocList			{ get; set; }
		public bool	AlwaysFloatingTab	{ get; set; }
		public bool	InsertRightNewTab	{ get; set; }
		public bool	TabFixedWidth		{ get; set; }
		public bool	FixedTabInOtherLine	{ get; set; }
		public bool	ShowPinOnNotFixed	{ get; set; }
		public bool	RetainPinStatus		{ get; set; }
		public bool	ConfirmMultiClose	{ get; set; }
		#endregion

		public SettingTab()
		{
			ShowCloseButton		= true;
			ShowIcon			= true;
			ShowDocMenu			= true;
			SortDocList			= false;
			AlwaysFloatingTab	= false;
			InsertRightNewTab	= true;
			TabFixedWidth		= true;
			FixedTabInOtherLine	= false;
			ShowPinOnNotFixed	= false;
			RetainPinStatus		= false;
			ConfirmMultiClose	= true;
		}

	}
}
