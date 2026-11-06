using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIItemButton : MonoBehaviour
{
    public Image icon;
    public TMP_Text textName;
    public Button button;

    private ItemData data;

    public void SetEmpty() // 호출시 비어있는 상태
    {
        data = null;
        icon.sprite = null;
        textName.text = string.Empty;
    }

    public void SetItem(string itemId)
    {
        SetItem(DataTableManager.ItemTable.Get(itemId));
    }

    public void SetItem(ItemData data)
    {
        if(data == null)
        {
            SetEmpty();
        }

        this.data = data;
        icon.sprite = data.SpriteIcon;
        textName.text = data.StringName;
    }
}
