using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyerclaw : Enemys
{
    private void Awake()
    {
        myzone = NPCcontrol.flyclawZones[Random.Range(0, NPCcontrol.flyclawZones.Length)];
        transform.position = PosInZone();
    }
    
    private void Update()
    {

        Moving();

    }

    ///-----------------------------------------------------------------------------------<|Movimiento del flyerclaw
    public void Moving()
    {
        timer++;
        if (timer == timelapse)
        {
            direcMove = (PosInZone() - transform.position).normalized;
            direcRotate = Random.Range(-3, 4);
            timer = 0;
            timelapse = Random.Range(5, 170);
        }
        transform.position += direcMove * 0.04f;
        transform.eulerAngles += new Vector3(0, direcRotate, 0);
    }

}

//public class Flyerclaw : MonoBehaviour
//{
//    /// <|VARIABLES GENERALES|>
//    /// <myzone referencia de la zona asignada para este flyerclaw
//    /// <timer contador de tiempo para el cambio de direcciones
//    /// <direcMove dirección de movimiento (con normalized)
//    /// <direcRotate dirección o variable de rotación (-3 a 3)
//    /// <timelapse tiempo de variación para las direcciones
//    /// </summary>
//    GameObject myzone;
//    int timer = 0;
//    Vector3 direcMove;
//    float direcRotate;
//    int timelapse = 50;

//    public GameObject[] organs = new GameObject[4];
//    public bool died;

//    ///--------------------------------------<|MÉTODOS DEL MONO BIJEBIO|>--------------------------------------|
//    ///--------------------------------------------------------------------------------------------------------|

//    private void Awake()
//    {
//        myzone = NPCcontrol.flyclawZones[Random.Range(0, NPCcontrol.flyclawZones.Length)];
//        transform.position = PosInZone();
//    }

//    private void Update()
//    {

//        //Moving();

//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.transform.name == "Rocket")
//        {
//            foreach (var item in organs)
//            {
//                if (item.GetComponent<SphereCollider>())
//                {
//                    item.GetComponent<SphereCollider>().enabled = true;
//                }
//                if (item.GetComponent<CapsuleCollider>())
//                {
//                    item.GetComponent<CapsuleCollider>().enabled = true;
//                }
//                item.AddComponent<Rigidbody>();
//            }
//            StartCoroutine("Die");
//        }
//    }
//    //<--------------------|>CORRUTINAS<|----------------------------------------------------------------------|
//    IEnumerator Die()
//    {
//        yield return new WaitForSeconds(3);
//        died = true;
//    }

//    ///-----------------------------------------<|MÉTODOS DE CLASE|>-------------------------------------------|
//    ///--------------------------------------------------------------------------------------------------------|


//    ///------------------------------------------------------------------<|Movimiento del flyerclaw
//    void Moving()
//    {
//        timer++;
//        if (timer == 100)
//        {
//            direcMove = (PosInZone() - transform.position).normalized;
//            direcRotate = Random.Range(-3, 4);
//            timer = 0;
//            timelapse = Random.Range(5, 170);
//        }
//        transform.position += direcMove * 0.04f;
//        transform.eulerAngles += new Vector3(0, direcRotate, 0);
//    }

//    ///------------------------------------------------------------------<|Retorno de vector dentro de zona
//    Vector3 PosInZone()
//    {
//        float range = myzone.transform.localScale.x / 2;
//        float x = Random.Range(range * (-1), range);
//        float z = Random.Range(range * (-1), range);
//        Vector3 r = myzone.transform.position;
//        return r += new Vector3(x, 5, z);
//    }
//}