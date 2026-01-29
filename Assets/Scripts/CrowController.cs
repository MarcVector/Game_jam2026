using UnityEngine;
using UnityEngine.InputSystem;

public class CrowController : MonoBehaviour
{
    public GameObject popupImage;

    bool isOpen = false;

    public void OpenImage() //abrir la imagen con el botón
    {

        isOpen = true;

        Debug.Log("Image Open");
    }

    private void Start()
    {
        popupImage.SetActive(false);
    }
    void Update()
    {

        if (isOpen) popupImage.SetActive(true);
        else return;
    }
}
