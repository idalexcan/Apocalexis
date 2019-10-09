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
    public static Vector3 pos;
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
            pos = transform.position;
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



