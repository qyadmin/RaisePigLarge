using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuDiManager : MonoBehaviour {

    public List<LandProperty> TuDi = new List<LandProperty>();
    [SerializeField]
    HttpMessageModel htp;
    // Use this for initialization
    void Awake () {
		foreach (Transform i in this.transform) 
		{
			LandProperty j = i.GetComponent<LandProperty> ();
			if (j)
				TuDi.Add (j);
		}
    }

	public void Refresh()
	{
        foreach (LandProperty i in TuDi)
        {
            i.ResetLand();
        }
        RefreshTuDi (Static.Instance.SaveTuDi);
	}

	void RefreshTuDi(Dictionary<string,Dic> message)
	{
		foreach (KeyValuePair<string,Dic> i in message)
		{
			TuDi[int.Parse(i.Key)-1].Message = i.Value.DataDic;
			TuDi[int.Parse(i.Key)-1].i = int.Parse(i.Key);
			TuDi [int.Parse (i.Key) - 1].Refresh ();
		}

	}
}
