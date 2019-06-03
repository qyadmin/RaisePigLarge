using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Regis : MonoBehaviour {
    [SerializeField]
    InputField PassWord,PassWord_;
    [SerializeField]
    InputField JYPassWord, JYPassWord_;
    [SerializeField]
    InputField YanZhengMa;
    [SerializeField]
    Text YanZhengMa_;
    [SerializeField]
    UnityEvent suc, fal;
    [SerializeField]
    Text Eorro;
    [SerializeField]
    HttpMessageModel htp;

    public void Validation()
    {
//        Eorro.text = null;
//        if (PassWord.text != PassWord_.text)
//        {
//            Eorro.text = "两次输入密码不正确";
//            return;
//        }
//        if (JYPassWord.text != JYPassWord_.text)
//        {
//            Eorro.text = "两次输入交易密码不正确";
//            return;
//        }
//        if (YanZhengMa.text != YanZhengMa_.text)
//        {
//            Eorro.text = "验证码错误";
//            return;
//        }
        suc.Invoke();
    }

    public void Succece()
    {
        Eorro.text = htp.Data.GetBase.msg;
    }
    public void Fail()
    {
        Eorro.text = htp.Data.GetBase.msg;
        
    }
}
