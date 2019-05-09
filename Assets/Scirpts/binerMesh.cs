using UnityEngine;
using System.Collections;

public class binerMesh : MonoBehaviour
{
    void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        MeshRenderer[] meshRenderer = GetComponentsInChildren<MeshRenderer>();  //获取自身和所有子物体中所有MeshRenderer组件
        Material[] mats = new Material[meshRenderer.Length];                    //新建材质球数组

        for (int i = 0; i < meshFilters.Length; i++)
        {
            mats[i] = meshRenderer[i].sharedMaterial;                           //获取材质球列表

            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, false);//为mesh.CombineMeshes添加一个 false 参数，表示并不是合并为一个网格，而是一个子网格列表

        transform.GetComponent<MeshRenderer>().sharedMaterials = mats;          //为合并后的GameObject指定材质

        transform.gameObject.SetActive(true);
    }
}