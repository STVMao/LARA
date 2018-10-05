using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFireBullet : MonoBehaviour
{

    [Space(2), Header("发射子弹键")]
    public KeyCode fireKeyCode;
    private Transform player;//主角
    [Space(2), SerializeField, Header("子弹的父物体")]
    private Transform bullet_Parent;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet(Input.GetKeyDown(fireKeyCode));
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    public void FireBullet(bool isFire)
    {
        if (isFire)
        {
            print("发射子弹");
            GameObject bullet = Instantiate<GameObject>(Resources.Load("Bullet") as GameObject, player.position, player.rotation, bullet_Parent);
            VideoManager.Instance.PlayClip("larabullet");
        }

    }
}
