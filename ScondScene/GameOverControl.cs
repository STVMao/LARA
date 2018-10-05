using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 结束游戏机制
/// </summary>
public class GameOverControl : MonoBehaviour
{
    // public static GameOverControl _Instance;
    // public static int secondStarCount;
    //public static int secondBloodCount;
    [Header("下一关的名字")]
    public string nextName;
    private void Awake()
    {
        if (Time.timeScale != 1)
            Time.timeScale = 1;
        // _Instance = this;
    }
    void Update()
    {
        GameOver();

    }

    /// <summary>
    /// 游戏结束机制
    /// </summary>
    public void GameOver()
    {
        if (GlobeManager._Instance.Player_Hp <= 0)
            UIManager._Instance.DisPlayGameOverPanel();
        if (EnemyCount._Instance.EnCount <= 0)//如果敌人的数量小于等于0
        {
            PlayerPrefs.SetInt("secondStarCount", GlobeManager._Instance.Start_Count);
            PlayerPrefs.SetInt("secondBloodCount", GlobeManager._Instance.Blood_Count);
            SceneManager.LoadScene(nextName);
        }

    }
}
