using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class liveUi : MonoBehaviour
{
    public Text liveText;


    // Update is called once per frame
    void Update()
    {
        if (playerStats.lives >= 0)
        {
            liveText.text = playerStats.lives.ToString() + " LIVES";
        }
        else
        {
            liveText.text = "0 LIVES";
        }
        
    }
}
