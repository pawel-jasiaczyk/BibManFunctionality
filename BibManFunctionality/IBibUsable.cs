using System;
using System.IO;
using System.Collections.Generic;

namespace BibManFunctionality
{
    // interfejsy ogólnowarstwowe
    public interface IBibOptionSwitchable
    {
        string[] OptionsName { get; }
        bool Mark { get; set; }
        bool GetOptionState(string optionName);
        bool GetOptionState(int optionNumber);
        bool SetOptionState(string optionName, bool state);
        bool SetOptionState(int optionNumber, bool state);
    }

    public interface IBibSelectable
    {
        bool Selected { get; set; }
    }

    // interfejsy najwyższej warstwy

    public interface IBibUsable
    {
        string Name { get; }
        IBibPositionUsable[] GetPositions();
        event EventHandler DataBaseChanged;
    }

    public interface IBibFileOperable
    {
        IBibDataFile[] Files { get; }
    }

    public interface IBibReadable : IBibUsable, IBibFileOperable
    {
        IBibDataFile OpenFile(string path);
        IBibDataFile AddFile(string path);
        void RemoveFile(string path);
        void ProceedOpenedFiles();
        void ClearBase();
    }

    public interface IBibWriteble : IBibUsable, IBibFileOperable
    {
        bool IsTextFile { get; }
        bool IsBinaryFile { get; }
        string GetFileText();
        byte[] GetFileBytes();
        string GetNativeFormatFileExtension();
        string GetFileName();
    }

    public interface IBibImportable : IBibUsable
    {
        void ImportData(IBibUsable data);
    }

    //interfejsy wartstwy pozycji
    
    public interface IBibPositionUsable
    {
        string Name { get; }
        string PositionType { get; }
        IBibUsable Parent { get; }
        IBibFieldUsable[] GetFields();
    }

    public interface IBibPositionEditable : IBibPositionUsable
    {
        string Name { get; set; }
        string PositionType { get; set; }
        IBibUsable Parent { get; set; }
        bool AddField(string name);
        bool AddField(string name, string value);
        bool AddField(string name, string[] values);
        bool AddField(IBibFieldUsable field);
        bool RemoveField(int fieldNumber);
        void ClearFields();
    }

    // interfejsy wartswy pól

    public interface IBibFieldUsable
    {
        string Name { get; }
        IBibPositionUsable Parent { get; }
        bool AllowMultipleValues { get; }
        string GetValue();
        string[] GetValues();
    }

    public interface IBibFieldEditable : IBibFieldUsable
    {
        string Name { get; set; }
        IBibPositionUsable Parent { get; set; }
        void SetValue(string value);
        void AddValue(string value);
        void RemoveValue(int valueNumber);
        void ClearValue();
    }
   
    // intertfejsy nie związane z warstwami

    //// TODO dodać funkcje podawania kodowania oraz binarnej postaci danych byte[].
    public interface IBibDataFile
    {
        string Path { get; }
        string FileName { get; }
        string FullName { get; }
    }

    public interface IBibTextFile : IBibDataFile
    {
        string Text { get; }
    }

    public interface IBibTranslate
    {
        string Translate(string input);
    }
}

