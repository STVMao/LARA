using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarCountGameOver : MonoBehaviour
{
    [Header ("下一关的名字")]
    public string nextName;
    List<GameObject> startCountList = new List<GameObject>();
    public GameObject[] star;
    public int starCount = 0;//场景中的星星数量
    private void Awake()
    {
        for (int i = 0; i < star.Length; i++)
        {
            startCountList.Add(star[i]);
        }
        starCount = startCountList.Count;
    }

    private void Update()
    {
        Init();
    }
    /// <summary>
    /// 判断星星是否吃完
    /// </summary>
    void Init()
    {
        for (int i = 0; i < startCountList.Count; i++)
        {
            if (startCountList[i] == null)
            {
                startCountList.RemoveAt(i);
            }
        }
        if (startCountList.Count <= 0)
        {
            PlayerPrefs.SetInt("secondStarCount", GlobeManager._Instance.Start_Count);
            PlayerPrefs.SetInt("secondBloodCount", GlobeManager._Instance.Blood_Count);
            SceneManager.LoadScene(nextName);
            print("游戏胜利");
        }
    }
}
