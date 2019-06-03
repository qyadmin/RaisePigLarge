using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePasswordInfo : MonoBehaviour {

	[SerializeField]
	HttpMessageModel htp;

	[SerializeField]
	InputField newpassword_,newpassword,password;

	[SerializeField]
	Text eorro;

	void OnEnable()
	{
		newpassword.text = null;
		newpassword_.text = null;
		password.text = null;
		eorro.text = null;
	}

	public void ButtonClick()
	{
		if (newpassword.text != newpassword_.text) 
		{
			eorro.text = "输入的两次新密码不一致";
		}
		else
			htp.Get();
	}
	public void Succece()
	{
		eorro.text = htp.Data.GetBase.msg;
		//Static.Instance.UpdateAllObj ();
	}
	public void Fail()
	{
		eorro.text = htp.Data.GetBase.msg;
	}
}
