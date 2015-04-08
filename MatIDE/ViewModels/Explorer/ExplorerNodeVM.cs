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

using System.Collections.ObjectModel;
using System.IO;
using System.Drawing;

using MatIDE.Models;
using MatIDE.Native;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Windows;

namespace MatIDE.ViewModels.Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class ExplorerNodeVM : ViewModel
	{
		private static Dictionary<string,BitmapSource>	_folderImages = new Dictionary<string,BitmapSource>();

		protected string									_key;
		protected string									_name;
		protected string									_fullPath;
		protected ExplorerNodeVMCollection<ExplorerNodeVM>	_children;

		public ExplorerNodeVM()
		{
		}

		public ExplorerNodeVM( string key, string name, string fullPath )
		{
			_key		= key;
			_name		= name;
			_fullPath	= fullPath;
		}

		public string Name
		{
			get {
				return _name;
			}
			set {
				if ( Equals( _name, value) )
					return;
				_name = value;
				RaisePropertyChanged();
			}
		}

		public string FullPath
		{
			get {
				return _fullPath;
			}
		}

		public BitmapSource Image
		{
			get {
				if ( !_folderImages.ContainsKey(_key) ){
					_folderImages[_key] = GetShellBitmap();
				}
				return _folderImages[_key];
			}
		}

		public ExplorerNodeVMCollection<ExplorerNodeVM> Children
		{
			get {
				if ( _children == null ){
					_children = new ExplorerNodeVMCollection<ExplorerNodeVM>();
					FillChildren();
				}
				return _children;
			}
		}

		protected virtual void FillChildren()
		{
			if ( string.IsNullOrEmpty(FullPath) )
				return;

			DirectoryInfo	di = new DirectoryInfo(FullPath);
			try {
				var dirs = di.GetDirectories().
									Where( p => (p.Attributes&FileAttributes.Hidden) == 0 ).
									Select( pp => new { pp.Name, pp.FullName });

				foreach ( var dir in dirs ){
					string	dispName, typeName;
					Win32Shell.GetFolderInfo( dir.FullName, out dispName, out typeName );
					Children.Add( new ExplorerNodeVM("NORMAL", dir.Name, dir.FullName));
				}
			}
			catch ( Exception ){
			}
		}

		protected virtual BitmapSource GetShellBitmap()
		{
			Win32Shell.SHFILEINFO	shInfo = new Win32Shell.SHFILEINFO();

			Win32Shell.SHGetFileInfo( FullPath, 0, ref shInfo, (uint)Marshal.SizeOf(shInfo), Win32Shell.SHGFI_ICON|Win32Shell.SHGFI_SMALLICON|Win32Shell.SHGFI_SYSICONINDEX );
			return Imaging.CreateBitmapSourceFromHIcon(shInfo.hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class ExplorerSFNodesVM : ExplorerNodeVM
	{
		private Guid	NodeGuid	{ get; set; }

		public ExplorerSFNodesVM( Guid guid ) : base()
		{
			string	dispName, fullPath;

			NodeGuid	= guid;
			Win32Shell.GetFolderInfo( NodeGuid, out dispName, out fullPath );
			_key		= "SF:" + dispName;
			_name		= dispName;
			_fullPath	= fullPath;
		}

		protected override BitmapSource GetShellBitmap()
		{
			IntPtr					pidRoot = IntPtr.Zero;
			Win32Shell.SHFILEINFO	shInfo = new Win32Shell.SHFILEINFO();
			BitmapSource			bmp;

			Win32Shell.SHGetKnownFolderIDList( NodeGuid, 0, IntPtr.Zero, out pidRoot );
			Win32Shell.SHGetFileInfo( pidRoot, 0, ref shInfo, (uint)Marshal.SizeOf(shInfo), Win32Shell.SHGFI_ICON|Win32Shell.SHGFI_SMALLICON|Win32Shell.SHGFI_PIDL );

			bmp = Imaging.CreateBitmapSourceFromHIcon(shInfo.hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
//			bmp.Save(@"c:\temp\pc.png");
			if ( pidRoot != IntPtr.Zero ){
				Win32Shell.IMalloc	malloc;
				Win32Shell.SHGetMalloc( out malloc );
				malloc.Free( pidRoot );
			}
			return bmp;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class ExplorerPCNodeVM : ExplorerSFNodesVM
	{
		public ExplorerPCNodeVM() : base(Win32Shell.FOLDERID_ComputerFolder)
		{
		}

		protected override void FillChildren()
		{
			Children.Add( new ExplorerSFNodesVM(Win32Shell.FOLDERID_Downloads));
			Children.Add( new ExplorerSFNodesVM(Win32Shell.FOLDERID_Desktop));
			Children.Add( new ExplorerSFNodesVM(Win32Shell.FOLDERID_Documents));
			Children.Add( new ExplorerSFNodesVM(Win32Shell.FOLDERID_Pictures));
			Children.Add( new ExplorerSFNodesVM(Win32Shell.FOLDERID_Videos));
			Children.Add( new ExplorerSFNodesVM(Win32Shell.FOLDERID_Music));

			var drives = DriveInfo.GetDrives().Select( d => new ExplorerLDNodeVM(d.RootDirectory.Name));
			foreach ( var drv in drives ){
				Children.Add(drv);
			}
		}
	}

	/// <summary>
	/// LogicalDrive
	/// </summary>
	public class ExplorerLDNodeVM : ExplorerNodeVM
	{
		public ExplorerLDNodeVM( string drvLetter ) : base()
		{
			string	dispName, typeName;

			Win32Shell.GetFolderInfo( drvLetter, out dispName, out typeName );
			_key		= "DRV:" + drvLetter;
			_name		= dispName;
			_fullPath	= drvLetter;
		}
	}

	public class ExplorerNodeVMCollection<T> : ObservableCollection<T>
		where T : ExplorerNodeVM
	{
		private ExplorerNodeVM	_parent;

		public ExplorerNodeVMCollection( ExplorerNodeVM parent )
		{
			_parent = parent;
		}

		public ExplorerNodeVMCollection()
			: this(null)
		{
		}

		protected override void OnCollectionChanged( System.Collections.Specialized.NotifyCollectionChangedEventArgs e )
		{
			base.OnCollectionChanged(e);
			/*
			if ( e.OldItems != null ){
				SetParents(e.OldItems.Cast<T>(), null);
			}
			if ( e.NewItems != null ){
				SetParents(e.NewItems.Cast<T>(), _parent);
			}
			*/
		}

		/*
		private static void SetParents( IEnumerable<T> items, ExplorerNodeVM parent )
		{
			foreach ( var item in items ){
				item.Parent = parent;
			}
		}
		*/
	}



}
