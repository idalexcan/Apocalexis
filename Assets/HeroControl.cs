using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroControl : MonoBehaviour
{
    public static float velocity = 5;
    public static float speed;
    public static float life = 100;
    public static int specialHab=50;
    public Text specialhab;
    public Text showlife;
    GameObject failed;

    private void Awake()
    {
        failed = GameObject.Find("Failed");
        failed.SetActive(false);
    }
    private void Update()
    {
        if (life>0)
        {
            Moving();
            Impulse();
            LifeThings();
        }
        else
        {
            failed.SetActive(true);
        }
        
    }
     
    void Moving()
    {
        //<|DIRECCIONAMIENTO>
        transform.eulerAngles = new Vector3(0, GameObject.Find("Main Camera").transform.eulerAngles.y, 0);
        GameObject.Find("Head").transform.eulerAngles = GameObject.Find("Main Camera").transform.eulerAngles;
        //<|CAMBIO DE VELOCIDAD|>
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = velocity * 2;
        }
        else
        {
            speed = velocity;
        }
        //<|MOVIMIENTO>
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * speed / 50;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * speed / 50;
        }

        if (Input.GetKey("d"))
        {
            transform.position += transform.right * speed / 50;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * speed / 50;
        }
        
    }

    void Impulse()
    {
        if (Input.GetMouseButton(1))
        {
            if (specialHab>0)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    transform.position += transform.forward * 15;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.position -= transform.forward * 15;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    transform.position += transform.up * 15;
                }
                specialHab--;
            }
        }
        else
        {
            if (specialHab<50)
            {
                specialHab++;
            }
            
        }
        specialhab.text = "SPECIAL HAB:"+specialHab;
    }
    
    void LifeThings()
    {
        showlife.text = "LIFE:" + life;
    }
}



//public class Proyectile : MonoBehaviour
//{
//    float impulse;
//    float impulseaux;
//    bool shot;
//    int timer=0;

//    public Vector3 initialpos;
    
//    private void Update()
//    {
//        if (timer==100)
//        {
//            Shot();
//        }
//        else
//        {
//            timer++;
//            Debug.Log("waiting!!");
//        }
//    }

//    void Shot()
//    {
//        if (Input.GetMouseButton(0))
//        {
//            impulse += 25;

//        }
//        else if (impulse != 0)
//        {
//            shot = true;
//            impulseaux = impulse;
//            impulse = 0;
//        }
//        if (shot)
//        {
//            GetComponent<Rigidbody>().AddForce(transform.forward * impulseaux);
//            Debug.Log("LANZAMIENTO!---------->" + impulseaux);
//            shot = false;
//        }

//        if (Input.GetMouseButton(1))
//        {
//            transform.position = initialpos + new Vector3(0, 0, 2);
//            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
//        }
//    }
//}

