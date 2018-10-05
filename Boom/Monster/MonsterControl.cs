using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{


    float hp = 2;
    public float scale;//monster的缩放比例
    private bool isLeft = true;//控制monster的方向
    Transform player;
    Transform firePoint;//发射子弹点
    Transform bulletParent;
    AudioSource au;
    private void Awake()
    {
        au = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        firePoint = transform.Find("monsterFirePoint");
        bulletParent = GameObject.Find("BulletParent").GetComponent<Transform>();
    }
    private void Start()
    {
        StartCoroutine(MonsterShooting(1.5f));
    }
    private void Update()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            return;
        }

        transform.localScale = new Vector3(-scale, scale, scale);
    }
    /// <summary>
    /// monster发射子弹
    /// </summary>
    IEnumerator MonsterShooting(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            GameObject monsterBullet = Instantiate(Resources.Load("light") as GameObject, firePoint.position, Quaternion.identity, bulletParent);
            VideoManager.Instance.PlayClip("monsterbullet", au);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager globe = GlobeManager._Instance;
            globe.Player_Hp -= 0.5f;
            EnemyCount._Instance.EnCount -= 1;
            globe.UpdateShow();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "bullet")
        {
            hp -= 0.5f;
            //  print("monster 掉血" + hp);
            Destroy(collision.gameObject);//销毁子弹
            if (hp <= 0)
            {
                EnemyCount._Instance.EnCount -= 1;
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.tag == "FirstSkill")
        {
            hp -= 1.5f;
            print("boom 掉血 " + hp);
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                EnemyCount._Instance.EnCount -= 1;
                Destroy(gameObject);
            }
        }
    }
}
