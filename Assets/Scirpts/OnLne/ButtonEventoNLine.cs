using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonEventoNLine : MonoBehaviour {

	public Text ID;
	private string SaveID;
	public void EventSend(string GetObject)
	{
		SaveID = GetObject;
	}

	[SerializeField]
	private Image ICON; 
	[SerializeField]
	private Image ShowIcon;
	[SerializeField]
	private InputField aDDRESS;
	[SerializeField]
	private HttpModel HTTP;
	public void SetID()
	{
		ShowIcon.sprite = ICON.sprite;
		ID.text = SaveID;
		if (aDDRESS.text == string.Empty)
			HTTP.Get ();
	}

	public void SaveTypeMessage(string GetObject)
	{
		this.gameObject.name = GetObject;
	}
}
