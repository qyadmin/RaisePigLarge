using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddressInfo : MonoBehaviour {
	[SerializeField]
	HttpMessageModel htp;

	[SerializeField]
	Text eorro;

	[SerializeField]
	InputField newaddress;

	void OnEnable()
	{
		newaddress.text = null;
		eorro.text = null;
	}

	public void ButtonClick()
	{
		htp.Get ();
	}

	public void Succece()
	{
		eorro.text = htp.Data.GetBase.msg;
		Static.Instance.UpdateAllObj ();
	}
	public void Fail()
	{
		eorro.text = htp.Data.GetBase.msg;
	}
}
