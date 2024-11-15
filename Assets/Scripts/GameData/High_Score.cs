using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class High_Score : MonoBehaviour
{
    public DataManager dataManager;

    public TextMeshProUGUI submitScoreText;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI playAgainText;

    public int ranMsg;

    // Start is called before the first frame update
    public void Start()
    {
        submitScoreText.text = dataManager.data.highScore.ToString();
        highScoreText.text = "Best: " + dataManager.data.highScore.ToString();
        lastScoreText.text = "Score: " + dataManager.data.lastScore.ToString();

        ranMsg = Random.Range(1,10);

        if (ranMsg == 1)
        {
            playAgainText.text = "Aww the cat woke me up...\nI can has another dream?";
        }
        else if (ranMsg == 2)
        {
            playAgainText.text = "\"Sniff\" \"Sniff\"\nDo I smell dinner?";
        }
        else if (ranMsg == 3)
        {
            playAgainText.text = "I can guard the house\nBut your sandwich... Better watch its back";
        }
        else if (ranMsg == 4)
        {
            playAgainText.text = "\"Stretching\"\nI'm sleepy, more dreams please";
        }
        else if (ranMsg == 5)
        {
            playAgainText.text = "Unless it's food time\nMore dreams please";
        }
        else if (ranMsg == 6)
        {
            playAgainText.text = "Aww I almost won my dreams\nI want to try again!";
        }
        else if (ranMsg == 7)
        {
            playAgainText.text = "\"Drooling\"\nThat dream food was so yummy!";
        }
        else if (ranMsg == 8)
        {
            playAgainText.text = "Life is a dream, and reality is dinner\nLet's play again!";
        }
        else if (ranMsg == 9)
        {
            playAgainText.text = "Unless it's food time\nMore dreams please!";
        }
        else if (ranMsg == 10)
        {
            playAgainText.text = "Aww the cat woke me up...\nI can has another dream?";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
