using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class roundSurrvived : MonoBehaviour
{
    public Text roundText;
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }
    IEnumerator AnimateText()
    {
        roundText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(0.7f);
        while(round< playerStats.rounds)
        {
            round++;

            roundText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }


    }

}
