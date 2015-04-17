using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using MatIDE.Models;

namespace MatIDE.ViewModels.Dock
{
	public class ProjectExplorerVM : ToolVM
	{
		public ProjectExplorerVM() : base("ProjectExplorer", "TPaneRight")
		{
		}

		public void Initialize()
		{
		}
	}
}
