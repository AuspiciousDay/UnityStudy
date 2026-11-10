using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UiCharacterInfo : MonoBehaviour
{
    public static readonly string FormatString = "{0} : {1}";

    public Image icon;
    public TMP_Text textName;
    public TMP_Text textHp;
    public TMP_Text textAtk;
    public TMP_Text textSpeed;

    public void SetEmpty()
    {
        icon.sprite = null;
        icon.enabled = false;
        textName.text = string.Empty;
        textHp.text = string.Empty;
        textAtk.text = string.Empty;
        textSpeed.text = string.Empty;
    }

    public void SetCharacter(SaveCharacterData saveCharacterData)
    {
        var st = DataTableManager.StringTable;
        var data = saveCharacterData.CharacterData;
        icon.sprite = data.SpriteIcon;
        icon.enabled = true;
        textName.text = string.Format(FormatString, st.Get("NAME"), data.StringName);
        textHp.text = string.Format(FormatString, st.Get("TYPE"), data.Hp);
        textAtk.text = string.Format(FormatString, st.Get("VALUE"), data.Atk);
        textSpeed.text = string.Format(FormatString, st.Get("COST"), data.Speed);
    }
}
