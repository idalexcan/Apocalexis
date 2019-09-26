using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    public static float velocity = 5;
    public static float speed;
    public GameObject mybody;
    bool looking;
    private void Update()
    {
        GameObject.Find("Head").transform.eulerAngles = GameObject.Find("Main Camera").transform.eulerAngles;
        Moving();
    }
     
    void Moving()
    {
        //if (looking)
        //{
        //    transform.eulerAngles = new Vector3(0, CameraControl.rotY, 0);transform.eulerAngles = new Vector3(0, CameraControl.rotY, 0);
        //}
        transform.eulerAngles = new Vector3(0, CameraControl.rotY, 0); //transform.eulerAngles = new Vector3(0, CameraControl.rotY, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = velocity * 2;
        }
        else
        {
            speed = velocity;
        }
        if (Input.GetKey("w"))
        {
            //looking = true;
            transform.position += transform.forward * speed / 50;
            mybody.transform.eulerAngles = new Vector3(speed, transform.eulerAngles.y, 0);
        }
        else if (Input.GetKey("s"))
        {
            //looking = true;
            transform.position -= transform.forward * speed / 50;
            mybody.transform.eulerAngles = new Vector3(-speed, transform.eulerAngles.y, 0);
        }
        else if (Input.GetKey("d"))
        {
            //looking = true;
            transform.position += transform.right * speed / 50;
        }
        else if (Input.GetKey("a"))
        {
            //looking = true;
            transform.position -= transform.right * speed / 50;
        }
        else
        {
            //looking = false;
            mybody.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

}




