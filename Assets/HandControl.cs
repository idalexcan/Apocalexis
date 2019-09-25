using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public GameObject myclaw;
    int timer = 0;


    ///--------------------------------------<|MÉTODOS DEL MONO BIJEBIO|>--------------------------------------|
    ///--------------------------------------------------------------------------------------------------------|

    void Update()
    {
        MoveClaw();
        AttackClaw();
    }

    ///-----------------------------------------<|MÉTODOS DE CLASE|>-------------------------------------------|
    ///--------------------------------------------------------------------------------------------------------|

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
            myclaw.transform.position += transform.up * 0.6f;
        }
        else if (timer <= 70)
        {
            if ((transform.position - myclaw.transform.position).magnitude > 0.5f)
            {
                myclaw.transform.position += (transform.position - myclaw.transform.position).normalized * 0.2f;
            }
        }
        else
        {
            timer = 0;
        }
    }

}
