using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class test1Menu : MonoBehaviour, IDataPersistance
{
    public bool onHand;
    public TMP_Text tex;
    private void Start()
    {
        //onHand = false;
        DataPersistanceManager.instance.LoadGame();
        ChangeObjTxt(onHand);
    }

    public void LoadData(GameData data)
    {
        this.onHand = data.onHand;
    }

    public void SaveData(ref GameData data)
    {
        data.onHand = this.onHand;
    }

    public void OnPickUpClicked()
    {
        Debug.Log("pick up button pressed");
        onHand = true;
        ChangeObjTxt(onHand);

    }
    public void OnDropClicked()
    {
        Debug.Log("droped button pressed");
        onHand = false;
        ChangeObjTxt(onHand);
    }
    public void OnChangeClicked()
    {
        Debug.Log("change scene button pressed");
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SampleScene");
    }

    public void OnSaveGameClicked()
    {
        Debug.Log("save game button");

        DataPersistanceManager.instance.SaveGame();
    }

    public void ChangeObjTxt(bool state)
    {
        if (onHand)
        {
            tex.text = "Object state: Picked up";
        }
        else
        {
            tex.text = "Object state: dropped";
        }
    }
}
