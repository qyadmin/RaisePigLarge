using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using System;
using TypeClass;
public delegate void UpdateDele();
public class Registrationinfo
{
    public string Name;
    public string PhoneNum;
    public string LoginPassWord;
    public string TransactPassWord;
    public string ReferrerPhoneNum;
}
public class Logininfo
{
    public string ID;
    public string PassWord;
    public string VerCode;
}
public class Topinfo
{
    public Image HeadImg;
    public string NameID;
    public string BoZhong;
    public string JinJu;
    public string Active;
}
public class Messageinfo
{
    public Image HeadImg;
    public string Name;
    public string NameID;
    public string PhoneID;
    public string PassWord;
}
[System.Serializable]
public class ImageSend
{
    public string Name;
    public string Value;
}

public class Dic
{
	public Dictionary<string, string> DataDic = new Dictionary<string, string>();
	public string GetVaule(string name)
	{
		string a = null;
		DataDic.TryGetValue (name,out a);
		return a;
	}

    public string GetKeys(string value)
    {
        string keys = null;
        foreach (var key in DataDic)
        {
            //Debug.Log(key.Value);
            if (key.Value == value)
            {
                keys = key.Key;
            }
        }
        return keys;
    }
    public Dic()
    {
        Static.Instance.ClearData += Clear;
    }
    public void Clear()
    {
        DataDic.Clear();
    }
}

public enum GetBackType
{
	Text,
	InputText,
    Event
}


[System.Serializable]
public class BaseData
{
    public string code;
	public Text codetext;
    public string result;
	public Text resulttext;
    public string msg;
	public Text msgtext;
    public InputField msgInputtext;
    public string url;
	public Text urltext;
}
[System.Serializable]
public class SendMessage
{
    public string Name;
    public InputField SendData;
	public bool IsGetOther;
	public string OtherName;
	public bool IsNub;
	public int Nub;
    public bool IsSave = false;
	public string MakeValue;

	public string SetValue()
	{
		string GetValue=null;
		if (IsNub) 
		{
			GetValue= Nub.ToString();
			return GetValue;
		}
		if (IsGetOther) 
		{
			GetValue=Static.Instance.GetValue(OtherName).ToString();
			return GetValue;

		}
		if (SendData != null)
		{
			GetValue=SendData.text;
			if (IsSave)
			{
				Static.Instance.AddValue(Name, SendData.text);
			}
		}
		else
		{
			GetValue=Static.Instance.GetValue(Name);
		}             

		return GetValue;
	}
}
[System.Serializable]
public class GetData
{
    public string ShowData;
    public Text GetDataObj;
    public bool IsSave=false;
}
[System.Serializable]
public class MessageInfo
{
    public int CutCount;
    public string DataName;
    public string URL;
    public BaseData GetBase;
    public SendMessage[] SendData;
    public bool Action = false;
    public GetData[] BackDataGet;
    public List<string> BackData = new List<string>();
    [TextArea(2, 5)]
    public string ShowMessage;
    public string[] GetDataList;
    public void GetData(string name,string value)
    {
        foreach (string child in GetDataList)
        {
            if (name == child)
            {
                Static.Instance.AddData(name, value);
                break;
            }
        }
    }
    public void Clear()
    {
        BackData.Clear();
    }
}

[System.Serializable]
public class NewMessageInfo
{
	public int CutCount;
	public string DataName;
	public string URL;
	public BaseData GetBase;
	[Tooltip("添加需要发送的参数")]
    public List<DataValue> SendData = new List<DataValue>();
    public bool Action = false;
	[Tooltip("获取数据列表")]
	public BackDataValue[] BackDataGet;
	[Tooltip("显示返回数据列表")]
	public List<string> BackData = new List<string>();
	[TextArea(2, 5)]
	public string ShowMessage;
	[Tooltip("保存列表中返回的数据")]
	public string[] GetDataList;

	public ListMessage MyListMessage;

    public void RemoveData(string Name)
    {
        foreach (DataValue child in SendData)
        {
            if (child.Name == Name)
            {
                SendData.Remove(child);
                break;
            }
        }
    }

    public void AddData(string key, string Value)
    {
        RemoveData(key);
        DataValue data = new DataValue();
        data.MyType = GetTypeValue.GetFromValue;
        data.Name = key;
        data.SetValue = Value;
        SendData.Add(data);
    }


    public void GetData(Dictionary<string,string> AllMessage)
	{
		foreach (BackDataValue child in BackDataGet)
		{
			string obj = null;
			AllMessage.TryGetValue(child.Name, out obj);
			child.SetString (obj);
		}
	}

	public void Clear()
	{
		BackData.Clear();
	}
}

public enum TypeGo
{
	GetTypeA,
	GetTypeB,
	GetTypeC,
    GetTypeD
}

[System.Serializable]
public class ListGetValue
{
	public GetBackType MyType;
	public bool IsInt;
	public string Name;
	public Text Showtext;
	public InputField ShowInputtext;
    public GameObject SendData;
    public string EventName;
}


public enum SetListType
{
	Text,
	Object
}

public enum ObjType
{
	Text,
	Image,
	GameObject
}

[System.Serializable]
public class ListBB
{
	public string Name;
	public ObjType MyObjeType;
	public SaveNameType MySaveType;
	public string OtherName;
	public string EventName;
}
//列表对象
[System.Serializable]
public class ListMessage
{
	public GameObject EventObj;
	public Transform FatherObj;
	public GameObject InsObj;
	public SetListType MyListType;
	public string ObjTag;
	public List<ListBB> NameList=new List<ListBB>();
	public List<ListGetValue> NameSingleList=new List<ListGetValue>();
	public Text[] GetTextList(GameObject GetObj)
	{
		return GetObj.GetComponentsInChildren<Text> ();
	}
	public List<GameObject> AllObj = new List<GameObject> ();

    public ListGetValue GetVauleNoAction;

    public void SetValueList(JsonData Getjson)
    {
         GetVauleNoAction.SendData.SendMessage(GetVauleNoAction.EventName, Getjson[GetVauleNoAction.Name]);
    }






    public void SetValueSingle(JsonData Getjson)
	{
		foreach (ListGetValue child in NameSingleList) 
		{
			if (Getjson [child.Name] == null)
				continue;
			else 
			{
				switch (child.MyType) 
				{
				case GetBackType.Text:
					child.Showtext.text = Getjson [child.Name].ToString ();
				break;
				case GetBackType.InputText:
					child.ShowInputtext.text = Getjson [child.Name].ToString ();
					if(child.IsInt)
						child.ShowInputtext.text = System.Math.Floor(float.Parse(child.ShowInputtext.text)).ToString();
				break;
                case GetBackType.Event:

                        child.SendData.SendMessage(child.EventName, Getjson[child.Name]);
                break;
                }
		
			}
		}
	}


	public List<JsonData> SetVauleBack(JsonData Getjson)
	{ 
		List<JsonData> NewData = new List<JsonData> ();

		for (int i=Getjson.Count-1;i>=0;i--)
			NewData.Add (Getjson[i]);
		return NewData;
	}


	public void SetVaule(JsonData Getjson)
	{ 
		
		List<JsonData> NewData = new List<JsonData> ();

		if (Getjson == null)
			return;
		for (int i=Getjson.Count-1;i>=0;i--)
			NewData.Add (Getjson[i]);
		int AddNub = 0;
 

		switch (MyListType) 
		{
		case SetListType.Text:
			foreach (JsonData child in NewData) 
			{
				GameObject NewList = GameObject.Instantiate (InsObj);
				NewList.transform.SetParent (FatherObj);
				NewList.transform.localScale = new Vector3(1, 1, 1);
				NewList.SetActive (true);
				//AllObj.Add (NewList);
				Text[] Alltext = GetTextList (NewList);
				for (int i = 0; i < NameList.Count; i++) 
				{
					NameList [i].MyObjeType = ObjType.Text;
					if(child[NameList [i].Name]!=null)
						Alltext [i].text = child[NameList [i].Name].ToString ();
					if (NameList [i].MySaveType==SaveNameType.SaveMySelfName) 
					{
						Static.Instance.AddValue (NameList [i].Name, child [NameList [i].Name].ToString ());
					}
					if (NameList [i].MySaveType==SaveNameType.SaveOtherName) 
					{
						Static.Instance.AddValue (NameList [i].OtherName, child [NameList [i].Name].ToString ());
					}
					if (NameList [i].MySaveType==SaveNameType.ActionEvent) 
					{
						Alltext [i].gameObject.SendMessage (NameList [i].EventName,child [NameList [i].Name].ToString ());
					}

				}
			}
			break;
		case SetListType.Object:
			foreach (JsonData child in NewData) 
			{
				GameObject NewList = GameObject.Instantiate (InsObj);
				NewList.transform.SetParent (FatherObj);
				NewList.transform.localScale = new Vector3(1, 1, 1);
				NewList.SetActive (true);
				//AllObj.Add (NewList);
				List<GameObject> Objlist=new List<GameObject>();

				foreach (Transform childa in NewList.transform) 
				{
					if (childa.CompareTag (ObjTag))
						Objlist.Add (childa.gameObject);
				}
				for (int i = 0; i < NameList.Count; i++) 
				{
					if (child [NameList [i].Name] != null)
					{
						switch (NameList [i].MyObjeType) 
						{
						case ObjType.Text:
							Objlist [i].GetComponent<Text>().text = child [NameList [i].Name].ToString ();
						break;
						case ObjType.Image:
							
							Texture2D texture = Base64StringToTexture2D(child [NameList [i].Name].ToString ());
							Sprite sprites = Sprite.Create(texture,new Rect(0,0,texture.width,texture.height),new Vector2(0.5f,0.5f));
							Objlist [i].GetComponent<Image>().sprite = sprites;
						break;
						}
					
					}
					if (NameList [i].MySaveType==SaveNameType.SaveMySelfName) 
					{
						Static.Instance.AddValue (NameList [i].Name, child [NameList [i].Name].ToString ());
					}
					if (NameList [i].MySaveType==SaveNameType.SaveOtherName) 
					{
						Static.Instance.AddValue (NameList [i].OtherName, child [NameList [i].Name].ToString ());
					}
					if (NameList [i].MySaveType==SaveNameType.ActionEvent) 
					{
						Objlist [i].gameObject.SendMessage (NameList [i].EventName,child [NameList [i].Name].ToString ());
					}

				}
			}

			break;
		}

	}


	public static  byte[] GetBytes(string str)
	{
		return System.Text.Encoding.ASCII.GetBytes(str);
		//return Encoding.ASCII.GetBytes(str.ToCharArray());
	}

	public static  string GetString(byte[] bytes)
	{
		return System.Text.Encoding.ASCII.GetString(bytes);
		//return Encoding.ASCII.GetString(bytes);
	}

	public byte[] Gettexture(string base64)
	{
		return System.Convert.FromBase64String(base64);
	}

	public  Texture2D Base64StringToTexture2D(string base64)
	{
		Texture2D tex = new Texture2D (4, 4, TextureFormat.ARGB32, false);
		try
		{
			byte[] bytes = System.Convert.FromBase64String(base64);
			tex.LoadImage(bytes);
		}
		catch(System.Exception ex)
		{
			Debug.LogError(ex.Message);
		}
		return tex;
	}    
}
