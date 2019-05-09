using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;
using System;
using System.IO;

public class kETTEST : MonoBehaviour 
{
	public string AAA;
	// Use this for initialization
	void Start () 
	{
		
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
			Debug.Log( UseMd5 ()+"****"+UseMd5 ().Length);
	}

	
	private static string strKey="caoMei987A";
	//MD5加密

	public string UserMd5()
	{
		string time =UnityEngine.Random.Range(0,10000).ToString();
		//string time =AAA;
		string cl = strKey+time;
		string pwd = "";
		MD5 md5 = MD5.Create();//实例化一个md5对像
		// 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
		byte[] s = md5.ComputeHash(Encoding.ASCII.GetBytes(cl));
		// 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
		for (int i = 0; i < s.Length; i++)
		{
			//Debug.Log (i + "---" + s [i].ToString ("X"));
			// 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
			pwd = pwd + s[i].ToString("x");
		}
		string Md5OK = "token" + "=" + pwd + "&" + "time" + "=" + time;
		return Md5OK;
	}

	public string UseMd5()
	{
		string time =UnityEngine.Random.Range(0,10000).ToString();
		//string time =AAA;
		string input = strKey+time;
		System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();  
		byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);  
		byte[] hash = md5.ComputeHash(inputBytes);  
		StringBuilder sb = new StringBuilder();  
		for (int i = 0; i < hash.Length; i++)  
		{  
			sb.Append(hash[i].ToString("X2"));//大  "X2",小"x2"    
		}  
		return sb.ToString();  
	}
}
