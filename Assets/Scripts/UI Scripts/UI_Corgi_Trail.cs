using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Corgi_Trail : MonoBehaviour
{

    public List<Sprite> corgiTrails;
    private int corgiTrailNum;
    private Image corgiBaseTrail;

    public void Start()
    {
        corgiTrailNum = FindObjectOfType<GameManager>().currentCorgiUpgrades[3];
        corgiBaseTrail = GetComponent<Image>();
        corgiBaseTrail.sprite = corgiTrails[corgiTrailNum];
    }

    public void ChangeTrailLeft()
    {
        corgiTrailNum--;

        if (corgiTrailNum == -1)
        {
            corgiTrailNum = corgiTrails.Count - 1;
        }

        corgiBaseTrail.sprite = corgiTrails[corgiTrailNum];

        FindObjectOfType<Upgrade_Corgi>().example_trail_num = FindObjectOfType<GameManager>().trailNum;
        FindObjectOfType<Upgrade_Corgi>().Trails();
    }

    public void ChangeTrailRight()
    {
        corgiTrailNum++;

        if (corgiTrailNum == corgiTrails.Count)
        {
            corgiTrailNum = 0;
        }

        corgiBaseTrail.sprite = corgiTrails[corgiTrailNum];

        FindObjectOfType<Upgrade_Corgi>().example_trail_num = FindObjectOfType<GameManager>().trailNum;
        FindObjectOfType<Upgrade_Corgi>().Trails();
    }

}
