using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Text.RegularExpressions;

public class GetIP : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
			WebClient client = new WebClient();
			client.Encoding = System.Text.Encoding.Default;
			string response = client.UploadString("http://iframe.ip138.com/ipcity.asp", "");
			Match mc = Regex.Match(response, @"location.href=""(.*)""");
			if (mc.Success && mc.Groups.Count > 1)
			{
				response = client.UploadString(mc.Groups[1].Value, "");
				string[] str1 = response.Split('[');
				response = str1[1];
				string[] str = response.Split(']');
				response = str[0];
				Debug.Log(response);
			}
	}

}
