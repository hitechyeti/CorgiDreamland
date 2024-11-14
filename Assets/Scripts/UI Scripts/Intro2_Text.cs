using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro2_Text : MonoBehaviour
{
    public TextMeshProUGUI intro2Text;

    // Start is called before the first frame update
    void Start()
    {
        intro2Text = GetComponent<TextMeshProUGUI>();
    }

    public void SetIntro2Text()
    {
        intro2Text.text = "RUN";
        Invoke(nameof(FadeIntro2), 2f);
    }

    public void SetStars2Text()
    {
        intro2Text.text = "Dash to break";
        Invoke(nameof(FadeStar2), 2f);
    }

    public void FadeIntro2()
    {
        StartCoroutine(FadeTextToZeroAlpha(10f, GetComponent<TextMeshProUGUI>()));
    }

    public void FadeStar2()
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
