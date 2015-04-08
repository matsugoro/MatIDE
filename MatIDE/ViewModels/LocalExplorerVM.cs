using System;
using Livet;
using MatIDE.ViewModels.Explorer;

namespace MatIDE.ViewModels
{
	public class LocalExplorerVM : ViewModel
	{
		ExplorerNodeVMCollection<ExplorerNodeVM>	_rootItems;

		public LocalExplorerVM()
		{
			
		}

		public void Initialize()
		{
		}

		public ExplorerNodeVMCollection<ExplorerNodeVM> RootItems
		{
			get {
				if ( _rootItems==null ){
					_rootItems = new ExplorerNodeVMCollection<ExplorerNodeVM>();
					_rootItems.Add(new ExplorerSFNodesVM(MatIDE.Native.Win32Shell.FOLDERID_Links));
					_rootItems.Add(new ExplorerPCNodeVM() );
//					_rootItems.Add(new ExplorerNodeVM("Network", Environment.GetFolderPath(Environment.SpecialFolder.NetworkShortcuts)) );
				}
				return _rootItems;
			}
		}


	}
}
