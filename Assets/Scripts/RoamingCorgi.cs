using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingCorgi : MonoBehaviour
{

    public int speed = 0;
    public int direction = 1;

    public int corgiState = 0;
    public int stateSwitchTimer = 0;
    public int stateSwitch = 0;

    public int sitting = 0;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        transform.position = new Vector3(-5.5f, -3.0f, 0f);
        speed = 0;
        direction = 1;
        corgiState = 1;
        stateSwitchTimer = 30;
        stateSwitch = 0;
        sitting = 1;
    }

    void FixedUpdate()
    {
        
        if (transform.position.x >= 7.5f)
        {
            direction = 0;
        }
        else if (transform.position.x <= -7.5f)
        {
            direction = 1;
        }

        if (direction == 0)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (direction == 1)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        if (stateSwitchTimer > 0)
        {
            stateSwitchTimer -= 1;
        }

        if (stateSwitchTimer == 0)
        {
            corgiState = Random.Range(1, 8);
            stateSwitch = 0;

            if (corgiState == 5 && sitting == 0)
            {
                sitting = 1;
            }
            else if (corgiState == 5 && sitting == 1)
            {
                corgiState = 4;
                sitting = 0;
            }
        }

        if (corgiState == 1 && stateSwitchTimer == 0 && stateSwitch == 0)
        {
            anim.SetTrigger("idle1");
            stateSwitchTimer = 300;
            speed = 0;
            stateSwitch = 1;
        }
        else if (corgiState == 2 && stateSwitchTimer == 0 && stateSwitch == 0)
        {
            anim.SetTrigger("idle2");
            stateSwitchTimer = 300;
            speed = 0;
            stateSwitch = 1;
        }
        else if (corgiState == 3 && stateSwitchTimer == 0 && stateSwitch == 0)
        {
            anim.SetTrigger("running");
            stateSwitchTimer = 300;
            speed = 3;
            stateSwitch = 1;
        }
        else if (corgiState == 4 && stateSwitchTimer == 0 && stateSwitch == 0)
        {
            anim.SetTrigger("running");
            stateSwitchTimer = 300;
            speed = 3;
            stateSwitch = 1;
        }
        else if (corgiState == 5 && stateSwitchTimer == 0 && stateSwitch == 0)
        {
            anim.SetTrigger("sit");
            stateSwitchTimer = 300;
            speed = 0;
            stateSwitch = 1;
        }
        else if (corgiState == 6 && stateSwitchTimer == 0 && stateSwitch == 0)
        {
            anim.SetTrigger("sniff");
            stateSwitchTimer = 300;
            speed = 0;
            stateSwitch = 1;
        }
        else if (corgiState == 7 && stateSwitchTimer == 0 && stateSwitch == 0)
        {
            anim.SetTrigger("sniffwalk");
            stateSwitchTimer = 300;
            speed = 1;
            stateSwitch = 1;
        }
        else if (corgiState == 8 && stateSwitchTimer == 0 && stateSwitch == 0)
        {
            anim.SetTrigger("walk");
            stateSwitchTimer = 300;
            speed = 2;
            stateSwitch = 1;
        }

    }

    void Sit()
    {
        anim.SetTrigger("sitting");
    }

}
