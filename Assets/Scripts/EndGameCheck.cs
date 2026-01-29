using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndGameCheck : MonoBehaviour, IDataPersistance
{
    bool gameOver = false;
    public Sprite endScreen;
    public Image inspectableMirror;
    public void LoadData(GameData data)
    {
        if (data.leaveObjectsState.Count == 5)
        {
            
        
                if (data.leaveObjectsState.Values.All(v => v))
                {
                    gameOver = true;
                }
            
        }
        
    }

    void Update()
    {
       
        if (gameOver)
        {
            inspectableMirror.GetComponent<Image>().sprite = endScreen;
        }
        gameOver = false;
    }

    public void SaveData(ref GameData data)
    {
        
    }
}
