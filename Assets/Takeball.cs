using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takeball : MonoBehaviour
{
    GameObject weapon;
    GameObject dropWeapon;
    bool throwed;
    int timer;
    public static GameObject shotpoint;
    GameObject hero;

    public int damage;
    public int potence;

    private void Awake()
    {
        shotpoint = GameObject.Find("Shotpoint");
        hero = GameObject.Find("Hero");
    }

    void Update()
    {
        Detect();
        TakingWeapon();
        CreateWeapon();
    }

    void Detect()
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
    }

    void TakingWeapon()
    {
        if (weapon != null)//&& weapon.transform.name == "Rocket"
        {
            weapon.transform.eulerAngles = Takeball.shotpoint.transform.eulerAngles;
            weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            weapon.GetComponent<Rigidbody>().useGravity = false;

            if (Input.GetMouseButtonDown(0))
            {
                if (weapon.transform.name == "Rocket")
                {
                    potence = 1000;
                }
                if (weapon.transform.name == "Spear") 
                {
                    potence = 5000;
                }
                weapon.GetComponent<Rigidbody>().AddForce((GameObject.Find("Shotpoint").transform.position - transform.position).normalized * potence);////new Vector3(0,2,3)*1000)
                weapon.GetComponent<Rigidbody>().useGravity = true;
                throwed = true;
                dropWeapon = weapon;
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
            if (timer == 100)
            {
                throwed = false;
                timer = 0;
                Destroy(dropWeapon);
            }
        }
    }

    void CreateWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject go = GameObject.Instantiate(GameObject.Find("Rocket"));
            go.transform.position = GameObject.Find("Takeball").transform.position;
            go.transform.tag = "weapon";
            go.transform.name = "Rocket";
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject go = GameObject.Instantiate(GameObject.Find("Spear"));
            go.transform.position = GameObject.Find("Takeball").transform.position;
            go.transform.tag = "weapon";
            go.transform.name = "Spear";
        }
    }
}


