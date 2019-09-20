using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawControl : MonoBehaviour
{
    Vector3 defaultpos;
    public float clawspeed=0.02f;
    public int intervale=20;
    void Start()
    {
        Debug.Log(transform.position);
        //transform.position = new Vector3(0, 0, 0);
        Debug.Log("->"+transform.position);
    }
    private void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward;
        }
    }
}
