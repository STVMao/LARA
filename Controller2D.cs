using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour
{
    //引用CharacterController  
    CharacterController characterController;
    //重力  
    public float gravity = 10;
    //水平移动的速度  
    public float walkSpeed = 5;
    //弹跳高度  
    public float jumpHeight = 5;

    //显示角色当前正受到攻击  
    float takenDamage = 0.2f;

    // 控制角色的移动方向  
    Vector3 moveDirection = Vector3.zero;
    float horizontal = 0;
    // Use this for initialization  
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame  
    void Update()
    {
        //控制角色的移动  
        characterController.Move(moveDirection * Time.deltaTime);
        horizontal = Input.GetAxis("Horizontal");
        //控制角色的重力  
        moveDirection.y -= gravity * Time.deltaTime;
        //控制角色右移（按d键和右键时）  在这里不直接使用0而是用0.01f是因为使用0之后会持续移动，无法静止  
        if (horizontal > 0.01f)
        {
            moveDirection.x = horizontal * walkSpeed;
        }
        //控制角色左移（按a键和左键时）  
        if (horizontal < 0.01f)
        {
            moveDirection.x = horizontal * walkSpeed;
        }
        // 弹跳控制  
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpHeight;
            }
        }
    }
    public IEnumerator TakenDamage()
    {
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(takenDamage);
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(takenDamage);
    }
}


