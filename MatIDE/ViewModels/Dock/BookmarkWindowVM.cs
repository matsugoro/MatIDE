using MatIDE.ViewModels.Dock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.ViewModels.Dock
{
	public class BookmarkWindowVM : ToolVM
	{
		public BookmarkWindowVM() : base("Bookmark", "TPaneBottom")
		{
			ContentId = "BookmarkWindow";
		}
	}
}
