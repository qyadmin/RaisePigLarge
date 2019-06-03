using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SavetextValue : MonoBehaviour {
	
	public void SaveValue(Text GetText)
	{
		Static.Instance.AddValue (GetText.name, GetText.text);
	}
}
