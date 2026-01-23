using UnityEngine;
using UnityEngine.InputSystem;

public class PopupImageController : MonoBehaviour
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

        if (Mouse.current.leftButton.wasPressedThisFrame) //esto desactiva la imagen clickando fuera
        {
            popupImage.SetActive(false);
            isOpen = false;
        }

        if (isOpen) popupImage.SetActive(true);
        else return;
    }
}
