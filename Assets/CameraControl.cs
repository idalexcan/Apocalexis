using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static float rotY;
    float x = 0, y = 0;

    private void Start()
    {
        //GameObject.Find("sujeto").AddComponent<Prueba>();
    }

    void Update()
    {
        transform.position = GameObject.Find("Rebanada").transform.position;
        transform.position += new Vector3(0, 0.25f, 0);
        x -= Input.GetAxis("Mouse Y");
        y += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(x, y, 0);
        rotY = transform.eulerAngles.y;
    }
    
}

public class Prueba : MonoBehaviour
{
    int timer = 0;
    Vector3 initialpos;
    private void Start()
    {
        initialpos = transform.position;
    }
    private void Update()
    {
        timer++;
        if (timer<5)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += new Vector3(0.5f, 0, 0);
            }
            
        }
        else if (timer<10)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position -= new Vector3(0.5f, 0, 0);
            }

        }
        else
        {
            timer = 0;
            transform.position = initialpos;
        }
    }
}

