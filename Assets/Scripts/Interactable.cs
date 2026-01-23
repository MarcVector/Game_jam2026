using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public GameObject PopUpText;

    bool playerInside;
    bool popUP;

    void Start()
    {
        PopUpText.SetActive(false);
        popUP = false;
    }

    void Update()
    {
        PopUpText.SetActive(popUP);

        if (!playerInside) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    void Interact()
    {
        Debug.Log("Interacted with object");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Debug.Log("Entered");
        playerInside = true;
        popUP=true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = false;
        PopUpText.SetActive(false);
    }
}
