using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeinfadeout : MonoBehaviour
{
    public static fadeinfadeout FadeInstance;

    private Image fadeEffect;
    public float fadeinEffect;

    private float fadeOutEffect;

    private void Awake()
    {
        fadeEffect = GetComponent<Image>();
        fadeinEffect = 255;
        fadeOutEffect = 0;

        if (FadeInstance == null) {
            FadeInstance = this;
           }
    }

    private void Update()
    {
        if (fadeinEffect > 0)
        {
            fadeIn();
        }
    }

    public void fadeIn()
    {
        fadeEffect.color = new Color(0, 0, 0, fadeinEffect -= Mathf.Lerp(0, 255, 10.0f));
    }

    public void FadeOut()
    {
        fadeEffect.color = new Color(0, 0, 0, fadeOutEffect += Mathf.Lerp(0, 255, 10.0f));
    }

}
