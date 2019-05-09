using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using System;
public class testImg : MonoBehaviour {

	public Texture2D aaa;
	public Image[] image;
	[SerializeField]
	string LoadURL, UpdataURL;

	private string TexPath;

	public string SavePath;

	[SerializeField]
	ImageSend[] sendmessage;

	private void Awake()
	{
		Static.Instance.ClearData += Get;
	}




	IEnumerator LoadImage()
	{
		string url= LoadURL + TexPath;
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null) 
		{
			Texture2D texture = www.texture;
			Sprite sprites = Sprite.Create(texture,new Rect(0,0,texture.width,texture.height),new Vector2(0.5f,0.5f));
			image[0].sprite = sprites;
		}
		else
			Debug.Log ("Fail"+www.error);
	}


	IEnumerator UploadTexture()
	{

		byte[] GetTex = aaa.EncodeToPNG ();
		string url= UpdataURL;
		WWWForm form = new WWWForm();

		form.AddBinaryData ("post", GetTex);

		for(int i = 0;i<sendmessage.Length;i++)
		{
			if (sendmessage[i].Name.Length != 0)
			{
				form.AddField(sendmessage[i].Name,(sendmessage[i].Value.Length != 0 ? sendmessage[i].Value : Static.Instance.GetValue(sendmessage[i].Name)));
			}
		}
		//form.AddField("img","tex");  
		//form.AddField("huiyuan_id", "1");
		WWW www = new WWW(url, form);
		yield return www;
		if (www.error != null)
			print(www.error);
		else
		{
			Debug.Log (www.text);
			string jsondata=www.text;
			int a=0;
            Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
            Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
			ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
			//String sr = null;
			//foreach (string str in infoall)
			//{
			//	sr += str;
			//}
			//JsonData jd = JsonMapper.ToObject(sr);
			//Debug.Log (www.text);
			//TexPath = jd ["data"].ToString ();
			//LoadIamge ();

		}

		//Static.Instance.UpdateAllObj ();
	}

	public void SendIamge()
	{
		StartCoroutine (UploadTexture());
	}

	public void LoadIamge()
	{
		StartCoroutine (LoadImage());
	}

	public void Get()
	{
		StopAllCoroutines();
		StartCoroutine(Check());

	}

	IEnumerator ImageGet(string path)
	{
		if (path != SavePath) 
		{
			Debug.Log ("头像");
			SavePath = path;
			string url = LoadURL + path;
			WWW www = new WWW (url);
			yield return www;
			if (www.error == null) {
				Texture2D texture = www.texture;
				Sprite sprites = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.5f, 0.5f));
				image [0].sprite = sprites;
				image [1].sprite = sprites;
			} else
				Debug.Log ("Fail" + www.error);
		}
		if (BusinessInfoHelper.Instance != null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}
	}

	IEnumerator Check()
	{
		while (Static.Instance.GetData("img") == null)
		{
			yield return new WaitForSeconds(0.2f);
		}
		StartCoroutine (ImageGet (Static.Instance.GetData ("img")));

	}

}
