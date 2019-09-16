using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public GameObject reference;
    public static GameObject flyclaw;
    void Start()
    {
        flyclaw = GameObject.Instantiate(reference) as GameObject;
        flyclaw.transform.position = new Vector3(0, 4, 0);
        flyclaw.AddComponent<Flyclaw>();

        
    }

    void Update()
    {
        
    }
}

public class Flyclaw : MonoBehaviour
{

}
