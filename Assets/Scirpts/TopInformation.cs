using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TopInformation : MonoBehaviour {
	[SerializeField]
	UnityEvent AwakeEvent;

	void Awake()
	{
		AwakeEvent.Invoke ();
	}

    private void Start()
    {
		Static.Instance.UpdateAllObj();
    }
}
