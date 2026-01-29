using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DoorScript : MonoBehaviour
{
    public GameObject PopUpText;
    //public GameObject parent;

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
        //Debug.Log("Interacted with object");
        UnityEngine.SceneManagement.SceneManager.LoadScene("EscenaBase");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Entered");
        playerInside = true;
        popUP = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = false;
        popUP = false;
    }
}
