using UnityEngine;
using System.Collections;

public class CSDPartOne : MonoBehaviour {

    /// <summary>
    /// 推物料的力度
    /// </summary>
    public float PushValue = 3509;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit RayInfo = new RaycastHit();
        if (Physics.Raycast(transform.position, Vector3.down, out RayInfo))
        {
            //射到了物料
            if (RayInfo.collider.gameObject.GetComponent<WuLiao>() != null)
            {
                var WLR = RayInfo.collider.gameObject.GetComponent<Rigidbody>();
                WLR.gameObject.transform.Translate(Vector3.forward.normalized * Time.deltaTime * PushValue, Space.World);
                WLR.isKinematic = false;
                WLR.drag = -0.5f;
            }
        }
	}
}
