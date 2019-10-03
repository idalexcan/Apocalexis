using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Limbtype
{
    claw,
    cannon
}

public class HandControl : MonoBehaviour
{
    public GameObject myclaw; 
    
    int timer = 0;
    public Limbtype limbtype;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("maldita sea");
        }
        switch (limbtype)
        {
            case Limbtype.claw:
                MoveClaw();
                AttackClaw();
                break;
            case Limbtype.cannon:
                MoveCannon();
                AttackCannon();
                break;
            default:
                break;
        }
        
    }

    ///------------------------------------------------------------------<|Ataque de la garra al agarrar
    void AttackClaw()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
        {
            if ((item.transform.position - myclaw.transform.position).magnitude < 1)
            {
                item.GetComponent<MeshRenderer>().material.color = Color.red;
                Destroy(item);
            }
        }
    }
    ///------------------------------------------------------------------<|Movimiento de garra
    void MoveClaw()
    {
        timer++;
        if (timer <= 8)
        {
            myclaw.transform.position += transform.up * 0.4f;
        }
        else if (timer <= 70)
        {
            if ((transform.position - myclaw.transform.position).magnitude > 0.3f)
            {
                myclaw.transform.position += (transform.position - myclaw.transform.position).normalized * 0.2f;
            }
        }
        else
        {
            timer = 0;
        }
    }


    ///------------------------------------------------------------------<|Ataque de la garra al agarrar
    void AttackCannon()
    {
        Debug.Log("marica ome");
    }
    ///------------------------------------------------------------------<|Movimiento de garra
    void MoveCannon()
    {

    }
}
