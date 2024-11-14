using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyUpgrades : MonoBehaviour
{
    public TextMeshProUGUI GBPText;
    public int GBP;

    public TextMeshProUGUI UpgradeCostsText;
    public int UpgradeCosts;

    // Start is called before the first frame update
    void Start()
    {
        GBPText.text = " : " + FindObjectOfType<GameManager>().GBP.ToString();
        UpgradeCostsText.text = " : 0";
    }

    // Update is called once per frame
    void Update()
    {
        GBPText.text = " : " + FindObjectOfType<GameManager>().GBP.ToString();
        UpgradeCostsText.text = " : " + FindObjectOfType<GameManager>().upgradeTotalCosts.ToString();
    }
}
