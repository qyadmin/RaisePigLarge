using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SetAction
{
	public ActionState PonitAI;
	[Range(0,1)]
	public float RandomValue=0.33f;
	//[HideInInspector]
	public int RangeNub;
}

public enum ActionState
{
	Idel,
	Walk,
	Attack
}
public class FaRMControl : MonoBehaviour {


	public Transform[] WayPoint;
	private Animator FarmAnimator;

	public ActionState MyActionType;
	public bool IsWalk;
	public int Speed;
	public Transform NowPoint;

	public void Start () 
	{
		FarmAnimator = GetComponent<Animator> ();
		UpdateWayPoint ();
	}
	

	void Update () 
	{
		if (IsWalk) 
		{
			if (Vector3.Distance (transform.position, NowPoint.position) <= 0.2f) 
			{
				IsWalk = false;
				SetPoint (CalculateAction(NowPoint.GetComponent<AIpoint>().MyAction));
			}
			Vector3 relativePos = NowPoint.position - transform.position;
			Quaternion rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(relativePos.normalized), Time.deltaTime*2);
			transform.rotation = rotation;
			transform.Translate(Vector3.forward * Speed * Time.deltaTime / 10);
		}
	}


	public ActionState CalculateAction(SetAction[] GetActionGroup)
	{
		ActionState CopAction = ActionState.Idel;
		int AddNub = 0;
		foreach (SetAction child in GetActionGroup) 
		{
			AddNub += (int)(child.RandomValue*100);
			child.RangeNub = AddNub;
		}
	
		int Nub = Random.Range (0, GetActionGroup.Last().RangeNub);

		foreach (SetAction child in GetActionGroup) 
		{
			if (Nub < child.RangeNub) 
			{
				CopAction = child.PonitAI;
				break;
			}
		}
			
		return CopAction;
	}



	void SetPoint(ActionState DoAction)
	{
		SetFalse ();
		MyActionType = DoAction;
		switch (MyActionType)
		{
		case ActionState.Idel:
			FarmAnimator.SetBool ("ToIdle",true);
			StartCoroutine ("Wait",Random.Range(5,20));
		break;

		case ActionState.Walk:
			UpdateWayPoint ();
		break;
		case ActionState.Attack:
			FarmAnimator.SetBool ("ToAttack",true);
			StartCoroutine ("Wait",Random.Range(2,2));
		break;
		}
	}


	IEnumerator Wait(int timewait)
	{
		yield return new WaitForSeconds (timewait);
		SetPoint (CalculateAction(NowPoint.GetComponent<AIpoint>().MyAction));
	}


	Dictionary<float,Transform> SearchWay=new Dictionary<float, Transform>();
	List<Transform> SortPoint=new List<Transform>();

	public void UpdateWayPoint()
	{
		SearchWay.Clear ();
		SortPoint.Clear ();
		foreach (Transform child in WayPoint) 
		{
			SearchWay.Add (Vector3.Distance (transform.position, child.position), child);
		}

		Dictionary<float,Transform> SorthWay = SearchWay.OrderBy (o => o.Key).ToDictionary (o=>o.Key,p => p.Value);

		foreach (Transform child in SorthWay.Values)
			SortPoint.Add (child);
		
		int a = (int)Time.time;
		NowPoint =a%2==0?SortPoint[2]:SortPoint[1];
		IsWalk = true;
		FarmAnimator.SetBool ("ToWalk",true);
	}


	void SetFalse()
	{
		FarmAnimator.SetBool ("ToWalk",false);
		FarmAnimator.SetBool ("ToAttack",false);
		FarmAnimator.SetBool ("ToIdle",false);
	}
}
