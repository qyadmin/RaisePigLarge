using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeiLanContarl : MonoBehaviour {

    [SerializeField]
    Material WeiLanMaterial;

    public void WeiLanReset()
    {
        if (Static.Instance.GetValue("weilan") == "0")
        {
            WeiLanMaterial.color = new Color(1, 1, 1, 1);
        }
        if (Static.Instance.GetValue("weilan") == "1")
        {
            WeiLanMaterial.color = new Color(100.0f/255.0f,1,100.0f/255.0f,1);
        }
        if (Static.Instance.GetValue("weilan") == "2")
        {
            WeiLanMaterial.color = new Color(190.0f/255.0f, 50.0f / 255.0f, 50.0f / 255.0f, 1);
        }
        if (Static.Instance.GetValue("weilan") == "3")
        {
            WeiLanMaterial.color = new Color(100f/255f, 159f / 255f, 1, 1);
        }
        if (Static.Instance.GetValue("weilan") == "4")
        {
            WeiLanMaterial.color = new Color(1, 174, 1, 1);
        }
    }
}
