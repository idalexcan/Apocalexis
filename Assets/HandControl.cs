using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public GameObject limb; 
    int timer = 0;
    GameObject hero;
    GameObject[] people;

    private void Awake()
    {
        hero = GameObject.Find("Rebanada");
        people = GameObject.FindGameObjectsWithTag("people");
    }

    void Update()
    {
        MoveClaw();
        AttackToHero();
    }

    ///------------------------------------------------------------------<|Ataque de la garra
    void AttackToHero()
    {
        if ((hero.transform.position - limb.transform.position).magnitude < 1)
        {
            hero.transform.position = limb.transform.position;
            
            if (HeroControl.life>0)
            {
                HeroControl.life -= 0.5f;
            }
        }
        
    }
    ///------------------------------------------------------------------<|Movimiento de garra
    void MoveClaw()
    {
        timer++;
        if (timer <= 30)
        {
            limb.transform.position += transform.up * 0.5f;
        }
        else if (timer <= 170)
        {
            if ((transform.position - limb.transform.position).magnitude > 0.3f)
            {
                limb.transform.position += (transform.position - limb.transform.position).normalized * 0.3f;
            }
        }
        else
        {
            timer = 0;
        }
    }

}
