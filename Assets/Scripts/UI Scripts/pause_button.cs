using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_button : MonoBehaviour
{
    public List<Sprite> pauseImages;
    private int pauseImageNum;
    private Image pauseBaseImage;
    private float tempTimeScale;
    public bool paused;

    public void Start()
    {
        pauseImageNum = 0;
        pauseBaseImage = GetComponent<Image>();
        pauseBaseImage.sprite = pauseImages[pauseImageNum];
        paused = false;
    }

    public void ChangeToPauseStatis()
    {
        if (FindObjectOfType<Player_Controller>().pause == 0)
        {
            if (FindObjectOfType<Player_Controller>().isAlive == true)
            {
                if (pauseImageNum == 0)
                {
                    pauseImageNum = 1;
                    //set to pause
                    paused = true;
                    FindObjectOfType<MainMusicLoop>().PauseMusic();
                    tempTimeScale = Time.timeScale;
                    Time.timeScale = 0;
                }
                else if (pauseImageNum == 1)
                {
                    pauseImageNum = 0;
                    //set to play
                    paused = false;
                    FindObjectOfType<MainMusicLoop>().UnPauseMusic();
                    Time.timeScale = tempTimeScale;
                }

                pauseBaseImage.sprite = pauseImages[pauseImageNum];
            }
        } 
    }
    
}
