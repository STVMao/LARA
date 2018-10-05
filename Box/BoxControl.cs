using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    Transform bloodParent;
    private void Awake()
    {
        bloodParent = GameObject.Find("BloodParent").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject bloodBox = Instantiate(Resources.Load("BloodBox") as GameObject, transform.position, Quaternion.identity, bloodParent);
            VideoManager.Instance.PlayClip("larabox");
            Destroy(gameObject);
        }
    }
}
