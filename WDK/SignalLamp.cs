using UnityEngine;
using System.Collections;

/// <summary>
/// by Wdk
/// 通过setLamp方法 控制灯的颜色
/// </summary>
/// 

public class SignalLamp : MonoBehaviour
{

    private static float OnAlpha = 1F;
    private static float OffAlpha = 0.1F;

    public Material RedMaterial;
    public Material BlueMaterial;
    public Material YellowMaterial;

    private HitLampSate RedLampState = HitLampSate.Stop;
    private HitLampSate BlueLampState = HitLampSate.Stop;
    private HitLampSate YellowLampState = HitLampSate.Stop;

    // Use this for initialization
    void Start()
    {
        //YellowMaterial.SetColor(Shader.PropertyToID("_Color"), new Color(YellowMaterial.color.r, YellowMaterial.color.g, YellowMaterial.color.b, OffAlpha));
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 三个灯是互斥关系 只会有一个灯亮
    /// </summary>
    /// <param name="newState"></param>
    public void SetState(SignalLampState newState)
    {
        //先关掉全部
        StopLamp(HitLampColor.Red);
        StopLamp(HitLampColor.Bule);
        StopLamp(HitLampColor.Yellow);
        switch (newState)
        {
            case SignalLampState.Error:
                StartLamp(HitLampColor.Red);
                setLamp(HitLampColor.Red, HitLampSate.Flicker);
                break;
            case SignalLampState.Running:
                StartLamp(HitLampColor.Bule);
                
                break;
            case SignalLampState.Warning:
                StartLamp(HitLampColor.Yellow);
                setLamp(HitLampColor.Yellow, HitLampSate.Flicker);
                break;
            case SignalLampState.None:
                break;
            default:
                break;
        }
    }
    public void setLamp(HitLampColor theColor, HitLampSate theState)
    {
        switch (theColor)
        {
            case HitLampColor.Red:
                switch (theState)
                {
                    case HitLampSate.Start:
                        RedLampState = HitLampSate.Start;
                        StopLamp(theColor);
                        StopCoroutine(RedFlicker());
                        StartLamp(theColor);
                        break;
                    case HitLampSate.Flicker:
                        //Debug.Log("fliker now");
                        StopCoroutine(RedFlicker());
                        //不加判断 闪烁的节奏不对 没找到获取协程信息的方法
                        if (RedLampState != HitLampSate.Flicker)
                        {
                            RedLampState = HitLampSate.Flicker;
                            StartCoroutine(RedFlicker());
                        }
                        break;
                    case HitLampSate.Stop:
                        RedLampState = HitLampSate.Stop;
                        StopCoroutine(RedFlicker());
                        StopLamp(theColor);
                        break;
                    default:
                        break;
                }
                break;
            case HitLampColor.Bule:
                switch (theState)
                {
                    case HitLampSate.Start:
                        BlueLampState = HitLampSate.Start;
                        StopLamp(theColor);
                        StopCoroutine(BlueFlicker());
                        StartLamp(theColor);
                        break;
                    case HitLampSate.Flicker:
                        //Debug.Log("fliker now");
                        StopCoroutine(BlueFlicker());
                        //不加判断 闪烁的节奏不对 没找到获取协程信息的方法
                        if (BlueLampState != HitLampSate.Flicker)
                        {
                            BlueLampState = HitLampSate.Flicker;
                            StartCoroutine(BlueFlicker());
                        }
                        break;
                    case HitLampSate.Stop:
                        BlueLampState = HitLampSate.Stop;
                        StopCoroutine(BlueFlicker());
                        StopLamp(theColor);
                        break;
                    default:
                        break;
                }
                break;
            case HitLampColor.Yellow:
                switch (theState)
                {
                    case HitLampSate.Start:
                        YellowLampState = HitLampSate.Start;
                        StopLamp(theColor);
                        StopCoroutine(YellowFlicker());
                        StartLamp(theColor);
                        break;
                    case HitLampSate.Flicker:
                        //Debug.Log("fliker now");
                        StopCoroutine(YellowFlicker());
                        //不加判断 闪烁的节奏不对 没找到获取协程信息的方法
                        if (YellowLampState != HitLampSate.Flicker)
                        {
                            YellowLampState = HitLampSate.Flicker;
                            StartCoroutine(YellowFlicker());
                        }
                        break;
                    case HitLampSate.Stop:
                        YellowLampState = HitLampSate.Stop;
                        StopCoroutine(YellowFlicker());
                        StopLamp(theColor);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }


    private void FlickerLamp(Material theLap)
    {
        if (theLap.color.a == OnAlpha)
        {
            theLap.SetColor(Shader.PropertyToID("_Color"), new Color(theLap.color.r, theLap.color.g, theLap.color.b, OffAlpha));
        }
        else
        {
            theLap.SetColor(Shader.PropertyToID("_Color"), new Color(theLap.color.r, theLap.color.g, theLap.color.b, OnAlpha));
        }
    }
    private void StartLamp(HitLampColor theColor)
    {
        switch (theColor)
        {
            case HitLampColor.Red:
                RedLampState = HitLampSate.Start;
                RedMaterial.SetColor(Shader.PropertyToID("_Color"), new Color(RedMaterial.color.r, RedMaterial.color.g, RedMaterial.color.b, OnAlpha));
                break;
            case HitLampColor.Bule:
                BlueLampState = HitLampSate.Start;
                BlueMaterial.SetColor(Shader.PropertyToID("_Color"), new Color(BlueMaterial.color.r, BlueMaterial.color.g, BlueMaterial.color.b, OnAlpha));
                break;
            case HitLampColor.Yellow:
                YellowLampState = HitLampSate.Start;
                YellowMaterial.SetColor(Shader.PropertyToID("_Color"), new Color(YellowMaterial.color.r, YellowMaterial.color.g, YellowMaterial.color.b, OnAlpha));
                break;
            default:
                break;
        }
    }

    private void StopLamp(HitLampColor theColor)
    {
        switch (theColor)
        {
            case HitLampColor.Red:
                RedLampState = HitLampSate.Stop;
                RedMaterial.SetColor(Shader.PropertyToID("_Color"), new Color(RedMaterial.color.r, RedMaterial.color.g, RedMaterial.color.b, OffAlpha));
                break;
            case HitLampColor.Bule:
                BlueLampState = HitLampSate.Stop;
                BlueMaterial.SetColor(Shader.PropertyToID("_Color"), new Color(BlueMaterial.color.r, BlueMaterial.color.g, BlueMaterial.color.b, OffAlpha));
                break;
            case HitLampColor.Yellow:
                YellowLampState = HitLampSate.Stop;
                YellowMaterial.SetColor(Shader.PropertyToID("_Color"), new Color(YellowMaterial.color.r, YellowMaterial.color.g, YellowMaterial.color.b, OffAlpha));
                break;
            default:
                break;
        }
    }
    //闪烁的协程
    IEnumerator RedFlicker()
    {
        while (RedLampState == HitLampSate.Flicker)
        {
            FlickerLamp(RedMaterial);
            yield return new WaitForSeconds(0.5F);
        }
    }
    IEnumerator BlueFlicker()
    {
        while (BlueLampState == HitLampSate.Flicker)
        {
            FlickerLamp(BlueMaterial);
            yield return new WaitForSeconds(0.5F);
        }
    }
    IEnumerator YellowFlicker()
    {

        while (YellowLampState == HitLampSate.Flicker)
        {
            FlickerLamp(YellowMaterial);
            yield return new WaitForSeconds(0.5F);
        }
    }



}
//对颜色和状态的枚举
public enum HitLampColor : int
{
    Red = 0,
    Bule = 1,
    Yellow = 2
}

public enum HitLampSate : int
{
    //开始 亮(但不一定会闪烁)
    Start = 0,
    //闪烁 (一定会闪烁)
    Flicker = 1,
    //停止 亮(不亮 也不闪烁)
    Stop = 2
}
