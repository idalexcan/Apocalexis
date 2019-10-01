using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitus : MonoBehaviour
{
    GameObject taked;
    bool throwed;
    int timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("weapon"))
        {
            if (!throwed)
            {
                if ((item.transform.position - transform.position).magnitude < 0.2f)
                {
                    taked = item;

                }
            }
            
        }

        if (taked != null && taked.transform.name == "Spear") 
        {
            taked.transform.eulerAngles = GameObject.Find("Head").transform.eulerAngles;
            if (Input.GetMouseButtonDown(0))
            {
                taked.GetComponent<Rigidbody>().AddForce((GameObject.Find("Shotpoint").transform.position-transform.position).normalized * 2000);////new Vector3(0,2,3)*1000)
                throwed = true;
                taked = null;
            }
            else
            {
                if (!throwed)
                {
                    taked.transform.position = transform.position;
                }
            }
        }
        if (throwed)
        {
            timer++;
            if (timer==70)
            {
                throwed = false;
                timer = 0;
            }
        }
    }
}
