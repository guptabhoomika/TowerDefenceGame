using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject gameOverUi;
    public static bool gameEnded;
    public GameObject gameWonUI;

    
    
    private void Start()
    {
        gameEnded = false;
    }
    void Update()
    {
        if (gameEnded)
            return;
        if (playerStats.lives <= 0)
        {

            Endgame();
        }
    }
    void Endgame()
    {
        gameEnded = true;
        gameOverUi.SetActive(true);

    }
    public void WinLevel()
    {
        gameEnded = true;

        gameWonUI.SetActive(true);
   
    }
}
