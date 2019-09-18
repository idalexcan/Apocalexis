using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public GameObject reference, reference2;
    public static GameObject flyerclaw;
    public static List<GameObject> flyerclaws=new List<GameObject>();
    public static int cantflyer;
    void Start()
    {
        //flyerclaw = GameObject.Instantiate(reference) as GameObject;
        //flyerclaw.AddComponent<Flyerclaw>();

        for (int i = 0; i < 1; i++)
        {
            flyerclaws.Add(GameObject.Instantiate(reference2));
            flyerclaws[i].transform.position = GameObject.Find("FlyerclawZone").transform.position;
            //flyerclaws[i].transform.position = Flyerclaw.InitialPos();
            //flyerclaws[i].AddComponent<Flyerclaw>();

        }

        foreach (var item in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (item.transform.name=="sujeto")
            {
                item.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
        }
    }

    void Update()
    {
        
    }
}


