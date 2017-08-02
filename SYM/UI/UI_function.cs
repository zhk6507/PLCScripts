using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_function : MonoBehaviour {




    public Transform c030;
    public Transform c604;
    public Transform c032;
    public Transform c033;
    public Transform c034;
    public Transform c035;

     public Transform c1;
    public Transform c2;
    public Transform c3;
    public Transform c4;
    public Transform c5;
    public Transform c6;

    public Button btn;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;
    public bool active;
    public Image warn;
	 //Use this for initialization
    /// <summary>
    /// 按钮控制对应开关
    /// </summary>
	void Start () {

        btn.onClick.AddListener(delegate
        {

            c030.gameObject.SetActive(!c030.gameObject.activeSelf);
           
                c1.gameObject.SetActive(!c1.gameObject.activeSelf);

                if (!c1.gameObject.activeSelf)
                {
                    warn.gameObject.SetActive(!warn.gameObject.activeSelf);
                }

        });
        btn1.onClick.AddListener(delegate
        {
            c604.gameObject.SetActive(!c604.gameObject.activeSelf);
            c2.gameObject.SetActive(!c2.gameObject.activeSelf);

        });
        btn2.onClick.AddListener(delegate
        {
            c032.gameObject.SetActive(!c032.gameObject.activeSelf);
            c3.gameObject.SetActive(!c3.gameObject.activeSelf);

        });
        btn3.onClick.AddListener(delegate
        {
            c033.gameObject.SetActive(!c033.gameObject.activeSelf);
            c4.gameObject.SetActive(!c4.gameObject.activeSelf);

        });
        btn4.onClick.AddListener(delegate
        {
            c034.gameObject.SetActive(!c034.gameObject.activeSelf);
            c5.gameObject.SetActive(!c5.gameObject.activeSelf);

        });
        btn5.onClick.AddListener(delegate
        {
            c035.gameObject.SetActive(!c035.gameObject.activeSelf);
            c6.gameObject.SetActive(!c6.gameObject.activeSelf);

        });

	}
    
	// Update is called once per frame
	
}
