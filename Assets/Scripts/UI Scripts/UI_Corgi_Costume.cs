using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Corgi_Costume : MonoBehaviour
{

    public List<Sprite> corgiCostumes;
    public int corgiCostumeNum;
    private Image corgiBaseCostume;

    public void Start()
    {
        corgiCostumeNum = FindObjectOfType<GameManager>().currentCorgiUpgrades[2];
        corgiBaseCostume = GetComponent<Image>();
        corgiBaseCostume.sprite = corgiCostumes[corgiCostumeNum];
    }

    public void ChangeCostumeLeft()
    {
        corgiCostumeNum--;

        if (corgiCostumeNum < 0)
        {
            corgiCostumeNum = 12;
        }

        corgiBaseCostume.sprite = corgiCostumes[corgiCostumeNum];
    }

    public void ChangeCostumeRight()
    {
        corgiCostumeNum++;

        if (corgiCostumeNum > 12)
        {
            corgiCostumeNum = 0;
        }

        corgiBaseCostume.sprite = corgiCostumes[corgiCostumeNum];
    }

}
