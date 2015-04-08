using System.Windows;

namespace MatIDE
{
	//=========================================================================
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	//=========================================================================
	public partial class MainWindow : Window
	{
		//=====================================================================
		/// <summary>Constructor</summary>
		//=====================================================================
		public MainWindow()
		{
			try {
				InitializeComponent();
			}
			catch ( System.Exception ex ){
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}
	}
}
