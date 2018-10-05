using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneControl : MonoBehaviour
{
    AudioSource au;
    private void Start()
    {
        au = GetComponent<AudioSource>();
        StartCoroutine(playerclip());
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobeManager globe = GlobeManager._Instance;
            globe.Player_Hp -= 1f;
            globe.UpdateShow();
            Destroy(gameObject);
        }
    }

    IEnumerator playerclip()
    {
        yield return new WaitForSeconds(1.5f);
        VideoManager.Instance.PlayClip("ston", au);
    }
}
