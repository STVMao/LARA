﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSkillControl : MonoBehaviour
{

    public float CDTime = 3f;//技能冷却时间
    float cd = 0;
    public KeyCode skillKeyBoard;//施放技能按键
    GlobeManager globe;
    [Header("遮罩精灵"), SerializeField]
    private UISprite sprite_Mask;
    private Transform player;//主角
    private bool isSkill = true;//是否能施放技能



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
                //  player.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                isSkill = true;
            }
        }
        if (sprite_Mask.fillAmount == 0 && isSkill && globe.Start_Count >= 3 && Input.GetKeyDown(skillKeyBoard))
        {
            GameObject skill = Instantiate(Resources.Load("Shield") as GameObject, player.position, Quaternion.identity, player);
            skill.transform.localPosition = new Vector3(1.4f, 0, 0);
            sprite_Mask.fillAmount = 1;
            cd = 0;
            globe.Start_Count -= 3;
            globe.UpdateShow();
            // player.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            isSkill = false;//禁止施放技能，进入冷却时间
        }
    }
}
