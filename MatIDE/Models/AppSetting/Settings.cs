using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;

namespace MatIDE.Models.AppSetting
{
	[Serializable]
	public class AppSettings : NotificationObject
	{
//		public static Settings Current	{ get; set; }

		public SettingGeneral		General		{ get; private set; }
		public SettingTab			Tab			{ get; private set; }
		public SettingEditCommon	EditCommon	{ get; private set; }

		public AppSettings()
		{
			General		= new SettingGeneral();
			Tab			= new SettingTab();
			EditCommon	= new SettingEditCommon();
		}

		#region Culture 変更通知プロパティ

		private string _Culture;

		/// <summary>
		/// カルチャを取得または設定します。
		/// </summary>
		public string Culture
		{
			get {
				return this._Culture;
			}
			set {
				if ( this._Culture != value ){
					this._Culture = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion
	
	
	}
}
