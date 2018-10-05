using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoomMonster : MonoBehaviour
{
    Transform enemyParent;
    float hp = 1;
    private void Awake()
    {
        enemyParent = GameObject.Find("EnemyParent").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject boom = Instantiate(Resources.Load("boom") as GameObject, transform.position, Quaternion.identity, enemyParent);
            GlobeManager globe = GlobeManager._Instance;
            globe.Player_Hp -= 0.5f;
            EnemyCount._Instance.EnCount -= 1;
            globe.UpdateShow();
            print("boom ");
            Destroy(gameObject, 0.1f);
        }

        if (collision.gameObject.tag == "bullet")
        {
            hp -= 0.4f;
            print("boom 掉血 " + hp);
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                EnemyCount._Instance.EnCount -= 1;
                Destroy(gameObject, 0.1f);
            }
        }

        if (collision.gameObject.tag == "FirstSkill")
        {
            hp -= 1.5f;
            print("boom 掉血 " + hp);
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                EnemyCount._Instance .EnCount -= 1;
                Destroy(gameObject, 0.1f);
            }
        }
    }

}
