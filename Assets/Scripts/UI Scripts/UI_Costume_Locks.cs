using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Costume_Locks : MonoBehaviour
{
    public List<Sprite> costumeLockImages;
    private int[] costumeUnlocks;
    private Image costumeBaseLockImage;

    // Start is called before the first frame update
    public void Start()
    {
        costumeBaseLockImage = GetComponent<Image>();

        costumeUnlocks = FindObjectOfType<GameManager>().costumeUnlocks;
    }

    // Update is called once per frame
    public void Update()
    {
        costumeBaseLockImage.sprite = costumeLockImages[costumeUnlocks[FindObjectOfType<UI_Corgi_Costume>().corgiCostumeNum]];
    }
}
