using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static Vector3 rotY;
    float x = 0, y = 0;

    private void Awake()
    {

    }

    private void Start()
    {
        transform.position = HeroControl.rebanada.GetComponent<Rebanada>().pos;
    }

    void Update()
    {
        transform.position = HeroControl.rebanada.GetComponent<Rebanada>().pos; 
        transform.position += new Vector3(0, 0, 0);

        x -= Input.GetAxis("Mouse Y");
        y += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(x, y, 0);
        rotY = transform.eulerAngles;
    }
}



