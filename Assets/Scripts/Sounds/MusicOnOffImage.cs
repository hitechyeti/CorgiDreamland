using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOffImage : MonoBehaviour
{
    public List<Sprite> musicOnOffImageList;
    private Image musicOnOffImage;
    private int musicImageIndex;

    public void Start()
    {
        musicImageIndex = FindObjectOfType<GameManager>().musicOn;
        musicOnOffImage = GetComponent<Image>();
        musicOnOffImage.sprite = musicOnOffImageList[musicImageIndex];
    }

    public void DisbaleMusicImage()
    {
        musicOnOffImage.sprite = musicOnOffImageList[0];
    }

    public void EnableMusicImage()
    {
        musicOnOffImage.sprite = musicOnOffImageList[1];
    }

}
