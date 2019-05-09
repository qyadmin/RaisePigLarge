using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnEnableBaoXiang : MonoBehaviour {

	public Text BX;
	void OnEnable()
	{
		BX.text = Static.Instance.GetValue ("");
	}
}
