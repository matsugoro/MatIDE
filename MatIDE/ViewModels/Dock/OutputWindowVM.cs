using MatIDE.ViewModels.Dock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.ViewModels
{
	public class OutputWindowVM : ToolVM
	{
		public OutputWindowVM() : base("Output", "TPaneBottom")
		{
			ContentId = "OutputWindow";
		}
	}
}
