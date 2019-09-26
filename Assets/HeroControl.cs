using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    public static float velocity = 5;
    public static float speed;
    private void Update()
    {
        GameObject.Find("Head").transform.eulerAngles = GameObject.Find("Main Camera").transform.eulerAngles;
        Moving();
    }
     
    void Moving()
    {
        //<|DIRECCIONAMIENTO>
        transform.eulerAngles = new Vector3(0, GameObject.Find("Main Camera").transform.eulerAngles.y, 0);
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

}




