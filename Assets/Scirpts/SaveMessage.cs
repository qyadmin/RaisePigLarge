using UnityEngine;
using System.Collections.Generic;
using System;
using LitJson;

//定义登陆信息对象
public class GetMessageInfo
{
	public int code;
	public string result;
	public string msg;
	public Dictionary<string, string> data;

	public string GetDataValue(string Sendkey)
	{
		string GetNowValue = null;
		bool Isget = data.TryGetValue(Sendkey, out GetNowValue);
		if (Isget)
			return GetNowValue;
		else
			return null;
	}
}
	
public class Gg
{
	public string title;
	public string news;
}
	
public class GetMessageDate
{
    public static T GetServerValue<T>(string JsonData)
    {
        T jd = JsonMapper.ToObject<T>(JsonData);
        return jd;
    }

	public static Gg GetObj(string Getjosn,int i)
	{
		JsonData jd = JsonMapper.ToObject (Getjosn);
		JsonData jdItem = jd["data"][i];  
		Gg GetGG = new Gg ();
		GetGG.title = (string)jdItem["title"];  
		GetGG.news = (string)jdItem["nr"];   
		return GetGG;
	}
}
