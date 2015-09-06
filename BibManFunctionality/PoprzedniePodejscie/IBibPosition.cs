using System;

namespace BibManFunctionality
{
	public interface IBibPosition
	{
		string PositionType{ get; set; }
		string Name{ get; set; }
		string SourceFilePath{ get; }
		IBibField[] GetFields ();
		void AddField (string name);
		void AddField (string name, string[] values);
		void AddField (IBibField field);
		void RemoveField (int propertyNumber);

		// funkcje do późniejszej implementacji

		// bool Export{ get; set; }
		// bool Ingrone { get; set; }
		// bool IsBibliographicPosition{ get; set; }
		// string GetAsText();
	}
}

