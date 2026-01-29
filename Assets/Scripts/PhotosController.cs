using UnityEngine;
using UnityEngine.InputSystem;

public class PhotosController : MonoBehaviour
{
    public GameObject sunflower;
    public GameObject trophy;
    public GameObject suitcase;
    public GameObject pills;
    public GameObject violin;
    public GameObject oasis;
    public GameObject back;

    bool isOpen = false;

    public void OpenImage() //abrir la imagen con el botón
    {

        isOpen = true;

        Debug.Log("Image Open");
    }

    private void Start()
    {
        sunflower.SetActive(false);
        trophy.SetActive(false);
        suitcase.SetActive(false);
        pills.SetActive(false);
        violin.SetActive(false);
        oasis.SetActive(false);
        back.SetActive(false);
    }
    void Update()
    {

        if (isOpen) 
        { sunflower.SetActive(true);
            trophy.SetActive(true);
            suitcase.SetActive(true);
            pills.SetActive(true);
            violin.SetActive(true);
            oasis.SetActive(true);
            back.SetActive(true);
        
        }
        else return;
    }
}
