using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoopHttp : MonoBehaviour {

	public UpdateDele EventUpdate;
	public string[] HttpModel;
	public GameObject ShowError;
	public GameObject ShowReStart;
	public HttpModel CheckURL;
	int nub = 0;
	public GameObject ReStartButton;
	public Transform ShowUIlOAD;
	void Start()
	{
		StartCheck ();
	}

    public SaveZH Getzh;
	public void StartCheck()
	{
  //      Debug.Log(Getzh.LoadURL());
  //      if(Getzh.LoadURL()!=string.Empty)
		//HttpModel [0] = Getzh.LoadURL();
  //      //
  //      HttpModel[0] = "http://test.mmykw.cn";
  //      //
        nub = 0;
		UpdateNextURL ();
		ReStartButton.SetActive (false);
	}



	public void UpdateNextURL()
	{
		if (IsGone) 
		{
			return;
		}
		if (nub == HttpModel.Length) 
		{
			ShowUIlOAD.localScale = new Vector3 (0,0,0);
			StopAllCoroutines ();
			ReStartButton.SetActive (true);
			return;
		}

//		if (nub > 0)
//			Static.Instance.URLold = HttpModel [nub - 1];

		Static.Instance.URL = HttpModel [nub];
		Debug.Log (Static.Instance.URL);
		//Debug.Log (Static.Instance.URLold);
		CheckURL.Get ();
		nub++;
		Invoke ("UpdateNextURL",2.0f);
	}

	public bool IsGone=false;

	public void SetTrue()
	{
		IsGone=true;
		ShowUIlOAD.localScale = new Vector3 (0,0,0);
	}

//	IEnumerator TimeBegin()
//	{
//		float a = Time.time;
//		while (Time.time - a < 15) 
//		{
//			yield return 5;
//		}
//		StopAllCoroutines ();
//		nub = 0;
//		ReStartButton.SetActive (true);
//		LoadingUI.SetActive(false);
//	}

//	public void UpdateDate()
//	{
//		StartCoroutine ("threadStart");
//	}
//
//	public bool isDone = true;
//	IEnumerator threadStart()
//	{
//		ShowError.SetActive (true);
//		ShowReStart.SetActive (false);
//		LoadingUI.SetActive (true);
//
//		float a = Time.time;
//		while (nub<HttpModel.Length)
//		{
//			if (isDone)
//			{
//				isDone = false;
//				if (HttpModel [nub] != null) 
//				{
//			
//				}
//				else
//					isDone = true;
//				nub++;
//
//			}
//			yield return 5;
////			if (Time.time - a > 5.0f) 
////			{
////				ShowError.SetActive (false);
////				ShowReStart.SetActive (true);
////				StopCoroutine ("threadStart");
////			}
//		}
//		LoadingUI.SetActive (false);
//		if(EventUpdate!=null)
//			EventUpdate.Invoke ();
//	}
//
//
//	public void UpdateNextURL()
//	{
//		isDone
//	}

}
