using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerSecond : MonoBehaviour
{

    private int startCount;
    private int bloodCount;
    private void Awake()
    {
        startCount = PlayerPrefs.GetInt("startCount");
        bloodCount = PlayerPrefs.GetInt("diamondCount");
        StartCoroutine(UpdateShow());
    }

    IEnumerator UpdateShow()
    {
        yield return new WaitForSeconds(0.1f);
        GlobeManager._Instance.Start_Count = startCount;
        GlobeManager._Instance.Blood_Count = bloodCount;
        GlobeManager._Instance.UpdateShow();
    }
}
