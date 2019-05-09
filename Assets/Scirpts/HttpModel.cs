using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using UnityEngine.Events;
using System.IO;
using UnityEngine.UI;
public class HttpModel : MonoBehaviour {

	public TypeGo DataType;
	public NewMessageInfo Data;

	public UnityEvent Suc, Fal;

	public bool IsLock=false;
	//public InputField inputField;
	private GameObject ShowLoad;
	private GameObject ShowError;

	public UnityEvent DoAction;
	public bool NoShow=false;
	void Awake()
	{
		ShowLoad = GameObject.Find ("HttpBack");
		ShowError=GameObject.Find ("ShowErrorGo");
		IsLock = Static.Instance.Lock;
	}

	public void Get()
	{
		Data.BackData.Clear ();
		//加密
		//EncryptDecipherTool.GetList(Data.SendData,Islock);
		message=null;
		message += "?"; 
		if(IsLock)
			message +=EncryptDecipherTool.UserMd5 ();
		if(ShowLoad!=null)
		ShowLoad.transform.localScale=new Vector3(1,1,1);
		if(ShowError!=null)
		ShowError.transform.localScale = new Vector3 (0, 0, 0);
		switch(DataType)
		{
		case TypeGo.GetTypeA:
			StopAllCoroutines();
			StartCoroutine ("GetMessageA");
		break;
		case TypeGo.GetTypeB:
			StopAllCoroutines();
			StartCoroutine ("GetMessageB");
		break;
		case TypeGo.GetTypeC:
			StopAllCoroutines();
			StartCoroutine ("GetMessageC");

		break;
            case TypeGo.GetTypeD:
                StopAllCoroutines();
                StartCoroutine("GetMessageD");

                break;
        }
	}
		
	IEnumerator GetMessageA()
	{
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Count > 0) 
		{
			foreach (DataValue child in Data.SendData)
			{
				message += "&" + child.Name + "=" +child.GetString();		        
			}      
		}
		message=EncryptDecipherTool.GetListOld(message,IsLock);
	
		url = url + message;
		Debug.Log (url);
		url = Uri.EscapeUriString(url);
		WWW www = new WWW(url);
		yield return www;

		if (www.error != null)
		{
			Data.ShowMessage="error code = " + www.error;
			if(ShowError!=null&&!NoShow)
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
			DoAction.Invoke ();
		}
		else
		{
			string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
			jsondata = jsondata.Remove(0, Data.CutCount);
			Data.ShowMessage = jsondata;
            //CreateFile(Application.streamingAssetsPath, "json.txt", jsondata);
            Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
            Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
			ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
			String sr = null;
			foreach (string str in infoall)
			{
				sr += str;
			}
			JsonData jd = JsonMapper.ToObject (sr);
			Data.GetBase.code=jd.Keys.Contains("code")?jd["code"].ToString():"";
			Data.GetBase.result=jd.Keys.Contains("result")?jd["result"].ToString():"";
			Data.GetBase.msg=jd.Keys.Contains("msg")?jd["msg"].ToString():"";
			Data.GetBase.url=jd.Keys.Contains("url")?jd["url"].ToString():"";
			if(Data.GetBase.msgInputtext!=null)
				Data.GetBase.msgInputtext.text = System.Math.Floor(float.Parse(Data.GetBase.msg)).ToString();
			if(Data.GetBase.codetext!=null)
			Data.GetBase.codetext.text = Data.GetBase.code;
			if(Data.GetBase.resulttext!=null)
			Data.GetBase.resulttext.text = Data.GetBase.result;
			if(Data.GetBase.msgtext!=null)
			Data.GetBase.msgtext.text = Data.GetBase.msg;
			if(Data.GetBase.urltext!=null)
				Data.GetBase.urltext.text = Data.GetBase.url;
		}

		if (Data.GetBase.code == "2")
			GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
		if (Data.GetBase.code == "1")
			Suc.Invoke ();
		else if (Data.GetBase.code == "0")
			Fal.Invoke ();
		
		if (BusinessInfoHelper.Instance !=  null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}

		ShowLoad.transform.localScale=new Vector3(0,0,0);
	}


	IEnumerator GetMessageB()
	{
		string url=Static.Instance.URL+Data.URL;

		if (Data.SendData.Count > 0)
		{
			foreach (DataValue child in Data.SendData)
			{
				message += "&" + child.Name + "=" +child.GetString();		        
			}        
		}
		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
		url = Uri.EscapeUriString(url);
		Debug.Log (url);
		WWW www = new WWW(url);
		yield return www;

		if (www.error != null)
		{
			Data.ShowMessage = "error code = " + www.error;
			if(ShowError!=null&&!NoShow)
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
		}
		else
		{
			string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
			jsondata = jsondata.Remove(0, Data.CutCount);
			int a = 0;
            //CreateFile(Application.streamingAssetsPath, "json.txt", jsondata);
            Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
            Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
			ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
			String sr = null;
			foreach (string str in infoall)
			{
				sr += str;
			}
			JsonData jd = JsonMapper.ToObject(sr);
			Data.ShowMessage = jsondata;
			Debug.Log(jsondata);
			Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
			Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
			Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";
			if(Data.GetBase.msgInputtext!=null)
				Data.GetBase.msgInputtext.text = System.Math.Floor(float.Parse(Data.GetBase.msg)).ToString();
			if(Data.GetBase.msgtext!=null)
				Data.GetBase.msgtext.text = Data.GetBase.msg;
			if (Data.GetBase.code == "1")
			{
				List<string> Savename = new List<string>();
				Dictionary<string, string> SaveMessage = new Dictionary<string, string>();

                foreach (Transform child in Data.MyListMessage.FatherObj)
                {
                    Destroy(child.gameObject);
                }
                Data.MyListMessage.SetVaule (jd[Data.DataName]);
					
				if (Data.Action)
				{
					Data.GetData (SaveMessage);
				}
			}

			if (Data.GetBase.code == "2")
				GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
			if (Data.GetBase.code == "1")
				Suc.Invoke();
			else
				Fal.Invoke();
			
		}
		if (BusinessInfoHelper.Instance != null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}
		ShowLoad.transform.localScale=new Vector3(0,0,0);
	}

	string message=null;
	IEnumerator GetMessageC()
	{
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Count > 0)
		{
			foreach (DataValue child in Data.SendData)
			{
				message += "&" + child.Name + "=" +child.GetString();		        
			}        
		}
		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
		url = Uri.EscapeUriString(url);
		Debug.Log (url);
		WWW www = new WWW(url);
		yield return www;

		if (www.error != null)
		{
			Data.ShowMessage = "error code = " + www.error;
			if(ShowError!=null&&!NoShow)
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
		}
		else
		{
			string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
			jsondata = jsondata.Remove(0, Data.CutCount);
			int a = 0;
            //CreateFile(Application.streamingAssetsPath, "json.txt", jsondata);
            Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
            Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
			ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
			String sr = null;
			foreach (string str in infoall)
			{
				sr += str;
			}
			JsonData jd = JsonMapper.ToObject(sr);
			Data.ShowMessage = jsondata;
			Debug.Log(jsondata);
			Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
			Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
			Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";

            if (Data.GetBase.msgInputtext != null)
                Data.GetBase.msgInputtext.text = System.Math.Floor(float.Parse(Data.GetBase.msg)).ToString();
            if (Data.GetBase.codetext != null)
                Data.GetBase.codetext.text = Data.GetBase.code;
            if (Data.GetBase.resulttext != null)
                Data.GetBase.resulttext.text = Data.GetBase.result;
            if (Data.GetBase.msgtext != null)
                Data.GetBase.msgtext.text = Data.GetBase.msg;
            if (Data.GetBase.urltext != null)
                Data.GetBase.urltext.text = Data.GetBase.url;


           
			if (Data.GetBase.code == "1")
			{
				List<string> Savename = new List<string>();
				Dictionary<string, string> SaveMessage = new Dictionary<string, string>();

				foreach (GameObject child in Data.MyListMessage.AllObj)
					Destroy (child);
				//Debug.Log (jd[Data.DataName]["name"]);
				Data.MyListMessage.SetValueSingle (jd[Data.DataName]);
				if (Data.Action)
				{
					Data.GetData (SaveMessage);
				}
			}

			if (Data.GetBase.code == "2")
				GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
			if (Data.GetBase.code == "1")
				Suc.Invoke();
			else
				Fal.Invoke();
		}
		if (BusinessInfoHelper.Instance != null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}
		ShowLoad.transform.localScale=new Vector3(0,0,0);
	}
    IEnumerator GetMessageD()
    {
        string url = Static.Instance.URL + Data.URL;
        if (Data.SendData.Count > 0)
        {
            foreach (DataValue child in Data.SendData)
            {
                message += "&" + child.Name + "=" + child.GetString();
            }
        }
        message = EncryptDecipherTool.GetListOld(message, IsLock);
        url = url + message;
        url = Uri.EscapeUriString(url);
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;

        if (www.error != null)
        {
            Data.ShowMessage = "error code = " + www.error;
            if (ShowError != null && !NoShow)
                ShowError.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
            jsondata = jsondata.Remove(0, Data.CutCount);
            int a = 0;
            //CreateFile(Application.streamingAssetsPath, "json.txt", jsondata);
            Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
            Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
            ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
            String sr = null;
            foreach (string str in infoall)
            {
                sr += str;
            }
            JsonData jd = JsonMapper.ToObject(sr);
            Data.ShowMessage = jsondata;
            Debug.Log(jsondata);
            Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
            Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
            Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";
            if (Data.GetBase.msgInputtext != null)
                Data.GetBase.msgInputtext.text = System.Math.Floor(float.Parse(Data.GetBase.msg)).ToString();
            if (Data.GetBase.code == "1")
            {
                List<string> Savename = new List<string>();
                Dictionary<string, string> SaveMessage = new Dictionary<string, string>();

                foreach (GameObject child in Data.MyListMessage.AllObj)
                    Destroy(child);
                //Debug.Log (jd[Data.DataName]["name"]);
                Data.MyListMessage.SetValueList(jd);
                if (Data.Action)
                {
                    Data.GetData(SaveMessage);
                }
            }

            if (Data.GetBase.code == "2")
                GameObject.Find("ErrorRestart").SendMessage("Restart", Data.GetBase.msg);
            if (Data.GetBase.code == "1")
                Suc.Invoke();
            else
                Fal.Invoke();
        }
        if (BusinessInfoHelper.Instance != null)
        {
            BusinessInfoHelper.Instance.isDone = true;
        }
        ShowLoad.transform.localScale = new Vector3(0, 0, 0);
    }
}
