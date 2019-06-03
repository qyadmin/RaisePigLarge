using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ListCreat : ScriptableObject {

	private Dictionary<string,string> SaveData=new Dictionary<string,string>();

	public void AddData(string nub,string data)
	{
		if (SaveData.ContainsKey (nub))
			SaveData.Remove (nub);
		SaveData.Add (nub,data);
	}
		
	public string GetData(string nub)
	{
		string GetValue = null;
		SaveData.TryGetValue (nub,out GetValue);
		return GetValue;
	}

	public void ClearData()
	{
		SaveData.Clear ();
	}

}
