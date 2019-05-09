using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using LitJson;
using UnityEngine.Events;
using UnityEngine.UI;
public class VerCodeEvent : MonoBehaviour {
    [SerializeField]
    Text VerCode;
    [SerializeField]
    string url;

    string VerCode_
    {
        set
        {
            VerCode.text = value;
        }
    }

    private void OnEnable()
    {
      //  SetNewVerCode();
    }

	public bool IsTel=false;
    public void SetNewVerCode()
    {
		if(IsTel)
			StartCoroutine(dlYanZheng());
    }

	public InputField Tel;

    IEnumerator YanZheng()
    {
		if(Static.Instance.Lock)
			url ="ajaxyzm.php"+"?"+EncryptDecipherTool.UserMd5 ();
		string tigUrl =Static.Instance.URL+url;
        WWW www = new WWW(tigUrl);
        yield return www;
        Debug.Log(www.text);
		ShowMessage = www.text;
        if (www.error != null)
        {
            Debug.Log("error code = " + www.error);
        }
        else
        {
//			string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
//			DeleteFile(Application.persistentDataPath, "json.txt");
//			CreateFile(Application.persistentDataPath, "json.txt", jsondata);
//			ArrayList infoall = LoadFile(Application.persistentDataPath, "json.txt");
//			String sr = null;
//			foreach (string str in infoall)
//			{
//				sr += str;
//			}
//            string a = jsondata;
			JsonData jd = JsonMapper.ToObject(www.text);
            VerCode_ = jd.Keys.Contains("data") ? jd["data"].ToString() : "";
			string msgshow=jd.Keys.Contains("msg")?jd["msg"].ToString():"";
			string code=jd.Keys.Contains("code")?jd["code"].ToString():"";
			if(code=="2")
				GameObject.Find ("ErrorRestart").SendMessage("Restart",msgshow);
        }
    }
	[TextArea(2,2)]
	public string ShowMessage;

	public Text Code, result, msg;
	IEnumerator dlYanZheng()
	{
		if(Static.Instance.Lock)
			url ="ajaxdlyzm.php"+"?"+EncryptDecipherTool.UserMd5 ()+"&tel"+"="+Tel.text;
		string tigUrl =Static.Instance.URL+url;
		WWW www = new WWW(tigUrl);
		yield return www;
		Debug.Log(www.text);
		ShowMessage = www.text;

		if (www.error != null)
		{
			Debug.Log("error code = " + www.error);
		}
		else
		{
			string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
			Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
            Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
			ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
			String sr = null;
			foreach (string str in infoall)
			{
				sr += str;
			}
			JsonData jd = JsonMapper.ToObject (sr);
			if(Code!=null)
			Code.text=jd.Keys.Contains("code")?jd["code"].ToString():"";
			if(result!=null)
			result.text=jd.Keys.Contains("result")?jd["result"].ToString():"";
			if(msg!=null)
			msg.text=jd.Keys.Contains("msg")?jd["msg"].ToString():"";
			VerCode_ = jd.Keys.Contains("data") ? jd["data"].ToString() : "";
			string msgshow=jd.Keys.Contains("msg")?jd["msg"].ToString():"";
			string code=jd.Keys.Contains("code")?jd["code"].ToString():"";
			if(code=="2")
				GameObject.Find ("ErrorRestart").SendMessage("Restart",msgshow);
		}
	}

}
