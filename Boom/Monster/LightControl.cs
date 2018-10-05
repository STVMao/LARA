using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : BulletControl
{
    bool isLeft = true;
    Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player.position.x > transform.position.x)
            return;
        isLeft = !isLeft;
    }
    public override void BUlletDir()
    {
        // base.BUlletDir();

        if (isLeft)
        {

            transform.Translate(Vector3.right * Time.deltaTime * GlobeManager._Instance.Bullet_Speed, Space.Self);
            return;
        }
        transform.localScale = new Vector3(-scale, scale, scale);
        transform.Translate(-Vector3.right * Time.deltaTime * GlobeManager._Instance.Bullet_Speed, Space.Self);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager globe = GlobeManager._Instance;
            globe.Player_Hp -= 1 / 8.0f;
            globe.UpdateShow();
            Destroy(gameObject);
        }
    }
}
