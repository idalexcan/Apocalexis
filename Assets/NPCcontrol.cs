using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public GameObject reference, reference2;
    public static List<GameObject> flyerclaws=new List<GameObject>();
    public static int cantflyer;
    public static GameObject[] flyclawZones;
    private void Awake()
    {
        flyclawZones = GameObject.FindGameObjectsWithTag("flyclaw");
        foreach (var item in flyclawZones)
        {
            item.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
    void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            flyerclaws.Add(GameObject.Instantiate(reference2));
            flyerclaws[i].AddComponent<Flyerclaw>();
        }

        foreach (var item in FindObjectsOfType(typeof(GameObject)) as GameObject[]) //COLOR DE SUJETOS (TEMPROAL)
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


