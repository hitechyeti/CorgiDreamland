using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeNumText : MonoBehaviour
{
    public TextMeshProUGUI volumeText;

    // Start is called before the first frame update
    void Start()
    {
        volumeText.text = FindObjectOfType<GameManager>().musicVol.ToString();
    }

    public void UpdateVolTextVisual()
    {
        volumeText.text = FindObjectOfType<GameManager>().musicVol.ToString();
    }
}
