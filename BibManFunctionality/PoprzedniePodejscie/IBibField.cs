using System;

namespace BibManFunctionality
{
	public interface IBibField
	{
		string Name{ get; set; }
		string[] GetValues ();
		/// <summary>
		/// Returns all values in on string.
		/// In common case one field has only one value.
		/// </summary>
		/// <returns>The value.</returns>
		string GetValue();
		void ClearValues();
		bool AddValue(string value);
		bool RemoveValue(int valueNumber);
		bool AllowMultipleValues{get; }
	}
}

