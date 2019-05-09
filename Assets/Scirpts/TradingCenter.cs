using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradingCenter : MonoBehaviour {
    [SerializeField]
    Slider TradingSlider;

    [SerializeField]
    Sprite Open, Close;


    [SerializeField]
    GameObject Plan_1, Plan_2, Plan_3;
    [SerializeField]
    Transform Contant_2, Contant_3;
    [SerializeField]
    GameObject info;
    [SerializeField]
    HttpMessageModel htp_info,htp_request;

	[SerializeField]
	InputField targetID,Jinju,Password;
	[SerializeField]
	Text eorro;
	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        GetType(1);
        UITradingCenterSlider();
    }

    public void GetType(int type)
    {
        Static.Instance.AddValue("type", type.ToString());
        Static.Instance.SaveTradingInfo.Clear();
        if (type != 1)
        {
            htp_info.Get();
        }
        PlanChange(type);
    }

    public void Send_request()
    {
        htp_request.Get();
    }


    void PlanChange(int i)
    {
        switch (i)
        {
            case 1:
                Plan_1.SetActive(true);
                Plan_2.SetActive(false);
                Plan_3.SetActive(false);
                break;
            case 2:
                Plan_1.SetActive(false);
                Plan_2.SetActive(true);
                Plan_3.SetActive(false);
                break;
            case 3:
                Plan_1.SetActive(false);
                Plan_2.SetActive(false);
                Plan_3.SetActive(true);
                break;
        }
    }
    public void ListReset()
    {
        for (int i = 0; i < Contant_2.childCount; i++)
        {
            Destroy(Contant_2.GetChild(i).gameObject);
        }
        for (int i = 0; i < Contant_3.childCount; i++)
        {
            Destroy(Contant_3.GetChild(i).gameObject);
        }
    }

    public void ListGrownList()
    {
        if (Plan_2.activeSelf)
            Grown_2();
        if (Plan_3.activeSelf)
            Grown_3();
    }

    void Grown_2()
    {
        ListReset();
        foreach (KeyValuePair<string, Dic> i in Static.Instance.SaveTradingInfo)
        {
            GameObject newFriend = Instantiate(info);
            newFriend.transform.parent = Contant_2;
            newFriend.transform.localScale = new Vector3(1, 1, 1);
            string name, num, time,type;
            i.Value.DataDic.TryGetValue("hy_name", out name);
            i.Value.DataDic.TryGetValue("sl", out num);
            i.Value.DataDic.TryGetValue("sj", out time);
            i.Value.DataDic.TryGetValue("status", out type);
            newFriend.GetComponent<TradingInfo>().SetValue(name, num, time,type);
        }
    }

    void Grown_3()
    {
        ListReset();
        foreach (KeyValuePair<string, Dic> i in Static.Instance.SaveTradingInfo)
        {
            GameObject newFriend = Instantiate(info);
            newFriend.transform.parent = Contant_3;
            newFriend.transform.localScale = new Vector3(1, 1, 1);
            string name, num, time, type;
            i.Value.DataDic.TryGetValue("hy_name", out name);
            i.Value.DataDic.TryGetValue("sl", out num);
            i.Value.DataDic.TryGetValue("sj", out time);
            i.Value.DataDic.TryGetValue("status", out type);
            newFriend.GetComponent<TradingInfo>().SetValue(name, num, time, type);
        }
    }


    public void UITradingCenterSlider()
    {
        TradingSlider.value = 0;
		targetID.text = null;
		Jinju.text = null;
		Password.text = null;
		eorro.text = null;
        valueChange();
    }

    public void valueChange()
    {
        Sprite ico = new Sprite();
        switch (TradingSlider.value.ToString())
        {
            case "0":
                ico = Open;
                break;
            case "1":
                ico = Close;
                break;
        }
        TradingSlider.handleRect.GetComponent<Image>().sprite = ico;
    }

	public void Succece()
	{
		eorro.text = htp_request.Data.GetBase.msg;
		Static.Instance.UpdateAllObj ();
	}
	public void Fail()
	{
		eorro.text = htp_request.Data.GetBase.msg;
	}
}
