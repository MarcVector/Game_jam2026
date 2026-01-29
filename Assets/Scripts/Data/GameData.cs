using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]

public class GameData
{
    
    public Vector3 playerPosition;
    public int scene;
    public SerializableDisctionary<string, bool> InteractablePlacerState;
    public SerializableDisctionary<string, bool> ObjectState;
    public SerializableDisctionary<string, bool> ObjectPickUpsState;
    public SerializableDisctionary<string, bool> leaveObjectsState;
    public string inventory;
    public bool onHand;
    public GameData()
    {
        playerPosition = Vector3.zero;
        InteractablePlacerState = new SerializableDisctionary<string, bool>();
        ObjectState = new SerializableDisctionary<string, bool>();
        ObjectPickUpsState = new SerializableDisctionary<string, bool>();
        leaveObjectsState = new SerializableDisctionary<string, bool>();
        onHand = false;
        inventory = "";
    }
}
