using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IOSPhoto : MonoBehaviour
{
    //public HttpImage GetRaw;
    byte[] SaveHeadImg = null;
    private int typeid; // 0 营业执照  1 物品
    // Use this for initialization
    public AndroidPhoto androidPhoto;
    public void Initialization()
    {
        if (IOSAlbumCamera.Instance)
        {
            IOSAlbumCamera.Instance.CallBack_PickImage_With_Base64 += callback_PickImage_With_Base64;
            IOSAlbumCamera.Instance.CallBack_ImageSavedToAlbum += callback_imageSavedToAlbum;
        }
    }

    public void DestroyFuntion()
    {
        if (IOSAlbumCamera.Instance)
        {
            IOSAlbumCamera.Instance.CallBack_PickImage_With_Base64 -= callback_PickImage_With_Base64;
            IOSAlbumCamera.Instance.CallBack_ImageSavedToAlbum -= callback_imageSavedToAlbum;
        }
    }

    public void OpenPhoto()
    {
        IOSAlbumCamera.iosOpenPhotoLibrary(true);
    }

    void onclick_album()
    {
        IOSAlbumCamera.iosOpenPhotoAlbums(true);
    }

    public void OpenCamera()
    {
        IOSAlbumCamera.iosOpenCamera(true);
    }

    //void onclick_saveToAlbum()
    //{
    //	string path = Application.persistentDataPath + "/lzhscreenshot.png";
    //	Debug.Log (path);

    //	byte[] bytes = (rawImage.texture as Texture2D).EncodeToPNG ();
    //	System.IO.File.WriteAllBytes (path, bytes);

    //	IOSAlbumCamera.iosSaveImageToPhotosAlbum (path);

    //}

    void callback_PickImage_With_Base64(string base64)
    {
        Texture2D tex = IOSAlbumCamera.Base64StringToTexture2D(base64);
        androidPhoto.SendPictureByTypeId(tex);
        // LoadImage.GetLoadIamge.SendImage(tex);
    }

    void callback_imageSavedToAlbum(string msg)
    {
        //txt_saveTip.text = msg;
    }


    public void CamReset()
    {
        StopAllCoroutines();
        SaveHeadImg = null;
    }
}
