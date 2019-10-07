using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public GameObject flyerclawref;
    public static List<GameObject> flyerclaws=new List<GameObject>();
    public static GameObject[] flyclawZones;
    public GameObject flyercannon;
    public static List<GameObject> flyercannons=new List<GameObject>();
    public static GameObject[] flyercannonZones;
    private void Awake()
    {
        flyclawZones = GameObject.FindGameObjectsWithTag("flyclawzone");
        flyercannonZones = GameObject.FindGameObjectsWithTag("flycannonzone");
    }

    void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            flyerclaws.Add(GameObject.Instantiate(flyerclawref));
        }
        for (int i = 0; i < 1; i++)
        {
            flyercannons.Add(GameObject.Instantiate(flyercannon));
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
        foreach (var item in flyercannons)
        {
            if (item != null && item.GetComponent<Flyercannon>().died)
            {
                Destroy(item);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject go = GameObject.Instantiate(GameObject.Find("Rocket"));
            go.transform.position = GameObject.Find("Takeball").transform.position;
            go.transform.tag = "weapon";
            go.transform.name = "Rocket";
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject go = GameObject.Instantiate(GameObject.Find("Spear"));
            go.transform.position = GameObject.Find("Takeball").transform.position;
            go.transform.tag = "weapon";
            go.transform.name = "Spear";
        }
    }
}




