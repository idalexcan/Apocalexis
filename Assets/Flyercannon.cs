using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyercannon : Enemys
{
    public GameObject[] alas = new GameObject[4];
    GameObject hero;
    private void Awake()
    {
        myzone = NPCcontrol.flyercannonZones[Random.Range(0, NPCcontrol.flyercannonZones.Length)];
        transform.position = PosInZone(3);
        hero = GameObject.Find("Rebanada");
    }

    private void Update()
    {

        Moving();
        FlyFx();
    }

    public new void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Spear")
        {
            StrikeReaction();
        }
        //Reaction("Spear", collision);
    }

    ///---------------------------------------------------------------------------------------<|Movimiento del flyercannon
    Vector3 aux;
    public void Moving()
    {
        transform.LookAt(hero.transform.position);
        timer++;
        if (timer == timelapse)
        {
            direcMove = (PosInZone(Random.Range(3, 15)) - transform.position).normalized;
            direcRotate = Random.Range(-3, 4);
            timer = 0;
            timelapse = Random.Range(5, 170);
        }
        transform.position += direcMove * 0.04f;
        transform.eulerAngles += new Vector3(0, direcRotate, 0);
    }

    ///---------------------------------------------------------------------------------------<|Efecto de aleteo
    int timerfly = 0, z;
    bool dir;
    Vector3 father;
    void FlyFx()
    {
        father = transform.eulerAngles;
        timerfly++;
        foreach (var item in alas)
        {
            dir = !dir;
            if (dir)
            {
                z = 4;
            }
            else
            {
                z = -4;
            }
            
            if (timerfly<8)
            {
                item.transform.eulerAngles += new Vector3(0, 0, z);
            }
            else if (timerfly==8)
            {
                item.transform.eulerAngles = new Vector3(father.x, father.y, 0);
            }
            else if (timerfly<=10)
            {
                item.transform.eulerAngles -= new Vector3(0, 0, z);
            }
            else
            {
                timerfly = 0;
            }
        }
    }
}
