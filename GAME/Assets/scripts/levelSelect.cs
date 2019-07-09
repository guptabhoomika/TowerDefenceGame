using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class levelSelect : MonoBehaviour
{

    public fader screenFader;
    public Button[] levelButton;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for (int i = 0; i < levelButton.Length; i++)
        {
            if(i+1 > levelReached)
            {
                levelButton[i].interactable = false;
            }
          
        }
    }
    public void selectLevel(string level)
    {
        screenFader.fadeTo(level);
    }
}
