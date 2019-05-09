using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PassWordChangeFinish : MonoBehaviour {
	[SerializeField]
	Text time;
	[SerializeField]
	UnityEvent quite;

	void OnEnable()
	{
		StartCoroutine (Times());
	}

	IEnumerator Times()
	{
		float i = 3;
		while (i > 0) 
		{
			time.text = Mathf.Floor(i).ToString();
			i -= Time.deltaTime;
			yield return null;
		}
		quite.Invoke ();
	}
}
