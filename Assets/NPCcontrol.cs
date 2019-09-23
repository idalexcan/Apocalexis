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
    }

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            flyerclaws.Add(GameObject.Instantiate(flyerclawref));
            flyerclaws[i].transform.position += new Vector3(i * 2, 0, 0);
        }
        
    }

}




