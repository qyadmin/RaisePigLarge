using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddNub : MonoBehaviour {

	public InputField mY;
	int aaa;
	public void Add(int aa)
	{
		if (mY.text != string.Empty)
			aaa = int.Parse (mY.text);
		else
			aaa = 0;
		aaa = (aaa + aa);
		aaa = aaa < 0 ? 0 : aaa;
		mY.text =aaa.ToString() ;

	}
}
