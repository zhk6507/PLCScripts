using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 整个传送带的控制部分
/// </summary>
public class ChuanSongDai : MonoBehaviour,WuLiaoInterface {

    #region 物料的阻力控制变量
    /// <summary>
    /// 物料正常下落的阻力
    /// </summary>
    public static float WuliaoFlowSpeedDrag = -20;
    /// <summary>
    /// 物料在传送带上的阻力
    /// </summary>
    public static float WuliaoFlowChuangSongDaiDrag = 30;
    #endregion

    //传送带上的物料 只要传送带动 所有的物料都要动
    public Stack<GameObject> wuLiaos = new Stack<GameObject>();
    //传送的带子
    public GameObject chuanSongDaiGo;

    //传送带运动速度
    public float m_scrollSpeed = 0.5F;

    public float ScrollSpeed
    {
        get { return m_scrollSpeed; }
        set {
            m_scrollSpeed = value;
            DaiZhi.scrollSpeed = value;
        }
    }
	//当前的传送速度
    public float m_currentScrollSpeed = 0F;

    public float CurrentScrollSpeed
    {
        get { return m_currentScrollSpeed; }
        set {
            m_currentScrollSpeed = value;
            DaiZhi.currentScrollSpeed = value;
        }
    }
    //物料的运动速度是相对于传送带的速度的一个比值
    public float m_wuLiaoSpeedPreCSD = 204F;

    public float WuLiaoSpeedPreCSD
    {
        get { return m_wuLiaoSpeedPreCSD; }
        set {
            m_wuLiaoSpeedPreCSD = value;
            DaiZhi.wuLiaoSpeedPreCSD = value;
        }
    }
    //传送的带子 用于控制移动速度
    public ChuanSongDaiZhi DaiZhi;

    // Use this for initialization
	void Start () {
        CurrentScrollSpeed = ScrollSpeed;
        DaiZhi.currentScrollSpeed = CurrentScrollSpeed;
        MainController.Share.systemStateChangeEvent += Share_systemStateChangeEvent;
	}

    void Share_systemStateChangeEvent(PLCSystemState newState)
    {
        switch (newState)
        {
            case PLCSystemState.Start:
                break;
            case PLCSystemState.Reset:
                break;
            case PLCSystemState.Manual:
                break;
            case PLCSystemState.Auto:
                break;
            case PLCSystemState.Stop:
                break;
            case PLCSystemState.OnPower:
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    //从机械臂获得物料
    void WuLiaoInterface.getNewWuLiaoFromPart<T>(T part, GameObject newWuliao)
    {
        newWuliao.transform.parent = chuanSongDaiGo.transform;
        wuLiaos.Push(newWuliao);
    }
}
