using System;

namespace BibManFunctionality
{
	public static class BibUsable
	{
		// Funckja konwertująca format znaku nastepnej linii w pliku wyjściowym
		// nie jestem pewien jej przydatności, poprawności ani bezpieczeństwa użytkowania.
		public static string ConvertHtmlOsTextFormat(string text,OS targetOS)
		{
			bool error = false;
			string toReturn = "";
			OS currentOS = targetOS;
			try{
				switch(System.Environment.OSVersion.Platform)
				{
				case (PlatformID.Unix) : {
						currentOS = OS.Unix;
						break;}
				case (PlatformID.MacOSX) : {
						currentOS = OS.MacOSX;
						break;}
				default : {
						currentOS = OS.Windows;
						break;
					}
				}
			}
			catch{
				error = true;
			}
			if (!error) {
				if (targetOS == currentOS)
					toReturn = text;
				else {
					if (currentOS == OS.Unix && targetOS == OS.Windows) {
						toReturn = text.Replace ("\n", "\n\r");
					}
					if (currentOS == OS.Unix && targetOS == OS.MacOSX) {
						toReturn = text.Replace ("\n", "\r");
					}
					if (currentOS == OS.Windows && targetOS == OS.Unix) {
						toReturn = text.Replace ("\r", "");
					}
					if (currentOS == OS.Windows && targetOS == OS.MacOSX) {
						toReturn = text.Replace ("\n", "");
					}
					if (currentOS == OS.MacOSX && targetOS == OS.Unix) {
						toReturn = text.Replace ("\r", "\n");
					}
					if (currentOS == OS.MacOSX && targetOS == OS.Windows) {
						toReturn = text.Replace ("\r", "\n\r");
					}
					if (targetOS == OS.MacOSX || currentOS == OS.MacOSX) {
						toReturn = text +
							"<!--Unfortunelly, MacOS text format isn't completly supported yet. -->" +
							"<!--Program will try change NextLine symbols for MacOSX version -->" +
							"<!--and use unicode format from OS when it's runnung. -->" +
							"<!--We don't give any guarantion that it will work well. -->";
					}
				}
			} else {
				toReturn = text + "\n<!-- It was unable to identify current OS, co TextConversion was'n possible-->";
			}
			return toReturn;
		}
	}
}

