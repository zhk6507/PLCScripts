using UnityEngine;
using System.Collections;


public class MainController:MonoBehaviour
{

    //状态改变的事件
    public delegate void PLCSystemStateChangeHandler(PLCSystemState newState);
    //和主控有关的部分要监听这个事件 参考RobotArm.cs文件
    public event PLCSystemStateChangeHandler systemStateChangeEvent;

    //单利
    public static MainController Share;
    //指示灯
    public SignalLamp signalLamp;
    //机械臂
    public RobotArm robotArm;
    //传送带
    public ChuanSongDai chuanSongDai;

    //系统当前状态
    public PLCState currentState = PLCState.None;

    void Awake()
    {
        Share = this;
        
    }
    void Start()
    {
        if (signalLamp == null)
        {
            Global.Debugg("Null");
        }
    }

    /// <summary>
    /// UI部分调用这个方法 发送系统切换状态消息
    /// </summary>
    /// <param name="newState">PLC:系统整体状态的枚举</param>
    public void  SetState(PLCSystemState newState)
    {
        systemStateChangeEvent(newState);
        switch (newState)
        {
            case PLCSystemState.Start:
                break;
            case PLCSystemState.Reset:
                currentState = PLCState.Reset;
                break;
            case PLCSystemState.Manual:
                currentState = PLCState.Manual;
                break;
            case PLCSystemState.Auto:
                currentState = PLCState.Auto;
                break;
            case PLCSystemState.Stop:
                break;
            case PLCSystemState.OnPower:
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// UI部分调用这个方法 改变指示灯的状态 
    /// </summary>
    /// <param name="newState">SignalLampState：想让指示灯处于哪种状态的枚举值</param>
    public void SetSignalLampState(SignalLampState newState)
    {
        //Global.Debugg("SetSignalLampState");
        signalLamp.SetState(newState);
    }
}

//系状态的枚举
public enum PLCSystemState : int
{
    //开始
    Start = 0,
    //复位
    Reset = 1,
    //手动
    Manual = 2,
    //自动
    Auto = 3,
    //停止
    Stop = 4,
    //上电
    OnPower = 5
}

//运动方向的枚举 （在模型前视图里来看 部件的运动有 左、右、上、下）
public enum PLCPartMoveDirection : int
{
    //左
    Left = 0,
    Right = 1,
    Up = 2,
    Down = 3,
    //不运动
    None = 4
}

//指示灯状态的枚举
public enum SignalLampState : int
{
    Error = 0,
    Running = 1,
    Warning = 2,
    None = 3
}

//整体运行状态
public enum PLCState : int
{
    Manual = 0,
    Auto = 1,
    Reset = 2,
    None = 3
}