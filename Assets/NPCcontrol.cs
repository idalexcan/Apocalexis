using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public GameObject flyerclawref;
    public static List<GameObject> flyerclaws=new List<GameObject>();
    public static GameObject[] flyclawZones;
    private void Awake()
    {
        flyclawZones = GameObject.FindGameObjectsWithTag("flyclawzone");
    }

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            flyerclaws.Add(GameObject.Instantiate(flyerclawref));
        }

    }

    private void Update()
    {
        foreach (var item in flyerclaws)
        {
            if (item != null && item.GetComponent<Flyerclaw>().died) 
            {
                Destroy(item);
            }
        }
    }
}




