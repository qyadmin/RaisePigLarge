// ==================================================================
// 作    者：Pablo.风暴洋-宋杨
// 説明する：在这里输入类的功能
// 作成時間：#CreateTime
// 類を作る：SharePicture.cs
// 版    本：v 1.0
// 会    社：大连仟源科技
// QQと微信：731483140
// ==================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharePicture : MonoBehaviour {
    public RawImage pictureRawImg;
    public Button addBtn, submitBtn;
    //public HttpModel http_SharePicture;
    public Text tipTxt;

    private void OnEnable()
    {
        pictureRawImg.texture = null;
    }

    private void Start()
    {
        addBtn.onClick.AddListener(Apply);
        //submitBtn.onClick.AddListener();
    }

    private void Apply()
    {
        //http_SharePicture.Data.AddData()
        if (pictureRawImg.texture == null)
        {
            tipTxt.text = "请先上传营业执照和物品照片";
            return;
        }

        //http_SharePicture.Get()
    }
}
