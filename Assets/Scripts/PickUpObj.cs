using System;
using UnityEngine;
using UnityEngine.VFX;

public class PickUpObj : MonoBehaviour, IDataPersistance
{

    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    //public int id;
    public string objName;
    public bool onHand;
    public SpriteRenderer visual;
    //add texture
    //add scene, position, and target scene/ position?
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void LoadData(GameData data)
    {
        data.ObjectState.TryGetValue(id, out onHand);
        if (onHand)
        {
            visual.gameObject.SetActive(false);
        }
    }
    public void SaveData(ref GameData data)
    {
        if (data.ObjectState.ContainsKey(id))
        {
            data.ObjectState.Remove(id);
        }
        data.ObjectState.Add(id, onHand);
    }
}
