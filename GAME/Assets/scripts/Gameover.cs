using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
  
    public string loadMenu;
    public fader screenfader;
   
    public void retry()
    {

        screenfader.fadeTo(SceneManager.GetActiveScene().name);
    }
    public void menu()
    {
        screenfader.fadeTo(loadMenu);
        
    }


}
