using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Corgi_Image : MonoBehaviour
{

    public List<Sprite> corgiImages;
    private int corgiImageNum;
    private Image corgiBaseImage;


    public void Start()
    {
        corgiImageNum = FindObjectOfType<GameManager>().currentCorgiUpgrades[0];
        corgiBaseImage = GetComponent<Image>();
        corgiBaseImage.sprite = corgiImages[corgiImageNum];
    }

    public void ChangeSpriteLeft()
    {
        corgiImageNum--;

        if (corgiImageNum == -1)
        {
            corgiImageNum = corgiImages.Count - 1;
        }

        corgiBaseImage.sprite = corgiImages[corgiImageNum];
    }

    public void ChangeSpriteRight()
    {
        corgiImageNum++;

        if (corgiImageNum == corgiImages.Count)
        {
            corgiImageNum = 0;
        }

        corgiBaseImage.sprite = corgiImages[corgiImageNum];
    }

}
