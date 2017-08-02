using UnityEngine;
using System.Collections;

public class CreatRingAndMove : MonoBehaviour {
    public UI_Button StartBtn;
    public UI_Button OnPower;
    public Transform[] Rings = new Transform[3];
    public Transform MaterialCylinder;
	// Use this for initialization
    void Start()
    {
        if (StartBtn.IsOn&&OnPower.IsOn)
        {
            StartCoroutine(RingCreat());
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator RingCreat()
    {
        for (int i = 0; i <4; i++)
        {
            Instantiate(Rings[Random.Range(0, Rings.Length)], MaterialCylinder.position, Quaternion.identity);

             yield return new WaitForSeconds(2f);
        }
       
    }
    
    void OnCollisionEnter(Collision coll)
    {
        for (int i = 0; i <2; i++)
			{
                if (coll.gameObject == Rings[i])
                {
                    Rings[i].transform.Translate(Vector3.back);
                }
			}
       
    }
}
