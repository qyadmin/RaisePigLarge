using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class SaveImage : MonoBehaviour
{
    public void SavePicture()
    {
        //StartCoroutine(SavePngToSD(DateTime.Now.ToFileTime().ToString()));
    }


    //    /// <summary>
    //    /// 截图后先检测图片是否保存成功然后调用保存到相册
    //    /// </summary>
    //    /// <param name="name"></param>
    //    public void SavePng(string name)
    //    {
    //#if UNITY_ANDROID
    //        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    //        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
    //        jo.CallStatic("SavePng", name);
    //#elif  UNITY_IPHONE

    //#endif
    //    }

    //    /// <summary>
    //    /// 保存截图到相册
    //    /// </summary>
    //    /// <param name="pngName"></param>
    //    /// <returns></returns>
    //    IEnumerator SavePngToSD(string pngName)
    //    {
    //        yield return new WaitForEndOfFrame();
    //        Application.CaptureScreenshot(pngName + ".png");
    //        while (!IsFileExistByPath(Application.persistentDataPath + "/" + pngName + ".png"))
    //            yield return new WaitForSeconds(0.05f);

    //        SavePng(pngName);
    //        yield return new WaitForSeconds(0.3f);
    //        //测试请求文件
    //        WWW www = new WWW("file:///" + Application.persistentDataPath + "/" + pngName + ".png");
    //        yield return www;
    //    }

    //    /// <summary>
    //    /// 检测文件是否存在
    //    /// </summary>
    //    /// <param name="path"></param>
    //    /// <returns></returns>
    //    public static bool IsFileExistByPath(string path)
    //    {
    //        FileInfo info = new FileInfo(path);

    //        bool b = false;

    //        if (info == null || info.Exists == false)
    //            b = false;
    //        else
    //            b = true;
    //        return b;
    //    }

    //点击事件触发保存操作
    public void OnCilck(RawImage images)
    {
        //StartCoroutine(SaveImages(images.sprite.texture));
        if (images.texture == null)
            return;

        StartCoroutine(SaveImages((Texture2D)images.texture));
    }

    //保存Png图片
    IEnumerator SaveImages(Texture2D texture)
    {
        string path = Application.persistentDataPath;
#if UNITY_ANDROID
        path = "/sdcard/DCIM/SaveImage"; //设置图片保存到设备的目录.
#endif
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string savePath = path + "/" + texture.name + ".png";
        File.WriteAllBytes(savePath, texture.EncodeToPNG());
        savePngAndUpdate(savePath);
        yield return new WaitForEndOfFrame();
    }

    //调用iOS或Android原生方法保存图片后更新相册.
    private void savePngAndUpdate(string fileName)
    {
#if UNITY_ANDROID
        using (AndroidJavaClass playerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject jo = playerActivity.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                jo.Call("scanFile", fileName, "保存成功辣٩(๑>◡<๑)۶ "); //这里我们可以设置保存成功弹窗内容
            }
        }
#endif
    }

    //用于获取Android原生方法类对象
    private AndroidJavaObject GetAndroidJavaObject()
    {
        return new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"); //设置成我们aar库中的签名+类名
    }
}
