using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckTanHao : MonoBehaviour {

	public Text myTEXT;
	public GameObject Loga;
	// Use this for initialization
	void Awake()
	{
		myTEXT = GetComponent<Text> ();
		myTEXT.text="0.0";

	}
	void Start () 
	{
	}
	// Update is called once per frame
	void Update () 
	{
		
		if (float.Parse (myTEXT.text)==0.0f)
			Loga.SetActive (false);
		else
			Loga.SetActive (true);
	}
}
