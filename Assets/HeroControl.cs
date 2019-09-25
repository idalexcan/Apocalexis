using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    public GameObject heroref;
    public static GameObject rebanada;
    public static Vector3 pos;
    public static float velocity=40;

    private void Awake()
    {
        rebanada = Instantiate(heroref);
        rebanada.AddComponent<Rebanada>();
    }
    
    private void Update()
    {
        
    }
}

public class Rebanada : MonoBehaviour
{
    public Vector3 pos;
    public float velocity=3;

    private void Awake()
    {
        pos = transform.position;
    }
    private void Update()
    {
        transform.eulerAngles = CameraControl.rotY;
        pos = transform.position;
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * velocity / 10;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * velocity / 10;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * velocity / 10;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * velocity / 10;
        }
    }

}


