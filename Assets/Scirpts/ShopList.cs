using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopList : MonoBehaviour
{
    [SerializeField]
    public Image Icon;
    [SerializeField]
    Text Name, Price, Message,ID;


    public Texture2D Base64StringToTexture2D(string base64)
    {
        Texture2D tex = new Texture2D(4, 4, TextureFormat.ARGB32, false);
        try
        {
            byte[] bytes = System.Convert.FromBase64String(base64);
            tex.LoadImage(bytes);
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
        return tex;
    }

    public string Icon_
    {
        set
        {
            Texture2D texture = Base64StringToTexture2D(value);
            Sprite sprites = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            Icon.sprite = sprites;
        }
    }

    public string Name_
    {
        get
        {
            return Name.text;
        }
        set
        {
            Name.text = value;
        }
    }
    public string Price_
    {
        get
        {
            return Price.text;
        }
        set
        {
            Price.text = value;
        }
    }
    public string Message_
    {
        get
        {
            return Message.text;
        }
        set
        {
            Message.text = value;
        }
    }
    public string ID_
    {
        get
        {
            return ID.text;
        }
        set
        {
            ID.text = value;
        }
    }


    public void SetValue(string icon, string name, string price, string message,string id)
    {
        Icon_ = icon;
        Name_ = name;
        Price_ = price;
        Message_ = message;
        ID_ = id;
    }

    public void ButtonClick()
    {
        Transform obj = this.transform;
        while (obj.GetComponent<ShopListFanYe>() == null)
        {
            obj = obj.transform.parent;
        }
        obj.SendMessageUpwards("GouMaiClick", this);
    }
}
