using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreen : MonoBehaviour
{
    public fader fader;
    public string loadMenu;
    public void Quit()
    {
        Application.Quit();

    }
    public void Menu()
    {
        fader.fadeTo(loadMenu);
    }

}
