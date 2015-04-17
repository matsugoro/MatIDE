using System;
using Livet;
using MatIDE.Models;

namespace MatIDE.ViewModels
{
	/// <summary>
	/// MRUEntry View Model
	/// </summary>
	public class MRUEntryVM : ViewModel
	{
		#region Fields
		private const int MaxDisplen = 32;
		private readonly MRUEntry _entry;
		private bool _dummyFlag;
		#endregion
		
		/// <summary>
		/// constructor
		/// </summary>
		public MRUEntryVM()
		{
			_entry = new MRUEntry() { FilePath = "", IsPinned = false };
			_dummyFlag = true;
		}
		
		/// <summary>
		/// constructor with Model
		/// </summary>
		/// <param name="entry">MruEntry model</param>
		public MRUEntryVM( MRUEntry entry )
		{
			_entry = new MRUEntry(entry);
			_dummyFlag = false;
		}
		
		public bool IsEnabled
		{
			get {
				return ! DummyEntry;
			}
		}
		
		public bool DummyEntry
		{
			get {
				return _dummyFlag;
			}
			set {
				if ( _dummyFlag != value ){
					_dummyFlag = value;
					RaisePropertyChanged("IsEnabled");
					RaisePropertyChanged("PathFileName");
					RaisePropertyChanged("DisplayName");
				}
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string PathFileName
		{
			get {
				return _entry.FilePath;
			}
			set {
				if ( _entry.FilePath != value ){
					_entry.FilePath = value;
					RaisePropertyChanged();
					RaisePropertyChanged("DisplayName");
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsPinned
		{
			get {
				return _entry.IsPinned;
			}
			set {
				if ( _entry.IsPinned != value ){
					_entry.IsPinned = value;
					RaisePropertyChanged();
				}
			}
		}
		
		/// <summary>
		/// DisplayName
		/// </summary>
		public string DisplayName
		{
			get {
				if ( DummyEntry ){
					return "No Entry";
				}
				else {
					if ( _entry == null || string.IsNullOrEmpty(PathFileName) )
						return string.Empty;
					return PathFileName.Length > MaxDisplen ?
						PathFileName.Substring(0,3) + "... " + PathFileName.Substring(PathFileName.Length - MaxDisplen) :
						PathFileName;				
				}
			}
		}
	}
}
