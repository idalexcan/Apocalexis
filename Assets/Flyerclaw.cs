using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyerclaw : MonoBehaviour
{
    private void Awake()
    {
          
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * 0.2f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * 0.2f;
        }
    } 
    
}

