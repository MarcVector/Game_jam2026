using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";
    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {

    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create directiory path in case it doesn't already exist
            Directory.CreateDirectory(Path.GetDirectoryName());
        }
        catch(Exception e)
        {
            Debug.LogError("Error ocurred trying to save data to file: " + fullPath + "\n" + e);
        }
    }
}
