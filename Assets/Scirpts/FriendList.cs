using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendList : MonoBehaviour {

	[SerializeField]
	Text ID,Name,JingBi;

	public string ID_
	{
		get
		{ 
			return ID.text;
		}
		set
		{ 
			ID.text = value;
		}
	}
	public string Name_
	{
		get
		{ 
			return Name.text;
		}
		set
		{ 
			Name.text = value;
		}
	}
	public string JingBi_
	{
		get
		{ 
			return JingBi.text;
		}
		set
		{ 
			JingBi.text = value;
		}
	}

	
	public void SetValue(string id,string name,string jinbi)
	{
		ID_ = id;
		Name_ = name;
		JingBi_ = jinbi;
	}
}
