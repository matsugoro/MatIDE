using System.Windows;
using MatIDE.ViewModels;

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
				MainWindowVM.Instance.InitCommandBindings(this);
			}
			catch ( System.Exception ex ){
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}
	}
}
