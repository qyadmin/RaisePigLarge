using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthS1 : MonoBehaviour {

    [SerializeField]
    Text Jinju, Num1, Num2, Num3, Num4,Time, tdjb;

    public string Jinju_
    {
        get
        {
            return Jinju.text;
        }
        set
        {
            Jinju.text = value;
        }
    }
    public string Num1_
    {
        get
        {
            return Num1.text;
        }
        set
        {
            Num1.text = value;
        }
    }
    public string Num2_
    {
        get
        {
            return Num2.text;
        }
        set
        {
            Num2.text = value;
        }
    }

    public string Num3_
    {
        get
        {
            return Num3.text;
        }
        set
        {
            Num3.text = value;
        }
    }

    public string Num4_
    {
        get
        {
            return Num4.text;
        }
        set
        {
            Num4.text = value;
        }
    }

    public string Time_
    {
        get
        {
            return Time.text;
        }
        set
        {
            Time.text = value;
        }
    }

	public void SetValue(string jinju, string num1, string num2,string num3,string num4,string time,string tdjb)
    {
        Jinju_ = jinju;
        Num1_ = num1;
        Num2_ = num2;
        Num3_ = num3;
        Num4_ = num4;
        Time_ = time;
    }
}
