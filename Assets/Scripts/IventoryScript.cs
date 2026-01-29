using UnityEngine;

public class IventoryScript : MonoBehaviour, IDataPersistance
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string Obj;

    public void LoadData(GameData data)
    {
        Obj = data.inventory;
    }

    public void SaveData(ref GameData data)
    {
        data.inventory = Obj;
    }


}
