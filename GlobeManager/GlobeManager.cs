using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeManager : MonoBehaviour
{
    public static GlobeManager _Instance;
    #region  固定字段



    private float bullet_Speed;
    private float player_Hp;
    private int start_Count;
    private int diamond_Count;
    private bool skill_First;
    private bool skill_Second;
    private bool skill_Third;
    private float destory_Bullet_Time;
    private float player_Move_Speed;
    private float player_Jump_AddForce;
    private int blood_Count;
    private int enemy_Count;
    #endregion

    #region 属性

    /// <summary>
    /// 子弹的速度
    /// </summary>
    public float Bullet_Speed
    {
        get
        {
            return bullet_Speed;
        }

        set
        {
            bullet_Speed = value;
        }
    }
    /// <summary>
    /// 主角hp
    /// </summary>
    public float Player_Hp
    {
        get
        {
            if (player_Hp <= 0)
                player_Hp = 0;
            else if (player_Hp >= 1) player_Hp = 1;
            return player_Hp;
        }

        set
        {
            player_Hp = value;
        }
    }
    /// <summary>
    /// start数量
    /// </summary>
    public int Start_Count
    {
        get
        {
            if (start_Count <= 0)
                start_Count = 0;
            return start_Count;
        }

        set
        {
            start_Count = value;
        }
    }
    /// <summary>
    /// 砖石数量
    /// </summary>
    public int Diamond_Count
    {
        get
        {
            return diamond_Count;
        }

        set
        {
            diamond_Count = value;
        }
    }
    /// <summary>
    /// 是否能施放第一个技能
    /// </summary>
    public bool Skill_First
    {
        get
        {
            return skill_First;
        }

        set
        {
            skill_First = value;
        }
    }
    /// <summary>
    /// 是否能施放第二个技能
    /// </summary>
    public bool Skill_Second
    {
        get
        {
            return skill_Second;
        }

        set
        {
            skill_Second = value;
        }
    }
    /// <summary>
    /// 是否能释放 第三个技能
    /// </summary>
    public bool Skill_Third
    {
        get
        {
            return skill_Third;
        }

        set
        {
            skill_Third = value;
        }
    }
    /// <summary>
    /// 子弹销毁时间
    /// </summary>
    public float Destory_Bullet_Time
    {
        get
        {
            return destory_Bullet_Time;
        }

        set
        {
            destory_Bullet_Time = value;
        }
    }
    /// <summary>
    /// player的移动速度
    /// </summary>
    public float Player_Move_Speed
    {
        get
        {
            return player_Move_Speed;
        }

        set
        {
            player_Move_Speed = value;
        }
    }
    /// <summary>
    /// 主角跳跃 向上的force
    /// </summary>
    public float Player_Jump_AddForce
    {
        get
        {
            return player_Jump_AddForce;
        }

        set
        {
            player_Jump_AddForce = value;
        }
    }
    /// <summary>
    /// 血瓶的数量
    /// </summary>
    public int Blood_Count
    {
        get
        {
            if (blood_Count <= 0)
                blood_Count = 0;
            return blood_Count;
        }

        set
        {
            blood_Count = value;
        }
    }
    /// <summary>
    /// 敌人数量
    /// </summary>
    public int Enemy_Count
    {
        get
        {
            return enemy_Count;
        }

        set
        {
            enemy_Count = value;
        }
    }


    #endregion


    public delegate void OnChangeEventHandler();//委托
    public event OnChangeEventHandler OnChangeEvent;//事件
    private void Awake()
    {
        _Instance = this;
        ///加载到下个场景
        //if (!gameObject .activeSelf )
        //{
        //    DontDestroyOnLoad(gameObject);
        //    Debug.LogWarning("不销毁");
        //}
     

    }
    private void Start()
    {
        Init();
    }
    /// <summary>
    /// 初始化 数据
    /// </summary>
    private void Init()
    {
        Bullet_Speed = 15f;
        Player_Hp = 1f;
        Start_Count = 10;
        Diamond_Count = 0;
        Skill_First = true;
        Skill_Second = false;
        Skill_Third = false;
        Destory_Bullet_Time = 3f;
        Player_Move_Speed = 10f;
        Player_Jump_AddForce = 300f;
        Blood_Count = 10;
        Enemy_Count = 6;
        OnChangeEvent();// 调用事件
    }

    /// <summary>
    /// 调用事件
    /// </summary>
    public void UpdateShow()
    {
        OnChangeEvent();// 调用事件
    }

}
