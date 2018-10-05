using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneNpc : MonoBehaviour
{

    [Header("开始按钮"), SerializeField]
    private UIButton btn_GameStart;
    [Header("开始按钮"), SerializeField]
    private UIButton btn_ExitGame;
    [Header("按钮面板"), SerializeField]
    private GameObject panel_UI;
    public float timer;

  //  public TypewriterEffect typewriter;
    void Start()
    {

      //  typewriter.is
        panel_UI.SetActive(false);
        UIEventListener.Get(btn_GameStart.gameObject).onClick = Btn_GameStart;
        UIEventListener.Get(btn_ExitGame.gameObject).onClick = Btn_ExitGame;
        StartCoroutine(DisPlayUI(timer));
    }

    private void Update()
    {
        // print(Time.time);
    }
    /// <summary>
    /// 开始游戏按钮事件
    /// </summary>
    void Btn_GameStart(GameObject go)
    {
        SceneManager.LoadScene("mainFirst");
    }
    /// <summary>
    /// 退出游戏按钮事件
    /// </summary>
    void Btn_ExitGame(GameObject go)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    IEnumerator DisPlayUI(float time)
    {
        yield return new WaitForSeconds(time);
        panel_UI.SetActive(true);
    }
}
