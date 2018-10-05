using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region 字段

    //虚拟轴返回值
    float horizontal;
    // float vertical;
    bool isDir;
    private Transform player;//主角
    [SerializeField, Header("主角的原始缩放")]
    private float player_Scale;
    [Header("控制跳跃的按键")]
    public KeyCode keyCode;//跳跃按键
    Rigidbody2D player_Rig;
    //主角最高的Y
    public float limit_Y;
    [Space(2), Header("发射子弹键")]
    public KeyCode fireKeyCode;
    [Space(2), SerializeField, Header("子弹的父物体")]
    private Transform bullet_Parent;

    [Space(2), SerializeField, Header("加血的案件")]
    private KeyCode ZKeyCode;

    public static PlayerManager _Instance;
    #endregion
    private void Awake()
    {
        _Instance = this;
        if (Time.timeScale != 1)
            Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player_Rig = player.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Player_Move(GlobeManager._Instance.Player_Move_Speed);
        PlayerJump(Input.GetKeyDown(keyCode), GlobeManager._Instance.Player_Jump_AddForce);
        IsFireBullet(Input.GetKeyDown(fireKeyCode));
        PlayerAddHp(Input.GetKeyDown(ZKeyCode));
        GameOver();
    }
    /// <summary>
    /// player 移动和朝向控制
    /// </summary>
    /// <param name="speed"> 移动速度</param>
    private void Player_Move(float speed)
    {
        horizontal = Input.GetAxis("Horizontal");
        player.Translate(horizontal * Time.deltaTime * speed, 0, 0);//player  move
        //主角朝向
        if (horizontal > 0)
            player.localScale = new Vector3(player_Scale, player_Scale, player_Scale);
        else if (horizontal < 0)
            player.localScale = new Vector3(-player_Scale, player_Scale, player_Scale);
        if (player.position.y >= limit_Y)
        {
            player_Rig.AddForce(-Vector3.up * speed);
            player.position = new Vector3(player.position.x, limit_Y, player.position.z);
        }
    }
    /// <summary>
    /// 主角跳跃
    /// </summary>
    /// <param name="isJump"> 是否按下跳跃键</param>
    /// <param name="force"> 跳跃的力</param>
    void PlayerJump(bool isJump, float force)
    {
        if (isJump)
        {
            player_Rig.AddForce(Vector3.up * force);
            // AudioSource.PlayClipAtPoint(Resources.Load("jump") as AudioClip, transform.position, 50);
            //  print("跳跃");
            VideoManager.Instance.PlayClip("jump");
        }
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    public void IsFireBullet(bool isFire)
    {
        if (isFire)
        {
          //  print("发射子弹");
            GameObject bullet = Instantiate<GameObject>(Resources.Load("Bullet") as GameObject, player.position, player.rotation, bullet_Parent);
            VideoManager.Instance.PlayClip("larabullet");
        }

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

    /// <summary>
    /// 游戏结束机制
    /// </summary>
    public void GameOver()
    {
        if (GlobeManager._Instance.Player_Hp <= 0)
            UIManager._Instance.DisPlayGameOverPanel();
        if (EnemyCount._Instance.EnCount <= 0)//如果敌人的数量小于等于0
        {
            //本地化保存 星星 和 diamond的数量
            PlayerPrefs.SetInt("startCount", GlobeManager._Instance.Start_Count);
            PlayerPrefs.SetInt("diamondCount", GlobeManager._Instance.Blood_Count);
            SceneManager.LoadScene("mainSecond");
        }

    }
}
