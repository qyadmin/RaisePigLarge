using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour 
{
    private void OnEnable()
    {
		Static.Instance.UpdateAllObj();
    }

	public void UpdateAllMesage()
	{
		Static.Instance.UpdateAllObj();
	}

}
