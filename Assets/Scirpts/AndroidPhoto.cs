using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AndroidPhoto : MonoBehaviour
{
    public RawImage yingyezhizhao;
    public RawImage goods;
    private int typeid; // 0 营业执照  1 物品
    public IOSPhoto ios;
    // Use this for initialization
    void Start()
    {
    }

    public Text debug;
    //打开相册	
    public void OpenPhoto(int typeid)
    {

        this.typeid = typeid;
#if UNITY_ANDROID
        Debug.Log("CAMERA");
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("OpenGallery");
#elif UNITY_IPHONE
		ios.OpenPhoto();
#endif

    }

    //打开相机
    public void OpenCamera()
    {
#if UNITY_ANDROID
        Debug.Log("PHONE");
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("takephoto");
#elif UNITY_IPHONE
		ios.OpenCamera();
#endif
    }

    public void BACK(string DATA)
    {
        debug.text = DATA;
    }


    public void GetImagePath(string imagePath)
    {
        if (imagePath == null)
            return;
        StartCoroutine("Load", imagePath);
    }

    public void GetTakeImagePath(string imagePath)
    {
        if (imagePath == null)
            return;
        StartCoroutine("Load", imagePath);
    }

    private IEnumerator Load(string imagePath)
    {

        WWW www = new WWW("file://" + imagePath);
        yield return www;
        if (www.error == null)
        {
            //成功读取图片，写自己的逻辑
            //GetComponent<ChangePhoto>().LoadAndroidImageOK(www.texture);
            //MessageManager._Instantiate.Show("现车获取成功，等待上传");
            SendPictureByTypeId(www.texture);
        }
        else
        {
            Debug.LogError("LoadImage>>>www.error:" + www.error);
        }
    }


    public void SendPictureByTypeId(Texture2D texture2D)
    {
        if (typeid == 0)
        {
            yingyezhizhao.texture = texture2D;
            yingyezhizhao.transform.GetChild(0).gameObject.SetActive(false);
            LoadImage.GetLoadIamge.SendImage(texture2D, 0);
        }
        else
        {
            goods.texture = texture2D;
            goods.transform.GetChild(0).gameObject.SetActive(false);
            LoadImage.GetLoadIamge.SendImage(texture2D, 1);
        }

    }
}
