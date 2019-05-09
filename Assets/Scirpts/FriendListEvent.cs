using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendListEvent : MonoBehaviour {

    [SerializeField]
    Transform type1, type2;

	// Use this for initialization
	void Start () {
		
	}

    public void ChoseType(string type)
    {
        switch (type)
        {
            case "0":
                type1.gameObject.SetActive(true);
                type2.gameObject.SetActive(false);
                break;
            case "1":
                type2.gameObject.SetActive(true);
                type1.gameObject.SetActive(false);
                break;
        }
    }
}
