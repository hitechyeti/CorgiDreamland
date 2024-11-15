using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsIce;

    [SerializeField] GameObject cloudEffect;
    [SerializeField] GameObject forwardDashEffect;
    [SerializeField] GameObject hat;

    public bool isJumping;

    private int running_hash = Animator.StringToHash("Running");
    private int flying_hash = Animator.StringToHash("Flying");
    private int sliding_hash = Animator.StringToHash("Sliding");
    private int jump_hash = Animator.StringToHash("Jump");

    private Vector2 newVelocity;
    private Vector2 fixVelocity;
    private Vector2 newForce;
    private Vector2 capsuleColliderSize;

    private CapsuleCollider2D cc;

    public int dreamType;

    public int anim_num;
    public Animator anim;

    public int trail_num;
    public int corgi_num;
    public int costume_num;

    //Tutorial Check
    public bool isTutorial;

    //Allow islands bool
    private bool allowIsland;

    //Speed upgrade
    public float speedIncrease;

    //Random Treat ComboStar
    private float randomTreatStar;

    //Alive Check
    public bool isAlive;

    //pause without changing time
    public int pause;

    //Sound Random Number
    public int ranDogEating;

    //Dash Settings
    public float dashTimer;
    public float dashLength;
    public bool dashing;
    public bool canDash;
    public bool canJump;
    public int jumpCounter;
    public int dashCounter;

    //Brick immunity after breaking
    public bool isBrickImmune;

    //Rotation options
    public Rigidbody2D rb;

    //Cloud Corgi Crash Prefab
    public GameObject prefabCloudCorgiCrash;
    public GameObject[] destroyObject1;

    //Corgi Hat Adjust
    public int corgiHatAdjust;

    //Grounded
    public bool grounded;
    public bool onIce;

    //gravity
    public float gravity;

    //Corgi Power Ups
    public bool bubbleShield;

    //start falling stars
    public bool fallingStars;
    public int randFallingStar;
    public int fallingStarCount;

    //Power Up Prefabs
    public GameObject prefabBubbleShield;

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

    private CostumeController costumeController;
    private GameManager gameManager;
    private Spawn_Hydrants spawn_Hydrants;
    private Hats hats;
    private Sound_Bubble sound_Bubble;
    private Sound_Bark sound_Bark;
    private Sound_DogEating sound_DogEating;
    private Sound_Dash sound_Dash;
    private Sound_ActivePirates sound_ActivePirates;
    private Sound_SpeedUp sound_SpeedUp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        rb.gravityScale = 0;
        cc = GetComponent<CapsuleCollider2D>();

        capsuleColliderSize = cc.size;

        //pause without chaning time
        pause = 1;

        //Alive Check
        isAlive = true;

        sound_Dash = FindObjectOfType<Sound_Dash>();
        sound_DogEating = FindObjectOfType<Sound_DogEating>();
        sound_Bark = FindObjectOfType<Sound_Bark>();
        sound_Bubble = FindObjectOfType<Sound_Bubble>();
        sound_ActivePirates = FindObjectOfType<Sound_ActivePirates>();
        sound_SpeedUp = FindObjectOfType<Sound_SpeedUp>();
        hats = FindObjectOfType<Hats>();
        spawn_Hydrants = FindObjectOfType<Spawn_Hydrants>();
        gameManager = FindObjectOfType<GameManager>();
        costumeController = FindObjectOfType<CostumeController>();
        trail_num = gameManager.trailNum;
        corgi_num = gameManager.corgiPickNum;
        costume_num = gameManager.costumePick;

        dashTimer = 0f;
        dashLength = 0.8f;
        dashing = false;

        canDash = true;
        canJump = true;
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        costumeController.costume_anim.SetBool("HasTail", gameManager.hasTail);

        dreamType = gameManager.dreamType;

        jumpCounter = 0;
        dashCounter = 0;

        //Speed Increase
        speedIncrease = 7;

        anim.SetInteger("CorgiNum", corgi_num);
        costumeController.costume_anim.SetInteger("CostumeNum", gameManager.costumePick);
        hats.hat_anim.SetInteger("HatNumber", gameManager.hatNum);

        //Corgi Power Ups
        bubbleShield = false;

        //Set brick immunityt o false
        isBrickImmune = false;

        //Allow Islands to spawn
        allowIsland = true;

        //start falling stars
        fallingStars = false;
        fallingStarCount = 0;

        StartSpeedUp();
    }

    public void StartCorgi()
    {
        rb.gravityScale = 2f;
    }


    private void Update()
    {
        if (pause == 0 && FindObjectOfType<pause_button>().paused == false)
        {
            KeyboardControls();
            //MobileControls();
        }
    }

    private void FixedUpdate()
    {
        if (pause == 0)
        {
            CheckGround();
            CheckIce();
            Dashing();
            ApplyMovement();
        }
    }

    private void CheckGround()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (grounded)
        {
            canJump = true;
            canDash = true;
            jumpCounter = 0;
            dashCounter = 0;
            anim.SetBool(running_hash, true);
            costumeController.costume_anim.SetBool(running_hash, true);
            hats.hat_anim.SetBool(running_hash, true);
            anim.SetBool(flying_hash, false);
            costumeController.costume_anim.SetBool(flying_hash, false);
            hats.hat_anim.SetBool(flying_hash, false);
        }
        else
        {
            rb.MoveRotation(0 * Time.deltaTime);
            anim.SetBool(running_hash, false);
            costumeController.costume_anim.SetBool(running_hash, false);
            hats.hat_anim.SetBool(running_hash, false);
        }
    }

    private void CheckIce()
    {
        onIce = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsIce);
        if (onIce)
        {
            canJump = true;
            canDash = true;
            jumpCounter = 0;
            dashCounter = 0;
            anim.SetBool(sliding_hash, true);
            costumeController.costume_anim.SetBool(sliding_hash, true);
            hats.hat_anim.SetBool(sliding_hash, true);
            anim.SetBool(flying_hash, false);
            costumeController.costume_anim.SetBool(flying_hash, false);
            hats.hat_anim.SetBool(flying_hash, false);
        }
        else
        {
            //rb.MoveRotation(0 * Time.deltaTime);
            anim.SetBool(sliding_hash, false);
            costumeController.costume_anim.SetBool(sliding_hash, false);
            hats.hat_anim.SetBool(sliding_hash, false);
        }
    }

    private void ApplyMovement()
    {
        //Set speed for platforms
        //FindObjectOfType<Island_Sets_Move>().speed = speedIncrease;

        //player movements
        if (grounded && !isJumping || onIce && !isJumping)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (!grounded && !onIce && dashing) //dashing
        {
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
        }
        else if (!grounded && !onIce) //If in air
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

            //set to flying when falling
            if (isJumping == false)
            {
                anim.SetBool(flying_hash, true);
                costumeController.costume_anim.SetBool(flying_hash, true);
                hats.hat_anim.SetBool(flying_hash, true);
            }
        }

        if (!grounded)//ice is always flat
        {
            rb.rotation = 0f;
        }

        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }

    private void Jump()
    {
        if (jumpCounter < 2)
        {
            jumpCounter++;
            rb.rotation = 0f;
            rb.gravityScale = gravity;
            isJumping = true;
            newVelocity.Set(0.0f, 0.0f);
            rb.velocity = newVelocity;
            newForce.Set(0.0f, jumpForce);
            rb.AddForce(newForce, ForceMode2D.Impulse);
            anim.SetTrigger(jump_hash);
            costumeController.costume_anim.SetTrigger(jump_hash);
            hats.hat_anim.SetTrigger(jump_hash);
            Instantiate(cloudEffect, transform);
        }
        if (jumpCounter == 0)
        {
            canJump = false;
        }
    }

    private void CloudJump()
    {
        rb.rotation = 0f;
        rb.gravityScale = gravity;
        isJumping = true;
        newVelocity.Set(0.0f, 0.0f);
        rb.velocity = newVelocity;
        newForce.Set(0.0f, jumpForce);
        rb.AddForce(newForce, ForceMode2D.Impulse);
        anim.SetTrigger(jump_hash);
        costumeController.costume_anim.SetTrigger(jump_hash);
        hats.hat_anim.SetTrigger(jump_hash);
        Instantiate(cloudEffect, transform);
        jumpCounter = 0;
    }

    private void Launch()
    {
        rb.rotation = 0f;
        newVelocity.Set(0.0f, 0.0f);
        rb.velocity = newVelocity;
        newForce.Set(0.0f, jumpForce * 0.8f);
        rb.AddForce(newForce, ForceMode2D.Impulse);
        //Dash();
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(IncreaseTimeScale));
    }

    public void StartSpeedUp()
    {
        InvokeRepeating(nameof(IncreaseTimeScale), 2.5f, 2.5f);
    }

    public void StartFallingStars()
    {
        InvokeRepeating(nameof(SummonFallingStars), 1.25f, 3.5f);
    }

    public void SummonFallingStars()
    {
        randFallingStar = Random.Range(1, 6);

        if (randFallingStar == 1)
        {
            spawn_Hydrants.SpawnFallingStar1();
        }
        else if (randFallingStar == 2)
        {
            spawn_Hydrants.SpawnFallingStar2();
        }
        else if (randFallingStar == 3)
        {
            spawn_Hydrants.SpawnFallingStar3();
        }
        else if (randFallingStar == 4)
        {
            spawn_Hydrants.SpawnFallingStar4();
        }
        else if (randFallingStar == 5)
        {
            spawn_Hydrants.SpawnFallingStar5();
        }

    }

    public void StopSpeedUp()
    {
        CancelInvoke(nameof(IncreaseTimeScale));
    }

    private void IncreaseTimeScale()
    {
        if (pause == 0)
        {

            if (speedIncrease < 9)
            {
                speedIncrease += 0.075f;
            }
            else if (speedIncrease < 10)
            {
                speedIncrease += 0.065f;
            }
            else if (speedIncrease < 11)
            {
                speedIncrease += 0.04f;
            }
            else if (speedIncrease < 12)
            {
                speedIncrease += 0.03f;
            }

            if (fallingStars == false && fallingStarCount >= 2)
            {
                fallingStars = true;
                StartFallingStars();
            }
        }
    }

    private void DecreaseTimeScale()
    {
        sound_SpeedUp.SpeedUp1();
        gameManager.stopwatch.transform.localScale = new Vector3(4, 4, 4);
        speedIncrease -= 1.0f;
        Invoke(nameof(ShrinkStopwatch), 1.5f);
    }

    private void ShrinkStopwatch()
    {
        gameManager.stopwatch.transform.localScale = new Vector3(0, 0, 0);
    }

    public void AddCorgiTrail()
    {
        //TRAILS ADDED TO CORGI
        if (trail_num == 1)
        {
            Instantiate(prefabCorgiTrail1, transform);
        }
        else if (trail_num == 2)
        {
            Instantiate(prefabStarTrail1, transform);
            Instantiate(prefabStarTrail2, transform);
            Instantiate(prefabStarTrail3, transform);
        }
        else if (trail_num == 3)
        {
            Instantiate(prefabGemTrail1, transform);
            Instantiate(prefabGemTrail2, transform);
            Instantiate(prefabGemTrail3, transform);
            Instantiate(prefabGemTrail4, transform);
            Instantiate(prefabGemTrail5, transform);
            Instantiate(prefabGemTrail6, transform);
        }
        else if (trail_num == 4)
        {
            Instantiate(prefabPumpkinTrail1, transform);
            Instantiate(prefabPumpkinTrail2, transform);
            Instantiate(prefabPumpkinTrail3, transform);
        }
        else if (trail_num == 5)
        {
            Instantiate(prefabCloverTrail1, transform);
            Instantiate(prefabCloverTrail2, transform);
            Instantiate(prefabCloverTrail3, transform);
        }
        else if (trail_num == 6)
        {
            Instantiate(prefabRibbinTrail1, transform);
        }
        else if (trail_num == 7)
        {
            Instantiate(prefabBoneTrail1, transform);
            Instantiate(prefabBoneTrail2, transform);
            Instantiate(prefabBoneTrail3, transform);
            Instantiate(prefabBoneTrail4, transform);
        }
        else if (trail_num == 8)
        {
            Instantiate(prefabHealTrail1, transform);
        }
        else if (trail_num == 9)
        {
            Instantiate(prefabOrbTrail1, transform);
            Instantiate(prefabOrbTrail2, transform);
            Instantiate(prefabOrbTrail3, transform);
        }
        else if (trail_num == 10)
        {
            Instantiate(prefabSlimeTrail1, transform);
            Instantiate(prefabSlimeTrail2, transform);
            Instantiate(prefabSlimeTrail3, transform);
        }
        else if (trail_num == 11)
        {
            Instantiate(prefabSnowflakeTrail1, transform);
            Instantiate(prefabSnowflakeTrail2, transform);
            Instantiate(prefabSnowflakeTrail3, transform);
            Instantiate(prefabSnowflakeTrail4, transform);
        }
        else if (trail_num == 12)
        {
            Instantiate(prefabBearTrail1, transform);
        }
        else if (trail_num == 13)
        {
            Instantiate(prefabHeartTrail1, transform);
            Instantiate(prefabHeartTrail2, transform);
            Instantiate(prefabHeartTrail3, transform);
        }
        else if (trail_num == 14)
        {
            Instantiate(prefabCoinTrail1, transform);
            Instantiate(prefabCoinTrail2, transform);
            Instantiate(prefabCoinTrail3, transform);
        }
        else if (trail_num == 15)
        {
            Instantiate(prefabCorgiRainbowTrail1, transform);
        }
    }

    private void Dash()
    {
        if (dashCounter < 2)
        {
            dashCounter++;
            dashing = true;
            Time.timeScale = 3f;
            dashTimer = 0;
            sound_Dash.Dash1();
            Instantiate(forwardDashEffect, transform);
        }
        if (dashCounter == 0)
        {
            canDash = false;
        }
    }

    private void Dashing()
    {
        //dash handling
        if (dashTimer < dashLength)
        {
            dashTimer += 1 * Time.deltaTime;
            isJumping = false;
        }
        else
        {
            Time.timeScale = 1f;
            dashing = false;
            rb.gravityScale = gravity;
        }

    }

    private void KeyboardControls()
    {
        //keyboard controls
        if (Input.GetKeyDown("space"))
        {
            if (canJump)
            {
                Jump();
            }
        }

        if (Input.GetKeyDown("a"))
        {
            if (canDash)
            {
                Dash();
            }
        }

    }

    private void MobileControls()
    {
        //mobile controls
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //var touch = Input.touches[0];

            if (touch.position.x + 90 < Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (gameManager.controlMode == 1)
                    {
                        if (canDash)
                        {
                            Dash();
                        }
                    }
                    else if (gameManager.controlMode == 2)
                    {
                        if (canJump)
                        {
                            Jump();
                        }

                    }
                }
            }
            else if (touch.position.x - 90 > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (gameManager.controlMode == 1)
                    {
                        if (canJump)
                        {
                            Jump();
                        }
                    }
                    else if (gameManager.controlMode == 2)
                    {
                        if (canDash)
                        {
                            Dash();
                        }
                    }
                }
            }

        }
    }

    public void GameOver()
    {
        gameManager.EndGameOver();
    }

    public void Pause()
    {
        pause = 1;
        Time.timeScale = 1f;
        anim.SetTrigger("StartGameOver");
        costumeController.costume_anim.SetTrigger("StartGameOver");
        hats.hat_anim.SetTrigger("StartGameOver");
        destroyObject1 = GameObject.FindGameObjectsWithTag("trail");

        foreach (GameObject oneObject in destroyObject1)
            Destroy(oneObject);
    }

    public void CorgiCloudGameover()
    {
        Instantiate(prefabCloudCorgiCrash, transform);
    }

    private void EndJump()
    {
        isJumping = false;
        anim.SetBool(flying_hash, true);
        costumeController.costume_anim.SetBool(flying_hash, true);
        hats.hat_anim.SetBool(flying_hash, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pause == 0)
        {
            if (isAlive == true)
            {
                if (collision.gameObject.transform.tag == "Cloud")
                {
                    CloudJump();
                }
                else if (collision.gameObject.transform.tag == "BubblePowerUp")
                {
                    if (bubbleShield == false)
                    {
                        sound_Bubble.BubbleGet();
                        bubbleShield = true;
                        Instantiate(prefabBubbleShield, transform);
                    }
                    else
                    {
                        sound_Bubble.BubbleGet();
                        gameManager.BubblePowerupScore();
                        spawn_Hydrants.IncreaseComboScoreVisual();
                    }
                }
                else if (collision.gameObject.transform.tag == "SlowDown")
                {
                    Destroy(collision.gameObject);
                    DecreaseTimeScale();
                }
                else if (collision.gameObject.transform.tag == "Hydrant")
                {
                    if (bubbleShield == true)
                    {
                        FindObjectOfType<BubbleShield>().bubble_anim.SetTrigger("Pop");
                    }
                    gameManager.StartGameOver();
                    CorgiCloudGameover();
                }
                else if (collision.gameObject.transform.tag == "Cannonball")
                {
                    if (bubbleShield == true)
                    {
                        FindObjectOfType<BubbleShield>().bubble_anim.SetTrigger("Pop");
                    }
                    else
                    {
                        gameManager.StartGameOver();
                        CorgiCloudGameover();
                    }
                }
                else if (collision.gameObject.transform.tag == "AllowIslandSet")
                {
                    Destroy(collision.gameObject);
                    allowIsland = true;
                }
                else if (collision.gameObject.transform.tag == "IslandSet")
                {
                    if (allowIsland == true)
                    {
                        Destroy(collision.gameObject);
                        allowIsland = false;
                        spawn_Hydrants.SpawnIslandSet();
                        spawn_Hydrants.SpawnBigPirateship();
                    }
                }
                else if (collision.gameObject.transform.tag == "Water")
                {
                    if (bubbleShield == true)
                    {
                        FindObjectOfType<BubbleShield>().bubble_anim.SetTrigger("Pop");
                    }
                    gameManager.StartGameOver();
                    CorgiCloudGameover();
                }
                else if (collision.gameObject.transform.tag == "Scoring")
                {
                    gameManager.IncreaseScore();
                    spawn_Hydrants.IncreaseScoreVisual();
                }
                else if (collision.gameObject.transform.tag == "TopOrBotStar")
                {
                    randomTreatStar = Random.Range(1, 3);
                    if (randomTreatStar == 1)
                    {
                        Destroy(collision.gameObject);
                        FindObjectOfType<CreateDogTreatsTop>().SpawnTreat();
                        FindObjectOfType<CreateComboStarTop>().CreateTopStar();

                    }
                    else if (randomTreatStar == 2)
                    {
                        Destroy(collision.gameObject);
                        FindObjectOfType<CreateDogTreatsBot>().SpawnTreat();
                        FindObjectOfType<CreateComboStarBot>().CreateBotStar();

                    }
                }
                else if (collision.gameObject.transform.tag == "ResetStarCombo")
                {
                    gameManager.comboScoreTracker = 0;
                    spawn_Hydrants.comboNum = 0;
                    //Close treasure room
                    spawn_Hydrants.treasurePick = 1;
                }
                else if (collision.gameObject.transform.tag == "RestartGameLoop")
                {
                    //reset treasure room to open
                    spawn_Hydrants.treasurePick = 2;
                    fallingStarCount += 1;
                }
                else if (collision.gameObject.transform.tag == "ComboStar")
                {
                    ranDogEating = Random.Range(1, 2);
                    if (ranDogEating == 1)
                    {
                        sound_DogEating.DogEating1();
                    }
                    else if (ranDogEating == 2)
                    {
                        sound_DogEating.DogEating2();
                    }
                    Destroy(collision.gameObject);
                    spawn_Hydrants.comboNum++;
                    gameManager.IncreaseComboScore();
                    spawn_Hydrants.IncreaseComboScoreVisual();
                }
                else if (collision.gameObject.transform.tag == "ResetTreatCombo")
                {
                    gameManager.comboTreatTracker = 0;
                }
                else if (collision.gameObject.transform.tag == "DogTreat1")
                {
                    ranDogEating = Random.Range(1, 2);
                    if (ranDogEating == 1)
                    {
                        sound_DogEating.DogEating1();
                    }
                    else if (ranDogEating == 2)
                    {
                        sound_DogEating.DogEating2();
                    }
                    Destroy(collision.gameObject);
                    gameManager.IncreaseGBP1();
                    spawn_Hydrants.IncreaseGBPVisual();
                    gameManager.IncreaseScore();
                    spawn_Hydrants.IncreaseScoreVisual();

                }
                else if (collision.gameObject.transform.tag == "DogTreat2")
                {
                    ranDogEating = Random.Range(1, 3);
                    if (ranDogEating == 1)
                    {
                        sound_Bark.Bark1();
                    }
                    else if (ranDogEating == 2)
                    {
                        sound_Bark.Bark2();
                    }
                    else if (ranDogEating == 3)
                    {
                        sound_Bark.Bark3();
                    }
                    Destroy(collision.gameObject);
                    gameManager.IncreaseGBP2();
                    spawn_Hydrants.IncreaseGBPVisual();
                    gameManager.IncreaseScore();
                    spawn_Hydrants.IncreaseScoreVisual();

                }
                else if (collision.gameObject.transform.tag == "DogTreat3")
                {
                    ranDogEating = Random.Range(1, 2);
                    if (ranDogEating == 1)
                    {
                        sound_DogEating.DogEating1();
                    }
                    else if (ranDogEating == 2)
                    {
                        sound_DogEating.DogEating2();
                    }
                    Destroy(collision.gameObject);
                    gameManager.IncreaseGBP3();
                    spawn_Hydrants.IncreaseGBPVisual();
                    gameManager.IncreaseScore();
                    spawn_Hydrants.IncreaseScoreVisual();

                }
                else if (collision.gameObject.transform.tag == "DogTreat8")
                {
                    ranDogEating = Random.Range(1, 3);
                    if (ranDogEating == 1)
                    {
                        sound_Bark.Bark1();
                    }
                    else if (ranDogEating == 2)
                    {
                        sound_Bark.Bark2();
                    }
                    else if (ranDogEating == 3)
                    {
                        sound_Bark.Bark3();
                    }
                    Destroy(collision.gameObject);
                    gameManager.IncreaseGBP8();
                    spawn_Hydrants.IncreaseGBPVisual();
                    gameManager.IncreaseScore();
                    spawn_Hydrants.IncreaseScoreVisual();

                }
                else if (collision.gameObject.transform.tag == "Pirate")
                {
                    sound_ActivePirates.PirateOyStopThat1();
                }
                else if (collision.gameObject.transform.tag == "Mole")
                {
                    CloudJump();
                    dashCounter--;
                    canDash = true;
                    if (dashCounter < 0)
                    {
                        dashCounter = 0;
                    }
                }
                else if (collision.gameObject.transform.tag == "EndTutorial")
                {
                    gameManager.TutorialGameOver();
                    CorgiCloudGameover();
                }

            }
        }
    }

}