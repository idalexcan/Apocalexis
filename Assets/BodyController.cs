using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] claws;
    bool suiting=true;
    void Start()
    {
        foreach (var item in claws)
        {
            item.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (suiting)
        {
            foreach (var item in claws)
            {
                item.transform.position = transform.position;
                
            }
            suiting = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "floor" || collision.transform.name == "FlyerclawZone")
        {
            int cont = 0;
            suiting = false;
            foreach (var item in claws)
            {
                if (cont!=0)
                {
                    item.SetActive(false);
                }
                cont++;
                
            }
        }
    }
}
