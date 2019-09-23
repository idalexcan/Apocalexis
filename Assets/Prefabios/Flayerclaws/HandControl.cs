using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : Flyerclaw
{
    public GameObject myclaw;
    int cont = 0;

    void Update()
    {
        MoveClaw();
        AttackClaw();
    }

    void AttackClaw()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
        {
            if ((item.transform.position - myclaw.transform.position).magnitude < 1)
            {
                item.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }


    void MoveClaw()
    {
        cont++;
        if (cont <= 5)
        {
            myclaw.transform.position += transform.up * 0.4f;
        }
        else if (cont <= 50)
        {
            if ((transform.position - myclaw.transform.position).magnitude > 0.5f)
            {
                myclaw.transform.position += (transform.position - myclaw.transform.position).normalized * 0.2f;
            }
        }
        else
        {
            cont = 0;
        }
    }
}
