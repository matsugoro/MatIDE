using System;

namespace MatIDE.Models
{
	/// <summary>
	/// Description of MRUEntry.
	/// </summary>
	public class MRUEntry
	{
		#region properties
		public string FilePath { get; set; }
		public bool IsPinned { get; set; }
		#endregion
		
		/// <summary>
		/// standard constructor
		/// </summary>
		public MRUEntry()
		{
		}
		
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="isPinned"></param>
		public MRUEntry(string filePath, bool isPinned)
		{
			this.FilePath = filePath;
			this.IsPinned = isPinned;
		}
		
		/// <summary>
		/// copy constructor
		/// </summary>
		/// <param name="entry"></param>
		public MRUEntry(MRUEntry entry)
		{
			if ( entry == null )
				return;
			this.FilePath = entry.FilePath;
			this.IsPinned = entry.IsPinned;
		}
		
	}
}
