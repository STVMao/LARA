using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    public UIButton quitBt;
    void Start()
    {
        quitBt.onClick.Add(new EventDelegate (this, "Quit"));
    }

    void Quit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
