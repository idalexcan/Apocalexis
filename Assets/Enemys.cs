using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    /// <|VARIABLES GENERALES|>
    /// <myzone referencia de la zona asignada para este flyerclaw
    /// <timer contador de tiempo para el cambio de direcciones
    /// <direcMove dirección de movimiento (con normalized)
    /// <direcRotate dirección o variable de rotación (-3 a 3)
    /// <timelapse tiempo de variación para las direcciones
    /// </summary>
    public GameObject myzone;
    public int timer = 0;
    public Vector3 direcMove;
    public float direcRotate;
    public int timelapse = 50;

    public GameObject[] organs = new GameObject[4];
    public bool died;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="weapon")
        {
            foreach (var item in organs)
            {
                if (item.GetComponent<SphereCollider>())
                {
                    item.GetComponent<SphereCollider>().enabled = true;
                }
                if (item.GetComponent<CapsuleCollider>())
                {
                    item.GetComponent<CapsuleCollider>().enabled = true;
                }
                item.AddComponent<Rigidbody>();
            }
            StartCoroutine("Die");
        }
    }

    ///------------------------------------------------------------------<|Corrutina que inica: "Muerto"
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        died = true;
    }

    ///------------------------------------------------------------------<|Retorno de vector dentro de zona
    public Vector3 PosInZone()
    {
        float range = myzone.transform.localScale.x / 2;
        float x = Random.Range(range * (-1), range);
        float z = Random.Range(range * (-1), range);
        Vector3 r = myzone.transform.position;
        return r += new Vector3(x, 5, z);
    }
}
