using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyercannon : Enemys
{
    public GameObject[] alas = new GameObject[4];
    private void Awake()
    {
        myzone = NPCcontrol.flyercannonZones[Random.Range(0, NPCcontrol.flyercannonZones.Length)];
        transform.position = PosInZone();
    }

    private void Update()
    {

        //Moving();
        FlyFx();
    }

    ///---------------------------------------------------------------------------------------<|Movimiento del flyerclaw
    public void Moving()
    {
        timer++;
        if (timer == timelapse/2)
        {
            direcMove = (PosInZone() - transform.position).normalized;
        }
        else if (timer == timelapse)
        {
            
            direcRotate = Random.Range(-2, 3);
            timer = 0;
            timelapse = Random.Range(10, 180);
        }
        transform.position += direcMove * 0.1f;
        transform.eulerAngles += new Vector3(0, direcRotate, 0);
        //timer++;
        //if (timer == timelapse)
        //{
        //    direcMove = (PosInZone() - transform.position).normalized;
        //    direcRotate = Random.Range(-3, 4);
        //    timer = 0;
        //    timelapse = Random.Range(5, 170);
        //}
        //transform.position += direcMove * 0.04f;
        //transform.eulerAngles += new Vector3(0, direcRotate, 0);
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
                item.transform.eulerAngles = new Vector3(father.z, father.y, 0);
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
