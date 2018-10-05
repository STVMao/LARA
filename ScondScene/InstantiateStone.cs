using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStone : MonoBehaviour
{

    public GameObject stone;
    public float timer;
    public float limitLeftX= -15f;
    public float limitRighrX = 120;
    public float limitY = 16.3f;
    void Start()
    {
        StartCoroutine(CloneStine(timer));
    }
    IEnumerator CloneStine(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            GameObject go = Instantiate(stone, new Vector3(Random.Range(limitLeftX, limitRighrX), limitY, 0), Quaternion.identity);
        }

    }
}
