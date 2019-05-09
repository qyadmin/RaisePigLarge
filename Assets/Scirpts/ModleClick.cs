using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HighlightingSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModleClick : MonoBehaviour {
    public static ModleClick Instance;
	public Text ShowDeadTime;
	public Text TodaySY;
    private LandProperty Target;
    public LandProperty Target_
    {
        get
        {
            return Target;
        }
        set
        {
            Target = value;
			if(Target)
			Static.Instance.AddValue ("d_id",Target.i.ToString());
        }
    }

    public bool BigLock = false;
    [SerializeField]
    ActionEvent Action;
    [SerializeField]
    Animator ActionPanel,TopPanel,LeftPanel,FanHuiPanel,GuoShuPanel,ShuInfoPanel;

    [SerializeField]
    Image Plan;

	[SerializeField]
	AudioSource ClickSound;

	[SerializeField]
	UnityEvent Baoxiang;
    // Use this for initialization
    void Awake()
    { 
		Instance = this;
        ClickEvent();
    }
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.I)) 
		//{
		//	Debug.Log (Static.Instance.GetValue ("d_id"));
		//	Dic GetDic = null;
		//	Static.Instance.SaveTuDi.TryGetValue (Static.Instance.GetValue ("d_id"),out GetDic);
		//	ShowDeadTime.text = GetDic.GetVaule("dqsj");
		//}
        
        if (BigLock)
            return;
        MouseClicks();
    }

    void TouchClick()
    {

    }

    void MouseClicks()
    {
        if (ConfirmTarget() == null)
        {

            return;
        }
        if (ConfirmTarget() == Target_)
        {
            return;
        }
            
        OtherClick(ConfirmTarget());
        Target_ = ConfirmTarget();
        TargetSetHighlight(Target_);
        ClickGuoShu(Target_);
        ClickEvent();
    }
    public void CamReset()
    {
        StopAllCoroutines();
        //Target_.GetComponent<Highlighter> ().FlashingOff;
        if (Target_ != null)
        {
   //         transform.GetChild(0).gameObject.SetActive(false);
			//for (int i = 0; i < Target_.IsKaiKenLand.transform.childCount; i++)
   //         {
			//	if (Target_.IsKaiKenLand.transform.GetChild(i).CompareTag("jinju"))
   //             {
			//		Target_.IsKaiKenLand.transform.GetChild(i).gameObject.layer = 9;
   //             }
   //         }
			//if (Target_.IsBoZhong.activeSelf) 
			//{
			//	for (int i = 0; i < Target_.IsBoZhong.transform.childCount; i++) {
			//		Target_.IsBoZhong.transform.GetChild (i).gameObject.layer = 9;
			//	}
			//}
            TargetHighReset(Target_);
        }
        Target_ = null;
        //StartCoroutine("ClickTargetPlanReset");
        CameraMove.Instance.CameraReset();
        ClickEvent();

        BigLock = false;
    }


    public void ClickReset()
    {
        //Target_.GetComponent<Highlighter> ().FlashingOff;
        if (Target_ != null)
        {
            TargetHighReset(Target_);
        }
        Target_ = null;
        ShuInfoPanel.gameObject.SetActive(false);
        ClickEvent();
    }

    private void OtherClick(LandProperty land)
    {
        if (Target_ != null && Target_ != land)
        {
            ClickReset();
        }
    }

    LandProperty ChoseParent(GameObject obj)
    {
        if (obj.GetComponent<LandProperty>() == null)
        {
            return obj.transform.parent.parent.GetComponent<LandProperty>();
        }
        else
            return obj.GetComponent<LandProperty>();
    }
		

    private void ClickGuoShu(LandProperty isLand)
    {
        if (isLand.KaiKen_.isKaiken)
        {
            StopAllCoroutines();
            //BigLock = true;
            CameraMove.Instance.TargetMove(isLand.transform);
   //         transform.GetChild(0).gameObject.SetActive(true);
			//for (int i = 0; i < isLand.IsKaiKenLand.transform.childCount; i++)
   //         {
			//	if (isLand.IsKaiKenLand.transform.GetChild(i).CompareTag("jinju"))
   //             {
			//		isLand.IsKaiKenLand.transform.GetChild (i).gameObject.layer = 8;
   //             }
   //         }
			//if (isLand.IsBoZhong.activeSelf) 
			//{
			//	for (int i = 0; i < isLand.IsBoZhong.transform.childCount; i++) {
			//		isLand.IsBoZhong.transform.GetChild (i).gameObject.layer = 8;
			//	}
			//}
            //StartCoroutine("ClickTargetPlan");
            FanHuiPanelUp(isLand);
			//天剑
			Dic GetDic = null;
			Static.Instance.SaveTuDi.TryGetValue (Static.Instance.GetValue ("d_id"),out GetDic);
			ShowDeadTime.text = GetDic.GetVaule("dqsj");
			TodaySY.text = GetDic.GetVaule("cf_jinbi");
			//天剑
        }
    }


    private void ClickEvent()
    {
        return;
		if (Target_ != null)
			ActionPanelContralUp();
		else
			ActionPanelContralDown();
    }

    private void ActionPanelContralUp()
    {
        if (Target_.KaiKen_.isKaiken)
            return;
        ActionPanel.SetBool("Up",true);
        ActionPanel.SetBool("Down",false);   
    }

    private void ActionPanelContralDown()
    {
        ActionPanel.SetBool("Up", false);
        ActionPanel.SetBool("Down", true);

        TopPanel.SetBool("Up", true);
        TopPanel.SetBool("Down", false);

        LeftPanel.SetBool("Up", true);
        LeftPanel.SetBool("Down", false);

        FanHuiPanel.SetBool("Up", false);
        FanHuiPanel.SetBool("Down", true);

        GuoShuPanel.SetBool("Up", false);
        GuoShuPanel.SetBool("Down", true);

		ShuInfoPanel.SetBool ("Up",false);
		ShuInfoPanel.SetBool ("Down",true);
    }

    private void FanHuiPanelUp(LandProperty isLand)
    {
        ShuInfoPanel.gameObject.SetActive(true);
        ShuInfoPanel.transform.position = Camera.main.WorldToScreenPoint(isLand.transform.position);
        return;
        TopPanel.SetBool("Up", false);
        TopPanel.SetBool("Down", true);

        LeftPanel.SetBool("Up", false);
        LeftPanel.SetBool("Down", true);

        GuoShuPanel.SetBool("Up",true);
        GuoShuPanel.SetBool("Down",false);

        FanHuiPanel.SetBool("Up", true);
        FanHuiPanel.SetBool("Down", false);

		ShuInfoPanel.SetBool ("Up",true);
		ShuInfoPanel.SetBool ("Down",false);
    }

    IEnumerator ClickTargetPlan()
    {
        Plan.gameObject.SetActive(true);
        while (Plan.color.a < 0.5f)
        {
            Plan.color = new Color(0, 0, 0, Plan.color.a + Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator ClickTargetPlanReset()
    {
        while (Plan.color.a > 0)
        {
            Plan.color = new Color(0, 0, 0, Plan.color.a - Time.deltaTime * 10);
            yield return null;
        }
        Plan.gameObject.SetActive(false);

    }

    LandProperty BenginTarget;
    LandProperty EndTarget;
    float MovingTime = 0;
    LandProperty ConfirmTarget()
    {

#if UNITY_EDITOR
        if (EventSystem.current.IsPointerOverGameObject() == true)
        {
            return null;
        }
#elif UNITY_IPHONE || UNITY_ANDROID
         if (Input.touchCount != 1)
            return null;
        if (Input.touchCount == 1 )
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return null;
            }
        }
#endif

#if UNITY_EDITOR
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
#elif UNITY_IPHONE || UNITY_ANDROID
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);//从摄像机发出到点击坐标的射线
#endif
        RaycastHit hitInfo;
        LayerMask mask = 1 << LayerMask.NameToLayer("TuDi");

        if (Physics.Raycast(ray, out hitInfo, 100000f, mask.value))
        {
#if UNITY_EDITOR

#elif UNITY_IPHONE || UNITY_ANDROID
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovingTime += Time.deltaTime;
                if (MovingTime > 0.1f)
                {
                    BenginTarget = null;
                    EndTarget = null;
                }
                return null;
            }
#endif


#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
#elif UNITY_IPHONE || UNITY_ANDROID
            if (Input.GetTouch(0).phase == TouchPhase.Began)
#endif
            {
                EndTarget = null;
                MovingTime = 0;
				if(hitInfo.collider.gameObject.CompareTag("baoxiang"))
				{
					Baoxiang.Invoke ();
				}
                if (hitInfo.collider.gameObject.CompareTag("jinju"))
                {
                    LandProperty hitobj = ChoseParent(hitInfo.collider.gameObject);
                    BenginTarget = hitobj;
                }
                else
                    BenginTarget = null;
            }
#if UNITY_EDITOR
            if (Input.GetMouseButtonUp(0))
#elif UNITY_IPHONE || UNITY_ANDROID
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
#endif
            {
                if (hitInfo.collider.gameObject.CompareTag("jinju"))
                {
                    LandProperty hitobj = ChoseParent(hitInfo.collider.gameObject);
                    EndTarget = hitobj;
                }
                else
                    EndTarget = null;
            }
        }
        else
        {
            EndTarget = null;
            BenginTarget = null;
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
#elif UNITY_IPHONE || UNITY_ANDROID
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
#endif
            {
#if UNITY_EDITOR
                if (!EventSystem.current.IsPointerOverGameObject() == true)
#elif UNITY_IPHONE || UNITY_ANDROID
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
                {
                    Action.ResetAction();
                    
                    ClickReset();
                }   
            } 
            return null;
        }





        if (BenginTarget == EndTarget && (BenginTarget != null && EndTarget != null))
        {
            return EndTarget;
        }
        else
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
#elif UNITY_IPHONE || UNITY_ANDROID
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
#endif
            {
#if UNITY_EDITOR
                if (!EventSystem.current.IsPointerOverGameObject() == true)
#elif UNITY_IPHONE || UNITY_ANDROID
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
                    ClickReset();
            }

            return null;
        }
           
    }


    void TargetSetHighlight(LandProperty target)
    {
        if (!target)
            return;
        Material highligh = new Material(Shader.Find("Custom/OutLine2"));
        highligh.SetColor("_TintColor", HexToColor("FF7C7C00"));
        highligh.mainTexture = target.SelfMaterial_.mainTexture;
        target.SetMaterial(highligh);
        target.GetComponent<LandJump>().ClickUp();
        Instantiate (ClickSound.gameObject);
    }

    void TargetHighReset(LandProperty target)
    {
        if (!target)
            return;
        target.SetMaterial(target.SaveSelfMaterial);
        target.SaveSelfMaterial = null;
    }


    public Color HexToColor(string hex)
    {
        byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        byte cc = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        float r = br / 255f;
        float g = bg / 255f;
        float b = bb / 255f;
        float a = cc / 255f;
        return new Color(r, g, b, a);
    }

    public void NewModleReset()
    {
        Action.ResetAction();

        ClickReset();
    }
}
