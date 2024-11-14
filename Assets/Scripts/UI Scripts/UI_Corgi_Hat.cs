using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Corgi_Hat : MonoBehaviour
{

    public List<Sprite> corgiHats;
    private int corgiHatNum;
    private Image corgiBaseHat;

    public void Start()
    {
        corgiHatNum = FindObjectOfType<GameManager>().currentCorgiUpgrades[1];
        corgiBaseHat = GetComponent<Image>();
        corgiBaseHat.sprite = corgiHats[corgiHatNum];
    }

    public void ChangeHatLeft()
    {
        corgiHatNum--;

        if (corgiHatNum == -1)
        {
            corgiHatNum = corgiHats.Count - 1;
        }

        corgiBaseHat.sprite = corgiHats[corgiHatNum];
    }

    public void ChangeHatRight()
    {
        corgiHatNum++;

        if (corgiHatNum == corgiHats.Count)
        {
            corgiHatNum = 0;
        }

        corgiBaseHat.sprite = corgiHats[corgiHatNum];
    }

}
