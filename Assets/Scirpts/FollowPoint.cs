using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour {

	[SerializeField]
	private Transform Father;
	// Update is called once per frame
	void Update () {
		transform.position = Father.position;
	}
}
