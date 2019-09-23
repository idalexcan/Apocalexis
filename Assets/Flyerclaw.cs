using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyerclaw : MonoBehaviour
{
    /// <|VARIABLES DE MOVIMIENTO|>
    /// < myzone Referencia de la zona de flayerclaws
    /// < direction dirección que indica cada cierto tiempo a hacia donde moverse (dentro de la flyerclaw zone)
    /// < timelapse el tiempo que determina cuando cambia la dirección 
    /// </summary>
    GameObject myzone;
    Vector3 direction;
    float timecont = 0;
    int timelapse = 0;
    /// <|VARIABLES SOBRE GARRAS VOLADORAS xd|>
    /// <claws Lista de garras voladoras
    /// </summary>
    GameObject clawref;
    public GameObject[] claws;
    public bool newclaw;
    public int cantclaw = 0;

    public GameObject body;
    private void Awake()
    {
        
        myzone = NPCcontrol.flyclawZones[Random.Range(0, NPCcontrol.flyclawZones.Length)];
        transform.position =  InzonePos();
        transform.position += new Vector3(0, 6, 0);
        claws = GameObject.FindGameObjectsWithTag("inactiveClaw") as GameObject[];
        
        foreach (var item in claws)
        {
            if (cantclaw!=0)
            {
                item.SetActive(false);
            }
            item.tag = "activeClaw";
            cantclaw++;
        }
        cantclaw = 0;

    }
    private void Start()
    {
        body.GetComponent<BodyController>().claws = claws;
    }

    private void Update()
    {
        Moving();
        if (cantclaw<claws.Length-1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CreateClaw();
            }
        }
        if (newclaw)
        {
            CreateClaw();
            newclaw = false;
        }
        body.transform.position = transform.position;
    }

    

    public void CreateClaw()
    {
        cantclaw++;
        claws[cantclaw].SetActive(true);
    }

    void Moving()
    {
        if (timecont == timelapse)
        {
            timecont = 0;
            timelapse = Random.Range(5, 500);
            direction = (InzonePos() - transform.position).normalized;
        }
        if ((transform.position - myzone.transform.position).magnitude >= myzone.transform.localScale.z / 2)
        {
            direction = (myzone.transform.position - transform.position).normalized;
        }
        transform.position += direction * 0.01f;
        timecont++;
        transform.eulerAngles += new Vector3(0, 1, 0);

    }

    Vector3 InzonePos()
    {
        Vector3 zonepos = myzone.transform.position;
        float rx = Random.Range(zonepos.x - myzone.transform.localScale.x, zonepos.x + myzone.transform.localScale.x);
        return new Vector3
        (Random.Range(zonepos.x - myzone.transform.localScale.x / 2, zonepos.x + myzone.transform.localScale.x / 2),
        zonepos.y,
        Random.Range(zonepos.z - myzone.transform.localScale.z / 2, zonepos.z + myzone.transform.localScale.z / 2));
    }

}

