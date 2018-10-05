using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCon : MonoBehaviour
{
    public Transform waterPoint;

    private void Awake()
    {
        waterPoint = GameObject.FindGameObjectWithTag("waterPoint").GetComponent<Transform>();
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject water = Instantiate(Resources.Load<GameObject>("Water"), waterPoint.position, Quaternion.identity);
            water.transform.SetParent(waterPoint);
            BossManager.Instance.BossHp -= 1.5f;
            BossManager.Instance.UpdaShow();
            Destroy(gameObject);
            Destroy(water, 0.5f);
        }
    }
}
