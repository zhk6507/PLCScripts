using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI_ButtonsGroup : MonoBehaviour {
    
    public UI_Button StartButton;
    public UI_Button ResetButton;
    public UI_Button ManualButton;
    public UI_Button AutoButton;
    public UI_Button StopButton;
    public UI_Button OnPowerButton;

    public Image NoPowerWarImage;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame

	void Update () {
        //对button状态的处理 越处于判读的底部优先级越高
        //if (!StartButton.IsOn)
        //{
        //    MainController.Share.SetSignalLampState(SignalLampState.None);
        //}

        ////自身打开,没有上电,图片提醒
        //if (StartButton.IsOn && !OnPowerButton.IsOn)
        //{
        //    NoPowerWarImage.gameObject.SetActive(true);
        //    MainController.Share.SetSignalLampState(SignalLampState.Warning);
        //}

        //if (StartButton.IsOn && OnPowerButton.IsOn)
        //{
        //    NoPowerWarImage.gameObject.SetActive(false);
        //    MainController.Share.SetSignalLampState(SignalLampState.Running);
        //}

        ////没开始 复位 手动 自动 都不亮
        //if (!StartButton.IsOn)
        //{
        //    ResetButton.IsOn = false;
        //    ManualButton.IsOn = false;
        //    AutoButton.IsOn = false;
        //}
	}

    public void ButtonClicked(UI_Button clickedButton)
    {
        switch (clickedButton.selfButtonType)
        {
            case PLCSystemState.Start:
                //亮着的时候被点击了 
                if (StartButton.IsOn)
                {
                    ResetButton.IsOn = false;
                    ManualButton.IsOn = false;
                    AutoButton.IsOn = false;
                    StartButton.IsOn = false;
                }
                else
                {
                    StartButton.IsOn = true;
                }
                break;
            case PLCSystemState.Reset:
                if (StartButton.IsOn && OnPowerButton.IsOn)
                {
                    ResetButton.IsOn = !ResetButton.IsOn;
                    if (ResetButton.IsOn)
                    {
                        MainController.Share.SetState(PLCSystemState.Reset);
                    }
                    
                }
                else
                {
                    ResetButton.IsOn = false;
                }
                break;
            case PLCSystemState.Manual:
                if (StartButton.IsOn && OnPowerButton.IsOn)
                {
                    if (!ManualButton.IsOn)
                    {
                        AutoButton.IsOn = false;
                        ManualButton.IsOn = true;
                        MainController.Share.SetState(PLCSystemState.Manual);
                    }
                    else
                    {
                        ManualButton.IsOn = false;
                    }
                }
                else
                {
                    ManualButton.IsOn = false;
                }
                break;
            case PLCSystemState.Auto:
                if (StartButton.IsOn && OnPowerButton.IsOn)
                {
                    if (!AutoButton.IsOn)
                    {
                        ManualButton.IsOn = false;
                        AutoButton.IsOn = true;
                        MainController.Share.SetState(PLCSystemState.Auto);
                    }
                    else
                    {
                        AutoButton.IsOn = false;
                    }
                }
                else
                {
                    AutoButton.IsOn = false;
                }
                break;
            case PLCSystemState.Stop:
                if (StartButton.IsOn && OnPowerButton.IsOn)
                {
                    StopButton.IsOn = !StopButton.IsOn;
                }
                else
                {
                    StopButton.IsOn = false;
                }
                break;
            case PLCSystemState.OnPower:
                if (OnPowerButton.IsOn)
                {
                    ResetButton.IsOn = false;
                    ManualButton.IsOn = false;
                    AutoButton.IsOn = false;
                    StopButton.IsOn = false;
                    OnPowerButton.IsOn = false;
                }
                else
                {
                    OnPowerButton.IsOn = true;
                }
                break;
            default:
                break;
        }

        //StartButton.IsOn = false;
        //ResetButton.IsOn = false;
        //ManualButton.IsOn = false;
        //AutoButton.IsOn = false;
        //StopButton.IsOn = false;
        //OnPowerButton.IsOn = false;
    }
}

