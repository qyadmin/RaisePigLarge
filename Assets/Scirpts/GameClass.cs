using UnityEngine;
using System.Collections;

namespace GameClass
{
	public enum StepTag
	{
		Step01_Animator, //停车
		Step02_Player, //打开支架
		Step03_Player, //打开门
		Step04_palyer, //连接水管
		Step05_Player, //开设备，按注水按钮
		Step06_Player, //打开阀门
		Step07_Player, //安全设施
		Step08_Player, //操作臂
		Step09_Player, //操作水炮
		Step10_Player, //灭火
		Step11_Player, //操作臂
		Step12_Player, //安全带
		Step13_Player, //关阀门
		Step14_Player, //关设备
		Step15_Player,//拆卸水管
		Step16_Player, //关门
		Step17_Player, //收支架
		Step18_Animator, //车开走

	}


    [System.Serializable]
	public class WaypointMessage
	{
		public StepTag StepNub;
		public GameObject[] StepWaypoint;
	}

	[System.Serializable]
	public class AnimatorControll
	{
		public float AnimatorLong;
		public Animator[] OtherAll;
		public string ToBoolName;
		public string AnimatorName;
	}
}
