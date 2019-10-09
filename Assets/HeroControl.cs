using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroControl : MonoBehaviour
{
    public static float velocity = 5;
    public static float speed;
    public static float life = 100;
    public static int hability=50;
    public static Vector3 pos;

    private void Update()
    {
        if (life > 0 && pos.y > -100 && NPCcontrol.enemies > 0) 
        {
            Moving();
            Impulse();
            pos = transform.position;
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
            if (hability>0)
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
                hability--;
            }
        }
        else
        {
            if (hability<50)
            {
                hability++;
            }
            
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name=="Bullet")
        {
            life = life - 5;
        }
        if (collision.gameObject.GetComponent<Person>())
        {
            if (collision.gameObject.GetComponent<Person>().infected)
            {
                life -= 1;
            }
        }
        
    }
}



