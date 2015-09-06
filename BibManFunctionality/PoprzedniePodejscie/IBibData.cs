using System;
using System.IO;

namespace BibManFunctionality
{
	public interface IBibData
	{
		/// <summary>
		/// Gets or sets the name of the data base.
		/// </summary>
		/// <value>The name of the data base.</value>
		string DataBaseName{ get; set;}
		/// <summary>
		/// Gets the full paths to source files.
		/// </summary>
		/// <value>The full path to source file.</value>
		string[] FullPath{get; }

		void OpenFile (string path);
		void AddFile (string path);
		/// <summary>
		/// Removes all positions from specifield file.
		/// </summary>
		/// <param name="path">Full path to file.</param>
		void RemoveFile (string path);
		/// <summary>
		/// Clears the data base.
		/// </summary>
		/// <description>Remove all bibliographic and additional positions from database object</description>
		void ClearBase();

		/// <summary>
		/// Gets all bibliographic the positions in data base.
		/// </summary>
		/// <returns>The table of positions.</returns>
		IBibPosition[] GetPositions();
		/// <summary>
		/// Adds new clear position with specified name.
		/// </summary>
		/// <returns><c>true</c>, if position was added, <c>false</c> otherwise.</returns>
		/// <param name="name">New position name.</param>
		bool AddPosition (string name);
		/// <summary>
		/// Adds the position.
		/// </summary>
		/// <returns><c>true</c>, if position was added, <c>false</c> otherwise.</returns>
		/// <param name="position">Position to add.</param>
		bool AddPosition (IBibPosition position);
		/// <summary>
		/// Removes the position with specified number.
		/// </summary>
		/// <param name="positionNumber">Number in GetPositions() result, which will be remove.</param>
		void RemovePosition (int positionNumber);

		// funkcje do implementacji w przyszłości

		// Stream GetNativeFormatStream();
		// string GetNativeFormatFileExtension();
	}
}

