using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class OnCLickBox : MonoBehaviour {

	[SerializeField]
	public UnityEvent DoAction;
	void OnMouseDown()
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		DoAction.Invoke ();
	}
}
