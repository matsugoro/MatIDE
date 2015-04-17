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
using MatIDE.Models.AppSetting;
using System.Windows;

namespace MatIDE.ViewModels
{
	public class SettingGeneralVM : SettingVMBase
	{
		/// <summary>
		/// 
		/// </summary>
		public void Initialize()
		{
		}

		/*
		/// <summary>
		/// アプリケーション外観
		/// </summary>
		public UInt32 VisualStyle
		{
			get {
				return _VisualStyle;
			}
			set {
				if ( this._VisualStyle != value ){
					this._VisualStyle = value;
					this.RaisePropertyChanged();
				}
			}
		}
		*/

		private Models.AppSetting.SettingGeneral General
		{
			get {
				return ((App)Application.Current).AppSet.General;
			}
		}

		/// <summary>
		/// リボンを使用する
		/// </summary>
		public bool UseRibbon {
			get {
				return General.UseRibbon;
			}
			set {
				if ( General.UseRibbon != value ){
					General.UseRibbon = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// ファンクションキー表示
		/// </summary>
		public bool ShowFunctionKeys {
			get {
				return General.ShowFunctionKeys;
			}
			set {
				if ( General.ShowFunctionKeys != value ) {
					General.ShowFunctionKeys = value;
					RaisePropertyChanged();
				}
			}
		}

		/*
		/// <summary>
		/// ファンクションキー表示位置
		/// </summary>
		public bool FunckeyPosUpper {
			get {
				return this._FunckeyPosUpper;
			}
			set {
				if ( this._FunckeyPosUpper != value ){
					this._FunckeyPosUpper = value;
					this.RaisePropertyChanged();
				}
			}
		}
		*/

		/// <summary>
		/// ステータスバーを表示する
		/// </summary>
		public bool ShowStatusBar
		{
			get {
				return General.ShowStatusBar;
			}
			set {
				if ( General.ShowStatusBar != value ){
					General.ShowStatusBar = value;
					RaisePropertyChanged();
				}
			}
		}

		private bool IsFlagSetting( StatusBarItem flag, StatusBarItem val )
		{
			return (flag & val) != 0;
		}

		private StatusBarItem SetFlag( bool bChecked, StatusBarItem flags, StatusBarItem val )
		{
			StatusBarItem	newFlag;

			if ( bChecked )
				newFlag = flags | val;
			else
				newFlag = flags & ~val;
			return newFlag;
		}

		public bool ShowCurrentRowCol
		{
			get {
				return IsFlagSetting( General.StatusBarFlags, StatusBarItem.CurrentRowCol);
			}
			set {
				if ( ShowCurrentRowCol != value ){
					General.StatusBarFlags = SetFlag( value, General.StatusBarFlags, StatusBarItem.CurrentRowCol );
					RaisePropertyChanged();
				}
			}
		}

		public bool ShowLinePos
		{
			get {
				return IsFlagSetting( General.StatusBarFlags, StatusBarItem.CurrentLinePos );
			}
			set {
				if ( ShowLinePos != value ){
					General.StatusBarFlags = SetFlag( value, General.StatusBarFlags, StatusBarItem.CurrentLinePos );
					RaisePropertyChanged();
				}
			}
		}

		public bool ShowCharLineSet
		{
			get {
				return IsFlagSetting( General.StatusBarFlags, StatusBarItem.CharLineSet );
			}
			set {
				if ( ShowCharLineSet != value ){
					General.StatusBarFlags = SetFlag( value, General.StatusBarFlags, StatusBarItem.CharLineSet );
					RaisePropertyChanged();
				}
			}
		}

		public bool ShowClock
		{
			get {
				return IsFlagSetting( General.StatusBarFlags, StatusBarItem.Clock );
			}
			set {
				if ( ShowClock != value ){
					General.StatusBarFlags = SetFlag( value, General.StatusBarFlags, StatusBarItem.Clock );
					RaisePropertyChanged();
				}
			}
		}

		public bool ShowCapsLock
		{
			get {
				return IsFlagSetting( General.StatusBarFlags, StatusBarItem.CapsLock );
			}
			set {
				if ( ShowCapsLock != value ){
					General.StatusBarFlags = SetFlag( value, General.StatusBarFlags, StatusBarItem.CapsLock );
					RaisePropertyChanged();
				}
			}
		}

		public bool ShowInsMode
		{
			get {
				return IsFlagSetting( General.StatusBarFlags, StatusBarItem.InsMode );
			}
			set {
				if ( ShowInsMode != value ){
					General.StatusBarFlags = SetFlag( value, General.StatusBarFlags, StatusBarItem.InsMode );
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// MRUに表示する最大ファイル数
		/// </summary>
		public Int32 MRUFileNum
		{
			get {
				return General.MaxMruFileNum;
			}
			set {
				if ( General.MaxMruFileNum != value ) {
					General.MaxMruFileNum = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// MRUに表示する最大プロジェクト数
		/// </summary>
		public Int32 MRUProjectNum
		{
			get {
				return General.MaxMruProjectNum;
			}
			set {
				if ( General.MaxMruProjectNum != value ) {
					General.MaxMruProjectNum = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 終了確認を表示する
		/// </summary>
		public bool ShowExitConfirm
		{
			get {
				return General.ShowExitConfirm;
			}
			set {
				if ( General.ShowExitConfirm != value ) {
					General.ShowExitConfirm = value;
					RaisePropertyChanged();
				}
			}
		}
	}
}
