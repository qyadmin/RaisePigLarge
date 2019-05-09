using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopListFanYe : MonoBehaviour {

    [SerializeField]
    Transform ListFather;
    [SerializeField]
    Dropdown TypeList;

    [SerializeField]
    GameObject info_1;

    [SerializeField]
    HttpMessageModel http;

    [SerializeField]
    int PageNum = 4;

    [SerializeField]
    int NowPage = 1;

    [SerializeField]
    Text Pages;

    [SerializeField]
    UnityEvent GouMaiEvent;

    [SerializeField]
    Transform GouMai;
    [SerializeField]
    Image icon;
    [SerializeField]
    Text Id,Name;

    public int NowPage_
    {
        get
        {
            return NowPage;
        }
        set
        {
            NowPage = value;
            Pages.text = NowPage.ToString();
        }

    }

    public void Refresh()
    {
        
        NowPage_ = 1;
        for (int i = 0; i < ListFather.childCount; i++)
        {
            Destroy(ListFather.GetChild(i).gameObject);
        }
    }

    public void GetList(int page)
    {
        for (int i = 0; i < ListFather.childCount; i++)
        {
            Destroy(ListFather.GetChild(i).gameObject);
        }
        int PageCount = 1;
        foreach (KeyValuePair<string, Dic> i in Static.Instance.SaveShopList)
        {
            if (PageCount <= (page - 1) * PageNum)
            {
                PageCount++;
            }
            else
            {
                GameObject newFriend = Instantiate(info_1);
                newFriend.transform.parent = ListFather;
                newFriend.transform.localScale = new Vector3(1, 1, 1);
                string icon, name, price, message, id;
                i.Value.DataDic.TryGetValue("cover", out icon);
                i.Value.DataDic.TryGetValue("title", out name);
                i.Value.DataDic.TryGetValue("price", out price);
                i.Value.DataDic.TryGetValue("nr", out message);
                i.Value.DataDic.TryGetValue("id", out id);
                //i.Value.DataDic.TryGetValue("tdjb", out tdjb);
                newFriend.GetComponent<ShopList>().SetValue(icon, name, price, message, id);
            }
            
        }
    }

    public void GetType()
    {
        Refresh();
        TypeList.ClearOptions();
        foreach (KeyValuePair<string, Dic> i in Static.Instance.SaveShopType)
        {
            string name;
            i.Value.DataDic.TryGetValue("name", out name);
            Dropdown.OptionData optionData = new Dropdown.OptionData();
            optionData.text = name;
            TypeList.options.Add(optionData);
        }
        TypeList.onValueChanged.AddListener(ClickDropdown);
        TypeList.transform.GetChild(0).GetComponent<Text>().text = TypeList.options[0].text;
        TypeList.value = 0;
        Static.Instance.AddValue("type", Static.Instance.GetShopTypeKeys(TypeList.options[0].text));
        http.Get();
    }

    public void NextPage()
    {
        if(NowPage < Mathf.CeilToInt((float)Static.Instance.SaveShopList.Count/(float)PageNum))
        {
            NowPage_ += 1;
            GetList(NowPage_);
        }       
    }
    public void UpPage()
    {
        if (NowPage > 1)
        {
            NowPage_ -= 1;
            GetList(NowPage_);
        }
           
    }


    private void ClickDropdown(int index)
    {
        Refresh();
        Static.Instance.AddValue("type", Static.Instance.GetShopTypeKeys(TypeList.options[index].text));
        http.Get();
    }

    public void GouMaiClick(ShopList list)
    {
        GouMai.gameObject.SetActive(true);
        icon.sprite = list.Icon.sprite;
        Id.text = list.ID_;
        Name.text = list.Name_;
        GouMaiEvent.Invoke();
    }
}
