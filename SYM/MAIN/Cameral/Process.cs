using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Process : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    public Button btn;
    public GameObject go;
    public bool active;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position1 = Camera.main.WorldToScreenPoint(go.transform.position);
       
        btn.gameObject.GetComponent<RectTransform>().anchoredPosition= new Vector2( position1.x,position1.y+200f);

        
	  ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.collider.gameObject == go)
            {
                btn.gameObject.SetActive(!active);
            }
            
        }
        
	}
}
