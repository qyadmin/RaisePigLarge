using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TiggerEvent : MonoBehaviour {

	public GameObject BaoXiang;
	void Start () 
	{
		if (Static.Instance.GetValue ("bxflag") == "1") 
		{
			BaoXiang.SetActive (true);
		}
	}
}
