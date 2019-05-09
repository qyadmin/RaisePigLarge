using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaodTiao : MonoBehaviour
{
	private AsyncOperation async;
	public bool IsGetIn=false;
	public void StartLaod ()
	{

		StartCoroutine(LoadScene());
	}


	public void StopLoad()
	{
		StopAllCoroutines();
	}

	IEnumerator LoadScene()
	{
		async = SceneManager.LoadSceneAsync("mainscene");//异步跳转到game场景
		async.allowSceneActivation = false;//当game场景加载到90%时，不让它直接跳转到game场景。
		yield return async;
	}
	// Update is called once per frame
	void Update () {

		if (async == null)
		{
			return;
		}
			
		if (IsGetIn)
		{
			async.allowSceneActivation = true;
		}
	}
}