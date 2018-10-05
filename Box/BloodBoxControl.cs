using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBoxControl : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager globe = GlobeManager._Instance;
            globe.Blood_Count += 2;
            globe.UpdateShow();
            VideoManager.Instance.PlayClip("larabottle");
            Destroy(gameObject);
        }
    }
}
