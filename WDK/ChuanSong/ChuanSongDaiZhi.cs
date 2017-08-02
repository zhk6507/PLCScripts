using UnityEngine;
using System.Collections;

/// <summary>
/// 传送的带子 只负责移动物料
/// </summary>
public class ChuanSongDaiZhi : MonoBehaviour {

    //传送带运动速度
    public float scrollSpeed = 0.5F;
    //当前的传送速度
    public float currentScrollSpeed = 0F;
    //物料的运动速度是相对于传送带的速度的一个比值
    public float wuLiaoSpeedPreCSD = 204F;
    //传送带的材质 用来模拟滚动传送带
    public Material chuanSongDaiMeterial;


    public ChuanSongDai CSDController;
    // Use this for initialization
	void Start () {
        currentScrollSpeed = scrollSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        #region 自动时才自动滚动
        if (MainController.Share.currentState == PLCState.Auto)
        {
            float oldOffset = chuanSongDaiMeterial.GetTextureOffset("_MainTex").x;
            float offset = oldOffset + Time.deltaTime * CSDController.CurrentScrollSpeed;
            chuanSongDaiMeterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        #endregion
    }

    #region 物料在传送带上的运动控制
    void OnCollisionEnter(Collision collisionInfo)
    {
        //碰撞进入时 减慢物料的下落阻力
        collisionInfo.rigidbody.drag = ChuanSongDai.WuliaoFlowChuangSongDaiDrag;
        collisionInfo.rigidbody.isKinematic = false;
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        //如果是在碰物料 物料的移动速度固定 并且跟随传送带
        if (collisionInfo.rigidbody.gameObject.GetComponent<WuLiao>() != null)
        {
            GameObject wl = collisionInfo.rigidbody.gameObject;
            var wulOldP = wl.transform.position;
            wulOldP.x += Time.deltaTime * CSDController.WuLiaoSpeedPreCSD * CSDController.CurrentScrollSpeed;
            wl.transform.position = wulOldP;
        }
    }
    //退出碰撞 啥事也不干 让检查部件给物料一个力 但是要恢复物料的重力
    void OnCollisionExit(Collision conllisionInfo)
    {
        //conllisionInfo.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        //conllisionInfo.rigidbody.drag = ChuanSongDai.WuliaoFlowSpeedDrag;
    }
    #endregion
}
