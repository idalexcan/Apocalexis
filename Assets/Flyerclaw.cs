using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyerclaw : MonoBehaviour
{
    /// <|VARIABLES GENERALES|>
    /// <myzone referencia de la zona asignada para este flyerclaw
    /// <timer contador de tiempo para el cambio de direcciones
    /// <direcMove dirección de movimiento (con normalized)
    /// <direcRotate dirección o variable de rotación (-3 a 3)
    /// <timelapse tiempo de variación para las direcciones
    /// </summary>
    GameObject myzone;
    int timer = 0;
    Vector3 direcMove;
    float direcRotate;
    int timelapse = 50;

    ///--------------------------------------<|MÉTODOS DEL MONO BIJEBIO|>--------------------------------------|
    ///--------------------------------------------------------------------------------------------------------|

    private void Awake()
    {
        myzone = NPCcontrol.flyclawZones[Random.Range(0, NPCcontrol.flyclawZones.Length)];
        transform.position = PosInZone();
    }
    
    private void Update()
    {
        Moving();
    }


    ///-----------------------------------------<|MÉTODOS DE CLASE|>-------------------------------------------|
    ///--------------------------------------------------------------------------------------------------------|
    
    
    ///------------------------------------------------------------------<|Mover
    void Moving()
    {

        timer++;
        if (timer == 100)
        {
            direcMove = (PosInZone() - transform.position).normalized;
            direcRotate = Random.Range(-3, 4);
            timer = 0;
            timelapse = Random.Range(5, 170);
        }
        transform.position += direcMove * 0.07f;
        transform.eulerAngles += new Vector3(0, direcRotate, 0);
    }

    ///------------------------------------------------------------------<|Retornar vector dentro de zona
    Vector3 PosInZone()
    {
        float range = myzone.transform.localScale.x / 2;
        float x = Random.Range(range * (-1), range);
        float z = Random.Range(range * (-1), range);
        Vector3 r = myzone.transform.position;
        return r += new Vector3(x, 5, z);
    }
}

