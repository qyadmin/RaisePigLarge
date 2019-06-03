using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using TypeClass;
[CustomEditor(typeof(HttpModel))]
public class TestListInspector : Editor
{
    private ReorderableList m_NameList;
	private ReorderableList GetDataList;
	private ReorderableList SetDataList;
	private ReorderableList ListDataList;
	private ReorderableList ListSingleList;
    private SerializedProperty GetMessageShow;
	private SerializedProperty GetBaseDataShow;
	private SerializedProperty GetListDataShow;
    private SerializedProperty GetListNoActionShow;
    private void OnEnable()
    {
        m_NameList = new ReorderableList(serializedObject,
			serializedObject.FindProperty("Data").FindPropertyRelative("SendData"),
            true, true, true, true);

		GetDataList = new ReorderableList(serializedObject,
			serializedObject.FindProperty("Data").FindPropertyRelative("GetDataList"),
          true, true, true, true);

		SetDataList = new ReorderableList(serializedObject,
			serializedObject.FindProperty("Data").FindPropertyRelative("BackDataGet"),
			true, true, true, true);

		ListDataList = new ReorderableList(serializedObject,
			serializedObject.FindProperty("Data").FindPropertyRelative("MyListMessage").FindPropertyRelative("NameList"),
			true, true, true, true);

		ListSingleList = new ReorderableList(serializedObject,
			serializedObject.FindProperty("Data").FindPropertyRelative("MyListMessage").FindPropertyRelative("NameSingleList"),
			true, true, true, true);
		
		GetDataList.drawElementCallback += DrawNameElementObj;

        m_NameList.drawElementCallback += DrawNameElement;

		SetDataList.drawElementCallback += DrawNameElementSetBack;

		ListDataList.drawElementCallback += DrawNameElementList;

		ListSingleList.drawElementCallback += DrawNameSingleList;


		ListSingleList.drawHeaderCallback = (Rect rect) =>
		{
			GUI.Label(rect, "添加获取返回数据的列表");
		};

        m_NameList.drawHeaderCallback = (Rect rect) =>
        {
            GUI.Label(rect, "添加请求数据的列表");
        };

		GetDataList.drawHeaderCallback = (Rect rect) =>
        {
            GUI.Label(rect, "返回数据列表");
        };

		SetDataList.drawHeaderCallback = (Rect rect) =>
		{
			GUI.Label(rect, "返回数据赋值列表");
		};

		ListDataList.drawHeaderCallback = (Rect rect) =>
		{
			GUI.Label(rect, "需要取得的列表数据");
		};
    }


	private void DrawNameSingleList(Rect rect, int index, bool selected, bool focused)
	{
		SerializedProperty element = ListSingleList.serializedProperty.GetArrayElementAtIndex(index);

		rect.y += 2;
		rect.height = EditorGUIUtility.singleLineHeight;
		EditorGUI.PropertyField(new Rect(rect.x+2*rect.width/3, rect.y, rect.width/5, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("MyType"), GUIContent.none);
		EditorGUI.LabelField (new Rect(rect.width-10, rect.y, 40, EditorGUIUtility.singleLineHeight),"ToInt");
		EditorGUI.PropertyField(new Rect(rect.width-25, rect.y, 10, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("IsInt"),GUIContent.none);

		EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width/3.6f, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("Name"), GUIContent.none);
		GetBackType ShowType =(GetBackType) element.FindPropertyRelative ("MyType").enumValueIndex;
		if(ShowType==GetBackType.Text)
			EditorGUI.PropertyField (new Rect(rect.x+rect.width/3.5f, rect.y,rect.width/3.5f, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Showtext"), GUIContent.none);
		if(ShowType==GetBackType.InputText)
			EditorGUI.PropertyField (new Rect(rect.x+rect.width/3.5f, rect.y, rect.width/3.5f, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("ShowInputtext"), GUIContent.none);
        if (ShowType == GetBackType.Event)
        {
            EditorGUI.PropertyField(new Rect(rect.x + rect.width / 4.5f, rect.y, rect.width / 4.5f, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("SendData"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + rect.width / 4.5f*2, rect.y, rect.width / 4.5f, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("EventName"), GUIContent.none);
        }
        //EditorGUI.PropertyField(rect, element, GUIContent.none);
    }

	private void DrawNameElementList(Rect rect, int index, bool selected, bool focused)
	{
		SerializedProperty element = ListDataList.serializedProperty.GetArrayElementAtIndex(index);

		rect.y += 2;
		rect.height = EditorGUIUtility.singleLineHeight;
		EditorGUI.PropertyField(new Rect(rect.x, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("Name"), GUIContent.none);
		EditorGUI.PropertyField (new Rect(rect.x+90, rect.y, 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("MyObjeType"), GUIContent.none);
		EditorGUI.PropertyField (new Rect(rect.width-50, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("MySaveType"), GUIContent.none);

		if ((SaveNameType)element.FindPropertyRelative ("MySaveType").enumValueIndex == SaveNameType.SaveOtherName) 
		{
			EditorGUI.PropertyField (new Rect(rect.width-150, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("OtherName"), GUIContent.none);
		}
		if ((SaveNameType)element.FindPropertyRelative ("MySaveType").enumValueIndex == SaveNameType.ActionEvent) 
		{
			EditorGUI.PropertyField (new Rect(rect.width-150, rect.y, 80, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("EventName"), GUIContent.none);
		}

		//EditorGUI.PropertyField(rect, element, GUIContent.none);
	}



    private void DrawNameElementObj(Rect rect, int index, bool selected, bool focused)
    {
		SerializedProperty element = GetDataList.serializedProperty.GetArrayElementAtIndex(index);

        rect.y += 2;
        rect.height = EditorGUIUtility.singleLineHeight;
		EditorGUI.PropertyField(rect, element, GUIContent.none);
//        EditorGUI.PropertyField(new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("SaveButtonEvent"), GUIContent.none);
//        EditorGUI.PropertyField(new Rect(rect.x + 100, rect.y, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("GetGasValve"), GUIContent.none);
    }

	private void DrawNameElementSetBack(Rect rect, int index, bool selected, bool focused)
	{
		SerializedProperty element = SetDataList.serializedProperty.GetArrayElementAtIndex(index);

		rect.y += 2;
		rect.height = EditorGUIUtility.singleLineHeight;
		EditorGUI.PropertyField(new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("MyType"), GUIContent.none);
		EditorGUI.PropertyField (new Rect(rect.width-20, rect.y, 20, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("IsSave"), GUIContent.none);

		GetBackTypeValue ShowType =(GetBackTypeValue) element.FindPropertyRelative ("MyType").enumValueIndex;
		if ( ShowType== GetBackTypeValue.GetValue) 
		{
			SetDataList.elementHeight = 40;
			EditorGUI.HelpBox(new Rect(rect.x+110, rect.y, rect.width/4, EditorGUIUtility.singleLineHeight),"获取的值赋给Text",MessageType.None);
			EditorGUI.PropertyField (new Rect(rect.x, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Name"), GUIContent.none);
			EditorGUI.PropertyField (new Rect(rect.width-100, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("SetText"), GUIContent.none);
		}
		if (ShowType == GetBackTypeValue.NoGetValue) 
		{
			SetDataList.elementHeight = 40;
			EditorGUI.HelpBox(new Rect(rect.x+110, rect.y, rect.width/4, EditorGUIUtility.singleLineHeight),"获取的值保存到列表",MessageType.None);
			EditorGUI.PropertyField (new Rect(rect.x, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Name"), GUIContent.none);
		}
	}






    private void DrawNameElement(Rect rect, int index, bool selected, bool focused)
    {
        SerializedProperty element = m_NameList.serializedProperty.GetArrayElementAtIndex(index);

        rect.y += 2;
        rect.height = EditorGUIUtility.singleLineHeight;
		EditorGUI.PropertyField(new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("MyType"), GUIContent.none);
		EditorGUI.PropertyField (new Rect(rect.width-20, rect.y, 20, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("IsSave"), GUIContent.none);
		GetTypeValue ShowType =(GetTypeValue) element.FindPropertyRelative ("MyType").enumValueIndex;
		if ( ShowType== GetTypeValue.GetFromValue) 
		{
			m_NameList.elementHeight = 40;
			EditorGUI.HelpBox(new Rect(rect.x+110, rect.y, rect.width/4, EditorGUIUtility.singleLineHeight),"从输入的值中获取",MessageType.None);
			EditorGUI.PropertyField (new Rect(rect.x, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Name"), GUIContent.none);
			EditorGUI.PropertyField (new Rect(rect.width-100, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("SetValue"), GUIContent.none);
		}
		if (ShowType == GetTypeValue.GetFormText) 
		{
			m_NameList.elementHeight = 40;
			EditorGUI.HelpBox(new Rect(rect.x+110, rect.y, rect.width/4, EditorGUIUtility.singleLineHeight),"拖入的Text中获取",MessageType.None);
			EditorGUI.PropertyField (new Rect(rect.x, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Name"), GUIContent.none);
			EditorGUI.PropertyField (new Rect(rect.width-100, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("SetText"), GUIContent.none);
		}
		if (ShowType == GetTypeValue.GetFromInputField) 
		{
			m_NameList.elementHeight = 40;
			EditorGUI.HelpBox(new Rect(rect.x+110, rect.y, rect.width/4, EditorGUIUtility.singleLineHeight),"从输入Text中获取",MessageType.None);
			EditorGUI.PropertyField (new Rect(rect.x, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Name"), GUIContent.none);
			EditorGUI.PropertyField (new Rect(rect.width-100, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("SetInputField"), GUIContent.none);
		}
		if (ShowType == GetTypeValue.GetFromList) 
		{
			m_NameList.elementHeight = 40;
			EditorGUI.HelpBox(new Rect(rect.x+110, rect.y, rect.width/4, EditorGUIUtility.singleLineHeight),"从储存列表中按自己的的名字获取",MessageType.None);
			EditorGUI.PropertyField (new Rect(rect.x, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Name"), GUIContent.none);
		}
		if (ShowType == GetTypeValue.GetFromListOther) 
		{
			m_NameList.elementHeight = 40;
			EditorGUI.HelpBox(new Rect(rect.x+110, rect.y, rect.width/4, EditorGUIUtility.singleLineHeight),"从储存列表中按输入的名字获取",MessageType.None);
			EditorGUI.PropertyField (new Rect(rect.x, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("Name"), GUIContent.none);
			EditorGUI.PropertyField (new Rect(rect.width-100, rect.y+20, 100, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative ("OtherName"), GUIContent.none);
		}
        //EditorGUI.PropertyField(new Rect(rect.x, rect.y + EditorGUIUtility.singleLineHeight * 2, rect.width, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("ShowError"), GUIContent.none);
        //EditorGUI.PropertyField(rect, itemData, GUIContent.none);
    }




    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        m_NameList.DoLayoutList();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("IsLock"));
		GetMessageShow = serializedObject.FindProperty("Data");
		EditorGUILayout.PropertyField(GetMessageShow.FindPropertyRelative("Action"));
		EditorGUI.BeginDisabledGroup (GetMessageShow.FindPropertyRelative("Action").boolValue);
		EditorGUILayout.PropertyField(GetMessageShow.FindPropertyRelative("CutCount"));
		EditorGUILayout.PropertyField(GetMessageShow.FindPropertyRelative("DataName"));
		EditorGUILayout.PropertyField(GetMessageShow.FindPropertyRelative("URL"));

		GetBaseDataShow = GetMessageShow.FindPropertyRelative("GetBase");
		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("code"));
		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("result"));
		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("msg"));
		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("url"));

		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("codetext"));
		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("resulttext"));
		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("msgtext"));
		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("urltext"));
		EditorGUILayout.PropertyField(GetBaseDataShow.FindPropertyRelative("msgInputtext"));

		EditorGUI.EndDisabledGroup ();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("DataType"));
		if ((TypeGo)(serializedObject.FindProperty ("DataType").enumValueIndex) ==TypeGo.GetTypeB) 
		{
			GUI.backgroundColor = Color.green;
			GetListDataShow = GetMessageShow.FindPropertyRelative ("MyListMessage");
			EditorGUILayout.PropertyField (GetListDataShow.FindPropertyRelative ("FatherObj"));
			EditorGUILayout.PropertyField (GetListDataShow.FindPropertyRelative ("InsObj"));
			EditorGUILayout.PropertyField (GetListDataShow.FindPropertyRelative ("MyListType"));
			EditorGUILayout.PropertyField (GetListDataShow.FindPropertyRelative ("ObjTag"));

			ListDataList.DoLayoutList ();
			GUI.backgroundColor = Color.white;
		}
		if ((TypeGo)(serializedObject.FindProperty ("DataType").enumValueIndex) == TypeGo.GetTypeC) 
		{
			GUI.backgroundColor = Color.yellow;
			ListSingleList.DoLayoutList ();
			GUI.backgroundColor = Color.white;
		}

        if ((TypeGo)(serializedObject.FindProperty("DataType").enumValueIndex) == TypeGo.GetTypeD)
        {
            GUI.backgroundColor = Color.blue;
            GetListNoActionShow = GetMessageShow.FindPropertyRelative("MyListMessage");
            EditorGUILayout.PropertyField(GetListNoActionShow.FindPropertyRelative("GetVauleNoAction").FindPropertyRelative("Name"));
            EditorGUILayout.PropertyField(GetListNoActionShow.FindPropertyRelative("GetVauleNoAction").FindPropertyRelative("EventName"));
            EditorGUILayout.PropertyField(GetListNoActionShow.FindPropertyRelative("GetVauleNoAction").FindPropertyRelative("SendData"));
            GUI.backgroundColor = Color.white;
        }
        //GetDataList.DoLayoutList ();
        //SetDataList.DoLayoutList ();

        EditorGUILayout.PropertyField(GetMessageShow.FindPropertyRelative("ShowMessage"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("Suc"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("Fal"));
		GUI.backgroundColor = Color.red;
		EditorGUILayout.PropertyField(serializedObject.FindProperty("DoAction"));
		GUI.backgroundColor = Color.white;
		EditorGUILayout.PropertyField(serializedObject.FindProperty("NoShow"));
        serializedObject.ApplyModifiedProperties();
    }
}