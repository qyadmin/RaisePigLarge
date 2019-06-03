using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTime : MonoBehaviour {
	[SerializeField]
	AudioSource sound;

	// Update is called once per frame
	void Update () {
		if (!sound.isPlaying) 
		{
			Destroy (this.gameObject);
		}
	}
}
