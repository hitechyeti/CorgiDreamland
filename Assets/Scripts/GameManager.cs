using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public DataManager dataManager;

    //Good Dream | Nightmare
    public int dreamType;

    //Control Mode
    public int controlMode;

    //Stopwatch when time increases
    [SerializeField] public GameObject stopwatch;

    public int score { get; private set; }
    public int corgiNum { get; private set; }

    public int corgiPickNum;
    public int hatNum;
    public int costumePick;
    public int trailNum;

    //combo score tracker
    public int comboScoreTracker;
    public int comboTreatTracker;

    //Has Tail Bool
    public bool hasTail;

    //For double version of costumes
    public int costumeLockPick;

    //public int[] costumeUnlocks2 = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //public int[] costumeCosts2 = new int[] { 0, 75, 75, 75, 75, 75, 125, 125, 125, 150, 175, 175, 175 };

    //Effect list
    public GameObject[] destroyEffect;

    //Total Upgrade Costs
    public int upgradeTotalCosts;
    public int upgradeCorgi;
    public int upgradeHat;
    public int upgradeCostume;
    public int upgradeTrail;

    //arrays for upgrades
    public int[] currentCorgiUpgrades;

    public int[] corgiUnlocks;
    public int[] corgiCosts;

    public int[] hatUnlocks;
    public int[] hatCosts;

    public int[] costumeUnlocks;
    public int[] costumeCosts;

    public int[] trailUnlocks;
    public int[] trailCosts;

    //Music Data
    public int musicVol;
    public int musicOn;

    //God Boy Points
    public int GBP;

    //High Score
    public int highScore;

    private GameObject can_MainGame;
    private GameObject can_Start;
    private GameObject can_Costumes;
    private GameObject can_Options;
    private GameObject can_Credits;
    private GameObject can_PlayAgain;

    protected override void Awake()
    {
        base.Awake();

        //Canvas Setup
        can_MainGame = GameObject.FindGameObjectWithTag("Canvas_MainGame");
        can_Start = GameObject.FindGameObjectWithTag("Canvas_Start");
        can_Costumes = GameObject.FindGameObjectWithTag("Canvas_Costumes");
        can_Options = GameObject.FindGameObjectWithTag("Canvas_Options");
        can_Credits = GameObject.FindGameObjectWithTag("Canvas_Credits");
        can_PlayAgain = GameObject.FindGameObjectWithTag("Canvas_PlayAgain");

        Time.timeScale = 1f;
        score = 0;
        comboScoreTracker = 0;
        comboTreatTracker = 0;

        //Load Player Data
        dataManager.Load();

        //Good Dream / Extreme Dream
        dreamType = dataManager.data.dreamType;

        //Control Mode
        controlMode = dataManager.data.controlMode;

        //Music Data Setup
        musicVol = dataManager.data.musicVolume;
        musicOn = dataManager.data.musicEnabled;

        //Good Boy Points / High Score
        GBP = dataManager.data.goodBoyPoints;
        highScore = dataManager.data.highScore;

        //Total Upgrade Costs
        upgradeTotalCosts = 0;
        upgradeCorgi = 0;
        upgradeHat = 0;
        upgradeCostume = 0;
        upgradeTrail = 0;

        //FORCE UPDATE PLAYER.TXT START
        //dataManager.data.costumeUnlocks = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        //dataManager.data.costumeCosts = new int[] { 0, 75, 75, 75, 75, 75, 125, 125, 125, 150, 175, 175, 175 };
        //costumeUnlocks = costumeUnlocks2;
        //costumeCosts = costumeCosts2;
        //dataManager.Save();
        //FORCE UPDATE PLAYER.TXT END

        //arrays for upgrades
        currentCorgiUpgrades = dataManager.data.currentCorgiUpgrades;

        corgiUnlocks = dataManager.data.corgiUnlocks;
        corgiCosts = dataManager.data.corgiCosts;

        hatUnlocks = dataManager.data.hatUnlocks;
        hatCosts = dataManager.data.hatCosts;

        costumeUnlocks = dataManager.data.costumeUnlocks;
        costumeCosts = dataManager.data.costumeCosts;

        trailUnlocks = dataManager.data.trailUnlocks;
        trailCosts = dataManager.data.trailCosts;

        //array indexes
        corgiPickNum = currentCorgiUpgrades[0];
        hatNum = currentCorgiUpgrades[1];
        costumePick = currentCorgiUpgrades[2];
        trailNum = currentCorgiUpgrades[3];

        if (corgiPickNum % 2 == 1)
        {
            hasTail = true;
        }
        else
        {
            hasTail = false;
        }

    }

    public void Start()
    {
        stopwatch.transform.localScale = new Vector3(0, 0, 0);
        can_MainGame.gameObject.SetActive(false);
        can_Costumes.gameObject.SetActive(false);
        can_Options.gameObject.SetActive(false);
        can_Credits.gameObject.SetActive(false);
        can_PlayAgain.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ScreenCapture.CaptureScreenshot("C:/Users/kpitn/OneDrive/Desktop/screenshots/Capture.png");
        }
    }

    public void UpdateCanvas()
    {
        can_MainGame.gameObject.SetActive(false);
        can_Start.gameObject.SetActive(false);
        can_Costumes.gameObject.SetActive(false);
        can_Options.gameObject.SetActive(false);
        can_Credits.gameObject.SetActive(false);
        can_PlayAgain.gameObject.SetActive(false);
    }

    public void ChangeControls()
    {
        if (controlMode == 1)
        {
            controlMode = 2;
            FindObjectOfType<ControlMode>().ControlsText();
        }
        else if (controlMode == 2)
        {
            controlMode = 1;
            FindObjectOfType<ControlMode>().ControlsText();
        }

        dataManager.data.controlMode = controlMode;
        dataManager.Save();
    }

    public void IncreaseScore()
    {
        if (dreamType == 1)
        {
            comboTreatTracker += 5;
            score += comboTreatTracker;
            FindObjectOfType<FadeOutText>().SetTreatText();
        }
        else if (dreamType == 2)
        {
            comboTreatTracker += 5;
            score += comboTreatTracker;
            FindObjectOfType<FadeOutText>().SetTreatText();
        }
    }

    public void IncreaseComboScore()
    {
        if (dreamType == 1)
        {
            comboScoreTracker += 100;
            score += comboScoreTracker;
            FindObjectOfType<FadeOutText>().SetScoreText();
        }
        else if (dreamType == 2)
        {
            comboScoreTracker += 100;
            score += comboScoreTracker;
            FindObjectOfType<FadeOutText>().SetScoreText();
        }
    }

    public void FallingStarScore()
    {
        if (dreamType == 1)
        {
            score += 1000;
            FindObjectOfType<FadeOutText>().SetStarText();
        }
        else if (dreamType == 2)
        {
            score += 1000;
            FindObjectOfType<FadeOutText>().SetStarText();
        }
    }

    public void BubblePowerupScore()
    {
        if (dreamType == 1)
        {
            score += 2500;
            FindObjectOfType<FadeOutText>().SetBubText();
        }
        else if (dreamType == 2)
        {
            score += 2500;
            FindObjectOfType<FadeOutText>().SetBubText();
        }
    }

    public void IncreaseGBP1()
    {
        if (dreamType == 1)
        {
            GBP += 2;
        }
        else if (dreamType == 2)
        {
            GBP += 2;
        }

    }

    public void IncreaseGBP2()
    {
        if (dreamType == 1)
        {
            GBP += 4;
        }
        else if (dreamType == 2)
        {
            GBP += 4;
        }

    }

    public void IncreaseGBP3()
    {
        if (dreamType == 1)
        {
            GBP += 6;
        }
        else if (dreamType == 2)
        {
            GBP += 6;
        }

    }

    public void IncreaseGBP8()
    {
        if (dreamType == 1)
        {
            GBP += 20;
        }
        else if (dreamType == 2)
        {
            GBP += 20;
        }

    }

    public void GameStart()
    {
        FindObjectOfType<Player_Controller>().pause = 0;
        FindObjectOfType<Spawn_Hydrants>().OnGameStart();
        FindObjectOfType<MainMusicLoop>().OnGameStart();
        FindObjectOfType<Player_Controller>().AddCorgiTrail();
        FindObjectOfType<Home>().HomeStartMoving();
        FindObjectOfType<Player_Controller>().StartCorgi();
        FindObjectOfType<Spawn_Hydrants>().SpawnIslandSet0();
        FindObjectOfType<CameraMovement>().ChangeX_Left();
        FindObjectOfType<Spawn_Hydrants>().ChangeX_Left();
        FindObjectOfType<Intro1_Text>().SetIntro1Text();
        FindObjectOfType<Intro2_Text>().SetIntro2Text();
    }
    
    public void StartGameOver()
    {
        if (score > dataManager.data.highScore)
        {
            dataManager.data.highScore = score;
        }

        dataManager.data.lastScore = score;
        dataManager.data.goodBoyPoints = GBP;
        dataManager.Save();

        FindObjectOfType<MainMusicLoop>().StopMusic();
        FindObjectOfType<Sound_Crash>().Crash1();
        FindObjectOfType<Player_Controller>().Pause();

        FindObjectOfType<Player_Controller>().isAlive = false;

        //Effects (jump and dash)
        destroyEffect = GameObject.FindGameObjectsWithTag("Effect");

        foreach (GameObject oneEffect in destroyEffect)
            Destroy(oneEffect);
    }

    public void TutorialGameOver()
    {
        if (score > dataManager.data.highScore)
        {
            dataManager.data.highScore = score;
        }

        dataManager.data.lastScore = score;
        dataManager.data.goodBoyPoints = GBP;
        dataManager.Save();

        FindObjectOfType<MainMusicLoop>().StopMusic();
        FindObjectOfType<Sound_Bark>().TwoBarks1();
        FindObjectOfType<Player_Controller>().Pause();

        FindObjectOfType<Player_Controller>().isAlive = false;

        //Effects (jump and dash)
        destroyEffect = GameObject.FindGameObjectsWithTag("Effect");

        foreach (GameObject oneEffect in destroyEffect)
            Destroy(oneEffect);
    }

    public void EndGameOver()
    {
        Invoke("SceneGameover", 1);
    }

    public void B_L_Corgi()
    {

        corgiPickNum--;

        if (corgiPickNum < 0)
        {
            corgiPickNum = 5;
        }

        if (corgiPickNum % 2 == 1)
        {
            hasTail = true;
        }
        else
        {
            hasTail = false;
        }

        upgradeCorgi = corgiCosts[corgiPickNum];
        upgradeTotalCosts = upgradeCorgi + upgradeHat + upgradeCostume + upgradeTrail;

    }

    public void B_R_Corgi()
    {

        corgiPickNum++;

        if (corgiPickNum > 5)
        {
            corgiPickNum = 0;
        }

        if (corgiPickNum % 2 == 1)
        {
            hasTail = true;
        }
        else
        {
            hasTail = false;
        }

        upgradeCorgi = corgiCosts[corgiPickNum];
        upgradeTotalCosts = upgradeCorgi + upgradeHat + upgradeCostume + upgradeTrail;

    }

    public void B_L_Hat()
    {
        if (hatNum > 0)
        {
            hatNum--;
        }
        else
        {
            hatNum = FindObjectOfType<UI_Corgi_Hat>().corgiHats.Count - 1;
        }

        upgradeHat = hatCosts[hatNum];
        upgradeTotalCosts = upgradeCorgi + upgradeHat + upgradeCostume + upgradeTrail;

    }

    public void B_R_Hat()
    {
        if (hatNum < FindObjectOfType<UI_Corgi_Hat>().corgiHats.Count - 1)
        {
            hatNum++;
        }
        else
        {
            hatNum = 0;
        }

        upgradeHat = hatCosts[hatNum];
        upgradeTotalCosts = upgradeCorgi + upgradeHat + upgradeCostume + upgradeTrail;

    }

    public void B_L_Costume()
    {
        costumePick--;

        if (costumePick < 0)
        {
            costumePick = 12;
        }

        upgradeCostume = costumeCosts[costumePick];
        upgradeTotalCosts = upgradeCorgi + upgradeHat + upgradeCostume + upgradeTrail;
    }

    public void B_R_Costume()
    {
        costumePick++;

        if (costumePick > 12)
        {
            costumePick = 0;
        }

        upgradeCostume = costumeCosts[costumePick];
        upgradeTotalCosts = upgradeCorgi + upgradeHat + upgradeCostume + upgradeTrail;
    }

    public void B_L_Trail()
    {
        if (trailNum > 0)
        {
            trailNum--;
        }
        else
        {
            trailNum = 15;
        }

        upgradeTrail = trailCosts[trailNum];
        upgradeTotalCosts = upgradeCorgi + upgradeHat + upgradeCostume + upgradeTrail;

    }

    public void B_R_Trail()
    {
        if (trailNum < 15)
        {
            trailNum++;
        }
        else
        {
            trailNum = 0;
        }

        upgradeTrail = trailCosts[trailNum];
        upgradeTotalCosts = upgradeCorgi + upgradeHat + upgradeCostume + upgradeTrail;

    }

    public void SceneGameover()
    {
        if (FindObjectOfType<Player_Controller>().isTutorial == false)
        {
            SceneManager.LoadScene("PlayAgain");
        }
        else
        {
            SceneManager.LoadScene("Start");
        }
    }

    public void SceneGoodDream()
    {
        //Reset Dream to Good Dream
        dataManager.data.dreamType = 2;
        dataManager.Save();

        StopAllCoroutines();
        UpdateCanvas();
        can_MainGame.gameObject.SetActive(true);

        SceneManager.LoadScene("MainGame");
    }

    public void SceneExtremeDream()
    {
        //Reset Dream to Good Dream
        dataManager.data.dreamType = 2;
        dataManager.Save();

        SceneManager.LoadScene("MainGame");
    }

    public void SceneCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ScenePlayAgain()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void SceneHomePage()
    {
        SceneManager.LoadScene("Start");
    }

    public void SceneUpgrades()
    {
        SceneManager.LoadScene("Costumes");
    }

    public void SceneOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void SceneHowToPlay()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void MusicVolumeUp()
    {
        if (musicVol < 9)
        {
            musicVol++;
        }
        FindObjectOfType<VolumeNumText>().UpdateVolTextVisual();
    }

    public void MusicVolumeDown()
    {
        if (musicVol > 1)
        {
            musicVol--;
        }
        FindObjectOfType<VolumeNumText>().UpdateVolTextVisual();
    }

    public void MusicEnable()
    {
        musicOn = 1;
        FindObjectOfType<MusicOnOffImage>().EnableMusicImage();
    }

    public void MusicDisable()
    {
        musicOn = 0;
        FindObjectOfType<MusicOnOffImage>().DisbaleMusicImage();
    }

    public void SceneHomeOptions()
    {
        dataManager.data.musicVolume = musicVol;
        dataManager.data.musicEnabled = musicOn;
        dataManager.Save();

        SceneManager.LoadScene("Start");
    }

    public void SceneHomeUpgrades()
    {
        if (corgiUnlocks[corgiPickNum] == 0 && hatUnlocks[hatNum] == 0 && costumeUnlocks[costumePick] == 0 && trailUnlocks[trailNum] == 0)
        {
            currentCorgiUpgrades[0] = corgiPickNum;
            currentCorgiUpgrades[1] = hatNum;
            currentCorgiUpgrades[2] = costumePick;
            currentCorgiUpgrades[3] = trailNum;

            dataManager.Save();
        }

        SceneManager.LoadScene("Start");
    }

    public void PurchaseUpgrades()
    {
        if (upgradeTotalCosts > 0)
        {
            if (GBP >= upgradeTotalCosts)
            {
                //Sound SFX
                FindObjectOfType<PurchaseClip>().PurchaseSFX();

                GBP -= upgradeTotalCosts;
                dataManager.data.goodBoyPoints -= upgradeTotalCosts;

                corgiUnlocks[corgiPickNum] = 0;
                hatUnlocks[hatNum] = 0;
                costumeUnlocks[costumePick] = 0;
                trailUnlocks[trailNum] = 0;

                corgiCosts[corgiPickNum] = 0;
                hatCosts[hatNum] = 0;
                costumeCosts[costumePick] = 0;
                trailCosts[trailNum] = 0;

                upgradeTotalCosts = 0;

                dataManager.Save();
            }
        }
    }

}
