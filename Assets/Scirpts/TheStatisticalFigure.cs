using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Newtonsoft.Json.Linq;
using LitJson;
public class TheStatisticalFigure : MonoBehaviour {

    [SerializeField]
    WMG_Axis_Graph Axis;
    [SerializeField]
    WMG_Series y_Axis,y2_Axis;

    WMG_Axis X_Axis;
    WMG_Axis Y_Axis;
    private void Awake()
    {
        X_Axis = Axis.xAxis;
        Y_Axis = Axis.yAxis;
    }


    public void Succece()
    {
        X_Axis.axisLabels.SetList(X_Value);

        y_Axis.pointValues.SetList(Y1_Value);

        y2_Axis.pointValues.SetList(Y2_Value);

       
    }


    private void Update()
    {
    }

    void SetYMaxMinValue(float min,float max)
    {
        Y_Axis.AxisMinValue = min;
        Y_Axis.AxisMaxValue = max;
    }


    public List<string> X_Value = new List<string>();
    public List<Vector2> Y1_Value = new List<Vector2>();
    public List<Vector2> Y2_Value = new List<Vector2>();


    public void GetJsonDataX(JsonData GetJson)
    {
        StopAllCoroutines();
        X_Value.Clear();
        foreach (var child in GetJson)
            X_Value.Add(child.ToString());

    }
    public void GetJsonDataY1(JsonData GetJson)
    {
        StopAllCoroutines();
        Y1_Value.Clear();
        StartCoroutine(SetY1(GetJson));
    }
    public void GetJsonDataY2(JsonData GetJson)
    {
        StopAllCoroutines();
        Y2_Value.Clear();
        StartCoroutine(SetY2(GetJson));
    }

    IEnumerator SetY1(JsonData GetJson)
    {
        while(X_Value == null)
        yield return null;
        for (int i = 0; i < GetJson.Count; i++)
        {
            Y1_Value.Add(new Vector2(float.Parse(X_Value[i].Split('-')[1]), float.Parse(GetJson[i].ToString())));
        }
        //foreach (var child in GetJson)
        //    Y1_Value.Add(new Vector2(, float.Parse(child.ToString())));

    }
    IEnumerator SetY2(JsonData GetJson)
    {
        while (X_Value == null)
            yield return null;
        for (int i = 0; i < GetJson.Count; i++)
        {
            Y2_Value.Add(new Vector2(float.Parse(X_Value[i].Split('-')[1]), float.Parse(GetJson[i].ToString())));
        }
        //foreach (var child in GetJson)
        //    Y1_Value.Add(new Vector2(, float.Parse(child.ToString())));

    }

}



