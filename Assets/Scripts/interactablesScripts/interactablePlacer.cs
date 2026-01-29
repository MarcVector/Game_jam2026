using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.VFX;

public class interactablePlacer : MonoBehaviour, IDataPersistance
{
    //[SerializeField] private string id;

    public string nameId;
    public string ObjectName;
    public bool completed;
    public Sprite uncomplete;
    public Sprite complete;
    public SpriteRenderer rend;


    public GameObject PopUpText;
    //public GameObject parent;

    bool playerInside;
    bool popUP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.GetComponent<Image>().sprite = uncomplete;
        PopUpText.SetActive(false);
        popUP = false;
    }

    void Update()
    {
        //PopUpText.SetActive(popUP);

        if (!playerInside) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    public void LoadData(GameData data)
    {
        data.InteractablePlacerState.TryGetValue(nameId, out completed);
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
        if (data.InteractablePlacerState.ContainsKey(nameId))
        {
            data.InteractablePlacerState.Remove(nameId);
        }
        data.InteractablePlacerState.Add(nameId, completed);
    }
    // Update is called once per frame
    

    public void UponCompletion()
    {
        completed = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = complete;
    }

    public void Interact()
    {
        Debug.Log("Interacted with object");
        UponCompletion();
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
