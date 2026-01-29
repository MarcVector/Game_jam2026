using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextBoxScript : MonoBehaviour
{

    public TMP_Text dialogue;
    public GameObject box;
    public GameObject speaker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogue.text = "";
        speaker.SetActive(false);
        box.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            dialogue.text = "";
            speaker.SetActive(false);
            box.SetActive(false);
        }
    }

    public void OpenTextBox(string lines)
    {
        dialogue.text = lines;
        speaker.SetActive(true);
        box.SetActive(true);
    }
}
