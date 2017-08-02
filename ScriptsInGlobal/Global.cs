using UnityEngine;
using System.Collections;

/// <summary>
/// 对于运行环境下的全局变量 以及对项目的单元测试
/// </summary>
public class Global : MonoBehaviour {


    public static bool isDebug = true;
    public static float i = 0;

    /// <summary>
    /// 使用这个方法输出调试信息 以后方便在发布时快速去掉debug信息 用法和Debug一样
    /// </summary>
    /// <param name="t"></param>
    public static void Debugg(object t){
        if (isDebug)
        {
            Debug.Log(t);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    MainController.Share.SetSignalLampState(SignalLampState.Error);
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    MainController.Share.SetSignalLampState(SignalLampState.Running);
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    MainController.Share.SetSignalLampState(SignalLampState.Warning);
        //}



        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    lampControll.setLamp(HitLampColor.Bule, HitLampSate.Start);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    lampControll.setLamp(HitLampColor.Bule, HitLampSate.Flicker);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    lampControll.setLamp(HitLampColor.Bule, HitLampSate.Stop);
        //}




        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    lampControll.setLamp(HitLampColor.Yellow, HitLampSate.Start);
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    lampControll.setLamp(HitLampColor.Yellow, HitLampSate.Flicker);
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    lampControll.setLamp(HitLampColor.Yellow, HitLampSate.Stop);
        //}



        //UI或其他部分的button 让MainController转发事件
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    MainController.Share.SetState(PLCSystemState.Start);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    MainController.Share.SetState(PLCSystemState.Reset);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    MainController.Share.SetState(PLCSystemState.Manual);
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    MainController.Share.SetState(PLCSystemState.Auto);
        //}
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    MainController.Share.SetState(PLCSystemState.Stop);
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    MainController.Share.SetState(PLCSystemState.OnPower);
        //}


        //测试机械臂的运动
        if (Input.GetKeyDown(KeyCode.A))
        {
            MainController.Share.SetState(PLCSystemState.Auto);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainController.Share.SetState(PLCSystemState.Manual);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            MainController.Share.SetState(PLCSystemState.Reset);
        }
	}
}