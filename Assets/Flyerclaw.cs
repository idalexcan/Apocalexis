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
    /// <summary>
    /// <|VARIABLES SOBRE GARRAS VOLADORAS xd|>
    /// <claws Lista de garras voladoras
    /// </summary>
    List<GameObject> claws = new List<GameObject>();
    public int myindex;
    private void Awake()
    {
        myzone = NPCcontrol.flyclawZones[Random.Range(0, NPCcontrol.flyclawZones.Length)];
        transform.position =  InitialPos();
    }
    private void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("claw"))
        {
            if (!item.GetComponent<ClawControl>())
            {
                GameObject.FindGameObjectWithTag("claw").AddComponent<ClawControl>();
            }
        }
        
    }
    private void Update()
    {
        Moving();
    }

    void Moving()
    {

        if (timecont == timelapse)
        {
            timecont = 0;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (Random.Range(-180, 181)), 0);
            timelapse = Random.Range(5, 500);
            direction = transform.forward;
        }
        if ((transform.position - myzone.transform.position).magnitude >= myzone.transform.localScale.z / 2)
        {
            direction = (myzone.transform.position - transform.position).normalized;
        }
        transform.position += direction * 0.07f;
        timecont++;
        GameObject.Find("Body").transform.eulerAngles = new Vector3(0, 0, 0);
        GameObject.Find("DiscBody").transform.eulerAngles = new Vector3(0, 0, 0); ;
    }

    Vector3 InitialPos()
    {
        Vector3 zonepos = myzone.transform.position;
        float rx = Random.Range(zonepos.x - myzone.transform.localScale.x, zonepos.x + myzone.transform.localScale.x);
        return new Vector3
        (Random.Range(zonepos.x - myzone.transform.localScale.x / 2, zonepos.x + myzone.transform.localScale.x / 2),
        zonepos.y + 6,
        Random.Range(zonepos.z - myzone.transform.localScale.z / 2, zonepos.z + myzone.transform.localScale.z / 2));
    }

}

public class Claw : MonoBehaviour
{
    void Start()
    {
        transform.position += new Vector3(0, 0, 0.5f);
    }
}
