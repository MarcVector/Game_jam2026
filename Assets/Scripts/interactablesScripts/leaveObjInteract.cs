using System.ComponentModel;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class leaveObjInteract : MonoBehaviour, IDataPersistance
{
    public string nameId;
    public string ObjectName;
    public bool completed;

    public Sprite uncomplete;
    public Sprite complete;
    public SpriteRenderer rend;

    public GameObject inventory;

    public GameObject PopUpText;
    //public GameObject parent;

    bool playerInside;
    bool popUP;
    public void LoadData(GameData data)
    {
        data.leaveObjectsState.TryGetValue(nameId, out completed);
        if (completed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = complete;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = uncomplete;
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.leaveObjectsState.ContainsKey(nameId))
        {
            data.leaveObjectsState.Remove(nameId);
        }
        data.leaveObjectsState.Add(nameId, completed);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PopUpText.SetActive(false);
        popUP = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInside) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && inventory.GetComponent<IventoryScript>().Obj == ObjectName)
        {
            Interact();
            inventory.GetComponent<IventoryScript>().Obj = "";
            inventory.GetComponent<IventoryScript>().RefreshInventory();
        }
    }

    public void Interact()
    {
        Debug.Log("Interacted with object");
        completed = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = complete;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
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
