using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoSingleton<BossManager>
{



    private float bossHp;
    private float skill1Damage;
    private float skill2Damage;
    private float skill3Damage;
    private float skill4Damage;
    private int returnHp;

    #region 属性
    public float BossHp
    {
        get
        {
            if (bossHp <= 0)
                bossHp = 0;
            if (bossHp >= 12)
                bossHp = 12;
            return bossHp;
        }
        set
        {
           
            bossHp = value;
        }
    }
    /// <summary>
    /// 技能1的伤害
    /// </summary>
    public float Skill1Damage
    {
        get
        {
            return skill1Damage;
        }

        set
        {
            skill1Damage = value;
        }
    }
    /// <summary>
    /// 技能2的伤害
    /// </summary>
    public float Skill2Damage
    {
        get
        {
            return skill2Damage;
        }

        set
        {
            skill2Damage = value;
        }
    }
    /// <summary>
    /// 技能3的伤害
    /// </summary>
    public float Skill3Damage
    {
        get
        {
            return skill3Damage;
        }

        set
        {
            skill3Damage = value;
        }
    }

    public float Skill4Damage
    {
        get
        {
            return skill4Damage;
        }

        set
        {
            skill4Damage = value;
        }
    }
    /// <summary>
    /// boss
    /// 回复的血量
    /// </summary>
    public int ReturnHp
    {
        get
        {
            return returnHp;
        }

        set
        {
            returnHp = value;
        }
    }


    #endregion


    public delegate void BossHandler();

    public event BossHandler BossEvent;

    private void Awake()
    {
        Init();

    }


    void Init()
    {
        BossHp = 12;
        Skill1Damage = 12;
        Skill2Damage = 3;
        skill4Damage = 2;
        ReturnHp = 2;
        // BossEvent();
    }


    public void UpdaShow()
    {
        BossEvent();
    }
}
