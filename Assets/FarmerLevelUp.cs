using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerLevelUp : MonoBehaviour {

	public int ValueUp;
	[System.Serializable]
	public class Level
	{
		
		public int PowerValue;
		public GameObject Farmer;
	}

	public Level[] MyLevelUp;
    [SerializeField]
    GameObject GouMai, ShengJi;
	void Start()
	{
		//NowFarmer = MyLevelUp [4].Farmer;
		//LevelUp ();
		//BusinessInfoHelper.Instance.EventUpdate+=this.LevelUp;
	}
	public void LevelUp()
	{
        Debug.Log(Static.Instance.GetValue("nongfu"));
		int MyPower =int.Parse(Static.Instance.GetValue ("nongfu"));
        if (MyPower != 0)
        {
            GouMai.SetActive(false);
            ShengJi.SetActive(true);
            SetFarmer(MyLevelUp[MyPower - 1].Farmer);
        }
        else
        {
            GouMai.SetActive(true);
            ShengJi.SetActive(false);
            FalseAll();
        }
		
	}

	public GameObject NowFarmer;
	void SetFarmer(GameObject NewFarmer)
	{
		NowFarmer.SetActive (false);
		NewFarmer.transform.position = NowFarmer.transform.position;
		NewFarmer.transform.eulerAngles = NowFarmer.transform.eulerAngles;
		NowFarmer = NewFarmer;
		NewFarmer.SetActive (true);
		NewFarmer.GetComponent<FaRMControl> ().Start ();
	}
		

	public void FalseAll()
	{
		foreach (Level child in MyLevelUp) 
		{
			child.Farmer.SetActive (false);
		}
	}
	void Update()
	{
//		if (Input.GetKeyDown (KeyCode.L))
//			LevelUp (ValueUp);
	}
}
