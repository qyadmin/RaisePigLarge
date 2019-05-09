using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Announcement : MonoBehaviour {
    [SerializeField]
    HttpMessageModel htp;

    private void OnEnable()
    {
		Invoke ("SHOW",0.5f);
      
    }

	void SHOW()
	{
		htp.Get();
	}

}
