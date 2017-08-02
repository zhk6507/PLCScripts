using UnityEngine;
using System.Collections;

public class ForceFunction : MonoBehaviour {
    public Transform ForcePole;
    private  bool run;
    public bool Active;
    public Transform EnterGreenLamp;
    public Transform ExstGreenLamp;

    public RobotArm arm;
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
          StartCoroutine(Move());
	}
    IEnumerator Move()
    {
        //Z轴在一定范围内运动
        if (run == true)
        {
            //自身坐标大于所到位置,进入
            if (ForcePole.position.z >= 1966f)
            {
                ForcePole.Translate(new Vector3(2f, 0f, 0f) * 0.1f);
                EnterGreenLamp.gameObject.SetActive(!Active);
            }
                //否则退出
            else {
               
                run = false;
                ExstGreenLamp.gameObject.SetActive(!Active);
            }
        }
            //其余范围的判定
        else 
        {
            //自身坐标小于所到位置,反方向退出
            if (ForcePole.position.z< 1966f)
            
            {
                ForcePole.Translate(new Vector3(-2f, 0f, 0f) * 0.1f);
                run = false;
                ExstGreenLamp.gameObject.SetActive(!Active);
            }
                //出了自身坐标范围,从新进入
           else if(ForcePole.position.z>= 2002f) {

               run = true;
               EnterGreenLamp.gameObject.SetActive(!Active);
            }
            else
            {
               //出了所到物体坐标,退出
                ForcePole.Translate(new Vector3(-2f, 0f, 0f) * 0.1f);
               
                run = false;
                ExstGreenLamp.gameObject.SetActive(!Active);
            }
        
        }
       
        yield return null;

    }
    
    enum MoveFocre : int
    {
        Reset = 0,
        Right = 1,
        Left = 2
    }

    void SongWuLiao()
    {
        
    }
}
