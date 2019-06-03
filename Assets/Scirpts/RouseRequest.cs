using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouseRequest : MonoBehaviour {
    [SerializeField]
    HttpMessageModel htp;
    [SerializeField]
    InputField Input;
	[SerializeField]
	Text eorro;

	void OnEnable() {
        Input.text = null;
		eorro.text = null;
    }
	

	public void ButtonClick () {
        htp.Get();
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
