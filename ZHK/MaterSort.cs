using UnityEngine;
using System.Collections;

public class MaterSort : MonoBehaviour {
    //public Vector3 fwd;
    RaycastHit hit;
    public GameObject block;
    public float angle;
    public WuLiaoColor theColor;

    private bool isDone = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("A");
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f)) {
            Debug.Log("B");
            if (ColorEnumToString(hit.collider.gameObject.tag) == theColor && !isDone)
            {
                Debug.Log("C");
                Debug.Log(hit.collider.gameObject.name);
                isDone = true;
                block.transform.Rotate(Vector3.back*angle);
                StartCoroutine(BlockBack());
                hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 10f;
                hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                hit.collider.gameObject.GetComponent<materialmovetest>().speed = 0;
            }
        }
                     
	}

    IEnumerator BlockBack()
    {
        yield return new WaitForSeconds(0.5f);
        block.transform.Rotate(Vector3.forward * angle);
        isDone = false;
    }

    private WuLiaoColor ColorEnumToString(string flg)
    {
        switch (flg)
        {
            case "Black":
                return WuLiaoColor.Black;
            case "White":
                return WuLiaoColor.White;
            case "Blue":
                return WuLiaoColor.Blue;
            default:
                return WuLiaoColor.None;
        }
    }
}
public enum WuLiaoColor: int{
    Black = 0,
    White = 1,
    Blue = 2,
    None = 3
}
