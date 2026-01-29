using UnityEngine;
using UnityEngine.UI;

public class IventoryScript : MonoBehaviour, IDataPersistance
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string Obj;
    public Image back;
    public Image ObjectImg;
    //collection of images
    public Sprite tulips;
    public Sprite sunflowers;
    public Sprite trophy;
    public Sprite scissors;
    public Sprite violin;
    public Sprite pills;

    public Sprite UIMask;

    public void RefreshInventory()
    {
        switch (Obj)
        {
            case "tulips":
                ObjectImg.sprite = tulips;
                break;
            case "sunflowers":
                ObjectImg.sprite = sunflowers;
                break;
            case "trophy":
                ObjectImg.sprite = trophy;
                break;
            case "scissors":
                ObjectImg.sprite = scissors;
                break;
            case "violin":
                ObjectImg.sprite = violin;
                break;
            case "pills":
                ObjectImg.sprite = pills;
                break;
            case "":
                ObjectImg.sprite = UIMask;
                break;
            default:
                Debug.Log("object is not in invetory data base or has an error");
                break;
        }

    }
    public void LoadData(GameData data)
    {
        Obj = data.inventory;
        RefreshInventory();
    }

    public void SaveData(ref GameData data)
    {
        data.inventory = Obj;
    }


}
