using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Xiong" || collision.gameObject.tag == "MiFeng" || collision.gameObject.tag == "SpriteMonster" || collision.gameObject.tag == "spin" ||
          collision.gameObject.tag == "stone" || collision.gameObject.tag == "boom" || collision.gameObject.tag == "light")//Xiong  MiFeng   SpriteMonster  spin   stone  boom   light
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
