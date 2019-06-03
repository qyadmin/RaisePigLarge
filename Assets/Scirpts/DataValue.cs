using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TypeClass;
namespace TypeClass
{
	public enum SaveNameType
	{
		None,
		SaveMySelfName,
		SaveOtherName,
		ActionEvent

	}

	public enum GetTypeValue
	{
		GetFromValue,
		GetFormText,
		GetFromInputField,
		GetFromList,
		GetFromListOther
	}

	public enum GetBackTypeValue
	{
		GetValue,
		NoGetValue,
	}


	public enum Valuetype
	{
		GetInt,
		GetString
	}
}
[System.Serializable]
public class DataValue
{
	public bool IsSave;
	public string Name;
	public string OtherName;

	public GetTypeValue MyType;

	public Text SetText;
	public InputField SetInputField;
	public string SetValue;

	//public TagerType MyTager;
	public string MakeValue;
	public string GetString()
	{
		string ValueData = null;
		switch (MyType)
		{
		case GetTypeValue.GetFromValue:
			ValueData = SetValue;
		break;
		case GetTypeValue.GetFormText:
			ValueData = SetText.text;
		break;
		case GetTypeValue.GetFromInputField:
			ValueData = SetInputField.text;
		break;
		case GetTypeValue.GetFromList:
			ValueData = Static.Instance.GetValue(Name);
		break;
		case GetTypeValue.GetFromListOther:
			ValueData = Static.Instance.GetValue(OtherName);
		break;
		}
		if(IsSave)
			Static.Instance.AddValue(Name,ValueData);
		return ValueData;

	}
}

[System.Serializable]
public class BackDataValue
{
	public GetBackTypeValue MyType;
	public bool IsSave;
	public string Name;
	public Text SetText;


	public void SetString(string BackValue)
	{
		switch (MyType)
		{
		case GetBackTypeValue.GetValue:
			SetText.text = BackValue;
		break;
		}
		if(IsSave)
			Static.Instance.AddValue(Name,BackValue);
	}
}

public class EventClass
{
	public UnityEvent Fuc;
	public UnityEvent Fal;
}