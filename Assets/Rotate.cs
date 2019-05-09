using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float speed;
	public Transform chenter;
	// Update is called once per frame
	void Update () {
		transform.RotateAround (chenter.position,Vector3.up,Time.deltaTime*speed);
	}
}
