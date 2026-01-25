using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]

public class GameData
{
    
    public Vector3 playerPosition;
    public int scene;
    public SerializableDisctionary<string, bool> objectsState;
    public GameData()
    {
        playerPosition = Vector3.zero;
        objectsState = new SerializableDisctionary<string, bool>();
    }
}
