using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossBloodPos : MonoBehaviour
{
    [Header("血条跟踪的目标点")]
    public Transform targetPos;

    public Transform blood;


    public Image image;
    private void Awake()
    {
        BossManager.Instance.BossEvent += BloodCon;//注册事件
    }
    private void Start()
    {
        BossManager.Instance.UpdaShow();//调用事件
    }
    /// <summary>
    /// 取消注册事件
    /// </summary>
    private void OnApplicationQuit()
    {
        BossManager.Instance.BossEvent -= BloodCon;//取消事件
    }
    /// <summary>
    /// 更新血条
    /// </summary>
    public void BloodCon()
    {
        image.fillAmount = BossManager.Instance.BossHp / 12;
    }
    void Update()
    {
        blood.position = targetPos.position;//控制Boss血条位置
        GameOver();
    }
    /// <summary>
    /// 胜利场景的名字
    /// </summary>
    public string victorySceneName;
    /// <summary>
    /// 游戏胜利条件
    /// </summary>
    void GameOver()
    {
        if (BossManager.Instance.BossHp <= 0)
        {
            VideoManager.Instance.PlayClip("dead");
            VideoManager.Instance.PlayClip("游戏胜利");
            StartCoroutine(StepScene());
        }
    }

    IEnumerator StepScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(victorySceneName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FirstSkill")
        {


            BossManager.Instance.BossHp -= 3f;
            BossManager.Instance.UpdaShow();
            Destroy(collision.gameObject);
        }
    }
}
