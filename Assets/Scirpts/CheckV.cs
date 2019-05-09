using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CheckV : MonoBehaviour {

	public string MyLevel;
	public Text BanBenNub;
	public GameObject UpdateButton;
	public HttpModel CheckGo;

	[SerializeField]
	private string UpdateURL;
	[SerializeField]
	private Text aaa;
	public bool IsStart;

	[SerializeField]
	UnityEvent AwakeEvent;
	void Start()
	{
		MyLevel = Static.Instance.Level;
		if (IsStart)
		{
			AwakeEvent.Invoke();
			CheckGoa();
		}
	}


	public void CheckGoa()
	{
		BanBenNub.text = MyLevel;
		CheckGo.Get();
	}
	public void Check()
	{
		// Debug.Log(aaa.text);
		UpdateButton.SetActive(true);
		if (aaa.text != string.Empty && aaa.text != null)
			UpdateURL = aaa.text;
		Static.Instance.AddValue ("UpdateURL",UpdateURL);
	}

	public void LevelUp()
	{
		Application.OpenURL(Static.Instance.GetValue ("UpdateURL"));
	}

	[SerializeField]
	string[] URLList;
	public void ChoseURL(Dropdown list)
	{
		switch (list.value)
		{
		case 0:
			Static.Instance.URL = URLList[0];//"http://test.mmykw.cn/ 				....";
				CheckGo.Get();
			break;
		case 1:
			Static.Instance.URL = URLList[1];// "http://test.mmykw.cn/ 			";
			CheckGo.Get();
			break;
		}
	}

	string urlNum;
	public void GetURLNum(SaveZH SaveURL)
	{
		urlNum = SaveURL.LoadURL();
		Debug.Log(urlNum);
	}

	public void LoadURL(Dropdown list)
	{
		if (urlNum == "")
			list.value = 0;
		else
			list.value = int.Parse(urlNum);
	}
		
	public void ChangvALUEbUTTONLeft(Dropdown list)
	{
		list.value = 0;
	}

	public void ChangvALUEbUTTONRight(Dropdown list)
	{
		list.value = 1;
	}
}