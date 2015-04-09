using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MatIDE
{
	using MatIDE.Models.AppSetting;
	using System.IO;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using MatIDE.Native;
	using System.Runtime.InteropServices;
	using System.Windows.Interop;

	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application
	{
		public AppSettings						AppSet			{ get; private set; }
		public Dictionary<string, ImageSource>	FileImage		{ get; private set; }

		protected override void OnStartup( StartupEventArgs e )
		{
			base.OnStartup( e );
			Livet.DispatcherHelper.UIDispatcher = this.Dispatcher;
			AppSet		= new AppSettings();
			FileImage	= new Dictionary<string,ImageSource>();
		}

		public ImageSource GetImageFromExt( string fileName )
		{
			string	ext;

			if ( string.IsNullOrEmpty(fileName) )
				return null;
			ext = Path.GetExtension( fileName );
			if ( string.IsNullOrEmpty(ext) )
				return null;

			if ( !FileImage.ContainsKey( ext ) ){
				Win32Shell.SHFILEINFO	shInfo = new Win32Shell.SHFILEINFO();
				Win32Shell.SHGetFileInfo( fileName, 0, ref shInfo, (uint)Marshal.SizeOf(shInfo), Win32Shell.SHGFI_ICON|Win32Shell.SHGFI_SMALLICON|Win32Shell.SHGFI_SYSICONINDEX );
				FileImage[ext] = Imaging.CreateBitmapSourceFromHIcon(shInfo.hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
			}
			return FileImage[ext];
		}



	}
}
