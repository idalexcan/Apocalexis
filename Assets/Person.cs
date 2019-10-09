using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public enum State
    {
        normal,
        engaloched
    }

    public State state;
    public GameObject normal;
    public GameObject engaloched;
    public GameObject[] organs = new GameObject[4];
    public bool died;
    public bool infected;

    int timer;
    int timelapse=50;
    float speed = 2;

    private void Awake()
    {
        transform.position += new Vector3(0, 10, 0);
    }

    void Update()
    {
        switch (state)
        {
            case State.normal:
                NormalConduct();
                infected = false;
                break;
            case State.engaloched:
                normal.SetActive(false);
                engaloched.SetActive(true);
                if (true)
                {

                }
                EngalochedConduct();
                infected = true;
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "activeClaw")
        {
            state = State.engaloched;
            transform.position += new Vector3(0, 1, 0);
            bool onetime=true;
            if (onetime)
            {
                NPCcontrol.enemies++;
                onetime = false;
            }
            
        }
        if (collision.transform.tag=="weapon")
        {
            foreach (var item in organs)
            {
                normal.SetActive(false);
                item.AddComponent<SphereCollider>();
                item.AddComponent<Rigidbody>();
            }
            StartCoroutine("Die");
        }
        
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        died = true;
    }

    void NormalConduct()
    {
        timer++;
        if (timer == (int)(timelapse * 0.25f)) 
        {
            transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }
        else if (timer == (int)(timelapse * 0.60f))
        {
            transform.LookAt(HeroControl.pos);
            speed = speed * 4;
        }
        else if (timer==timelapse)
        {
            speed = Random.Range(1, 10);
            timer = 0;
            timelapse = Random.Range(10, 200);
        }
        transform.position += transform.forward * (speed/100);
    }

    void EngalochedConduct()
    {
        if ((HeroControl.pos-transform.position).magnitude<10)
        {
            speed = 15;
            transform.LookAt(HeroControl.pos);
        }
        else
        {
            timer++;
            if (timer < (int)(timelapse / 2))
            {
                transform.eulerAngles += new Vector3(0, Random.Range(-5, 5), 0);
            }
            if (timer == timelapse)
            {
                transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
                speed = Random.Range(1, 10);
                timer = 0;
                timelapse = Random.Range(20, 100);
            }
        }
        transform.position += transform.forward * (speed / 100);
    }
     
}
