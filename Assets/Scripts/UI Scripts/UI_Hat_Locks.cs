using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hat_Locks : MonoBehaviour
{
    public List<Sprite> hatLockImages;
    private int[] hatUnlocks;
    private Image hatBaseLockImage;

    // Start is called before the first frame update
    public void Start()
    {
        hatBaseLockImage = GetComponent<Image>();

        hatUnlocks = FindObjectOfType<GameManager>().hatUnlocks;
    }

    // Update is called once per frame
    public void Update()
    {
        hatBaseLockImage.sprite = hatLockImages[hatUnlocks[FindObjectOfType<GameManager>().hatNum]];
    }
}
