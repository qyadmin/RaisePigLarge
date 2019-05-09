using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageGet : MonoBehaviour {

	public Image tEX01;
	public Image tEX02;
	public Transform IamgeObj;
	public void Get()
	{
		int Nubget = 0;
		if(Static.Instance.GetValue ("img")!=string.Empty)
			Nubget= int.Parse (Static.Instance.GetValue ("img"));
		Debug.Log (Nubget);
		if (Nubget != 0) 
		{
			if (IamgeObj.GetChild (Nubget - 1) != null) {
				tEX01.sprite = IamgeObj.GetChild (Nubget - 1).GetComponent<Image> ().sprite;
				tEX02.sprite = tEX01.sprite;
			} else
				Debug.LogError ("没有找到头像");
		}
		if (BusinessInfoHelper.Instance !=  null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}
	}
}
