using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using MatIDE.Models;
using System.Windows;

namespace MatIDE.ViewModels
{
	public class SettingTabVM : SettingVMBase
	{
		public void Initialize()
		{
		}

		private Models.AppSetting.SettingTab Tab
		{
			get {
				return ((App)Application.Current).AppSet.Tab;
			}
		}

		/// <summary>
		/// 各タブにクローズボタンを表示
		/// </summary>
		public bool ShowCloseButton
		{
			get {
				return Tab.ShowCloseButton;
			}
			set {
				if ( Tab.ShowCloseButton != value ) {
					Tab.ShowCloseButton = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 各タブにアイコンを表示
		/// </summary>
		public bool ShowIcon
		{
			get {
				return Tab.ShowIcon;
			}
			set {
				if ( Tab.ShowIcon != value ){
					Tab.ShowIcon = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// タブ領域右側にドキュメントメニューを表示
		/// </summary>
		public bool ShowDocMenu
		{
			get {
				return Tab.ShowDocMenu;
			}
			set {
				if ( Tab.ShowDocMenu != value ) {
					Tab.ShowDocMenu = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// ドキュメント一覧を名前でソート
		/// </summary>
		public bool SortDocList
		{
			get {
				return Tab.SortDocList;
			}
			set {
				if ( Tab.SortDocList != value ){
					Tab.SortDocList = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// フローティングタブウェルを常にメインウィンドウの上部に表示する
		/// </summary>
		public bool AlwaysFloatingTab
		{
			get {
				return Tab.AlwaysFloatingTab;
			}
			set {
				if ( Tab.AlwaysFloatingTab != value ) {
					Tab.AlwaysFloatingTab = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 既存のタブの右側に常に新しいタブを表示
		/// </summary>
		public bool InsertRightNewTab
		{
			get {
				return Tab.InsertRightNewTab;
			}
			set {
				if ( Tab.InsertRightNewTab != value ) {
					Tab.InsertRightNewTab = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// タブを等幅で表示
		/// </summary>
		public bool TabFixedWidth
		{
			get {
				return Tab.TabFixedWidth;
			}
			set {
				if ( Tab.TabFixedWidth != value ){
					Tab.TabFixedWidth = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 固定されたタブを別行に表示
		/// </summary>
		public bool FixedTabInOtherLine
		{
			get {
				return Tab.FixedTabInOtherLine;
			}
			set {
				if ( Tab.FixedTabInOtherLine != value ){
					Tab.FixedTabInOtherLine = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 固定されていないタブにピンボタンを表示
		/// </summary>
		public bool ShowPinOnNotFixed
		{
			get {
				return Tab.ShowPinOnNotFixed;
			}
			set {
				if ( Tab.ShowPinOnNotFixed != value ){
					Tab.ShowPinOnNotFixed = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// ドキュメントがウェルから削除されたときにピンステータスを維持する
		/// </summary>
		public bool RetainPinStatus
		{
			get {
				return Tab.RetainPinStatus;
			}
			set {
				if ( Tab.RetainPinStatus != value ) {
					Tab.RetainPinStatus = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 複数のドキュメントを閉じるときに確認
		/// </summary>
		public bool ConfirmMultiClose
		{
			get {
				return Tab.ConfirmMultiClose;
			}
			set {
				if ( Tab.ConfirmMultiClose != value ) {
					Tab.ConfirmMultiClose = value;
					RaisePropertyChanged();
				}
			}
		}


	}
}
