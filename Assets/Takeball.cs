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
        //Spear.TakingSpear(ref weapon, ref dropWeapon, ref throwed, ref timer, transform.position);
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


}

//public class Rocket : MonoBehaviour
//{
    
//    private void Awake()
//    {
//        damage = 50;
//    }
//    public static void TakingRocket(ref GameObject _weapon, ref GameObject _dropWeapon, ref bool _throwed, ref int _timer, Vector3 position)
//    {
//        if (_weapon != null && _weapon.transform.name == "Rocket")
//        {
//            _weapon.transform.eulerAngles = Takeball.shotpoint.transform.eulerAngles;
//            _weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
//            _weapon.GetComponent<Rigidbody>().useGravity = false;

//            if (Input.GetMouseButtonDown(0))
//            {
//                if (_weapon.transform.name == "Rocket")
//                {
//                    potence = 1000;
//                }
//                _weapon.GetComponent<Rigidbody>().AddForce((GameObject.Find("Shotpoint").transform.position - position).normalized * potence);////new Vector3(0,2,3)*1000)
//                _weapon.GetComponent<Rigidbody>().useGravity = true;
//                _throwed = true;
//                _dropWeapon = _weapon;
//                _weapon = null;
//            }
//            else
//            {
//                if (!_throwed)
//                {
//                    _weapon.transform.position = position;
//                }
//            }
//        }
//        if (_throwed)
//        {
//            _timer++;
//            if (_timer == 300)
//            {
//                _throwed = false;
//                _timer = 0;
//                Destroy(_dropWeapon);
//            }
//        }
//    }
//}

