using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour {

    public enum ScreenType
    {
        Horizontal,Vertical
    }

    public ScreenType ChsoeType;
    public float WaitTime;
    void Start()
    {
        Invoke("SetCreenAction", WaitTime);
    }


	void SetCreenAction()
    {
		switch (ChsoeType)
		{
		case ScreenType.Horizontal:
			ChangeLeftScreen();
			break;

		case ScreenType.Vertical:
                ChangeUpScreen();
			break;
		}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    //横屏
    public void ChangeLeftScreen()
    {
        ScreenAwakeHorizontal();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    //竖屏
    public void ChangeUpScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
    }


    void ScreenAwakeHorizontal()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }


    //IEnumerator ToBig(Tranform GetObj)
    //{
    //    while (GetObj)
    //}

}
