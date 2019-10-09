using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public static GameObject fail;
    public static GameObject win;
    public Text life;
    public Text hability;
    public Text enemies;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (HeroControl.life<0 || HeroControl.pos.y<-100)
        {
            fail.SetActive(true);
        }
        if (NPCcontrol.enemies==0)
        {

        }
        life.text = "LIFEl:" + HeroControl.life;
        hability.text = "HABILITY:" + HeroControl.hability;
        enemies.text = "ENEMIES:" + NPCcontrol.enemies;
    }
}
