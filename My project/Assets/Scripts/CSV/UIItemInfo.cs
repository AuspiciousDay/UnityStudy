using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfo : MonoBehaviour
{
    public TMP_Text textName;
    public Image icon;
    public TMP_Text textType;
    public TMP_Text textValue;
    public TMP_Text textCost;
    public TMP_Text textDesc;

    private ItemData data;

    public void SetEmpty()
    {
        data = null;
        textName.text = string.Empty;
        icon.sprite = null;
        textValue.text = string.Empty;
        textCost.text = string.Empty;
        textDesc.text = string.Empty;
    }


    public void SetItem(string id)
    {
        SetItem(DataTableManager.ItemTable.Get(id));
    }

    public void SetItem(ItemData data)
    {
        if (data == null)
        {
            SetEmpty();
        }
        
        this.data = data;
        textName.text = data.StringName;
        icon.sprite = data.SpriteIcon;
        textValue.text = data.Type.ToString();
        textCost.text = data.Cost.ToString();
        textDesc.text = data.StringDesc;
    }
}
