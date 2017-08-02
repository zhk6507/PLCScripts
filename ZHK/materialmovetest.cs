using UnityEngine;
using System.Collections;

public class materialmovetest : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(0,0,speed*Time.deltaTime,Space.World);
	}
    
}
