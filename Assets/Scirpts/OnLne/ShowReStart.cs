using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowReStart : MonoBehaviour {

	public Text MessageShow;
	public void Restart(string GetMessage)
	{
		transform.localScale = new Vector3 (1, 1, 1);
		MessageShow.text = GetMessage;
	}

}
