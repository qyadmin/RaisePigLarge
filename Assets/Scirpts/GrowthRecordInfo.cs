using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthRecordInfo : MonoBehaviour {
    [SerializeField]
    GameObject Plan_1,Plan_2,Plan_3,Plan_4,Plan_5, Plan_6, Plan_7;
    [SerializeField]
    Transform Contant_1, Contant_2, Contant_3;
    [SerializeField]
    GameObject info_1, info_2, info_3;
    [SerializeField]
    HttpMessageModel htp;
	[SerializeField]
	HttpMessageModel lasthtp;
	[SerializeField]
	HttpMessageModel nexthtp;
    [SerializeField]
    Text Plan1_Total, Plan2_Total;
    void OnEnable()
    {
        Static.Instance.AddValue("type", "1");
        Static.Instance.SaveGrownInfo.Clear();
        htp.Get();
        PlanChange(1);
        //ListFriendlist ();
    }
    public void InfoType(int i)
    {
        Static.Instance.AddValue("type", i.ToString());
        Static.Instance.SaveGrownInfo.Clear();
        htp.Get();
        PlanChange(i);
    }

	//下一页
	public void InfoTypelast(int i)
	{
		Static.Instance.AddValue("type", i.ToString());
		Static.Instance.SaveGrownInfo.Clear();
		lasthtp.Get();
		PlanChange(i);
	}

	//上一页
	public void InfoTypenext(int i)
	{
		Static.Instance.AddValue("type", i.ToString());
		Static.Instance.SaveGrownInfo.Clear();
		nexthtp.Get();
		PlanChange(i);
	}

    public void PlanChange(int i)
    {
        switch (i)
        {
            case 1:
                Plan_1.SetActive(true);
                Plan_2.SetActive(false);
                Plan_3.SetActive(false);
                Plan_4.SetActive(false);
                Plan_5.SetActive(false);
                Plan_6.SetActive(false);
                Plan_7.SetActive(false);
                break;
            case 2:
                Plan_1.SetActive(false);
                Plan_2.SetActive(true);
                Plan_3.SetActive(false);
                Plan_4.SetActive(false);
                Plan_5.SetActive(false);
                Plan_6.SetActive(false);
                Plan_7.SetActive(false);
                break;
            case 3:
                Plan_1.SetActive(false);
                Plan_2.SetActive(false);
                Plan_3.SetActive(true);
                Plan_4.SetActive(false);
                Plan_5.SetActive(false);
                Plan_6.SetActive(false);
                Plan_7.SetActive(false);
                break;
            case 4:
                Plan_1.SetActive(false);
                Plan_2.SetActive(false);
                Plan_3.SetActive(false);
                Plan_4.SetActive(true);
                Plan_5.SetActive(false);
                Plan_6.SetActive(false);
                Plan_7.SetActive(false);
                break;
            case 5:
                Plan_1.SetActive(false);
                Plan_2.SetActive(false);
                Plan_3.SetActive(false);
                Plan_4.SetActive(false);
                Plan_5.SetActive(true);
                Plan_6.SetActive(false);
                Plan_7.SetActive(false);
                break;
            case 6:
                Plan_1.SetActive(false);
                Plan_2.SetActive(false);
                Plan_3.SetActive(false);
                Plan_4.SetActive(false);
                Plan_5.SetActive(false);
                Plan_6.SetActive(true);
                Plan_7.SetActive(false);
                break;
            case 7:
                Plan_1.SetActive(false);
                Plan_2.SetActive(false);
                Plan_3.SetActive(false);
                Plan_4.SetActive(false);
                Plan_5.SetActive(false);
                Plan_6.SetActive(false);
                Plan_7.SetActive(true);
                break;
        }
    }

    public void ListReset()
    {
        for (int i = 0; i < Contant_1.childCount; i++)
        {
            Destroy(Contant_1.GetChild(i).gameObject);
        }
        for (int i = 0; i < Contant_2.childCount; i++)
        {
            Destroy(Contant_2.GetChild(i).gameObject);
        }
        for (int i = 0; i < Contant_3.childCount; i++)
        {
            Destroy(Contant_3.GetChild(i).gameObject);
        }
        Plan1_Total.text = "0";
        Plan2_Total.text = "0";
    }

    public void ListGrownList()
    {
        if (Plan_1.activeSelf)
            Grown_1();
        if (Plan_2.activeSelf)
            Grown_2();
        if (Plan_3.activeSelf)
            Grown_3();
    }

    void Grown_1()
    {
        ListReset();
        foreach (KeyValuePair<string, Dic> i in Static.Instance.SaveGrownInfo)
        {
            GameObject newFriend = Instantiate(info_1);
            newFriend.transform.parent = Contant_1;
            newFriend.transform.localScale = new Vector3(1, 1, 1);
            string jinju, num1,num2,num3,num4,time,tdjb="";
            i.Value.DataDic.TryGetValue("shouyi", out jinju);
            i.Value.DataDic.TryGetValue("cfbl", out num1);
            i.Value.DataDic.TryGetValue("mutoubl", out num2);
            i.Value.DataDic.TryGetValue("realbl", out num3);
            i.Value.DataDic.TryGetValue("zpbl", out num4);
            i.Value.DataDic.TryGetValue("sj", out time);
			i.Value.DataDic.TryGetValue("wljb", out tdjb);
            newFriend.GetComponent<GrowthS1>().SetValue(jinju,num1,num2,num3,num4, time,tdjb);
        }
        Plan1_Total.text = Static.Instance.GetValue("total_sl");
    }
    void Grown_2()
    {
        ListReset();
        foreach (KeyValuePair<string, Dic> i in Static.Instance.SaveGrownInfo)
        {
            GameObject newFriend = Instantiate(info_2);
            newFriend.transform.parent = Contant_2;
            newFriend.transform.localScale = new Vector3(1, 1, 1);
            string name,num,time;
            i.Value.DataDic.TryGetValue("hy_name",out name);
            i.Value.DataDic.TryGetValue("sl", out num);
            i.Value.DataDic.TryGetValue("sj", out time);
            newFriend.GetComponent<GrowthS2>().SetValue(name,num,time);
        }
        Plan2_Total.text = Static.Instance.GetValue("total_sl");
    }

    void Grown_3()
    {
        ListReset();
        foreach (KeyValuePair<string, Dic> i in Static.Instance.SaveGrownInfo)
        {
            GameObject newFriend = Instantiate(info_3);
            newFriend.transform.parent = Contant_3;
            newFriend.transform.localScale = new Vector3(1, 1, 1);
            string type, num, species,time;
            i.Value.DataDic.TryGetValue("shtype", out type);
            i.Value.DataDic.TryGetValue("sl", out num);
            i.Value.DataDic.TryGetValue("zhonglei", out species);
            i.Value.DataDic.TryGetValue("sj",out time);
            newFriend.GetComponent<GrowthS3>().SetValue(type, num, species,time);
        }
    }
}
