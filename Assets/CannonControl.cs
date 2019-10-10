using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletbase;
    int timer;
    int timelapse=100;

    private void Awake()
    {
        bullet.GetComponent<SphereCollider>().enabled = false;
        
    }
    
    private void Update()
    {
        timer++;
        if (timer < (int)(timelapse * 0.4f))
        {
            bullet.transform.position = bulletbase.transform.position;
        }
        else if (timer == (int)(timelapse * 0.4f))
        {
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(10,25)*1000);
            bullet.GetComponent<SphereCollider>().enabled = true;
        }
        else if (timer == (int)(timelapse * 0.7f))
        {
            bullet.GetComponent<Rigidbody>().useGravity = true;
        }
        else if (timer == timelapse) 
        {
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            bullet.GetComponent<Rigidbody>().useGravity = false;
            bullet.transform.position = bulletbase.transform.position;
            bullet.GetComponent<SphereCollider>().enabled = false;
            timer = 0;
            timelapse = Random.Range(40, 400);

        }
        //Debug.Log(timelapse + "-->" + (int)(timelapse * 0.4f));
    }
}
