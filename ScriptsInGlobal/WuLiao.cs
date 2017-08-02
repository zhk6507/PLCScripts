using UnityEngine;
using System.Collections;

public class WuLiao : MonoBehaviour {


    public static GameObject RedWuLiaoPrefabs;
    public static GameObject BlueWuLiaoPrefabs;
    public static GameObject YellowWuLiaoPrefabs;

	// Use this for initialization
	void Start () {
        RedWuLiaoPrefabs = Resources.Load<GameObject>("");
        BlueWuLiaoPrefabs = Resources.Load<GameObject>("");
        YellowWuLiaoPrefabs = Resources.Load<GameObject>("");
	}
	
	// Update is called once per frame
	void Update () {
	}

    //工厂方法 用颜色初始化
    public static GameObject CreateNewWuLiaoWithColor(WuLiaoColor theColor)
    {
        GameObject newWuliao = null;
        switch (theColor)
        {
            case WuLiaoColor.Red:
                newWuliao = Instantiate(RedWuLiaoPrefabs);
                break;
            case WuLiaoColor.Blue:
                newWuliao = Instantiate(BlueWuLiaoPrefabs);
                break;
            case WuLiaoColor.Yellow:
                newWuliao = Instantiate(YellowWuLiaoPrefabs);
                break;
            default:
                break;
        }
        newWuliao.AddComponent<WuLiao>();
        return newWuliao;
    }

    public enum WuLiaoColor : int
    {
        Red = 0,
        Blue = 1,
        Yellow = 2
    }
}

interface WuLiaoInterface
{
    /// <summary>
    /// 从谁获得了物料 注意这个地方有泛型约束 用这个方法的类必须实现了WuLiaoInterface接口
    /// </summary>
    /// <typeparam name="T">上一个部件的类名</typeparam>
    /// <param name="part">上一个部件的实例</param>
    /// <param name="newWuliao">收到的物料</param>
    void getNewWuLiaoFromPart<T>(T part, GameObject newWuliao) where T : WuLiaoInterface;
}