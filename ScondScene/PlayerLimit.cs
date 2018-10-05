using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimit : MonoBehaviour
{
    //主角最高的Y
    public float limit_Y;
    public float bootom_Y;
    public float left_X;
    public float right_X;
    private Transform player;//主角
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y >= limit_Y)
        {
            player.position = new Vector3(player.position.x, limit_Y, player.position.z);
        }
        else if (player.position.y <= bootom_Y)
        {
            player.position = new Vector3(player.position.x, bootom_Y, player.position.z);
        }
        if (player.position.x >= right_X)
        {
            player.position = new Vector3(right_X, player.position.y, player.position.z);
        }
        else if (player.position.x <= left_X)
        {
            player.position = new Vector3(left_X, player.position.y, player.position.z);
        }


    }
}
