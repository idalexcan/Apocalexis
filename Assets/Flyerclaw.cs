using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyerclaw : MonoBehaviour
{
    /// <|SUMARIO|>
    /// < myzone Referencia de la zona de flayerclaws
    /// < direction dirección que indica cada cierto tiempo a hacia donde moverse (dentro de la flyerclaw zone)
    /// < timelapse el tiempo que determina cuando cambia la dirección 
    /// </summary>
    public static GameObject myzone;
    Vector3 direction;
    float timecont = 0;
    int timelapse = 0;
    private void Awake()
    {
        myzone = GameObject.Find("FlyerclawZone");
        //transform.position = new Vector3(Random.Range(myzone.transform.position.x, myzone.transform.localScale.x), 3, 0);
    }
    private void Start()
    {
        //Vector3 zonepos = GameObject.Find("FlyerclawZone").transform.position;
        //transform.position = new Vector3(
        //    Random.Range(zonepos.x - 20, zonepos.x + 20),  
        //    3,                                              
        //    Random.Range(zonepos.z - 20, zonepos.z + 20));

    }
    private void Update()
    {
        if (timecont == timelapse)
        {
            timecont = 0;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (Random.Range(-180, 181)), 0);
            timelapse = Random.Range(5, 500);
            direction = transform.forward;
        }
        timecont++;
        if ((transform.position - myzone.transform.position).magnitude >= myzone.transform.localScale.z / 2)
        {
            direction = (myzone.transform.position - transform.position).normalized;
        }
        transform.position += direction * 0.05f;
    }


    public static Vector3 InitialPos()
    {
        Vector3 zonepos = GameObject.Find("FlyerclawZone").transform.position;
        float rx = Random.Range(zonepos.x - myzone.transform.localScale.x, zonepos.x + myzone.transform.localScale.x);
        return zonepos;
        //(Random.Range(zonepos.x - myzone.transform.localScale.x, zonepos.x + myzone.transform.localScale.x),
        //zonepos.y+3,
        //Random.Range(zonepos.z - myzone.transform.localScale.z, zonepos.z + myzone.transform.localScale.z));
    }

    ///-------------------------------------------------------------------------------------------------------------------------------------
    ///-------------------------------------------------<|EXTRAS|>--------------------------------------------------------------------------
    void BasicMoving()
    {
        timecont++;
        if (timecont == 50)
        {
            timecont = 0;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (Random.Range(-70, 71)), 0);
        }
        transform.position += transform.forward * 0.05f;
    }///-----------------------------------------------------------------------------------<|Movimiento pero más fluido
}
