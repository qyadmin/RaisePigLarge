using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HuaDongKuangAnimation : MonoBehaviour {

    Animator Kuang;

    bool isOpen;

    [SerializeField]
    Button UpButton, DownButton;
	// Use this for initialization
	void Start () {
        isOpen = false;
        Kuang = this.GetComponent<Animator>();
        UpButton.onClick.AddListener(delegate ()
        {
            Up();
        });
        DownButton.onClick.AddListener(delegate ()
        {
            Down();
        });
	}

    public void Up()
    {
        isOpen = true;
        Kuang.SetBool("Up", false);
        Kuang.SetBool("Down", true);
    }

    public void Down()
    {
        isOpen = true;
        Kuang.SetBool("Up",true);
        Kuang.SetBool("Down",false);
    }

    public void ClickTarget()
    {
        if (isOpen)
        {
            Down();
        }
        UpButton.interactable = false;
    }
    public void ResetClick()
    {
        UpButton.interactable = true;
    }

}
