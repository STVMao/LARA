using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager _Instance;
    [SerializeField, Header("设置按钮")]
    private UIButton btn_Set;
    [SerializeField, Header("设置面板")]
    private TweenPosition panel_Set;
    [Space(2), SerializeField, Header("退出游戏按钮")]
    private UIButton btn_quitGame;
    [Space(2), Header("暂停游戏按钮"), SerializeField]
    private UIButton btn_StopGame;
    [Space(2), Header("继续游戏按钮"), SerializeField]
    private UIButton btn_ContinueGame;
    [Space(2), Header("音乐按钮"), SerializeField]
    private UIButton btn_IsPlayBGM;
    [Space(2), Header("游戏结束面板"), SerializeField]
    private GameObject panel_GameOver;
    [Space(2), Header("描述面板"), SerializeField]
    private GameObject panel_DirPanel;
    [Space(2), Header("显示描述面板面板"), SerializeField]
    private UIButton btn_DisplayDirPanel;
    [Space(2), Header("退出描述面板"), SerializeField]
    private UIButton btn_ExitDirPanel;

    [Space(2), Header("重新开始游戏按钮"), SerializeField]
    private UIButton btn_Restart;
    [Space(2), Header("退出游戏按钮"), SerializeField]
    private UIButton btn_TuiChu;

    [Header("本关场景名字"), SerializeField]
    private string levelName;

    [Header("音乐"), SerializeField]
    private AudioSource au;

    /// <summary>
    /// 控制Button界面的 出现和隐藏
    /// </summary>
    bool isDisplay = false;
    /// <summary>
    /// BGM是否播放
    /// </summary>
    bool isBGM = true;

    private void Awake()
    {
        _Instance = this;
        panel_DirPanel.SetActive(false);
        panel_GameOver.SetActive(false);
        btn_StopGame.gameObject.SetActive(true);
        btn_ContinueGame.gameObject.SetActive(false);
        btn_Set.onClick.Add(new EventDelegate(this, "Btn_Set"));
        btn_quitGame.onClick.Add(new EventDelegate(this, "Btn_ExitGame"));
        btn_ContinueGame.onClick.Add(new EventDelegate(this, "Btn_ContinueGame"));
        btn_StopGame.onClick.Add(new EventDelegate(this, "Btn_StopGame"));
        btn_IsPlayBGM.onClick.Add(new EventDelegate(this, "BGMControl"));
        btn_TuiChu.onClick.Add(new EventDelegate(this, "Btn_ExitGame"));
        btn_Restart.onClick.Add(new EventDelegate(this, "Btn_RestartGame"));
        btn_DisplayDirPanel.onClick.Add(new EventDelegate(this, "Btn_DisplayDirPanel"));
        btn_ExitDirPanel.onClick.Add(new EventDelegate(this, "Btn_ExitDirPanel"));
    }
    #region 按钮事件函数


    /// <summary>
    /// 显示设置panel
    /// </summary>
    void Btn_Set()
    {
        isDisplay = !isDisplay;
        if (isDisplay)
            panel_Set.PlayForward();
        else
            panel_Set.PlayReverse();
    }
    /// <summary>
    /// 退出游戏按钮事件
    /// </summary>
    public void Btn_ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
    /// <summary>
    /// 暂停游戏按钮事件
    /// </summary>
    void Btn_StopGame()
    {
        if (!btn_ContinueGame.gameObject.activeSelf)
            btn_ContinueGame.gameObject.SetActive(true);
        if (btn_StopGame.gameObject.activeSelf)
            btn_StopGame.gameObject.SetActive(false);
        if (Time.timeScale != 0)
            Time.timeScale = 0;
    }
    /// <summary>
    /// 继续游戏按钮事件
    /// </summary>
    void Btn_ContinueGame()
    {
        if (!btn_StopGame.gameObject.activeSelf)
            btn_StopGame.gameObject.SetActive(true);
        if (btn_ContinueGame.gameObject.activeSelf)
            btn_ContinueGame.gameObject.SetActive(false);
        if (Time.timeScale != 1)
            Time.timeScale = 1;

    }
    /// <summary>
    /// BGM
    /// </summary>
    void BGMControl()
    {
        isBGM = !isBGM;
        if (isBGM && !au.isPlaying) au.Play();
        else au.Pause();
    }
    /// <summary>
    /// 重新开始按钮事件
    /// </summary>
    void Btn_RestartGame()
    {
        if (Time.timeScale != 1)
            Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
    }
    /// <summary>
    /// 当游戏失败的时候显示
    /// </summary>
    public void DisPlayGameOverPanel()
    {
        if (!panel_GameOver.activeSelf)
            panel_GameOver.SetActive(true);
        if (Time.timeScale != 0)
            Time.timeScale = 0;

    }
    /// <summary>
    /// 显示帮助面板的按钮事件
    /// </summary>
    void Btn_DisplayDirPanel()
    {
        if (Time.timeScale != 0)
            Time.timeScale = 0;
        panel_DirPanel.SetActive(true);
    }
    /// <summary>
    /// 退出描述按钮事件
    /// </summary>
    void Btn_ExitDirPanel()
    {
        if (Time.timeScale != 1)
            Time.timeScale = 1;
        panel_DirPanel.SetActive(false);
    }
    #endregion
}
