using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 机械臂 控制旋转 前进 张合手臂
/// </summary>
public class RobotArm : MonoBehaviour, WuLiaoInterface
{




    //物料数组 用堆栈处理 不需要考虑越界问题 也符合实际情况
    public Stack<GameObject> wuLiaos = new Stack<GameObject>();
    //当前处理的物料
    public GameObject currentWuLiao;

    //传送带
    public ChuanSongDai chuanSongDai;
    ///旋转部分
    public Transform PartOneGo;
    //要旋转到的角度
    public float DesRotateValue = 0f;
    //旋转的速度 度/帧（大概 1秒转1度）
    public float RotateValuePerFrame = 1 / 60F;
    //旋转的精度
    public float RotatePrecision = 1F;
    //原始位置(复位后的旋转角度)
    public float OrgRotationValue = -90F;
    //左转最大值
    public float LeftRotationValue = -55.7F;
    //右转最大值
    public float RightRotationValue = -117F;

    public float 我是分割线;
    //前进后退部分
    /// 用来前进 后退的物体
    public Transform PartTwoGo;
    public float OrgForward = 0f;
    public float MaxForward = -227F;
    public float MinForward = -140F;
    public float DesForward = 0f;
    public float ForwardPrecision = 0.1F;

    public float 我也是分割线;
    public Transform PartThreeGo;
    public float OrgUpDown = 0f;
    public float MaxUp = -1131F;
    public float MinDown = -1206F;
    public float DesUpDown = 0f;
    public float UpDownPrecision = 0.1f;

    public float 我还是分割线;
    public Transform PartFourGo;



    //取物料的位置
    public RobotArmMoveStruct InPostionState = new RobotArmMoveStruct();
    //放物料的位置
    public RobotArmMoveStruct OutPostionState = new RobotArmMoveStruct();
    //原点位置
    public RobotArmMoveStruct OrgPostionState = new RobotArmMoveStruct();

    //是否在移动
    public bool isMoving = false;
    //是否移动到了最左侧
    public bool isMoveToLeft = false;
    //是否移动到了最右侧
    public bool isMoveToRight = false;
    //res的值不用管

    public GameObject TestWuLiao;

    void Start()
    {

        //保存一下原始位置
        OrgRotationValue = PartOneGo.localEulerAngles.y;
        OrgForward = PartTwoGo.localPosition.x;
        OrgUpDown = PartThreeGo.localPosition.y;

        //当前位置设置为原始位置
        DesRotateValue = OrgRotationValue;
        DesForward = OrgForward;
        DesUpDown = OrgUpDown;

        OrgPostionState.PartFourValue = OrgRotationValue;
        OrgPostionState.PartTwoValue = OrgForward;
        OrgPostionState.PartThreeValue = OrgUpDown;

        InPostionState.PartOneValue = 36F;
        InPostionState.PartTwoValue = -220F;
        InPostionState.PartThreeValue = -1186F;

        OutPostionState.PartOneValue = -28F;
        OutPostionState.PartTwoValue = -191F;
        OutPostionState.PartThreeValue = -1169F;

        //监听事件
        MainController.Share.systemStateChangeEvent += Share_systemStateChangeEvent;

        for (int i = 0; i < 100; i++)
        {
            GameObject newWL = Instantiate<GameObject>(TestWuLiao);
            newWL.AddComponent<WuLiao>();
            newWL.transform.parent = PartFourGo;
            newWL.transform.localPosition = Vector3.zero;
            wuLiaos.Push(newWL);
        }
    }

    void Share_systemStateChangeEvent(PLCSystemState newState)
    {
        switch (newState)
        {
            case PLCSystemState.Start:
                break;
            case PLCSystemState.Reset:
                setArmStateByMoveStruct(OrgPostionState);
                break;
            case PLCSystemState.Manual:
                setArmStateByMoveStruct(OutPostionState);
                break;
            case PLCSystemState.Auto:
                setArmStateByMoveStruct(InPostionState);
                break;
            case PLCSystemState.Stop:
                DesRotateValue = OrgRotationValue;
                break;
            case PLCSystemState.OnPower:
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region 处理旋转

        //旋转这部分比较容易进坑 1:转向问题 2:在Inspect面板里看到的负角不是localEulerAngles分量的值 unity会将这个值转成正值 但是可以用负向处理旋转
        //目标是往左转
        if (DesRotateValue >= 0)
        {
            if (Mathf.Abs(DesRotateValue - PartOneGo.localEulerAngles.y) > RotatePrecision)
            {
                float smooth = 2.0F;
                Quaternion target = Quaternion.Euler(0, DesRotateValue, 0);
                PartOneGo.localEulerAngles = Quaternion.Slerp(PartOneGo.localRotation, target, Time.deltaTime * smooth).eulerAngles;
                isMoving = true;
                isMoveToLeft = false;
                isMoveToRight = false;
            }
            else
            {
                isMoveToLeft = true;
                isMoving = false;
            }
        }//目标往右转
        else
        {
            if (Mathf.Abs(DesRotateValue - (PartOneGo.localEulerAngles.y - 360)) > RotatePrecision)
            {
                float smooth = 2.0F;
                Quaternion target = Quaternion.Euler(0, DesRotateValue, 0);
                PartOneGo.localEulerAngles = Quaternion.Slerp(PartOneGo.localRotation, target, Time.deltaTime * smooth).eulerAngles;
                isMoving = true;
                isMoveToRight = false;
                isMoveToLeft = false;
            }
            else
            {
                isMoveToRight = true;
                isMoving = false;
            }
        }
        //前进 后退部分
        if (Mathf.Abs(Mathf.Abs(DesForward) - Mathf.Abs(PartTwoGo.localPosition.x)) > ForwardPrecision)
        {
            var newForward = PartTwoGo.localPosition;
            newForward.x += (DesForward - PartTwoGo.localPosition.x) * RotateValuePerFrame;
            PartTwoGo.localPosition = newForward;
        }
        //上下部分
        if (Mathf.Abs(Mathf.Abs(DesUpDown) - Mathf.Abs(PartThreeGo.localPosition.y)) > UpDownPrecision)
        {
            var newUpDown = PartThreeGo.localPosition;
            newUpDown.y += (DesUpDown - PartThreeGo.localPosition.y) * RotateValuePerFrame;
            PartThreeGo.localPosition = newUpDown;
        }
        #endregion

        #region 处理自动
        if (MainController.Share.currentState == PLCState.Auto)
        {
            //到右端时 放下物体 移回到左端 
            if (isMoveToRight)
            {
                setArmStateByMoveStruct(InPostionState);
                if (wuLiaos.Count > 0)
                {
                    if (currentWuLiao != null)
                    {
                        (chuanSongDai as WuLiaoInterface).getNewWuLiaoFromPart<RobotArm>(this, currentWuLiao);
                        //先往下位移一点 再加刚体
                        currentWuLiao.transform.Translate(new Vector3(0, -10, 0), Space.World);
                        currentWuLiao.AddComponent<BoxCollider>();
                        currentWuLiao.GetComponent<BoxCollider>().isTrigger = false;
                        currentWuLiao.AddComponent<Rigidbody>();
                        currentWuLiao.GetComponent<Rigidbody>().mass = 0.1f;
                        currentWuLiao.GetComponent<Rigidbody>().drag = ChuanSongDai.WuliaoFlowSpeedDrag;
                        
                    }
                    currentWuLiao = null;
                }
            }
            //到左端时 拿起物体 移回右端
            if (isMoveToLeft)
            {
                if (wuLiaos.Count != 0)
                {
                    currentWuLiao = wuLiaos.Pop();
                    currentWuLiao.transform.parent = PartFourGo;
                    currentWuLiao.transform.localPosition = Vector3.zero;
                }
                setArmStateByMoveStruct(OutPostionState);
            }
        }

        #endregion
    }
    //移动到固定点的快捷方法
    private void setArmStateByMoveStruct(RobotArmMoveStruct theStruct)
    {
        DesRotateValue = theStruct.PartOneValue;
        DesForward = theStruct.PartTwoValue;
        DesUpDown = theStruct.PartThreeValue;
    }

    public struct RobotArmMoveStruct
    {
        public float PartOneValue;
        public float PartTwoValue;
        public float PartThreeValue;
        public float PartFourValue;
    }

    /// <summary>
    /// 外部调用这个接口 给机械臂一个物料
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="part"></param>
    /// <param name="newWuliao"></param>
    void WuLiaoInterface.getNewWuLiaoFromPart<T>(T part, GameObject newWuliao)
    {
        Debug.Log("Great!!!");
        wuLiaos.Push(newWuliao);
    }
}
