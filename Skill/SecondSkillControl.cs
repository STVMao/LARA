using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSkillControl : MonoBehaviour
{

    public float CDTime = 3f;//技能冷却时间
    float cd = 0;
    public KeyCode skillKeyBoard;//施放技能按键
    GlobeManager globe;
    [Header("遮罩精灵"), SerializeField]
    private UISprite sprite_Mask;
    private Transform player;//主角
    private bool isSkill = true;//是否能施放技能

    [Header("位移距离"), SerializeField]
    private float disTran;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (sprite_Mask.fillAmount != 0)
            sprite_Mask.fillAmount = 0;

    }
    private void Start()
    {
        globe = GlobeManager._Instance;
    }

    private void Update()
    {
        UserSkill();
    }
    /// <summary>
    /// 施放技能条件
    /// </summary>
    public virtual void UserSkill()
    {
        if (isSkill == false)
        {
            cd += Time.deltaTime;
            if (cd >= CDTime)
            {
                cd = CDTime;
            }

            sprite_Mask.fillAmount = 1 - cd / CDTime;
            if (sprite_Mask.fillAmount <= 0)
            {
                isSkill = true;
            }
        }
        if (sprite_Mask.fillAmount == 0 && isSkill && globe.Start_Count >= 3 && Input.GetKeyDown(skillKeyBoard))
        {
            if (player.localScale.x > 0)
            {
                player.position += new Vector3(disTran, 0, 0);
                MouseMove._Instance.currentPoint = player.position;
            }

            else
            {
                player.position -= new Vector3(disTran, 0, 0);
                MouseMove._Instance.currentPoint = player.position;
            }
               
           // MouseMove._Instance.currentPoint = transform.position;

            sprite_Mask.fillAmount = 1;
            cd = 0f;//冷却时间重置
            globe.Start_Count -= 3;
            globe.UpdateShow();
            isSkill = false;//禁止施放技能，进入冷却时间
        }
    }
}
