using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Corgi_Locks : MonoBehaviour
{
    public List<Sprite> corgiLockImages;
    private int[] corgiUnlocks;
    private Image corgiBaseLockImage;

    // Start is called before the first frame update
    public void Start()
    {
        corgiBaseLockImage = GetComponent<Image>();

        corgiUnlocks = FindObjectOfType<GameManager>().corgiUnlocks;
    }

    // Update is called once per frame
    public void Update()
    {
        corgiBaseLockImage.sprite = corgiLockImages[corgiUnlocks[FindObjectOfType<GameManager>().corgiPickNum]];
    }
}
