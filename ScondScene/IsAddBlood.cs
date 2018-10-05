using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAddBlood : MonoBehaviour
{


    [Space(2), SerializeField, Header("加血的案件")]
    private KeyCode ZKeyCode;

    void Update()
    {
        PlayerAddHp(Input.GetKeyDown(ZKeyCode));
    }
    /// <summary>
    /// 主角加血
    /// </summary>
    public void PlayerAddHp(bool isDown)
    {
        if (isDown)
        {
            GlobeManager globe = GlobeManager._Instance;
            if (globe.Blood_Count >= 2 && globe.Player_Hp < 1)
            {
                globe.Blood_Count -= 2;
                globe.Player_Hp += 0.25f;
                globe.UpdateShow();
            }
        }

    }
}
