using MatIDE.ViewModels.Dock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.ViewModels.Dock
{
	public class FindResultVM : ToolVM
	{
		public FindResultVM() : base("FindResult", "TPaneBottom")
		{
			ContentId = "FindResultWindow";
		}
	}
}
