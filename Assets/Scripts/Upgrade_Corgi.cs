using UnityEngine;

public class Upgrade_Corgi : MonoBehaviour
{
    [SerializeField] GameObject hat;
    [SerializeField] GameObject flyingCorgi;

    Animator example_anim;
    public int anim_num;

    public int example_trail_num;
    public int example_corgi_num;

    //Corgi Hat Adjust
    public int corgiHatAdjust;

    //Trail Prefabs
    public GameObject prefabStarTrail1;
    public GameObject prefabStarTrail2;
    public GameObject prefabStarTrail3;

    public GameObject prefabCorgiTrail1;

    public GameObject prefabGemTrail1;
    public GameObject prefabGemTrail2;
    public GameObject prefabGemTrail3;
    public GameObject prefabGemTrail4;
    public GameObject prefabGemTrail5;
    public GameObject prefabGemTrail6;

    public GameObject prefabPumpkinTrail1;
    public GameObject prefabPumpkinTrail2;
    public GameObject prefabPumpkinTrail3;

    public GameObject prefabCloverTrail1;
    public GameObject prefabCloverTrail2;
    public GameObject prefabCloverTrail3;

    public GameObject prefabRibbinTrail1;

    public GameObject prefabBoneTrail1;
    public GameObject prefabBoneTrail2;
    public GameObject prefabBoneTrail3;
    public GameObject prefabBoneTrail4;

    public GameObject prefabHealTrail1;

    public GameObject prefabOrbTrail1;
    public GameObject prefabOrbTrail2;
    public GameObject prefabOrbTrail3;

    public GameObject prefabSlimeTrail1;
    public GameObject prefabSlimeTrail2;
    public GameObject prefabSlimeTrail3;

    public GameObject prefabSnowflakeTrail1;
    public GameObject prefabSnowflakeTrail2;
    public GameObject prefabSnowflakeTrail3;
    public GameObject prefabSnowflakeTrail4;

    public GameObject prefabBearTrail1;

    public GameObject prefabHeartTrail1;
    public GameObject prefabHeartTrail2;
    public GameObject prefabHeartTrail3;

    public GameObject prefabCoinTrail1;
    public GameObject prefabCoinTrail2;
    public GameObject prefabCoinTrail3;

    public GameObject prefabCorgiRainbowTrail1;

    public GameObject[] destroyObject1;

    private void Awake()
    {
        example_corgi_num = 0;
        example_trail_num = 0;
    }

    private void Start()
    {
        example_anim = gameObject.GetComponent<Animator>();
        example_trail_num = FindObjectOfType<GameManager>().trailNum;
        Trails();
    }

    private void Corgi_And_Costume()
    {
        //CORGIS VIA ANIMATION
        example_anim.SetInteger("CorgiNum", example_corgi_num);

        FindObjectOfType<CostumeController>().costume_anim.SetInteger("CostumeNum", FindObjectOfType<GameManager>().costumePick);
        FindObjectOfType<CostumeController>().costume_anim.SetBool("HasTail", FindObjectOfType<GameManager>().hasTail);
        FindObjectOfType<Hats>().hat_anim.SetInteger("HatNumber", FindObjectOfType<GameManager>().hatNum);
    }

    public void DestroyTrails()
    {
        //DESTROY OLD TRAIL
        destroyObject1 = GameObject.FindGameObjectsWithTag("trail");

        foreach (GameObject oneObject in destroyObject1)
            Destroy(oneObject);
    }

    public void Trails()
    {
        //DESTROY OLD TRAIL
        destroyObject1 = GameObject.FindGameObjectsWithTag("trail");

        foreach (GameObject oneObject in destroyObject1)
            Destroy(oneObject);

        //TRAILS ADDED TO CORGI
        if (example_trail_num == 0)
        {
            destroyObject1 = GameObject.FindGameObjectsWithTag("trail");
        }
        else if (example_trail_num == 1)
        {
            Instantiate(prefabCorgiTrail1, transform);
        }
        else if (example_trail_num == 2)
        {
            Instantiate(prefabStarTrail1, transform);
            Instantiate(prefabStarTrail2, transform);
            Instantiate(prefabStarTrail3, transform);
        }
        else if (example_trail_num == 3)
        {
            Instantiate(prefabGemTrail1, transform);
            Instantiate(prefabGemTrail2, transform);
            Instantiate(prefabGemTrail3, transform);
            Instantiate(prefabGemTrail4, transform);
            Instantiate(prefabGemTrail5, transform);
            Instantiate(prefabGemTrail6, transform);
        }
        else if (example_trail_num == 4)
        {
            Instantiate(prefabPumpkinTrail1, transform);
            Instantiate(prefabPumpkinTrail2, transform);
            Instantiate(prefabPumpkinTrail3, transform);
        }
        else if (example_trail_num == 5)
        {
            Instantiate(prefabCloverTrail1, transform);
            Instantiate(prefabCloverTrail2, transform);
            Instantiate(prefabCloverTrail3, transform);
        }
        else if (example_trail_num == 6)
        {
            Instantiate(prefabRibbinTrail1, transform);
        }
        else if (example_trail_num == 7)
        {
            Instantiate(prefabBoneTrail1, transform);
            Instantiate(prefabBoneTrail2, transform);
            Instantiate(prefabBoneTrail3, transform);
            Instantiate(prefabBoneTrail4, transform);
        }
        else if (example_trail_num == 8)
        {
            Instantiate(prefabHealTrail1, transform);
        }
        else if (example_trail_num == 9)
        {
            Instantiate(prefabOrbTrail1, transform);
            Instantiate(prefabOrbTrail2, transform);
            Instantiate(prefabOrbTrail3, transform);
        }
        else if (example_trail_num == 10)
        {
            Instantiate(prefabSlimeTrail1, transform);
            Instantiate(prefabSlimeTrail2, transform);
            Instantiate(prefabSlimeTrail3, transform);
        }
        else if (example_trail_num == 11)
        {
            Instantiate(prefabSnowflakeTrail1, transform);
            Instantiate(prefabSnowflakeTrail2, transform);
            Instantiate(prefabSnowflakeTrail3, transform);
            Instantiate(prefabSnowflakeTrail4, transform);
        }
        else if (example_trail_num == 12)
        {
            Instantiate(prefabBearTrail1, transform);
        }
        else if (example_trail_num == 13)
        {
            Instantiate(prefabHeartTrail1, transform);
            Instantiate(prefabHeartTrail2, transform);
            Instantiate(prefabHeartTrail3, transform);
        }
        else if (example_trail_num == 14)
        {
            Instantiate(prefabCoinTrail1, transform);
            Instantiate(prefabCoinTrail2, transform);
            Instantiate(prefabCoinTrail3, transform);
        }
        else if (example_trail_num == 15)
        {
            Instantiate(prefabCorgiRainbowTrail1, transform);
        }

    }

    private void Update()
    {
        example_corgi_num = FindObjectOfType<GameManager>().corgiPickNum;

        Corgi_And_Costume();
    }

}
