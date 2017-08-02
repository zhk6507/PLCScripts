using UnityEngine;
using System.Collections;

public class flow : MonoBehaviour {
    public GameObject go;
    public Vector3 uip;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        uip = Camera.main.WorldToScreenPoint(go.transform.position);
        
	}
}
