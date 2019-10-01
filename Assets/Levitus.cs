using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitus : MonoBehaviour
{
    GameObject weapon;
    GameObject throwedobj;
    bool throwed;
    int timer;



    void Update()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("weapon"))
        {
            if (!throwed)
            {
                if ((item.transform.position - transform.position).magnitude < 0.2f)
                {
                    weapon = item;
                }
            }
        }

        ToSpear();
        
    }

    void ToSpear()
    {
        if (weapon != null && weapon.transform.name == "Spear")
        {
            weapon.transform.eulerAngles = GameObject.Find("Head").transform.eulerAngles;
            weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            weapon.GetComponent<Rigidbody>().useGravity = false;
            if (Input.GetMouseButtonDown(0))
            {
                weapon.GetComponent<Rigidbody>().AddForce((GameObject.Find("Shotpoint").transform.position - transform.position).normalized * 1000);////new Vector3(0,2,3)*1000)
                throwed = true;
                weapon = null;
            }
            else
            {
                if (!throwed)
                {
                    weapon.transform.position = transform.position;
                }
            }
        }
        if (throwed)
        {
            timer++;
            if (timer == 70)
            {
                throwed = false;
                timer = 0;
            }
        }
    }
}



