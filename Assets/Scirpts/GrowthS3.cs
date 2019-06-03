using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthS3 : MonoBehaviour {

    [SerializeField]
    Text Type,Species, Num, Time;

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
    public string Species_
    {
        get
        {
            return Species.text;
        }
        set
        {
            Species.text = value;
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


    public void SetValue(string type,string num, string species, string time)
    {
        Type_ = type;
        Species_ = species;
        Num_ = num;
        Time_ = time;
    }
}
