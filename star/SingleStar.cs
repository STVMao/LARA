using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager._Instance.Start_Count += 1;
            GlobeManager._Instance.UpdateShow();
            VideoManager.Instance.PlayClip("larastar");
            //print("1倍星星");
            Destroy(gameObject);
        }
    }
}
