using UnityEngine;

using UnityEngine.UI;
 public class pauseButton : MonoBehaviour
{
    public GameObject pauseUI;
    public fader screenFader;
   
    
    public void Toggle()
    {

        pauseUI.SetActive(!pauseUI.activeSelf);
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
