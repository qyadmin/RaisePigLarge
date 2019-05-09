using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using LitJson;
using System.Collections.Generic;


public class HttpMessage : MonoBehaviour
{
    public static HttpMessage GetMessage;

    void Awake()
    {
        GetMessage = this;
    }

    void Start()
    {
		//StartCoroutine("LoginRequest");
		 
    }


   

    public void Gonggao()
    {
        StartCoroutine("GongGao");
    }





    //请求注册
    //public void OnReg()
    //{
    //    string url = "http://ddhc.mmykw.cn/regapi.php";
    //    WWWForm sum = new WWWForm();
    //    sum.AddField("tel", tel.text);
    //    sum.AddField("name", name.text);
    //    sum.AddField("password", password.text);
    //    sum.AddField("jy_password", jy_password.text);
    //    sum.AddField("tj_tel", tj_tel.text);
    //    sum.AddField("code", code.text);
    //    StartCoroutine(OnRegister(url, sum));
    //}

    IEnumerator OnRegister(string url, WWWForm sum)
    {
        WWW GetRegister = new WWW(url, sum);
        yield return GetRegister;
        if (GetRegister.error != null)
        {
            Debug.Log(GetRegister.error);
        }
        else
        {
            Debug.Log(GetRegister.text);
        }
    }


    //获取图片
    public void GetTexture()
    {
        string url = "";
        StartCoroutine(GetTEX(url));
    }

    Texture2D GetTexMS;

    IEnumerator GetTEX(String url)
    {
        WWW www = new WWW(url);
        yield return www;
        GetTexMS = www.texture;
    }

    //请求公告信息
    IEnumerator GongGao()
    {
        string url = "http://ddhc.mmykw.cn/newsApi.php";

        string tigUrl = url;
        WWW www = new WWW(tigUrl);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("error code = " + www.error);
        }
        else
        {
            string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
            jsondata = jsondata.Remove(0, 42);
            Debug.Log(jsondata);
            Gg GetNews = GetMessageDate.GetObj(jsondata, 0);

            //Announcement.Instance.Gonggao(GetNews);
            Debug.Log(GetNews.title);
            Debug.Log(GetNews.news);
        }
    }


    int huiyuan_id = 15;
    //请求签到
    IEnumerator QianDao()
    {
        string url = "http://ddhc.mmykw.cn/qdApi.php?" + "&huiyuan_id=" + huiyuan_id.ToString();
        string tigUrl = url;
        WWW www = new WWW(tigUrl);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("error code = " + www.error);
        }
        else
        {
            Debug.Log(www.text);
            string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
            JsonData jd = JsonMapper.ToObject(jsondata);
            Debug.Log(jd["msg"]);
        }
    }














}


