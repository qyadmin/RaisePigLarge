using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthS2 : MonoBehaviour {
    [SerializeField]
    Text Name, Num, Time;

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


    public void SetValue(string name, string num, string time)
    {
        Name_ = name;
        Num_ = num;
        Time_ = time;
    }
}
