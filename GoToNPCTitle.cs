using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNPCTitle : MonoBehaviour
{

    public UIButton btn;
    public string sceneName;
    void Start()
    {
        btn.onClick.Add(new EventDelegate(this , "ChangeScene"));
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
