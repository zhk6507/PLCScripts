using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI_Button : MonoBehaviour {

    public UI_ButtonsGroup group;

    private bool isOn = false;

    public bool IsOn
    {
        get { return isOn; }
        set { 
            isOn = value;
            SetOnOrOff(value);
        }
    }
    public GameObject OnGo;
    public GameObject OffGo;

    public PLCSystemState selfButtonType;
    public UI_Button menuBtn;
    public UI_Button autoBtn;
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(delegate()
        {
            //更改按钮的状态并发给主控消息
            //isOn = !isOn;
            //SetOnOrOff(isOn);
            group.ButtonClicked(this);
            //MainController.Share.SetState(selfButtonType);
        });
        //MainController.Share.systemStateChangeEvent += Share_systemStateChangeEvent;
	}

    void Share_systemStateChangeEvent(PLCSystemState newState)
    {
        //手动与自动按钮互斥
        if (newState == PLCSystemState.Auto && selfButtonType == PLCSystemState.Manual && isOn == true)
        {
            isOn = false;
            SetOnOrOff(false);
        }
        if (newState == PLCSystemState.Manual && selfButtonType == PLCSystemState.Auto && isOn == true)
        {
            isOn = false;
            SetOnOrOff(false);
        }
        //throw new System.NotImplementedException();
    }
	
	// Update is called once per frame
	void Update () {
        //SetOnOrOff(isOn);
	}
    public void SetOnOrOff(bool flg){
        OnGo.SetActive(flg);
        OffGo.SetActive(!flg);
        GetComponent<Image>().color = flg == true ? Color.green : Color.red;
    }
}
