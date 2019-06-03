using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedInput : MonoBehaviour {

	int Number;
	[SerializeField]
	InputField NumText;

	[SerializeField]
	GameObject BoZhongClickSound,BoZhongSucceful;

    [SerializeField]
    HttpMessageModel BozhongdateMax;
	int Number_
	{
		get
		{ 
			return Number;
		}
		set
		{ 
			Number = value;
			NumText.text = Number.ToString();
			//Static.Instance.AddValue ("sl",Number.ToString());
		}
	}
	void OnEnable()
	{
        Number_ = 0;
        BozhongdateMax.Get();

    }

	public void change()
	{
		Static.Instance.AddValue ("sl",NumText.text);
	}

	public void Reduction()
	{
		Number_ = int.Parse (NumText.text);
		if (Number_ > 0) 
		{
			Number_ -= 1;
			Instantiate (BoZhongClickSound);
		}
		Static.Instance.AddValue ("sl",Number_.ToString());
	}
	public void Add()
	{
		Number_ = int.Parse (NumText.text);
		Number_ += 1;
		Instantiate (BoZhongClickSound);
		Static.Instance.AddValue ("sl",Number_.ToString());
	}

	public void Confirm()
	{
		Debug.Log ("播种成功");
		Instantiate (BoZhongSucceful);
		Static.Instance.UpdateAllObj ();
	}

}
