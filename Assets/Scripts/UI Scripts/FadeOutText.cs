using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOutText : MonoBehaviour
{

    public TextMeshPro ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTreatText()
    {
        ScoreText.text = "+" + FindObjectOfType<GameManager>().comboTreatTracker.ToString();
        StartCoroutine(FadeTextToZeroAlpha(10f, GetComponent<TextMeshPro>()));
    }

    public void SetScoreText()
    {
        ScoreText.text = "+" + FindObjectOfType<GameManager>().comboScoreTracker.ToString();
        StartCoroutine(FadeTextToZeroAlpha(10f, GetComponent<TextMeshPro>()));
    }

    public void SetStarText()
    {
        ScoreText.text = "+1000";
        StartCoroutine(FadeTextToZeroAlpha(10f, GetComponent<TextMeshPro>()));
    }

    public void SetBubText()
    {
        ScoreText.text = "+2500";
        StartCoroutine(FadeTextToZeroAlpha(10f, GetComponent<TextMeshPro>()));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshPro i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - ((Time.deltaTime / t) * (t/1.25f)));
            yield return null;
            
        }
    }

}
