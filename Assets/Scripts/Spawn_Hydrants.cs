using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn_Hydrants : MonoBehaviour
{
    //BUG TESTING VARIABLE
    public int islandNumbers = 0;

    [SerializeField] GameObject backgroundTop1;
    [SerializeField] GameObject backgroundBot1;
    [SerializeField] GameObject backgroundBot2;

    private float backAdjust;

    public GameObject prefabIslandSet0;
    public GameObject prefabIslandSet1;
    public GameObject prefabIslandSet2;
    public GameObject prefabIslandSet3;
    public GameObject prefabIslandSet4;
    public GameObject prefabIslandSet5;
    public GameObject prefabIslandSet6;
    public GameObject prefabIslandSet7;
    public GameObject prefabIceSet1;
    public GameObject prefabIceSet2;
    public GameObject prefabIceSet3;
    public GameObject prefabTreasureSet1;
    public GameObject prefabTreasureSet2;

    public GameObject prefabStar_Top;
    public GameObject prefabStar_Bot;
    public GameObject prefabBallLightning;

    public GameObject prefabBigPirateship;

    //Falling Star
    public GameObject prefabFallingStar;

    //Big Pirateship Exists
    public bool bigPirateshipExists;
    public int bigPirateshipToggle;

    public int obstacleRandom = 1;
    public int lastObstacle;
    public int skipObstacle;

    public int starRandom = 1;

    //Last Island and Nums
    public int lastIslandSet = 0;
    public int islandNum = 0;

    //Last Ice Set
    public int lastIceSet = 0;

    //Treasure Pick
    public int treasurePick = 0;

    //Storm Cloud Coverage
    public GameObject prefabStorm_Cloud1;
    public GameObject prefabStorm_Cloud2;
    public GameObject prefabStorm_Cloud3;
    public GameObject prefabStorm_Cloud4;
    public GameObject prefabStorm_Cloud5;
    public GameObject prefabStorm_Cloud6;
    public int cloudRandom = 1;

    public int islandRandom = 0;
    public int iceRandom = 0;

    public GameObject prefabSeagull;
    public float spawnRateSeagull = 1f;
    public float minHeightSeagull = -1f;
    public float maxHeightSeagull = 1f;

    public GameObject prefabGoldfish;
    public float spawnRateGoldfish = 1f;
    public float minHeightGoldfish = -1f;
    public float maxHeightGoldfish = 1f;

    public GameObject prefabPufferfish;
    public float spawnRatePufferfish = 1f;
    public float minHeightPufferfish = -1f;
    public float maxHeightPufferfish = 1f;

    public GameObject prefabTunaSnapping;
    public float spawnRateTunaSnapping = 1f;
    public float minHeightTunaSnapping = -1f;
    public float maxHeightTunaSnapping = 1f;

    public GameObject prefabPirateshipBlacksails;
    public float spawnRatePirateshipBlacksails = 1f;
    public float minHeightPirateshipBlacksails = -1f;
    public float maxHeightPirateshipBlacksails = 1f;

    public GameObject prefabcorgiMain;

    public int timeBetweenGF = 125;
    public int lastTimeGF = 0;

    public int timeBetweenTS = 175;
    public int lastTimeTS = 0;

    public int timeBetweenPF = 200;
    public int lastTimePF = 0;

    public int timeBetweenSG = 250;
    public int lastTimeSG = 0;

    public int timeBetweenPSBS = 250;
    public int lastTimePSBS = 0;

    //Score Text
    public TextMeshProUGUI scoreText;
    public int scoreVisual;

    //High Score Text
    public TextMeshProUGUI highScoreText;
    public int highScoreVisual;

    //ComboStar
    public int comboStarPoints;

    //Good Boy Points
    public TextMeshProUGUI GBPText;
    public int GBPVisual;
    //public int dogTreatRan;
    public int dogTreatNow;

    //Spawn Animals
    public int comboNum;

    private GameManager gameManager;
    private CameraMovement cameraMovement;
    private Player_Controller player_Controller;
    private BigPirateship bigPirateship;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        cameraMovement = FindObjectOfType<CameraMovement>();
        player_Controller = FindObjectOfType<Player_Controller>();
        bigPirateship = FindObjectOfType<BigPirateship>();
        scoreText = GameObject.FindGameObjectWithTag("Score_TXT").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.FindGameObjectWithTag("HighScore_TXT").GetComponent<TextMeshProUGUI>();
        GBPText = GameObject.FindGameObjectWithTag("GBP_TXT").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        cameraMovement.ChangeMaxY_High();

        backAdjust = 0f;
        islandNum = 1;
        //dogTreatRan = 1;
        dogTreatNow = 10;
        comboNum = 0;
        lastObstacle = 0;
        skipObstacle = 7;

        GBPVisual = gameManager.GBP;
        GBPText.text = " : " + GBPVisual.ToString();

        highScoreVisual = gameManager.highScore;
        highScoreText.text = "Best: " + highScoreVisual.ToString();

        scoreVisual = 0;
        comboStarPoints = 1;
        CorgiMain();

        //Set Big Pirateship exists to false
        bigPirateshipExists = false;
        bigPirateshipToggle = 0;

        //Default treasure open
        treasurePick = 2;

        //BUG TESTING VARIABLE
        islandNumbers = 0;
}

    private void FixedUpdate()
    {
        if (comboNum > 0)
        {
            if (lastTimeGF >= timeBetweenGF)
            {
                lastTimeGF = 0;
                timeBetweenGF = Random.Range(100, 200);
                SpawnGoldfish();
            }
        }

        if (comboNum > 2)
        {
            if (lastTimeTS >= timeBetweenTS)
            {
                lastTimeTS = 0;
                timeBetweenTS = Random.Range(100, 200);
                SpawnTunaSnapping();
            }
        }

        if (comboNum > 4)
        {
            if (lastTimePF >= timeBetweenPF)
            {
                lastTimePF = 0;
                timeBetweenPF = Random.Range(700, 900);
                SpawnPufferfish();
            }
        }

        if (comboNum > 8)
        {
            if (lastTimeSG >= timeBetweenSG)
            {
                lastTimeSG = 0;
                timeBetweenSG = Random.Range(150, 400);
                SpawnSeagull();
            }
        }

        lastTimeGF += 1;
        lastTimeTS += 1;
        lastTimePF += 1;
        lastTimeSG += 1;
    }

    public void OnGameStart()
    {
        //InvokeRepeating(nameof(SpawnObstacleType), 1f, 1f);
        //InvokeRepeating(nameof(SpawnStormClouds), 1.3f, 1.3f);
    }

    private void OnDisable()
    {
        //CancelInvoke(nameof(SpawnObstacleType));
        //CancelInvoke(nameof(SpawnStormClouds));
    }

    private void SpawnStormClouds()
    {
        cloudRandom = Random.Range(1, 7);
        if (cloudRandom == 1)
        {
            SpawnStormCloud1();
        }
        else if (cloudRandom == 2)
        {
            SpawnStormCloud2();
        }
        else if (cloudRandom == 3)
        {
            SpawnStormCloud3();
        }
        else if (cloudRandom == 4)
        {
            SpawnStormCloud4();
        }
        else if (cloudRandom == 5)
        {
            SpawnStormCloud5();
        }
        else if (cloudRandom == 6)
        {
            SpawnStormCloud6();
        }
    }

    private void SpawnStormCloud1()
    {
        GameObject storm_cloud = Instantiate(prefabStorm_Cloud1, transform.position, Quaternion.identity);
        storm_cloud.transform.position += Vector3.up * Random.Range(4.5f, 4.5f);
    }

    private void SpawnStormCloud2()
    {
        GameObject storm_cloud = Instantiate(prefabStorm_Cloud2, transform.position, Quaternion.identity);
        storm_cloud.transform.position += Vector3.up * Random.Range(4.5f, 4.5f);
    }

    private void SpawnStormCloud3()
    {
        GameObject storm_cloud = Instantiate(prefabStorm_Cloud3, transform.position, Quaternion.identity);
        storm_cloud.transform.position += Vector3.up * Random.Range(4.5f, 4.5f);
    }

    private void SpawnStormCloud4()
    {
        GameObject storm_cloud = Instantiate(prefabStorm_Cloud4, transform.position, Quaternion.identity);
        storm_cloud.transform.position += Vector3.up * Random.Range(4.5f, 4.5f);
    }

    private void SpawnStormCloud5()
    {
        GameObject storm_cloud = Instantiate(prefabStorm_Cloud5, transform.position, Quaternion.identity);
        storm_cloud.transform.position += Vector3.up * Random.Range(4.5f, 4.5f);
    }

    private void SpawnStormCloud6()
    {
        GameObject storm_cloud = Instantiate(prefabStorm_Cloud6, transform.position, Quaternion.identity);
        storm_cloud.transform.position += Vector3.up * Random.Range(4.5f, 4.5f);
    }

    public void SpawnFallingStar1()
    {
        GameObject falling_star = Instantiate(prefabFallingStar, transform.position, Quaternion.identity);
        falling_star.transform.position += Vector3.up * Random.Range(12f, 12f);
        falling_star.transform.position += Vector3.right * Random.Range(7f, 7f);
    }

    public void SpawnFallingStar2()
    {
        GameObject falling_star = Instantiate(prefabFallingStar, transform.position, Quaternion.identity);
        falling_star.transform.position += Vector3.up * Random.Range(12f, 12f);
        falling_star.transform.position += Vector3.right * Random.Range(9f, 9f);
    }

    public void SpawnFallingStar3()
    {
        GameObject falling_star = Instantiate(prefabFallingStar, transform.position, Quaternion.identity);
        falling_star.transform.position += Vector3.up * Random.Range(12f, 12f);
        falling_star.transform.position += Vector3.right * Random.Range(11f, 11f);
    }

    public void SpawnFallingStar4()
    {
        GameObject falling_star = Instantiate(prefabFallingStar, transform.position, Quaternion.identity);
        falling_star.transform.position += Vector3.up * Random.Range(12f, 12f);
        falling_star.transform.position += Vector3.right * Random.Range(13f, 13f);
    }

    public void SpawnFallingStar5()
    {
        GameObject falling_star = Instantiate(prefabFallingStar, transform.position, Quaternion.identity);
        falling_star.transform.position += Vector3.up * Random.Range(12f, 12f);
        falling_star.transform.position += Vector3.right * Random.Range(15f, 15f);
    }

    public void SpawnIslandSet()
    {
        islandNumbers++;

        if (islandNum <= 5)
        {
            islandRandom = Random.Range(1, 5);

            //Check for same last island
            if (islandRandom == lastIslandSet)
            {
                islandRandom += 1;
            }

            if (islandRandom > 7)
            {
                islandRandom = 1;
            }

            //Spawn island set
            if (islandRandom == 1)
            {
                lastIslandSet = 1;
                SpawnIslandSet1();
            }
            else if (islandRandom == 2)
            {
                lastIslandSet = 2;
                SpawnIslandSet2();
            }
            else if (islandRandom == 3)
            {
                lastIslandSet = 3;
                SpawnIslandSet3();
            }
            else if (islandRandom == 4)
            {
                lastIslandSet = 4;
                SpawnIslandSet4();
            }
            else if (islandRandom == 5)
            {
                lastIslandSet = 5;
                SpawnIslandSet5();
            }
            else if (islandRandom == 6)
            {
                lastIslandSet = 6;
                SpawnIslandSet6();
            }
            else if (islandRandom == 7)
            {
                lastIslandSet = 7;
                SpawnIslandSet7();
            }

            islandNum += 1;

        }
        else if (islandNum > 5 && islandNum <= 8)
        {
            //Start Storm Clouds
            if (islandNum == 6)
            {
                cameraMovement.ChangeMaxY_Low();
                InvokeRepeating(nameof(SpawnStormClouds), 1.0f, 1.0f);

                player_Controller.StopSpeedUp();
            }

            iceRandom = Random.Range(1, 4);

            //Check for same last ice set
            if (iceRandom == lastIceSet)
            {
                iceRandom += 1;
            }

            if (iceRandom > 3)
            {
                iceRandom = 1;
            }

            //Spawn ice set
            if (iceRandom == 1)
            {
                lastIceSet = 1;
                SpawnIceSet1();
            }
            else if (iceRandom == 2)
            {
                lastIceSet = 2;
                SpawnIceSet2();
            }
            else if (iceRandom == 3)
            {
                lastIceSet = 3;
                SpawnIceSet3();
            }

            islandNum += 1;

            if (islandNum == 9)
            {
                //Cancel Storm Clouds
                CancelInvoke(nameof(SpawnStormClouds));
            }
        }
        else if (islandNum == 9)
        {

            player_Controller.StartSpeedUp();
            cameraMovement.ChangeMaxY_High();

            //Spawn treasure location
            if (treasurePick == 1)
            {
                SpawnTreasureSet1();
            }
            else if (treasurePick == 2)
            {
                SpawnTreasureSet2();
            }

            islandNum = 1;

            //Dismiss big pirateship & stop cannons
            //??? WHY DOES IT STOP AOBVE CODE WORKING???
            //ALSO Big Pirateship not spawning NE more
            if (bigPirateshipExists)
            {
                bigPirateship.BigPirateshipLeave();
            }
                
        }
        
    }

    private void SpawnObstacleType()
    {
        if (skipObstacle > 0)
        {
            skipObstacle -= 1;
        }
        else
        {
            skipObstacle = 3;

            obstacleRandom = Random.Range(1, 6);

            if (obstacleRandom == lastObstacle)
            {
                lastObstacle += 1;
            }

            if (lastObstacle > 5)
            {
                lastObstacle = 1;
            }

            if (obstacleRandom == 1)
            {
                //SpawnBrickWall_Bot();
               // SpawnAllBrickWall();
                lastObstacle = 1;
            }
            else if (obstacleRandom == 2)
            {
                //SpawnAllBrickWall();
                lastObstacle = 2;
            }
            else if (obstacleRandom == 3)
            {
                BallLightning1();
                lastObstacle = 3;
            }
            else if (obstacleRandom == 4)
            {
                BallLightning2();
                lastObstacle = 4;
            }
            else if (obstacleRandom == 5)
            {
                BallLightning3();
                lastObstacle = 5;
            }
        } 
    }

    private void SpawnComboStarType()
    {
        SpawnStar_Top();
        SpawnStar_Bot();
    }


    //SPAWN Initial Island
    public void SpawnIslandSet0()
    {
        GameObject islandSet0 = Instantiate(prefabIslandSet0, transform.position, Quaternion.identity);
        islandSet0.transform.position += Vector3.left * Random.Range(12f, 12f);
    }

    //SPAWN Types
    private void SpawnIslandSet1()
    {
        GameObject islandSet1 = Instantiate(prefabIslandSet1, transform.position, Quaternion.identity);
        islandSet1.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIslandSet2()
    {
        GameObject islandSet2 = Instantiate(prefabIslandSet2, transform.position, Quaternion.identity);
        islandSet2.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIslandSet3()
    {
        GameObject islandSet3 = Instantiate(prefabIslandSet3, transform.position, Quaternion.identity);
        islandSet3.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIslandSet4()
    {
        GameObject islandSet4 = Instantiate(prefabIslandSet4, transform.position, Quaternion.identity);
        islandSet4.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIslandSet5()
    {
        GameObject islandSet5 = Instantiate(prefabIslandSet5, transform.position, Quaternion.identity);
        islandSet5.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIslandSet6()
    {
        GameObject islandSet6 = Instantiate(prefabIslandSet6, transform.position, Quaternion.identity);
        islandSet6.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIslandSet7()
    {
        GameObject islandSet7 = Instantiate(prefabIslandSet7, transform.position, Quaternion.identity);
        islandSet7.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIceSet1()
    {
        GameObject iceSet1 = Instantiate(prefabIceSet1, transform.position, Quaternion.identity);
        iceSet1.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIceSet2()
    {
        GameObject iceSet2 = Instantiate(prefabIceSet2, transform.position, Quaternion.identity);
        iceSet2.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnIceSet3()
    {
        GameObject iceSet3 = Instantiate(prefabIceSet3, transform.position, Quaternion.identity);
        iceSet3.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnTreasureSet1()
    {
        GameObject treasureSet1 = Instantiate(prefabTreasureSet1, transform.position, Quaternion.identity);
        treasureSet1.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    private void SpawnTreasureSet2()
    {
        GameObject treasureSet2 = Instantiate(prefabTreasureSet2, transform.position, Quaternion.identity);
        treasureSet2.transform.position += Vector3.left * Random.Range(3f, 3f);
    }

    //Spawn stars

    private void SpawnStar_Top()
    {
        GameObject starTop = Instantiate(prefabStar_Top, transform.position, Quaternion.identity);
        starTop.transform.position += Vector3.up * Random.Range(0, 0);
    }

    private void SpawnStar_Bot()
    {
        GameObject starBot = Instantiate(prefabStar_Bot, transform.position, Quaternion.identity);
        starBot.transform.position += Vector3.up * Random.Range(0, 0);
    }

    //BALL LIGHTNING
    private void BallLightning1()
    {
        GameObject ballLightning = Instantiate(prefabBallLightning, transform.position, Quaternion.identity);
        ballLightning.transform.position += Vector3.up * Random.Range(-1.5f, -1.5f);
    }

    private void BallLightning2()
    {
        GameObject ballLightning = Instantiate(prefabBallLightning, transform.position, Quaternion.identity);
        ballLightning.transform.position += Vector3.up * Random.Range(0, 0);
    }

    private void BallLightning3()
    {
        GameObject ballLightning = Instantiate(prefabBallLightning, transform.position, Quaternion.identity);
        ballLightning.transform.position += Vector3.up * Random.Range(1.5f, 1.5f);
    }

    //Big Priateship
    public void SpawnBigPirateship()
    {
        if (bigPirateshipExists == false && bigPirateshipToggle == 0)
        {
            GameObject bigPirateship = Instantiate(prefabBigPirateship, transform.position, Quaternion.identity);
            bigPirateship.transform.position += Vector3.left * Random.Range(55f, 55f);
            bigPirateship.transform.position += Vector3.up * Random.Range(-1.3f, -1.3f);
            bigPirateshipExists = true;
            bigPirateshipToggle = 2;
        }
        else
        {
            if (bigPirateshipExists == false && bigPirateshipToggle > 0)
            {
                bigPirateshipToggle--;
            }
        }
    }

    //SPAWN CREATURES
    private void SpawnGoldfish()
    {
        GameObject goldfish = Instantiate(prefabGoldfish, transform.position, Quaternion.identity);
        goldfish.transform.position += Vector3.down * Random.Range(minHeightGoldfish, maxHeightGoldfish);
    }

    private void SpawnTunaSnapping()
    {
        GameObject tunaSnapping = Instantiate(prefabTunaSnapping, transform.position, Quaternion.identity);
        tunaSnapping.transform.position += Vector3.down * Random.Range(minHeightTunaSnapping, maxHeightTunaSnapping);
    }

    private void SpawnPufferfish()
    {
        GameObject pufferfish = Instantiate(prefabPufferfish, transform.position, Quaternion.identity);
        pufferfish.transform.position += Vector3.down * Random.Range(minHeightPufferfish, maxHeightPufferfish);
    }

    private void SpawnSeagull()
    {
        GameObject seagull = Instantiate(prefabSeagull, transform.position, Quaternion.identity);
        seagull.transform.position += Vector3.down * Random.Range(minHeightSeagull, maxHeightSeagull);
    }

    private void SpawnPirateshipBlacksails()
    {
        GameObject pirateshipBlacksails = Instantiate(prefabPirateshipBlacksails, transform.position, Quaternion.identity);
        pirateshipBlacksails.transform.position += Vector3.down * Random.Range(minHeightPirateshipBlacksails, maxHeightPirateshipBlacksails);
    }

    //CORGI MAIN
    private void CorgiMain()
    {
        GameObject corgiMain = Instantiate(prefabcorgiMain, transform.position, Quaternion.identity);
        corgiMain.transform.position = Vector3.zero;
        cameraMovement.target = corgiMain.transform;
    }

    public void IncreaseScoreVisual()
    {
        scoreVisual = gameManager.score;
        scoreText.text = "Score: " + scoreVisual.ToString();
    }

    public void IncreaseComboScoreVisual()
    {
        scoreVisual = gameManager.score;
        scoreText.text = "Score: " + scoreVisual.ToString();
    }

    public void HighScoreVisual()
    {

    }

    public void IncreaseGBPVisual()
    {
        GBPVisual = gameManager.GBP;
        GBPText.text = " : " + GBPVisual.ToString();
    }

    //Adjust Background
    public void ChangeX_Left()
    {
        backgroundTop1.transform.position = new Vector3(backAdjust, 1, 0);
        backgroundBot1.transform.position = new Vector3(backAdjust, -4.5f, 0);
        backgroundBot2.transform.position = new Vector3(backAdjust, -4.5f, -1);

        if (backAdjust < 3)
        {
            backAdjust += 0.1f;
            Invoke(nameof(ChangeX_Left), 0.05f);
        }
    }

}
