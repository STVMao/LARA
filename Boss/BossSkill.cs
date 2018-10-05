using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    [Header("fire位置")]
    public Transform firePoint;
    public GameObject handFire;

    public Transform player;
    public Transform m_Tra;

    Animator ani;
    [Header("咆哮提示UI")]
    public GameObject textUI;


    public float dis;
    public float disPM = 8f;
    public float time = 1f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        m_Tra = gameObject.transform;
        ani = GetComponent<Animator>();
        InvokeRepeating("InstantiateWater", 15, 15);//重复生成水滴

        dis = Vector3.Distance(player.position, m_Tra.position);
    }
    void Update()
    {
        dis = Vector3.Distance(player.position, m_Tra.position);
        if (dis < disPM)
        {
            time += Time.deltaTime;
            if (((int)time) % 4 == 0)
            {
                time += 1;
                int index = Random.Range(1, 4);
                print(time + "       " + index);
                switch (index)
                {
                    case 1:
                        SkillFirst();
                        print("SkillFirst");
                        break;
                    case 2:
                        SkillSecond();
                        print("SkillSecond");
                        break;
                    case 3:
                      //  SkillThird();
                        print("SkillThird");
                        break;
                }
            }
        }

    }

    [Header("水滴预制体")]
    public GameObject waterDot;
    /// <summary>
    /// 生成水滴
    /// </summary>
    void InstantiateWater()
    {
        Vector3 pos = new Vector3(Random.Range(-4, 150), 0.7f, 0);
        GameObject go = Instantiate(waterDot, pos, Quaternion.identity);
    }

    #region SkillFirst
    /// <summary>
    /// Boss技能的sCale
    /// </summary>
    /// <param name="obj"></param>
    private void ScaleController(GameObject obj)
    {
        if (m_Tra.position.x > player.position.x)
            obj.transform.localScale = new Vector3(1, 1, 1);
        else
            obj.transform.localScale = new Vector3(-1, 1, 1);

    }
    /// <summary>
    /// 技能1
    /// </summary>
    void SkillFirst()
    {
        BossMove.isSkill = true;//Boss不可移动，在释放此技能的时候
        ani.SetBool("HandFire", true);
        GameObject fire = Instantiate(handFire, firePoint.position, Quaternion.identity);
        //VideoManager.Instance.PlayClip("火山喷发");
        ScaleController(fire);

        StartCoroutine(SetIsSkill());
    }



    [Header("释放技能可移动时间")]
    public float timer = 3f;
    IEnumerator SetIsSkill()
    {
        yield return new WaitForSeconds(timer);
        ani.SetBool("HandFire", false);
        BossMove.isSkill = false;
    }
    #endregion

    #region SkillSecond

    public Transform windPoint;
    public GameObject windObj;
    void SkillSecond()
    {
        GameObject wind = Instantiate(windObj, windPoint.position, Quaternion.identity);
    }
    #endregion

    #region SkillThird


    void SkillThird()
    {
        VideoManager.Instance.PlayClip("终极怪物怒吼");
        textUI.SetActive(true);
        StartCoroutine(HideOrdisplay(textUI, 2, false));
        if (IsDirBoss())
        {
            StartCoroutine(Hit());
        }

    }
    /// <summary>
    /// 判断player是否面向
    /// </summary>
    /// <returns></returns>
    bool IsDirBoss()
    {
        if (true)
        {
            return true;
        }
        return false;
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(2f);
        BossManager.Instance.BossHp += 2;
        BossManager.Instance.UpdaShow();
        GlobeManager._Instance.Player_Hp -= 0.5f;
        GlobeManager._Instance.UpdateShow();
    }
    /// <summary>
    /// 协成控制UI提示的消失
    /// </summary>
    /// <param name="go"></param>
    /// <param name="timer"></param>
    /// <param name="isVisible"></param>
    /// <returns></returns>
    IEnumerator HideOrdisplay(GameObject go, float timer, bool isVisible)
    {
        yield return new WaitForSeconds(timer);
        go.SetActive(isVisible);
    }

    IEnumerator PlayerMoveNoLimit()
    {
        yield return new WaitForSeconds(1f);
        MouseMove.isMove = true;//主角可以移动
    }
    #endregion
}
