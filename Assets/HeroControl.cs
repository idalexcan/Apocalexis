using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    public static float velocity = 5;
    public static float speed;
    
    private void Awake()
    {
        GameObject.Find("Impulser").AddComponent<Proyectile>();
    }
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


public class Proyectile : MonoBehaviour
{
    float impulse;
    float impulseaux;
    bool shot;

    private void Update()
    {
        Debug.Log(impulse);
        if (Input.GetKey(KeyCode.Space))
        {
            impulse += 25;
            
        }
        else if (impulse!=0)
        {
            shot = true;
            impulseaux = impulse;
            impulse = 0;
        }
        if (shot)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * impulseaux);
            Debug.Log("LANZAMIENTO!---------->"+impulseaux);
            shot = false;
        }
    }
}

