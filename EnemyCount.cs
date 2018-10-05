using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public static EnemyCount _Instance;
    List<GameObject> enemyList = new List<GameObject>();
    public GameObject[] enemy;
    public  int EnCount = 0;//场景中的敌人数量
    private void Awake()
    {
        _Instance = this;
        for (int i = 0; i < enemy.Length; i++)
        {
            enemyList.Add(enemy[i]);
        }
        EnCount = enemyList.Count;
    }
    void UpdateShow()
    {
        Init();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    void Init()
    {
        print(EnCount);
    }
}
