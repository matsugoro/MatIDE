using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.Models.Shell
{
	public enum ShellTypes
	{
		MyComputer,
		NetworkRoot,
		LogicalDrive,
		SpecialFolder,
		Directory,
		File
	}

	public class ShellObject : ObservableCollection<ShellObject>
	{
	}


		public class SettingNode : ObservableCollection<SettingNode>
		{
			/// <summary>
			/// 設定項目名
			/// </summary>
			public string		Name			{ get; set; }

			/// <summary>
			/// 
			/// </summary>
			public string		NameOfViewModel	{ get; set; }

			/// <summary>
			/// 設定項目下位項目
			/// </summary>
			public SettingNode	Children		{ get; set; }

			/// <summary>
			/// 
			/// </summary>
			public SettingNode()
			{
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="name"></param>
			public SettingNode( string name, string vm )
			{
				this.Name = name;
				this.NameOfViewModel = vm;
			}
		}


}
