using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuInformation : MonoBehaviour {

	[SerializeField]
	Text Shangxian,Jinju;

	void Update()
	{
		if (ModleClick.Instance.Target_ != null && ModleClick.Instance.Target_.KaiKen_.isKaiken) {
			Shangxian.text = ModleClick.Instance.Target_.GetTreeMessage("limit");
			Jinju.text = ModleClick.Instance.Target_.GetTreeMessage ("sl");
		}
	}
}
