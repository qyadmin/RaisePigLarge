using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionEvent : MonoBehaviour {

    [SerializeField]
    Animator Shovel;
	[SerializeField]
	HttpMessageModel KaiKen_htp;

	[SerializeField]
	HttpMessageModel BoZhong_htp;

	[SerializeField]
	HttpMessageModel ShouHuo_htp;

	[SerializeField]
	HttpMessageModel ShiFei_htp;

	[SerializeField]
	GameObject ShouHuoSound,ShiFeiSound;

    [SerializeField]
    Image BZ, KK, SH;

	public void KaiKenTuDi()
	{
        if (ModleClick.Instance.Target_ != null)
		KaiKen_htp.Get ();
	}

	public void BoZhongTuDi()
	{
		BoZhong_htp.Get ();
	}

	public void ShouHuoTuDi()
	{
		ShouHuo_htp.Get ();
	}
	public void ShiFeiTuDi()
	{
		ShiFei_htp.Get ();
	}


    public void KaiKen_2()
    {
        ResetAction();
        ModleClick.Instance.ClickReset();
        KK.color = new Color(1,1,1,1f);

        StartCoroutine("WaitKaiKen");
    }
    IEnumerator WaitKaiKen()
    {
        while (ModleClick.Instance.Target_ == null)
        {
            yield return null;
        }
        KaiKenTuDi();
    }

    public void BoZhong_2(GameObject Plan)
    {
        ResetAction();
        ModleClick.Instance.ClickReset();
        BZ.color = new Color(1, 1, 1, 1f);
        StartCoroutine("WaitBoZhong",Plan);
    }
    IEnumerator WaitBoZhong(GameObject Plan)
    {
        while (ModleClick.Instance.Target_ == null)
        {
            yield return null;
        }
        BoZhong(Plan);
    }
    public void ShouHuo_2()
    {
        ResetAction();
        ModleClick.Instance.ClickReset();
        SH.color = new Color(1, 1, 1, 1f);
        
        StartCoroutine("WaitShouHuo");
    }
    IEnumerator WaitShouHuo()
    {
        while (ModleClick.Instance.Target_ == null)
        {
            yield return null;
        }
        ShouHuoTuDi();
    }

	public void KaiKen()
	{
		if (ModleClick.Instance.Target_ != null) 
		{
            LandProperty land = ModleClick.Instance.Target_;
            if (!land.KaiKen_.isKaiken)
            {
                Debug.Log("准备开垦"+ land.gameObject.name);
                StartCoroutine(KaiKenAction(land));
            }
            else
            {
                Debug.Log("开垦过了"+ land.gameObject.name);
            }
        }
	}

	public void BoZhong(GameObject message)
    {
        if (ModleClick.Instance.Target_ != null)
        {
            LandProperty land = ModleClick.Instance.Target_;
            if (!land.KaiKen_.isKaiken)
            {
                Debug.Log("土地还未开垦，请先开垦土地");
                return;
            }

			if (message && !message.activeSelf)
				message.SetActive(true);
        }
    }		




    public void ShiFei()
    {
		Debug.Log ("施肥成功");
		Instantiate (ShiFeiSound);
		Static.Instance.UpdateAllObj ();
    }
    public void ShouHuo()
    {
		Debug.Log ("收获成功");
		Instantiate (ShouHuoSound);
		Static.Instance.UpdateAllObj ();
    }

    [SerializeField]
    GameObject SoundObj;

    IEnumerator KaiKenAction(LandProperty land)
    {
        Shovel.transform.position = land.transform.position;
        //Shovel.gameObject.SetActive(true);
        Debug.Log("准备开垦");
        
        //yield return new WaitForSeconds(2);
        yield return null;
        land.KaiKen_.isKaiken = true;
        //Shovel.gameObject.SetActive(false);
        Instantiate(SoundObj);
        land.TuDiKaiKen(true);
		Static.Instance.UpdateAllObj ();

    }


    public void ResetAction()
    {
        BZ.color = new Color(1,1,1,0.5f);
        SH.color = new Color(1, 1, 1, 0.5f);
        KK.color = new Color(1, 1, 1, 0.5f);
        StopAllCoroutines();
    }
}
