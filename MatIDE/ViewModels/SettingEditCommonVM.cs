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
	public class SettingEditCommonVM : SettingVMBase
	{
		public void Initialize()
		{
		}

		private Models.AppSetting.SettingEditCommon EditCommon
		{
			get {
				return ((App)Application.Current).AppSet.EditCommon;
			}
		}

		/// <summary>
		/// フリーカーソルモードか
		/// </summary>
		public bool FreeCursor
		{
			get {
				return EditCommon.FreeCursor;
			}
			set {
				if ( EditCommon.FreeCursor != value ){
					EditCommon.FreeCursor = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 単語単位で移動するときに、単語の両端で止まるか
		/// </summary>
		public bool StopsBothEndsWord
		{
			get {
				return EditCommon.StopsBothEndsWord;
			}
			set {
				if ( EditCommon.StopsBothEndsWord != value ){
					EditCommon.StopsBothEndsWord = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 段落単位で移動するときに、段落の両端で止まるか
		/// </summary>
		public bool StopsBothEndsPara
		{
			get {
				return EditCommon.StopsBothEndsPara;
			}
			set {
				if ( EditCommon.StopsBothEndsPara != value ){
					EditCommon.StopsBothEndsPara = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// マウスクリックにてアクティベートされた時はカーソル位置を移動しない
		/// </summary>
		public bool NoActivateMoveMouse
		{
			get {
				return EditCommon.NoActivateMoveMouse;
			}
			set {
				if ( EditCommon.NoActivateMoveMouse != value ){
					EditCommon.NoActivateMoveMouse = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// カーソルのタイプ
		/// </summary>
		public CaretType CaretType
		{
			get {
				return EditCommon.CaretType;
			}
			set {
				if ( EditCommon.CaretType != value ){
					EditCommon.CaretType = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// ブックマークエリアの表示
		/// </summary>
		public bool ShowBookmarkArea
		{
			get {
				return EditCommon.ShowBookmarkArea;
			}
			set {
				if ( EditCommon.ShowBookmarkArea != value ){
					EditCommon.ShowBookmarkArea = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 変更部分エリアの表示
		/// </summary>
		public bool ShowChangeArea
		{
			get {
				return EditCommon.ShowChangeArea;
			}
			set {
				if ( EditCommon.ShowChangeArea != value ){
					EditCommon.ShowChangeArea = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 垂直スクロールバーの表示
		/// </summary>
		public bool ShowVScroll
		{
			get {
				return EditCommon.ShowVScroll;
			}
			set {
				if ( EditCommon.ShowVScroll != value ){
					EditCommon.ShowVScroll = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 水平スクロールバーの表示
		/// </summary>
		public bool ShowHScroll
		{
			get {
				return EditCommon.ShowHScroll;
			}
			set {
				if ( EditCommon.ShowHScroll != value ){
					EditCommon.ShowHScroll = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// ルーラの表示
		/// </summary>
		public bool ShowRuler
		{
			get {
				return EditCommon.ShowRuler;
			}
			set {
				if ( EditCommon.ShowRuler != value ){
					EditCommon.ShowRuler = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// ルーラ高さ
		/// </summary>
		public int RulerHeight
		{
			get {
				return EditCommon.RulerHeight;
			}
			set {
				if ( EditCommon.RulerHeight != value ){
					EditCommon.RulerHeight = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// ルーラーとテキストの隙間 
		/// </summary>
		public int RulerBottomSpace
		{
			get {
				return EditCommon.RulerBottomSpace;
			}
			set {
				if ( EditCommon.RulerBottomSpace != value ){
					EditCommon.RulerBottomSpace = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// キーリピート時のスクロール行数
		/// </summary>
		public int RptScrollLineNum
		{
			get {
				return EditCommon.RptScrollLineNum;
			}
			set {
				if ( EditCommon.RptScrollLineNum != value ){
					EditCommon.RptScrollLineNum = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// キーリピート時のスクロールを滑らかにするか
		/// </summary>
		public bool RptScrollSmooth
		{
			get {
				return EditCommon.RptScroll_Smooth;
			}
			set {
				if ( EditCommon.RptScroll_Smooth != value ){
					EditCommon.RptScroll_Smooth = value;
					RaisePropertyChanged();
				}
			}
		}

		/*
		/// <summary>
		/// ページスクロールマウス設定
		/// </summary>
		public ActMouseWheel PageScrollAct
		{
			get {
				return _PageScrollAct;
			}
			set {
				if ( _PageScrollAct != value ){
					_PageScrollAct = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// 横スクロールマウス設定
		/// </summary>
		public ActMouseWheel HorzScrollAct
		{
			get {
				return _HorzScrollAct;
			}
			set {
				if ( _HorzScrollAct != value ){
					_HorzScrollAct = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// フォント名
		/// </summary>
		public string FontName
		{
			get {
				return _FontName;
			}
			set {
				if ( _FontName != value ){
					_FontName = value;
					RaisePropertyChanged();
				}
			}
		}

		/// <summary>
		/// フォントサイズ
		/// </summary>
		public int FontSize
		{
			get {
				return _FontSize;
			}
			set {
				if ( _FontSize != value ){
					_FontSize = value;
					RaisePropertyChanged();
				}
			}
		}
		*/
		/// <summary>
		/// 画面描画にキャッシュを使用する
		/// </summary>
		public bool UseDrawCache
		{
			get {
				return EditCommon.UseDrawCache;
			}
			set {
				if ( EditCommon.UseDrawCache != value ){
					EditCommon.UseDrawCache = value;
					RaisePropertyChanged();
				}
			}
		}
	}
}
