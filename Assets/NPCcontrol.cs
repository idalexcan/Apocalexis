using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public GameObject flyerclawref;
    public static List<GameObject> flyerclaws=new List<GameObject>();
    public static int cantflyer;
    public static GameObject[] flyclawZones;
    private void Awake()
    {
        flyclawZones = GameObject.FindGameObjectsWithTag("flyclawzone");
        foreach (var item in flyclawZones)
        {
            item.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            flyerclaws.Add(GameObject.Instantiate(flyerclawref));
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


