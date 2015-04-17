using System;
using System.Collections.Generic;

namespace MatIDE.Models
{
	/// <summary>
	/// Description of MRUList.
	/// </summary>
	public class MRUList
	{
		#region properties
		private List<MRUEntry>	_entries = null;
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public MRUList()
		{
		}
		
		/// <summary>
		/// 
		/// </summary>
		public List<MRUEntry> Entries
		{
			get {
				if ( _entries == null )
					_entries = new List<MRUEntry>();
				return _entries;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entry"></param>
		/// <returns></returns>
		internal bool addEntry( MRUEntry entry )
		{
			if ( entry == null )
				return false;
			Entries.Add( new MRUEntry(entry) );
			return true;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		internal void removeMru( string filePath )
		{
			if ( _entries == null || string.IsNullOrEmpty(filePath) )
				return;
			Entries.RemoveAll( item => item.FilePath == filePath );
		}
	}
}
