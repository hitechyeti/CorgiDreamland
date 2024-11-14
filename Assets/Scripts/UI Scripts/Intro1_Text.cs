using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro1_Text : MonoBehaviour
{
    public TextMeshProUGUI intro1Text;

    // Start is called before the first frame update
    void Start()
    {
        intro1Text = GetComponent<TextMeshProUGUI>();
    }

    public void SetIntro1Text()
    {
        intro1Text.text = "They want your dreams";
        Invoke(nameof(FadeIntro1), 2f);
    }

    public void SetStars1Text()
    {
        intro1Text.text = "The stars are falling";
        Invoke(nameof(FadeStar1), 2f);
    }

    public void FadeIntro1()
    {
        StartCoroutine(FadeTextToZeroAlpha(10f, GetComponent<TextMeshProUGUI>()));
    }

    public void FadeStar1()
    {
        StartCoroutine(FadeText(3f, GetComponent<TextMeshProUGUI>()));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - ((Time.deltaTime / t) * (t / 1.25f)));
            yield return null;

        }
    }

    public IEnumerator FadeText(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;

        }
    }
}
