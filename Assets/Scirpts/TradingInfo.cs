using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TradingInfo : MonoBehaviour {

    [SerializeField]
    Text Name, Num, Time, Type;

    public string Name_
    {
        get
        {
            return Name.text;
        }
        set
        {
            Name.text = value;
        }
    }
    public string Num_
    {
        get
        {
            return Num.text;
        }
        set
        {
            Num.text = value;
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
    public string Type_
    {
        get
        {
            return Type.text;
        }
        set
        {
            Type.text = value;
        }
    }


    public void SetValue(string name, string num, string time,string type)
    {
        Name_ = name;
        Num_ = num;
        Time_ = time;
        Type_ = type;
    }
}
