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

        if (taked!=null)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                //taked.transform.eulerAngles = transform.eulerAngles;
                taked.GetComponent<Rigidbody>().AddForce(GameObject.Find("Head").transform.forward * 2000);////new Vector3(0,2,3)*1000)
                throwed = true;
                taked = null;
            }
            else
            {
                if (!throwed)
                {
                    taked.transform.position = transform.position;
                    taked.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
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
        //Debug.Log("lanzamiento:"+throwed+" objeto:"+taked)
        Debug.Log(taked);
        
    }
}
