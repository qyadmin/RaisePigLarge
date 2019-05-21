using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeRMBtoUser : MonoBehaviour
{
    public Call call;
    public Button _300Btn, _600Btn, _1200Btn, _2400Btn, _4800Btn, _9600Btn;
    // Use this for initialization
    void Start()
    {
        _300Btn.onClick.AddListener(() =>
        {
            call.send(300);
        });

        _600Btn.onClick.AddListener(() =>
        {
            call.send(600);
        });
        _1200Btn.onClick.AddListener(() =>
        {
            call.send(1200);
        });
        _2400Btn.onClick.AddListener(() =>
        {
            call.send(2400);
        });
        _4800Btn.onClick.AddListener(() =>
        {
            call.send(4800);
        });
        _9600Btn.onClick.AddListener(() =>
        {
            call.send(9600);
        });
    }
}
