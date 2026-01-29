using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPickups : MonoBehaviour, IDataPersistance
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string objectName;
    public bool OnMap;
    public Sprite ObjImg;
    public SpriteRenderer rend;

    public GameObject inventory;

    public GameObject PopUpText;
    bool playerInside;
    bool popUP;
    void Start()
    {
        PopUpText.SetActive(false);
        popUP = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInside) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    public void Interact()
    {
        Debug.Log("Picked up object");
        OnMap = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        //drop all other objects

        //put iteam into inventory
        inventory.GetComponent<IventoryScript>().Obj = objectName;
    }

    public void LoadData(GameData data)
    {
        data.ObjectPickUpsState.TryGetValue(objectName, out OnMap);
        if (OnMap)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ObjImg;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
    public void SaveData(ref GameData data)
    {
        if (inventory.GetComponent<IventoryScript>().Obj != this.objectName)//no esta al inventary onMap = true
        {
            OnMap = true;
        }

        if (data.ObjectPickUpsState.ContainsKey(objectName))
        {
            data.ObjectPickUpsState.Remove(objectName);
        }
        data.ObjectPickUpsState.Add(objectName, OnMap);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || OnMap == false) return;
        PopUpText.SetActive(popUP);

        Debug.Log("Entered");
        playerInside = true;
        popUP = true;
        PopUpText.SetActive(popUP);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;


        playerInside = false;
        popUP = false;
        PopUpText.SetActive(popUP);
    }

}
