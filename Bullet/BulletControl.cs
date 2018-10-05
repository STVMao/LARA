using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private bool isRight = true;//控制子弹的方向
    public float scale;
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localScale.x > 0)
            return;
        isRight = !isRight;
    }
    private void Start()
    {
       // GlobeManager globe = GlobeManager._Instance;
        Destroy(gameObject, 3f);
        //  print(isRight);
    }
    private void Update()
    {
        BUlletDir();

    }

    public virtual void BUlletDir()
    {
        if (isRight)
            transform.Translate(Vector3.right * Time.deltaTime * GlobeManager._Instance.Bullet_Speed, Space.Self);
        else
        {
            transform.localScale = new Vector3(-scale, scale, scale);
            transform.Translate(-Vector3.right * Time.deltaTime * GlobeManager._Instance.Bullet_Speed, Space.Self);
        }
    }
}
