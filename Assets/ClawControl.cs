using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawControl : BodyController
{
    public GameObject mybody;
    GameObject closebody;
    bool boxcollActive=true;
    public bool positionate = true;
    void Start()
    {
        GetComponent<BoxCollider>().enabled = boxcollActive;
        transform.position = mybody.transform.position;
    }
    
    private void Update()
    {
        //transform.position = new Vector3(transform.position.x, mybody.transform.position.y + 0.5f, transform.position.y);
        //if (positionate)
        //{
        //    transform.position = mybody.transform.position;
        //}

        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * 0.07f;
        }
        else if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * 0.07f;
        }
        else
        {
            if ((mybody.transform.position - transform.position).magnitude > 1)
            {
                transform.position += (mybody.transform.position - transform.position).normalized * 0.05f;
            }
        }

        foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
        {
            boxcollActive = (item.transform.position - transform.position).magnitude > 2;
        }
        GetComponent<BoxCollider>().enabled = boxcollActive;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name=="sujeto")
        {
            collision.transform.name = "dead";
        }
        //boxcollActive = false;
    }
}
