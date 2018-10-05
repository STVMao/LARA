using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAddFlashSkill : MonoBehaviour
{
    [Header("技能面板"), SerializeField]
    private GameObject skill;
    [Header("NPCUI"), SerializeField]
    private GameObject npc;
    void Start()
    {
        npc.SetActive(true);
        skill.SetActive(false);
        StartCoroutine(DisplayUI(4));
    }

    IEnumerator DisplayUI(float time)
    {
        yield return new WaitForSeconds(time);
        npc.GetComponent<TweenAlpha>().PlayForward();
        skill .GetComponent<TweenAlpha>().PlayForward();
        yield return new WaitForSeconds(2);
        npc.SetActive(false);
        skill.SetActive(true);
    }
}
