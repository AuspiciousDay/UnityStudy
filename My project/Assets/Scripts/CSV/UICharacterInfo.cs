using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterInfo : MonoBehaviour
{
    public TMP_Text textRealName;
    public TMP_Text textName;
    public Image icon;
    public TMP_Text textHp;
    public TMP_Text textAtk;
    public TMP_Text textDef;
    public TMP_Text textSpeed;

    private CharacterData data;

    public void SetEmpty()
    {
        data = null;
        textName.text = string.Empty;
        textRealName.text = string.Empty;
        textHp.text = string.Empty;
        textAtk.text = string.Empty;
        textDef.text = string.Empty;
        textSpeed.text = string.Empty;
        icon.sprite = null;
    }

    public void SetCharacter(string id)
    {
        SetCharacter(DataTableManager.CharacterTable.Get(id));
    }
    public void SetCharacter(CharacterData data)
    {
        if(data == null)
        {
            SetEmpty();
        }

        this.data = data;
        textName.text = data.StringId;
        textRealName.text = data.StringName;
        icon.sprite = data.SpriteIcon;
        textHp.text = data.Hp.ToString();
        textAtk.text = data.Atk.ToString();
        textDef.text = data.Def.ToString();
        textSpeed.text = data.Speed.ToString();
    }
    
}
