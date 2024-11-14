using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Trail_Locks : MonoBehaviour
{
    public List<Sprite> trailLockImages;
    private int[] trailUnlocks;
    private Image trailBaseLockImage;

    // Start is called before the first frame update
    public void Start()
    {
        trailBaseLockImage = GetComponent<Image>();

        trailUnlocks = FindObjectOfType<GameManager>().trailUnlocks;
    }

    // Update is called once per frame
    public void Update()
    {
        trailBaseLockImage.sprite = trailLockImages[trailUnlocks[FindObjectOfType<GameManager>().trailNum]];
    }
}
