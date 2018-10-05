using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public static MouseMove _Instance;
    [Header("鼠标点击的点")]
    public Vector3 currentPoint = Vector3.zero;
    [Header("player当前的点")]
    public Vector3 oldPoint = Vector3.zero;
    public float player_Scale;
    public float move_Speed;

    public static bool isMove = true;
    public static bool IsMouseEntrUIRoot
    {
        get
        {
            Vector3 mousePosition = Input.mousePosition;
            GameObject hoverObject = UICamera.Raycast(mousePosition) ? UICamera.lastHit.collider.gameObject : null;//三元运算符
            if (hoverObject != null)
                return false;
            return true;
        }
    }

    private void Awake()
    {
        _Instance = this;
    }
    void Start()
    {
        oldPoint = transform.position;
        currentPoint = transform.position;
    }
    void Update()
    {
        if (!isMove)
            return;

        oldPoint = transform.position;
        if (Input.GetMouseButtonDown(0) && IsMouseEntrUIRoot)
        {
            currentPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
        if (Vector3.Distance(currentPoint, oldPoint) >= 0.2f)
        {
            Vector3 nor = (currentPoint - oldPoint).normalized;
            transform.Translate(nor * Time.deltaTime * move_Speed);
        }

        if (oldPoint.x > currentPoint.x)
            transform.localScale = new Vector3(-player_Scale, player_Scale, player_Scale);
        else
            transform.localScale = new Vector3(player_Scale, player_Scale, player_Scale);

    }
}
