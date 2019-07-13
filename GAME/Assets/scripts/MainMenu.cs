using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToload;
    public string loadAbout;
    public string loadControl;
    public fader sceneFader;
    public void Play()
    {
        sceneFader.fadeTo(levelToload);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void About()
    {
        sceneFader.fadeTo(loadAbout);
        Debug.Log("About");
    }
    public void Controls()
    {
        sceneFader.fadeTo(loadControl);
        Debug.Log("Controls");
    }

}
