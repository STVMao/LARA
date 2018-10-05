using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpControl : MonoBehaviour
{

    [Space(2), Header("Star label"), SerializeField]
    private UILabel label_StartCount;
    [Space(2), Header("HpSprite"), SerializeField]
    private UISprite sprite_Hp;
    [Space(2), Header("label blood"), SerializeField]
    private UILabel label_Blood;
    private void Awake()
    {
        GlobeManager._Instance.OnChangeEvent += Init;    
    }

    /// <summary>
    /// 初始化  需要注册事件
    /// </summary>
    void Init()
    {
        UpdateShow();
    }
    /// <summary>
    /// 更新数据
    /// </summary>
    void UpdateShow()
    {
        GlobeManager globeManager = GlobeManager._Instance;
        label_StartCount.text = globeManager.Start_Count.ToString();
        label_Blood.text = globeManager.Blood_Count.ToString();
        sprite_Hp.fillAmount = globeManager.Player_Hp;
    }
}
