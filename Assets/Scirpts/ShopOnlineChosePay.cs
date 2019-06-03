using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOnlineChosePay : MonoBehaviour {

    [SerializeField]
    Toggle Dog, Goald;

    private void Start()
    {
        Dog.onValueChanged.AddListener(delegate (bool isOn) { ChosePay1(); });
        Goald.onValueChanged.AddListener(delegate (bool isOn) { ChosePay2(); });
    }

    public void ChosePay1()
    {
        if (Dog.isOn)
            Goald.isOn = false;

        SetpayModel();


    }
    public void ChosePay2()
    {
        if (Goald.isOn)
            Dog.isOn = false;

        SetpayModel();
    }

    [SerializeField]
    Text payModel;
    public void SetpayModel()
    {
        if (Dog.isOn || Goald.isOn)
            if (Dog.isOn)
                payModel.text = "1";
            else
                payModel.text = "0";
        else
            payModel.text = null;


    }


}
