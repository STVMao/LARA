using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteMonsterFire : MonoBehaviour
{

    Transform firePoint;//发射子弹点
    Transform bulletParent;
    Transform player;
    public float scale;//monster的缩放比例
    AudioSource au;
    private void Awake()
    {
        au = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        firePoint = transform.Find("FirePoint");
        bulletParent = GameObject.Find("BulletParent").GetComponent<Transform>();
    }
    private void Start()
    {
        StartCoroutine(MonsterShooting(3f));
    }

    void Update()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-scale, scale, scale);
            return;
        }

        transform.localScale = new Vector3(scale, scale, scale);
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
            // VideoManager.Instance.PlayClip("monsterbullet");
            VideoManager.Instance.PlayClip("monsterbullet", au);
        }

    }
}
