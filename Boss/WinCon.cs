using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{
    public Transform player;
    public float force = 10f;
    public Transform boss;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boss = GameObject.FindGameObjectWithTag("boss").GetComponent <Transform >();
        if (player.position.x < boss.position.x)
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * Time.deltaTime * force, ForceMode2D.Force);
        else
            GetComponent<Rigidbody2D>().AddForce(-Vector2.left * Time.deltaTime * force, ForceMode2D.Force);
        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager._Instance.Player_Hp -= 0.75f;
            GlobeManager._Instance.UpdateShow();
            Destroy(gameObject);
        }
    }


}
