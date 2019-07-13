using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public fader screenfader;
    public string menuLoad;
    public string nextLevel = "level2";
    public int levelNo = 2;


    public void Continue()
    {
        screenfader.fadeTo(nextLevel);


        PlayerPrefs.SetInt("levelReached", levelNo);

        Debug.Log("Won!");
    }

    public void MenuLoad()
    {
        screenfader.fadeTo(menuLoad);
    }
}
