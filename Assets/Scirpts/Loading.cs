using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour {
    public static Loading Instance;

    [SerializeField]
    InputField PhoneID;
    [SerializeField]
    InputField PassWord;
    [SerializeField]
    InputField VerCode;
    [SerializeField]
    HttpMessageModel htp;
    [SerializeField]
    Text YanZhengMa;
    [SerializeField]
    InputField YanZhengMaInput;

    [SerializeField]
    Text WinningInfo;

	[SerializeField]
	private LaodTiao GetLoad;
    string PhoneID_
    {
        get
        {
            return PhoneID.text;
        }
        set
        {
            name = value;
        }
    }
    string PassWord_
    {
        get
        {
            return PassWord.text;
        }
        set
        {
            name = value;
        }
    }
    string VerCode_
    {
        get
        {
            return VerCode.text;
        }
        set
        {
            name = value;
        }
    }

    void Start()
    {
        Instance = this;
		GetLoad.StartLaod ();
    }

    public void Login()
    {
		Static.Instance.ClearAll ();
        Static.Instance.CurrentAccount = LogininfoEnc();
        Logining();
    }

	public GameObject pppp;
    public void LoginSuccess()
    {
        if (YanZhengMa.text == YanZhengMaInput.text)
        {
            Static.Instance.LoginAccount = Static.Instance.CurrentAccount;
            WinningInfo.text = "登录成功";
			GetLoad.IsGetIn = true;
			pppp.SetActive (true);
        }
        else
        {
            WinningInfo.text = "验证码有误";
            Static.Instance.LoginAccount = null;
            Debug.Log("验证码错误");
        }
           
    }

    public void LoginFailed()
    {
		
//        WinningInfo.text = "帐号或密码有误";
//        Static.Instance.LoginAccount = null;
//        Debug.Log("登录失败");
    }

    Logininfo LogininfoEnc()
    {
        Logininfo info = new Logininfo();
        info.ID = PhoneID_;
        info.PassWord = PassWord_;
        info.VerCode = VerCode_;
        return info;
    }

    void Logininfo()
    {

    }

    public void Registration()
    {

    }
    public void ForgetPassword()
    {

    }

    public void Logining()
    {
        htp.Get();
    }
}
