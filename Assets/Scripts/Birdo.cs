using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Birdo : MonoBehaviour
{
    //public GameObject parent;

    public void ChangeScene(string sceneName)
    {
        //Debug.Log("Interacted with object");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
