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
        flyclaw.transform.position = new Vector3(40, 2, -40);
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
    Vector3 pointzone, pointzone2, direction;
    private void Start()
    {
        pointzone = new Vector3(40, 2, -40);
        pointzone2 = new Vector3(40, 2, -4);
    }
    float timecont = 0;
    float directioncont = 0;
    private void Update()
    {
        timecont++;
        
        if (timecont == 100)
        {
            timecont = 0;
            direction = PointDir(pointzone, 40, 40);
            Debug.Log(direction);
        }
        transform.position += direction*0.5f;
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
