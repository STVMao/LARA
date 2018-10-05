using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleStar : MonoBehaviour
{
    Transform uiRoot;
    private void Awake()
    {
        uiRoot = GameObject.Find("UI Root").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager._Instance.Start_Count += 3;
            GameObject root = Instantiate(Resources.Load("Container_SuperStar") as GameObject, uiRoot);
            Destroy(root, 2f);
            GlobeManager._Instance.UpdateShow();
           // print("3倍星星");
            VideoManager.Instance.PlayClip("larastar");
            Destroy(gameObject, 0.05f);
        }
    }
}
