﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static float rotY;
    float x = 0, y = 0;

    void Update()
    {
        //transform.position = GameObject.Find("Rebanada").transform.position;
        //transform.position += new Vector3(0, 0.5f, 0);
        x -= Input.GetAxis("Mouse Y");
        y += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(x, y, 0);
        rotY = transform.eulerAngles.y;
        Moving();
    }
    void Moving()
    {
        transform.position = GameObject.Find("Rebanada").transform.position;
        transform.position += new Vector3(0, 0.5f, 0);
    }
}



