using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BusinessInfoHelper:MonoBehaviour
{
	public static BusinessInfoHelper Instance;
	public UpdateDele EventUpdate;

	public GameObject[] HttpModel;

	public GameObject LoadingUI;

	public GameObject ShowError;
	public GameObject ShowReStart;
	void Awake()
	{
		Instance = this;
	}

    public void UpdateDate()
	{
		StartCoroutine ("threadStart");
	}

    public bool isDone = true;
    IEnumerator threadStart()
    {
		ShowError.SetActive (true);
		ShowReStart.SetActive (false);
		LoadingUI.SetActive (true);
        int nub = 0;
		float a = Time.time;
        while (nub<HttpModel.Length)
        {
           if (isDone)
           {
                isDone = false;
				if(HttpModel[nub] != null)
				HttpModel[nub].SendMessage("Get");
				else
					isDone = true;
                nub++;

            }
          yield return 5;
		  if (Time.time - a > 5.0f) 
		  {
			ShowError.SetActive (false);
			ShowReStart.SetActive (true);
			StopCoroutine ("threadStart");
		  }
        }
		LoadingUI.SetActive (false);
		if(EventUpdate!=null)
		EventUpdate.Invoke ();
    }

	//public FarmerLevelUp MyLevel;

	public void LoadForget()
	{
		SceneManager.LoadScene ("forget");
	}
}




