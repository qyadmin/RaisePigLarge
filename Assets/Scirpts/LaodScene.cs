using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaodScene : MonoBehaviour {

	public bool IsLoad;
	void Start()
	{
		if (IsLoad)
			Invoke ("loadaa",2.0f);
	}

	public void Laod(string Name)
	{
		SceneManager.LoadScene (Name);
	}
		
	void loadaa()
	{
		SceneManager.LoadScene ("mainmeun");
	}
}
