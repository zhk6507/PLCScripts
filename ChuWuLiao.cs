using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChuWuLiao : MonoBehaviour {
    //物料的预制体
    public GameObject WuLiaoPrefab;
    //创建物料的地方
    public Transform createPoint;
    //保存物料的栈
    public Stack<GameObject> wuLiaos = new Stack<GameObject>();
    //推杆
    public GameObject TuiGan;

    //推的量
    public float PushValue = 100F;
    //回去的量
    public float BackValue = 0F;
    //推或回的标志 true:回的状态 false:推的状态
    public bool BackOrPush = true;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 1; i++)
        {
            CreateWuLiao();
        }

	}
	
	// Update is called once per frame
	void Update () {
        foreach (var item in wuLiaos)
        {
            if (item.GetComponent<Rigidbody>() != null)
            {
                if (item.GetComponent<Rigidbody>().constraints == (RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionZ))
                {
                    //Debug.Log("Push WuLiao");
                    //item.GetComponent<Rigidbody>().AddForce(Vector3.down*10F);

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            TuiWuLiao();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TuiGanBack();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateWuLiao();
        }

        //回的状态
        if (BackOrPush)
        {
            if (BackValue > 0)
            {
                TuiGan.transform.Translate(new Vector3(-1, 0, 0));
                BackValue -= 1;
            }

        //推的状态
        }
        else
        {
            if (PushValue < 100)
            {
                TuiGan.transform.Translate(new Vector3(1,0,0));
                PushValue += 1;
            }
        }
	}

    public void CreateWuLiao()
    {
        GameObject newWL = Instantiate(WuLiaoPrefab);
        newWL.transform.parent = transform;
        newWL.transform.position = createPoint.position;
        newWL.AddComponent<WuLiao>();
        newWL.AddComponent<BoxCollider>();
        newWL.AddComponent<Rigidbody>();
        newWL.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        newWL.GetComponent<Rigidbody>().drag = 0f;

        wuLiaos.Push(newWL);
    }
    public void TuiWuLiao()
    {
        BackOrPush = false;
        PushValue = 0;
        //TuiGan.transform.Translate(new Vector3(100,0,0));
    }
    public void TuiGanBack()
    {
        BackOrPush = true;
        BackValue = 100;
        //TuiGan.transform.Translate(new Vector3(-100, 0, 0));
    }
}
