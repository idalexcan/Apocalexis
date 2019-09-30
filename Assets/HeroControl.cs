using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    public static float velocity = 5;
    public static float speed;
    public GameObject levitus;
    
    private void Awake()
    {
        //GameObject.Find("Proyectile").AddComponent<Proyectile>();
    }
    private void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
        //    LevitusControl();
        //}
        //else
        //{
        //    Moving();
        //}
        Moving();

        //GameObject.Find("Proyectile").GetComponent<Proyectile>().initialpos = transform.position;
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
            
            if (Input.GetMouseButton(1))
            {
                levitus.transform.position += transform.forward * speed / 50;
            }
            else
            {
                transform.position += transform.forward * speed / 50;
            }
        }
        if (Input.GetKey("s"))
        {
            
            if (Input.GetMouseButton(1))
            {
                levitus.transform.position -= transform.forward * speed / 50;
            }
            else
            {
                transform.position -= transform.forward * speed / 50;
            }
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

    void LevitusControl()
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
            levitus.transform.position += transform.forward * speed / 50;
        }
        if (Input.GetKey("s"))
        {
            levitus.transform.position -= transform.forward * speed / 50;
        }
        //if (Input.GetKey("d"))
        //{
        //    levitus.transform.position += transform.right * speed / 50;
        //}
        //if (Input.GetKey("a"))
        //{
        //    levitus.transform.position -= transform.right * speed / 50;
        //}
        //levitus.transform.position += new Vector3(Input.GetAxis("Mouse X") * 0.1f, Input.GetAxis("Mouse Y") * 0.1f, 0);
    }
}


public class Proyectile : MonoBehaviour
{
    float impulse;
    float impulseaux;
    bool shot;
    int timer=0;

    public Vector3 initialpos;
    
    private void Update()
    {
        //Debug.Log(Input.GetMouseButton(0));
        
        if (timer==100)
        {
            Shot();
        }
        else
        {
            timer++;
            Debug.Log("waiting!!");
        }
    }

    void Shot()
    {
        if (Input.GetMouseButton(0))
        {
            impulse += 25;

        }
        else if (impulse != 0)
        {
            shot = true;
            impulseaux = impulse;
            impulse = 0;
        }
        if (shot)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * impulseaux);
            Debug.Log("LANZAMIENTO!---------->" + impulseaux);
            shot = false;
        }

        if (Input.GetMouseButton(1))
        {
            transform.position = initialpos + new Vector3(0, 0, 2);
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }
}

