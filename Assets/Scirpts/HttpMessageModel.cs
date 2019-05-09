using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.Events;
using System;

public class HttpMessageModel : MonoBehaviour {
    public enum TypeGo
	{
		Send,
		GetTypeA,
		GetTypeB,
		GetTypeC,
        GetTypeD,
		GetTypeE,
        GetGrownInfoTyppe,
        GetTradingInfo,
        SendTexture,
		GetTexture,
        GetTypeShopList,
        GetTypeShopType
    }
    public TypeGo DataType;
    public MessageInfo Data;

    [SerializeField]
    UnityEvent Suc, Fal;

	public bool IsLock=false;
    IEnumerator Send()
	{
		string url=Static.Instance.URL+Data.URL;
		WWWForm sum = new WWWForm();
		foreach (SendMessage child in Data.SendData) 
		{
			sum.AddField(child.Name, child.SendData.text);
		}
		url = url + message;
		Debug.Log (url);
		WWW www = new WWW(url, sum);
		yield return www;

		if (www.error != null)
		{
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
		}
		else
		{
			string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
			jsondata = jsondata.Remove(0, Data.CutCount);
			int a = 0;
            Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
            Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
			ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
			String sr = null;
			foreach (string str in infoall)
			{
				sr += str;
			}
			Debug.Log (sr);
			JsonData jd = JsonMapper.ToObject(sr);
			Data.ShowMessage = jsondata;
			Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
			Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
			Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";
			Data.ShowMessage = jsondata;
			for (int i=0;i<jd.Count;i++) 
			{
				Data.BackData.Add (jd[i].ToString());
			}
		}
			
		if (Data.GetBase.code == "2")
			GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
        if (Data.GetBase.code == "1")
            Suc.Invoke();
        else if (Data.GetBase.code == "0")
            Fal.Invoke();

		ShowLoad.transform.localScale=new Vector3(0,0,0);
		
    }

    //string url = "http://ddhc.mmykw.cn/regapi.php";
    //string url = "http://ddhc.mmykw.cn/qdApi.php";
    //url = "http://ddhc.mmykw.cn/newsApi.php";

	private GameObject ShowLoad;
	private GameObject ShowError;

	void Awake()
	{
		ShowLoad = GameObject.Find ("HttpBack");
		ShowError=GameObject.Find ("ShowErrorGo");
	}

    private void Start()
    {
        Static.Instance.ClearData += Get;
		IsLock = Static.Instance.Lock;
    }

    private void OnDisable()
    {
        Static.Instance.ClearData -= Get;
    }

    public void Get()
	{

//		string A = Static.Instance.URL;
//		string B = Static.Instance.URLold;
//		if (A != null) {
//			A = Data.URL.Replace (B, A);
//			Data.URL = A;
//		}
//		Debug.Log (Data.URL);


		Data.BackData.Clear ();
		//EncryptDecipherTool.GetListOld(Data.SendData,IsLock);

		message = null;
		message += "?"; 
		if(IsLock)
			message +=EncryptDecipherTool.UserMd5 ();
		ShowLoad.transform.localScale=new Vector3(1,1,1);
		if(ShowError!=null)
		ShowError.transform.localScale = new Vector3 (0, 0, 0);
		switch(DataType)
		{
		case TypeGo.GetTypeA:
                StopAllCoroutines();
                StartCoroutine ("GetMessageTYA");
			break;
		case TypeGo.GetTypeB:
                StopAllCoroutines();
                StartCoroutine(GetMessageTYB());
            break;
		case TypeGo.GetTypeC:
                StopAllCoroutines();
                StartCoroutine ("GetMessageTYC");
			break;
        case TypeGo.GetTypeD:
                StopAllCoroutines();
                StartCoroutine(GetMessageTYD());
                break;
		case TypeGo.GetTypeE:
			StopAllCoroutines();
			StartCoroutine(GetMessageTYE());
			break;
        case TypeGo.GetGrownInfoTyppe:
            StopAllCoroutines();
            StartCoroutine(GetMessageGrown());
            break;
        case TypeGo.GetTradingInfo:
            StopAllCoroutines();
            StartCoroutine(TradingMessageInfo());
            break;
        case TypeGo.Send:
            StopAllCoroutines();
            StartCoroutine (Send());
			break;
        case TypeGo.GetTypeShopList:
            StopAllCoroutines();
            StartCoroutine(GetMessageShopList());
            break;
        case TypeGo.GetTypeShopType:
            StopAllCoroutines();
            StartCoroutine(GetMessageShopTypeList());
            break;
        }
	}

	private string message;
	IEnumerator GetMessageTYA()
	{
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0) 
		{
			//message += "?";
			foreach (SendMessage child in Data.SendData)
			{
				message += "&" + child.Name + "=" + child.SetValue();
			}       
		}
			

		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;

		WWW www = new WWW(url);
		yield return www;
		ShowLoad.SetActive (false);
		Data.ShowMessage = www.text;
		if (www.error != null)
		{
			Data.ShowMessage="error code = " + www.error;
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
		}
		else
		{
			string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
			jsondata = jsondata.Remove(0, Data.CutCount);
			int a = 0;
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

			Data.GetBase.code=jd.Keys.Contains("code")?jd["code"].ToString():"";
			Data.GetBase.result=jd.Keys.Contains("result")?jd["result"].ToString():"";
			Data.GetBase.msg=jd.Keys.Contains("msg")?jd["msg"].ToString():"";
			List<string> Savename=new List<string>();
			foreach (string child in jd [Data.DataName][0].Keys) 
			{
				Savename.Add (child);
			}
			for (int i=0;i<jd[Data.DataName][0].Count;i++) 
			{
				Data.BackData.Add (jd[Data.DataName][0][i].ToString());
				if (Data.Action && i < Data.BackDataGet.Length) 
				{
					Data.BackDataGet [i].GetDataObj.text = jd [Data.DataName] [0] [i].ToString ();
					Data.BackDataGet [i].ShowData = Savename[i];
				}
		    }
		}
		if (Data.GetBase.code == "2")
			GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
		if (BusinessInfoHelper.Instance !=  null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}
		ShowLoad.transform.localScale=new Vector3(0,0,0);
	}

    IEnumerator GetMessageTYB()
    {
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0) 
		{
			//message += "?";
			foreach (SendMessage child in Data.SendData)
			{
				message += "&" + child.Name + "=" + child.SetValue();
			}       
		}
		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
		Debug.Log (url);

        WWW www = new WWW(url);
        yield return www;
		Data.ShowMessage = www.text;
        if (www.error != null)
        {
            Data.ShowMessage = "error code = " + www.error;
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
        }
        else
        {
            string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
            jsondata = jsondata.Remove(0, Data.CutCount);
            int a = 0;
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
			if(Data.GetBase.codetext!=null)
				Data.GetBase.codetext.text = Data.GetBase.code;
			if(Data.GetBase.resulttext!=null)
				Data.GetBase.resulttext.text = Data.GetBase.result;
			if(Data.GetBase.msgtext!=null)
				Data.GetBase.msgtext.text = Data.GetBase.msg;
			
            if (Data.GetBase.code == "1")
            {
                List<string> Savename = new List<string>();
                Dictionary<string, string> SaveMessage = new Dictionary<string, string>();

                foreach (string child in jd[Data.DataName].Keys)
                {
                    Savename.Add(child);
                }

                for (int i = 0; i < jd[Data.DataName].Count; i++)
                {
					if (jd [Data.DataName] [i] == null) {
						Data.BackData.Add ("null");
					} else {
						Data.BackData.Add (jd [Data.DataName] [i].ToString ());
					}

                    SaveMessage.Add(Savename[i], Data.BackData[i]);
                    Data.GetData(Savename[i], Data.BackData[i]);

                }
                if (Data.Action)
                {
                    foreach (GetData child in Data.BackDataGet)
                    {
                        string obj = null;
                        SaveMessage.TryGetValue(child.ShowData, out obj);

                        if (child.IsSave)
                            Static.Instance.AddValue(child.ShowData, obj);
                        if (child.GetDataObj != null)
                            child.GetDataObj.text = obj;
                    }
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

    IEnumerator GetMessageTYC()
	{
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0) 
		{
			//message += "?";
			foreach (SendMessage child in Data.SendData)
			{
				message += "&" + child.Name + "=" + child.SetValue();
			}       
		}
		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
        url = Uri.EscapeUriString(url);
		Debug.Log (url);
        WWW www = new WWW(url);
		yield return www;
		Data.ShowMessage = www.text;
		if (www.error != null)
		{
			Data.ShowMessage="error code = " + www.error;
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
		}
		else
		{
			
				string jsondata = System.Text.Encoding.UTF8.GetString (www.bytes, 3, www.bytes.Length - 3);
				jsondata = jsondata.Remove (0, Data.CutCount);
				Data.ShowMessage = jsondata;
				JsonData jd = JsonMapper.ToObject (jsondata);
				Data.GetBase.code = jd.Keys.Contains ("code") ? jd ["code"].ToString () : "";
				Data.GetBase.result = jd.Keys.Contains ("result") ? jd ["result"].ToString () : "";
				Data.GetBase.msg = jd.Keys.Contains ("msg") ? jd ["msg"].ToString () : "";
				if (Data.GetBase.codetext != null)
					Data.GetBase.codetext.text = Data.GetBase.code;
				if (Data.GetBase.resulttext != null)
					Data.GetBase.resulttext.text = Data.GetBase.result;
				if (Data.GetBase.msgtext != null)
					Data.GetBase.msgtext.text = Data.GetBase.msg;
			if (Data.GetBase.msgInputtext != null) 
			{
				float aaa = 0;
				bool HaveInt=float.TryParse (Data.GetBase.msg,out aaa);
				if(HaveInt)
					Data.GetBase.msgInputtext.text = System.Math.Floor (aaa).ToString ();
			}
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

    


    IEnumerator GetMessageTYD()
    {
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0) 
		{
			//message += "?";
			foreach (SendMessage child in Data.SendData)
			{
				message += "&" + child.Name + "=" + child.SetValue();
			}       
		}

		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
        WWW www = new WWW(url);
        yield return www;
		Data.ShowMessage = www.text;
        if (www.error != null)
        {
            Data.ShowMessage = "error code = " + www.error;
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
        }
        else
        {
            string jsondata = www.text;
            jsondata = jsondata.Remove(0, Data.CutCount);
            int a = 0;
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

			if (Data.GetBase.code == "1") 
			{
				List<string> NameGround = new List<string> ();

				if (jd [Data.DataName] != null)
					for (int i = 0; i < jd [Data.DataName].Count; i++) {
						foreach (string name in jd[Data.DataName][i].Keys) {
							NameGround.Add (name);
						}
						Dic GroundData = new Dic ();
						for (int j = 0; j < jd [Data.DataName] [i].Count; j++) {
							if (jd [Data.DataName] [i] [j] != null)
								GroundData.DataDic.Add (NameGround [j], jd [Data.DataName] [i] [j].ToString ());
						}
						string aa = jd [Data.DataName] [i] ["d_id"].ToString ();

						Static.Instance.AddTuDi (aa, GroundData);
						NameGround.Clear ();
					}
			}


			if (Data.GetBase.code == "2")
				GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
			if (Data.GetBase.code == "1")
				Suc.Invoke ();
			else if (Data.GetBase.code == "0")
				Fal.Invoke ();
        }
		if (BusinessInfoHelper.Instance != null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}
		ShowLoad.transform.localScale=new Vector3(0,0,0);
    }


	IEnumerator GetMessageTYE()
	{
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0) 
		{
			//message += "?";
			foreach (SendMessage child in Data.SendData)
			{
				message += "&" + child.Name + "=" + child.SetValue();
			}       
		}

		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
		Debug.Log (url);
		WWW www = new WWW(url);
		yield return www;
		Data.ShowMessage = www.text;
		if (www.error != null)
		{
			Data.ShowMessage = "error code = " + www.error;
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
		}
		else
		{
			string jsondata = www.text;
			jsondata = jsondata.Remove(0, Data.CutCount);
			Data.ShowMessage = jsondata;
			int a = 0;
            Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
            Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
			ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
			String sr = null;
			foreach (string str in infoall)
			{
				sr += str;
			}
			JsonData jd = JsonMapper.ToObject(sr);
			Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
			Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
			Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";
			string td_num = jd.Keys.Contains("td_num") ? jd["td_num"].ToString() : "";
			string total_sl = jd.Keys.Contains("tj_num") ? jd["tj_num"].ToString() : "";
			Static.Instance.AddValue("td_num", td_num);
			Static.Instance.AddValue("tj_num", total_sl);

			if (Data.GetBase.code == "1") {
				List<string> NameGround = new List<string> ();

				if (jd [Data.DataName] != null)
					for (int i = 0; i < jd [Data.DataName].Count; i++) {
						foreach (string name in jd[Data.DataName][i].Keys) {
							NameGround.Add (name);
						}
						Dic GroundData = new Dic ();
						for (int j = 0; j < jd [Data.DataName] [i].Count; j++) {
							GroundData.DataDic.Add (NameGround [j], jd [Data.DataName] [i] [j].ToString ());
						}
						Static.Instance.AddFriend (jd [Data.DataName] [i] ["bianhao"].ToString (), GroundData);
						NameGround.Clear ();
					}
			}

			if (Data.GetBase.code == "2")
				GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
			if (Data.GetBase.code == "1")
				Suc.Invoke ();
			else if (Data.GetBase.code == "0")
				Fal.Invoke ();
		}
		if (BusinessInfoHelper.Instance != null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}
		ShowLoad.transform.localScale=new Vector3(0,0,0);
	}


    IEnumerator GetMessageGrown()
    {
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0) 
		{
			//message += "?";
			foreach (SendMessage child in Data.SendData)
			{
				message += "&" + child.Name + "=" + child.SetValue();
			}       
		}

		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
        WWW www = new WWW(url);
        yield return www;
		Data.ShowMessage = www.text;
        if (www.error != null)
        {
            Data.ShowMessage = "error code = " + www.error;
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
        }
        else
        {
            string jsondata = www.text;
            jsondata = jsondata.Remove(0, Data.CutCount);
            int a = 0;
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
            string total_sl = jd.Keys.Contains("total_sl") ? jd["total_sl"].ToString() : "";
			//添加翻页
			//Static.Instance.AddValue("last", jd["last"].ToString());
			//Static.Instance.AddValue("next", jd["next"].ToString());
			//添加翻页
            Static.Instance.AddValue("total_sl", total_sl);
			if (Data.GetBase.code == "1") {
				List<string> NameGround = new List<string> ();

				if (jd [Data.DataName] != null)
					for (int i = 0; i < jd [Data.DataName].Count; i++) {
						foreach (string name in jd[Data.DataName][i].Keys) {
							NameGround.Add (name);
						}
						Dic GroundData = new Dic ();

						for (int j = 0; j < jd [Data.DataName] [i].Count; j++) {
							if (jd [Data.DataName] [i] [j] != null)
								GroundData.DataDic.Add (NameGround [j], jd [Data.DataName] [i] [j].ToString ());
							else
								GroundData.DataDic.Add (NameGround [j], string.Empty);
						}
						Static.Instance.SaveGrown (jd [Data.DataName] [i] ["id"].ToString (), GroundData);
						NameGround.Clear ();
					}
			}

			if (Data.GetBase.code == "2")
				GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
            if (Data.GetBase.code == "1")
                Suc.Invoke();
            else if (Data.GetBase.code == "0")
                Fal.Invoke();
        }
        if (BusinessInfoHelper.Instance != null)
        {
            BusinessInfoHelper.Instance.isDone = true;
        }
		ShowLoad.transform.localScale=new Vector3(0,0,0);
    }

    IEnumerator GetMessageShopList()
    {
        string url = Static.Instance.URL + Data.URL;
        if (Data.SendData.Length > 0)
        {
            //message += "?";
            foreach (SendMessage child in Data.SendData)
            {
                message += "&" + child.Name + "=" + child.SetValue();
            }
        }

        message = EncryptDecipherTool.GetListOld(message, IsLock);
        url = url + message;
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;

        if (www.error != null)
        {
            Data.ShowMessage = "error code = " + www.error;
            ShowError.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            string jsondata = www.text;
            jsondata = jsondata.Remove(0, Data.CutCount);
            int a = 0;
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

            List<string> NameGround = new List<string>();
            Static.Instance.SaveShopList.Clear();
            try
            {
                if (jd[Data.DataName] != null)
                    for (int i = 0; i < jd[Data.DataName].Count; i++)
                    {
                        foreach (string name in jd[Data.DataName][i].Keys)
                        {
                            NameGround.Add(name);
                        }
                        Dic GroundData = new Dic();
                        for (int j = 0; j < jd[Data.DataName][i].Count; j++)
                        {
                            if (jd[Data.DataName][i][j] != null)
                                GroundData.DataDic.Add(NameGround[j], jd[Data.DataName][i][j].ToString());
                        }
                        string aa = jd[Data.DataName][i]["id"].ToString();
                        Static.Instance.AddShopList(aa, GroundData);

                        NameGround.Clear();
                    }
            }
            catch
            {
                Debug.LogError("无Data");
            }


            if (Data.GetBase.code == "1")
                Suc.Invoke();
            else if (Data.GetBase.code == "0")
                Fal.Invoke();
        }
        if (BusinessInfoHelper.Instance != null)
        {
            BusinessInfoHelper.Instance.isDone = true;
        }
        ShowLoad.transform.localScale = new Vector3(0, 0, 0);
    }

    IEnumerator GetMessageShopTypeList()
    {

        string url = Static.Instance.URL + Data.URL;
        if (Data.SendData.Length > 0)
        {
            //message += "?";
            foreach (SendMessage child in Data.SendData)
            {
                message += "&" + child.Name + "=" + child.SetValue();
            }
        }

        message = EncryptDecipherTool.GetListOld(message, IsLock);
        url = url + message;
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;

        if (www.error != null)
        {
            Data.ShowMessage = "error code = " + www.error;
            ShowError.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            string jsondata = www.text;
            jsondata = jsondata.Remove(0, Data.CutCount);
            int a = 0;
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

            List<string> NameGround = new List<string>();
            Static.Instance.SaveShopType.Clear();
            if (jd[Data.DataName] != null)
                for (int i = 0; i < jd[Data.DataName].Count; i++)
                {
                    foreach (string name in jd[Data.DataName][i].Keys)
                    {
                        NameGround.Add(name);
                    }
                    Dic GroundData = new Dic();
                    for (int j = 0; j < jd[Data.DataName][i].Count; j++)
                    {
                        if (jd[Data.DataName][i][j] != null)
                            GroundData.DataDic.Add(NameGround[j], jd[Data.DataName][i][j].ToString());
                    }
                    string aa = jd[Data.DataName][i]["id"].ToString();
                    Static.Instance.AddShopType(aa, GroundData);

                    NameGround.Clear();
                }

            if (Data.GetBase.code == "1")
                Suc.Invoke();
            else if (Data.GetBase.code == "0")
                Fal.Invoke();
        }
        if (BusinessInfoHelper.Instance != null)
        {
            BusinessInfoHelper.Instance.isDone = true;
        }
        ShowLoad.transform.localScale = new Vector3(0, 0, 0);
    }


    IEnumerator TradingMessageInfo()
    {
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0) 
		{
			//message += "?";
			foreach (SendMessage child in Data.SendData)
			{
				message += "&" + child.Name + "=" + child.SetValue();
			}       
		}

		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;
		Data.ShowMessage = www.text;
        if (www.error != null)
        {
            Data.ShowMessage = "error code = " + www.error;
			ShowError.transform.localScale = new Vector3 (1, 1, 1);
        }
        else
        {
            string jsondata = www.text;
            jsondata = jsondata.Remove(0, Data.CutCount);
            int a = 0;
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

			if (Data.GetBase.code == "1") {
				List<string> NameGround = new List<string> ();

				if (jd [Data.DataName] != null)
					for (int i = 0; i < jd [Data.DataName].Count; i++) {
						foreach (string name in jd[Data.DataName][i].Keys) {
							NameGround.Add (name);
						}
						Dic GroundData = new Dic ();
						for (int j = 0; j < jd [Data.DataName] [i].Count; j++) {
							GroundData.DataDic.Add (NameGround [j], jd [Data.DataName] [i] [j].ToString ());
						}
						Static.Instance.SaveTradingInfo.Add (jd [Data.DataName] [i] ["id"].ToString (), GroundData);
						NameGround.Clear ();
					}
			}

			if (Data.GetBase.code == "2")
				GameObject.Find ("ErrorRestart").SendMessage("Restart",Data.GetBase.msg);
            if (Data.GetBase.code == "1")
                Suc.Invoke();
            else if (Data.GetBase.code == "0")
                Fal.Invoke();
        }
        if (BusinessInfoHelper.Instance != null)
        {
            BusinessInfoHelper.Instance.isDone = true;
        }
		ShowLoad.transform.localScale=new Vector3(0,0,0);
    }

    public void OpenURL()
    {
        Application.OpenURL("http://sdj.mmykw.cn/shangcheng/dzp_search.php");
    }
}
