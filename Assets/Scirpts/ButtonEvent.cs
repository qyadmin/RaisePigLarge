using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour {
    [SerializeField]
    LoadingTiao lt;

	[SerializeField]
	GameObject SoundObj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UIPersonal(GameObject message)
    {
		if (message && !message.activeSelf) {
			message.SetActive(true);
			if (message.GetComponentInChildren<Animator> ()) {
				message.GetComponentInChildren<Animator> ().SetBool ("Up",true);
				message.GetComponentInChildren<Animator> ().SetBool ("Down",false);
			}
			ButtonAddSound ();
            ModleClick.Instance.NewModleReset();
		}
           
    }
    public void UIPersonalESC(GameObject message)
    {
		if (message && message.activeSelf) {
			if (message.GetComponentInChildren<Animator> ()) {
				message.GetComponentInChildren<Animator> ().SetBool ("Up",false);
				message.GetComponentInChildren<Animator> ().SetBool ("Down",true);
				StartCoroutine (AnimatorStart(message.GetComponentInChildren<Animator>()));
			}
			else
			message.SetActive(false);
			ButtonAddSound ();
		}
            
    }

	public void UIPersonalESCNew(GameObject message)
	{
		if (message && message.activeSelf) {
			if (message.GetComponentInChildren<Animator> ()) {
				message.GetComponentInChildren<Animator> ().SetBool ("Up",false);
				message.GetComponentInChildren<Animator> ().SetBool ("Down",true);
				StartCoroutine (AnimatorStart(message.GetComponentInChildren<Animator>()));
			}
//			else
//				message.SetActive(false);
			ButtonAddSound ();
		}

	}



    public void UIregistration(int scenenum)
    {
        lt.LoadingScene(scenenum);
    }

    public void Gonggao()
    {

    }

    public void UIFanHui()
    {
        ModleClick.Instance.CamReset();
		ButtonAddSound ();
    }


    public void SaveHeadImg()
    {

    }

	public void ButtonAddSound()
	{
		Instantiate (SoundObj);
	}

    public void Quite()
    {
        Static.Instance.ClearAll();
    }

	IEnumerator AnimatorStart(Animator anim)
	{
		AnimatorStateInfo info =anim.GetCurrentAnimatorStateInfo(0);


		yield return new WaitForSeconds (0.25f);
		anim.transform.parent.gameObject.SetActive (false);
	}

}
