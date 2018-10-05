using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{

    public Transform playerTra;
    public Transform m_Tra;

    /// <summary>
    /// boss 刚开始不追主角，当第一次发现主角时   开始追
    /// </summary>
    bool bossIsFollow = false;
    /// <summary>
    /// //是否在释放技能
    /// </summary>
    public static bool isSkill = false;

    private void Awake()
    {
        if (playerTra == null)
            playerTra = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (m_Tra == null)
            m_Tra = this.transform;
    }
    float dis = 0;
    void Update()
    {
        dis = Vector3.Distance(playerTra.position, m_Tra.position);
        FindPLayer();
        if (!bossIsFollow)
            return;
        if (isSkill)
            return;
        BossMoveFunction();
        BossScaleDir();
    }

    Vector3 normalPos;
    public float moveSpeed = 0.5f;
    [Header("朝向主角移动的最小距离")]
    public float disMove = 1f;

    [Header("Boss的Scale")]
    public float scale;
    /// <summary>
    /// Boss移动
    /// </summary>
    void BossMoveFunction()
    {
        normalPos = playerTra.position - m_Tra.position;

        if (dis > disMove)
        {
            m_Tra.Translate(normalPos * Time.deltaTime * moveSpeed);
        }

    }

    /// <summary>
    /// 判断Boss的朝向
    /// </summary>
    void BossScaleDir()
    {
        if (m_Tra.position.x > playerTra.position.x)
        {
            m_Tra.localScale = new Vector3(scale, scale, scale);
        }
        else
            m_Tra.localScale = new Vector3(-scale, scale, scale);
    }

    [Header("Boss第一次发现Player的距离")]
    public float disFind = 25f;
    /// <summary>
    /// 何时发现主角
    /// </summary>
    void FindPLayer()
    {
        if (dis < disFind)
        {
            bossIsFollow = true;
        }
    }
}
