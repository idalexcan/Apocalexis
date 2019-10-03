using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takeball : MonoBehaviour
{
    GameObject weapon;
    GameObject throwedobj;
    bool throwed;
    int timer;



    void Update()
    {

        Detect();
        //ToSpear();
        Rocket.TakingSpear(ref weapon, ref throwed, ref timer, transform.position);
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
    

}

public class Rocket : MonoBehaviour
{
    public static void TakingSpear(ref GameObject _weapon, ref bool _throwed, ref int _timer, Vector3 position)
    {
        if (_weapon != null && _weapon.transform.name == "Rocket")
        {
            _weapon.transform.eulerAngles = GameObject.Find("Head").transform.eulerAngles;
            _weapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            _weapon.GetComponent<Rigidbody>().useGravity = false;
            if (Input.GetMouseButtonDown(0))
            {
                _weapon.GetComponent<Rigidbody>().AddForce((GameObject.Find("Shotpoint").transform.position - position).normalized * 2000);////new Vector3(0,2,3)*1000)
                _throwed = true;
                _weapon = null;
            }
            else
            {
                if (!_throwed)
                {
                    _weapon.transform.position = position;
                }
            }
        }
        if (_throwed)
        {
            _timer++;
            if (_timer == 70)
            {
                _throwed = false;
                _timer = 0;
            }
        }
    }
}

