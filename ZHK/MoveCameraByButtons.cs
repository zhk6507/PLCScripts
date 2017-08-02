using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveCameraByButtons : MonoBehaviour
{
    /// <summary>
    /// 获得三个视图的按钮
    /// </summary>
    public Button FrontButton;
    public Button BackButton;
    public Button TopButton;
    public MoveCameraByMouse mcbm;

    public Vector2 btn1V;
    public Vector2 btn2V;
    public Vector2 btn3V;


    public float distanceToCamera = 1500f;

    public float textX;
    public float textY;
    // Use this for initialization
    void Start()
    {
        //添加三个按钮的点击事件
        FrontButton.onClick.AddListener(delegate
        {
            mcbm.x = 0f;
            mcbm.y = 45f;
            mcbm.distance = distanceToCamera;
            btn1V = new Vector2(mcbm.x, mcbm.y);
        });

        BackButton.onClick.AddListener(delegate {
            mcbm.x = 180f;
            mcbm.y = 45f;
            mcbm.distance = distanceToCamera;
            btn2V = new Vector2(mcbm.x, mcbm.y);
        });
        TopButton.onClick.AddListener(delegate {
            mcbm.x = 0f;
            mcbm.y = 90f;
            mcbm.distance = distanceToCamera;
            btn3V = new Vector2(mcbm.x, mcbm.y);
        });
    }
    void Update()
    {
        //mcbm.x = textX;
        //mcbm.y = textY;
    }
}
