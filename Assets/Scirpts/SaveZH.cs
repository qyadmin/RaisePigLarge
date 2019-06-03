using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using System.Linq;
public class SaveZH : MonoBehaviour {

	public InputField Name;
	public InputField Password;

	void Start()
	{
		Name.text = LoadName ();
		Password.text = Loadpassword ();
		//      if(LoadURL()!=string.Empty)
		//Static.Instance.URL = LoadURL ();
	}


	public void SetName(Dropdown URLList)
	{
		string aa=Static.Instance.GetValue ("tel");
		string bb=Static.Instance.GetValue ("password");
		SaveName (aa);
		password (bb);
		SaveURL (URLList);
		SaveNameLsit (Static.Instance.GetNeedNameList(Name.text,Password.text));
	}



	public void SaveNameLsit(string Namelist)
	{
        Static.Instance.DeleteFile(Application.persistentDataPath, "nameList.txt");
        Static.Instance.CreateFile(Application.persistentDataPath, "nameList.txt", Namelist);
	}




	public void SaveName(string Name)
	{
        Static.Instance.DeleteFile(Application.persistentDataPath, "name.txt");
        Static.Instance.CreateFile(Application.persistentDataPath, "name.txt", Name);
	}

	public void password(string Name)
	{
        Static.Instance.DeleteFile(Application.persistentDataPath, "password.txt");
        Static.Instance.CreateFile(Application.persistentDataPath, "password.txt", Name);
	}



	public string  LoadName()
	{
		ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "name.txt");
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

	public string  Loadpassword()
	{
		ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "password.txt");
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


	public string  LoadNameList()
	{
		ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "nameList.txt");
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


	public Transform NameListFather;
	public GameObject baseLsit;
	public void GetNameShow(GameObject ButtonChild)
	{
		if (baseLsit.activeSelf) 
		{
			baseLsit.SetActive (false);
			return;
		}
		else
			baseLsit.SetActive (true);
		foreach (Transform child in NameListFather)
			Destroy (child.gameObject);

		Dictionary<string ,string> NMAELSIT = Static.Instance.SetNameListBack (LoadNameList());

		foreach (string child in NMAELSIT.Keys) 
		{
			GameObject Newname = GameObject.Instantiate (ButtonChild);
			Newname.SetActive (true);
			Newname.GetComponentInChildren<Text> ().text = child;
			Newname.transform.SetParent (NameListFather);
			Newname.transform.localScale = new Vector3 (1,1,1);
		}
	}

	public void SetLogin(Text Nametext)
	{
		Name.text = Nametext.text;
		Password.text = Static.Instance.GetPassWord (Nametext.text);
		baseLsit.SetActive (false);
	}


	public void SaveURL(Dropdown URLList)
	{
        Static.Instance.DeleteFile(Application.persistentDataPath, "URL.txt");
        Static.Instance.CreateFile(Application.persistentDataPath, "URL.txt", URLList.value.ToString());
	}


	public string  LoadURL()
	{
		ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "URL.txt");
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