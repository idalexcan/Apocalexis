﻿using System.Collections;
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
    public GameObject person;
    public static List<GameObject> people = new List<GameObject>();
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
        for (int i = 0; i < 1; i++)
        {
            people.Add(GameObject.Instantiate(person));
        }
    }

    private void Update()
    {
        DestroyKilled();

        
    }

    void DestroyKilled()
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
        foreach (var item in people)
        {
            if (item != null && item.GetComponent<Person>().died)
            {
                Destroy(item);
            }
        }
    }

}




