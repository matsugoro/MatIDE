using System;
using Livet;
using MatIDE.ViewModels.Explorer;
using MatIDE.Docking;
using MatIDE.ViewModels.Dock;

namespace MatIDE.ViewModels
{
	public class LocalExplorerVM : ToolViewModel
	{
		ExplorerNodeVMCollection<ExplorerNodeVM>	_rootItems;

		public LocalExplorerVM() : base("LocalExplorer")
		{
		}

		public ExplorerNodeVMCollection<ExplorerNodeVM> RootItems
		{
			get {
				if ( _rootItems==null ){
					_rootItems = new ExplorerNodeVMCollection<ExplorerNodeVM>();
					_rootItems.Add(new ExplorerSFNodesVM(MatIDE.Native.Win32Shell.FOLDERID_Links));
					_rootItems.Add(new ExplorerPCNodeVM() );
				}
				return _rootItems;
			}
		}


	}
}
