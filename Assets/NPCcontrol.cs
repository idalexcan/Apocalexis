using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public GameObject reference;
    public static GameObject flyclaw;
    void Start()
    {
        flyclaw = GameObject.Instantiate(reference) as GameObject;
        flyclaw.AddComponent<Flyclaw>();
        
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

public class Flyclaw : MonoBehaviour
{
    Vector3 pointzone, 
            direction;
    float timecont = 100;
    int timelapse = 100;
    private void Awake()
    {
        
    }
    private void Start()
    {
        transform.position = GameObject.Find("FlyclawZone").transform.position;
        pointzone = GameObject.Find("FlyclawZone").transform.position;
    }
    private void Update()
    {
        if (timecont == timelapse)
        {
            timecont = 0;
            direction = PointDir(pointzone, 40, 40);
            timelapse = Random.Range(10, 200);
        }
        transform.position += direction * 0.5f;
        timecont++;
    }

    Vector3 PointDir(Vector3 CenterZone, float rangeX, float rangeZ) 
    {
        Vector3 point;
        float randomX = Random.Range(CenterZone.x - (rangeX / 2), CenterZone.x + (rangeX / 2)), 
              randomZ = Random.Range(CenterZone.z - (rangeZ / 2), CenterZone.z + (rangeZ / 2));
        point = new Vector3(randomX, 2, randomZ);
        return (point-transform.position).normalized;
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
