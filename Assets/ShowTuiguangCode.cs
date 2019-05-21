using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShowTuiguangCode : MonoBehaviour
{
    public RawImage qrCodeImg;

    public void ShowQrCode(object obj)
    {
        LoadImage.GetLoadIamge.Load(obj.ToString(), new RawImage[] { qrCodeImg });
    }
}