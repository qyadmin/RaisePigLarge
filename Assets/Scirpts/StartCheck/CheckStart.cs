using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using LitJson;
using System.IO;
using System;
public class CheckStart : MonoBehaviour {

	public UnityEvent MyEvent;
	private string LocalID;
	void Start()
	{
		LocalID = LoadGG ();
		string ServerID=Static.Instance.GetValue("gg_id");
		Debug.Log (ServerID + "*************" + LocalID);
		if (ServerID != LocalID) 
		{
			MyEvent.Invoke ();
			SaveGG (ServerID);
		}
	}
		
	public void SaveGG(string nub)
	{
        Static.Instance.DeleteFile(Application.persistentDataPath, "GG.txt");
        Static.Instance.CreateFile(Application.persistentDataPath, "GG.txt", nub);
	}


	public string  LoadGG()
	{
		ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "GG.txt");
		String sr = null;
		if (infoall == null)
			return string.Empty;
		foreach (string str in infoall)
		{
			sr += str;
		}
		Debug.Log (sr);
		return sr;
	}
}
