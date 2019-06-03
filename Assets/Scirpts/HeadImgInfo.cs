using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IOSAlbumCamera))]
[RequireComponent(typeof(IOSPhoto))]
public class HeadImgInfo : MonoBehaviour
{
    public static HeadImgInfo Instance;

    IOSPhoto IOSDevice;



    private void Resetsetting()
    {
        IOSDevice = this.GetComponent<IOSPhoto>();
    }



    private void Start()
    {
        Resetsetting();
        Instance = this;
#if UNITY_ANDROID
        //AndroidDevice.Initialization();
#elif UNITY_IPHONE
        IOSDevice.Initialization();
#endif
    }

    void OnDestroy()
    {
#if UNITY_ANDROID

#elif UNITY_IPHONE
        IOSDevice.DestroyFuntion();
#endif
    }

    //开启相机

    public void OpenCamera()
    {
#if UNITY_ANDROID
        //AndroidDevice.OpenCamera();
#elif UNITY_IPHONE
         IOSDevice.OpenCamera();
#endif

    }
    //打开相册
    public void OpenPhoto()
    {
#if UNITY_ANDROID
        //AndroidDevice.OpenPhoto();
#elif UNITY_IPHONE
         IOSDevice.OpenPhoto();
#endif
    }

    public void SaveHeadImg()
    {
#if UNITY_ANDROID
        //AndroidDevice.SavePhotoButton();
#elif UNITY_IPHONE
        //IOSDevice.SavePhotoButton();
#endif
    }

    public void ResetCam()
    {
#if UNITY_ANDROID
        //AndroidDevice.CamReset();
#elif UNITY_IPHONE
         IOSDevice.CamReset();
#endif
    }


    [ContextMenu("Rename")]
    public void Rename()
    {
        this.gameObject.name = "IOSAlbumCamera";
    }
}
