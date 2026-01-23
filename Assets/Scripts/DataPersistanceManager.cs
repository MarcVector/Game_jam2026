using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NUnit.Framework;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;

    public static DataPersistanceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    
    public void LoadGame()
    {
        //load files and translate them
        //if there is no data to load create new data
        if (this.gameData == null)
        {
            Debug.Log("No data found. Initializing new data");
            NewGame();
        }
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
        Debug.Log("Loaded info x");
    }
    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
    Debug.Log("saved info x");

        //pass data to all scripts tp update
        //safe data to a file
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }

}
