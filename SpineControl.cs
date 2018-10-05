using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineControl : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager globe = GlobeManager._Instance;
            globe.Player_Hp -= 0.5f;
            globe.UpdateShow();
            Destroy(gameObject);
        }
    }
}
