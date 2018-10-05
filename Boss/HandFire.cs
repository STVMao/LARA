using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFire : MonoBehaviour
{

    public GameObject[] fire;
    void Start()
    {
        StartCoroutine(Viewer());
        Destroy(gameObject, 6f);
    }

    public float timer = 3;
    public float timeT = 0.2f;
    IEnumerator Viewer()
    {
        yield return new WaitForSeconds(timer);
        fire[0].SetActive(true);
        yield return new WaitForSeconds(timeT);
        fire[1].SetActive(true);
        yield return new WaitForSeconds(timeT);
        fire[2].SetActive(true);

    }

}
