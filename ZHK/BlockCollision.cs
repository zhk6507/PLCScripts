using UnityEngine;
using System.Collections;

public class BlockCollision : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag=="White")
        {
            Debug.Log("white");
            coll.gameObject.GetComponent<Rigidbody>().velocity = Vector3.right*1.1f;
            coll.gameObject.GetComponent<Rigidbody>().useGravity= true;
            coll.gameObject.GetComponent<materialmovetest>().speed = 0; 
        }
        if (coll.gameObject.tag=="Blue")
        {
            Debug.Log("blue");
            coll.gameObject.GetComponent<Rigidbody>().velocity = Vector3.right*1.25f;
            coll.gameObject.GetComponent<Rigidbody>().useGravity= true;
            coll.gameObject.GetComponent<materialmovetest>().speed = 0; 
        }
    }
       
}
