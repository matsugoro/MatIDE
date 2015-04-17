using System;
using Livet;
using MatIDE.ViewModels.Explorer;
using MatIDE.Docking;
using MatIDE.ViewModels.Dock;

namespace MatIDE.ViewModels
{
	public class ProjectExplorerVM : ToolViewModel
	{
//		ExplorerNodeVMCollection<ExplorerNodeVM>	_rootItems;

		public ProjectExplorerVM() : base("ProjectFileView", "TPaneRight")
		{
			ContentId = "ProjectExplorer";
		}

		/*
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
		*/

	}
}
