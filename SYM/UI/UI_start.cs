using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_start : MonoBehaviour
{

    public GameObject startT;
    public GameObject startF;
    private Ray ray;
    private RaycastHit hit;
    public bool actives;


    // Use this for initialization
    void Start()
    {


        startT.SetActive(actives);
        startF.SetActive(!actives);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                startT.SetActive(actives);
                startF.SetActive(!actives);
                actives = !actives;

            }


        }
    }
   
}




