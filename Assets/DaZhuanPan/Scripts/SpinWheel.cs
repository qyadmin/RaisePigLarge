using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpinWheel : MonoBehaviour
{
	public List<int> prize;
	public List<AnimationCurve> animationCurves;
	
	private bool spinning;	
	private float anglePerItem;	
	private int randomTime;
	private int itemNumber;

    [System.Serializable]
    class ZhuanPan
    {
        public int[] Jiang;
        public Text Gailv;
        public string Name;
    }
    [SerializeField]
    Button StartButton;
    [SerializeField]
    UnityEvent Zhuaning, ZhuanFinsh;

    [SerializeField]
    float jiaodu = 0,GuDingJiao;

    [SerializeField]
    Text JieGuo;

    [SerializeField]
    ZhuanPan[] Prize;

    void Start(){
		spinning = false;
		anglePerItem = 360;		
	}

    public void SetStartButtonfalse()
    {
        StartButton.interactable = false;
    }
    public void SetStartButtontrue()
    {
        StartButton.interactable = true;
    }
    float maxAngle;
    public void ButtonClick ()
	{
		if (!spinning) {
            randomTime = Random.Range (1, 2);
			itemNumber = Random.Range (0, 360);
			maxAngle = 360 * randomTime + GetAngel();

            StartCoroutine (SpinTheWheel (2 * randomTime, maxAngle));
		}
	}
    float startAngle;

    IEnumerator SpinTheWheel (float time, float maxAngle)
	{
		spinning = true;
		
		float timer = 0.0f;		
		startAngle = transform.localEulerAngles.z;		
		maxAngle = maxAngle - startAngle;
		
		int animationCurveNumber = Random.Range (0, animationCurves.Count);
		Debug.Log ("Animation Curve No. : " + animationCurveNumber);
		
		while (timer < time) {
		//to calculate rotation
			float angle = maxAngle * animationCurves [animationCurveNumber].Evaluate (timer / time) ;
			transform.localEulerAngles = new Vector3 (0.0f, 0.0f, angle + startAngle);
			timer += Time.deltaTime;
			yield return 0;
		}
		
		transform.localEulerAngles = new Vector3 (0.0f, 0.0f, maxAngle + startAngle);
		spinning = false;
        ZhuanFinsh.Invoke();
		//Debug.Log ("Prize: " + prize [itemNumber]);//use prize[itemNumnber] as per requirement
	}
    public void ExitDaZhuanPan()
    {
        StopAllCoroutines();
        spinning = false;
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
        SetStartButtontrue();
    }

    float GetAngel()
    {
        float random = Random.Range(0.0f, 101.0f);

        int GetNum = 0;
        float Gailv_ = 0;
        for (int i = 0; i < Prize.Length; i++)
        {
            Gailv_ += float.Parse(Prize[i].Gailv.text);
            if (random <= Gailv_ * 100)
            {
                GetNum = i;
                break;
            }
                
        }
       

        int GetPart = Random.Range(0,Prize[GetNum].Jiang.Length);

        float GetAngel_su = Random.Range((Prize[GetNum].Jiang[GetPart]-1) * GuDingJiao, Prize[GetNum].Jiang[GetPart]* GuDingJiao);
        Debug.Log(random + "    " + Prize[GetNum].Name+"    "+ GetPart+"    "+ GetAngel_su);
        jiaodu = GetAngel_su;
        JieGuo.text = Prize[GetNum].Name;
        Zhuaning.Invoke();
        return GetAngel_su;
    }
}
