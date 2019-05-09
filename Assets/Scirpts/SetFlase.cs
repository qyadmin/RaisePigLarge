using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetFlase : MonoBehaviour {


	// Use this for initialization
	void OnDisable () 
	{
		Invoke ("fl",3.0f);
	}

	void fl()
	{
		gameObject.SetActive (false);
	}
}
