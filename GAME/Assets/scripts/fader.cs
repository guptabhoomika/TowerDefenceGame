using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fader : MonoBehaviour
{
    public Image fadeImg;
    public AnimationCurve fadecurve;
    private void Start()
    {
        StartCoroutine(fadeIn());
    }
    IEnumerator fadeIn()
    {
        float t = 1f;
        while(t > 0f)
        {
            t -= Time.deltaTime * 2f;
            float a = fadecurve.Evaluate(t); 
            fadeImg.color = new Color(0f, 0f, 0f, a);
                
            yield return 0;
        }

    }
    public void fadeTo(string scene)
    {
        StartCoroutine(fadeOut(scene));
    }
    IEnumerator fadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadecurve.Evaluate(t);
            fadeImg.color = new Color(0f, 0f, 0f, a);

            yield return 0;
        }
        SceneManager.LoadScene(scene);

    }
}
