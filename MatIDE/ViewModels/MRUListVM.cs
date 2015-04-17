using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using Livet;

namespace MatIDE.ViewModels
{
	/// <summary>
	/// Description of MRUListVM.
	/// </summary>
	public class MRUListVM : ViewModel
	{
		#region Fields
		private ObservableCollection<MRUEntryVM> _listEntry;
		private readonly int maxMruEntryCount;
		#endregion
		
		public MRUListVM()
		{
			maxMruEntryCount = ((App)Application.Current).AppSet.General.MaxMruFileNum;
			_listEntry = new ObservableCollection<MRUEntryVM>();
			_listEntry.Add( new MRUEntryVM() );
		}
		
		public int MaxMruEntryCount
		{
			get {
				return maxMruEntryCount;
			}
		}
		
		public ObservableCollection<MRUEntryVM> ListOfMruEntries
		{
			get {
				return _listEntry;
			}
			set {
				if ( _listEntry != value ){
					_listEntry = value;
					RaisePropertyChanged();
				}
			}
		}
		
		public void AddNewEntryIntoMRU( string filePath )
		{
			if ( _listEntry != null && _listEntry.SingleOrDefault( mru => mru.PathFileName == filePath) != null )
				return;

			if ( _listEntry == null )
				_listEntry = new ObservableCollection<MRUEntryVM>();
			
			if ( _listEntry.Count == 1 && _listEntry[0].DummyEntry ){
				_listEntry.RemoveAt(0);
			}

			if ( MaxMruEntryCount <= _listEntry.Count )
				_listEntry.RemoveAt( _listEntry.Count-1 );
			_listEntry.Add( new MRUEntryVM() { PathFileName=filePath, IsPinned=false, DummyEntry=false });
		}
	}
}
