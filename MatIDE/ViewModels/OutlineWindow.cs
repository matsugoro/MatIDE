using MatIDE.ViewModels.Dock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.ViewModels
{
	public class OutlineWindowVM : ToolViewModel
	{
		public OutlineWindowVM() : base("Outline", "TPaneRight")
		{
			ContentId = "OutlineWindow";
		}
	}
}
