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
using System.Windows.Media.Imaging;

	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application
	{
		public AppSettings						AppSet			{ get; private set; }
		public Dictionary<Guid, BitmapSource>	FolderImage		{ get; private set; }

		protected override void OnStartup( StartupEventArgs e )
		{
			base.OnStartup( e );
			AppSet		= new AppSettings();
			FolderImage	= new Dictionary<Guid,BitmapSource>();
		}


	}
}
