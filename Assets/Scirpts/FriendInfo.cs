using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendInfo : MonoBehaviour {

	[SerializeField]
	Transform Contant;

	[SerializeField]
	GameObject Firend;

    [SerializeField]
    HttpMessageModel htp;
	[SerializeField]
	HttpMessageModel htp2;
	[SerializeField]
	Text Totoal;
	[SerializeField]
	Text ZhiTuiTotoal;

    [SerializeField]
    Transform GouMaiYiJian, YiJian;
	public void SetStart()
	{
        switch (Static.Instance.GetValue("yjflag"))
        {
            case "0":
                GouMaiYiJian.gameObject.SetActive(true);
                YiJian.gameObject.SetActive(false);
                break;
            case "1":
                GouMaiYiJian.gameObject.SetActive(false);
                YiJian.gameObject.SetActive(true);
                break;
        }
       // Static.Instance.SaveFriend.Clear();
        //htp.Get();
		//htp2.Get();
        //ListFriendlist ();
    }

//	public void FirendLevel(int i)
//	{
//		Static.Instance.AddValue ("daishu",i.ToString());
//        Static.Instance.SaveFriend.Clear();
//        htp.Get();
//		htp2.Get();
//    }


	public void ListFriendlist()
	{
		

	}


	public void SetZhTui()
	{
		ZhiTuiTotoal.text=Static.Instance.GetValue ("tj_num");
		Totoal.text = Static.Instance.GetValue ("td_num");
	}
}
