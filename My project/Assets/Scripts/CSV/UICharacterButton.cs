using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICharacterButton : MonoBehaviour
{
    public Image icon;
    public TMP_Text textName;
    public Button button;

    private CharacterData data;

    public void SetEmpty()
    {
        data = null;
        icon.sprite = null;
        textName.text = string.Empty;
    }
    public void SetCharacter(string charId)
    {
        SetCharacter(DataTableManager.CharacterTable.Get(charId));
    }
    public void SetCharacter(CharacterData data)
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
