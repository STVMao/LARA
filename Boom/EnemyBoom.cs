using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoom : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager globe = GlobeManager._Instance;
            globe.Player_Hp -= 0.5f;
            globe.UpdateShow();//调用事件，更新 血量
            Destroy(gameObject, 0.1f);
        }
    }
}
