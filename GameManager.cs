using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //Controller2D脚本的参量  
    public Controller2D controller2D;
    //角色生命值  
    public Texture playersHealthTexture;
    //控制上面那个Teture的屏幕所在位置  
    public float screenPositionX;
    public float screenPositionY;
    //控制桌面图标的大小  
    public int iconSizeX = 25;
    public int iconSizeY = 25;
    //初始生命值  
    public int playersHealth = 3;
    GameObject player;
    //这个地方定义了私有变量player作为一个GameObject，然后用下面的FindGameObjectWithTag获取它，这样的话，在下面的伤害判断时，就可以用player.renderer了。  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //OnGUI函数最好不要出现多次，容易造成混乱，所以我把要展示的东西都整合在这个里面  
    void OnGUI()
    {

        //控制角色生命值的心的显示  
        for (int h = 0; h < playersHealth; h++)
        {
            GUI.DrawTexture(new Rect(screenPositionX + (h * iconSizeX), screenPositionY, iconSizeX, iconSizeY), playersHealthTexture, ScaleMode.ScaleToFit, true, 0);
        }
    }

    void PlayerDamaged(int damage)
    {   //此处使用player.renderer.enabled来进行判断，如果角色没有在闪烁，也就是存在的状态为真，那么才会受到伤害，这样可以避免角色连续受伤，还有另外一种方法是采用计时，这里没有采用那种方法。  
　　      if (player.GetComponent<Renderer>().enabled)
        {
            if (playersHealth > 0)
            {
                playersHealth -= damage;
            }

            if (playersHealth <= 0)
            {
                RestartScene();
            }
        }
    }

    void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}