using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))] // [RequireComponent(typeof (TMP_Text))]가 있는 스크립트가 추가 될때 해당 오브젝트의 Component에 TMP_Text가 붙어있게 보장
[ExecuteInEditMode] // EditMode(Unity에서 플레이버튼 누르지 않을때)에서도 해당 스크립트를 실행하도록함
public class LocalizationText : MonoBehaviour
{
    public string stringId;

#if UNITY_EDITOR // 전처리기 -> 실제 컴파일되기 전에 코드를 제외시킴
    public Languages editorLang;
#endif

    private TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Variables.OnLanguageChanged += OnChangedLanguage;
        OnChangedLanguage();
    }

    private void OnDisable()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            OnChangedLanguage(editorLang);
            return;
        }
#endif

        Variables.OnLanguageChanged -= OnChangedLanguage;
    }

    public void OnChangedLanguage()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            return;
        }
#endif
        text.text = DataTableManager.StringTable.Get(stringId);
    }

#if UNITY_EDITOR
    public void OnChangedLanguage(Languages lang)
    {
        var tableId = DataTableIds.StringTableIds[(int)lang];
        var stringTable = DataTableManager.Get<StringTable>(tableId);
        text.text = stringTable.Get(stringId);
    }

    [ContextMenu("Apply Editor lang To All Active")] // 해당 컴포넌트의 설정메뉴 추가
    private void ApplyEditorlangToAllActive()
    {
        var all = FindObjectsByType<LocalizationText>(FindObjectsSortMode.None); // FindObjectsByType 활성화되어있는 오브젝트를 찾아서 LocalizationText형 배열로 만들어서 넘겨줌 // 실시간 동작하는 프로그램에는 사용X  
        foreach (var item in all)
        {
            item.editorLang = editorLang;
            item.OnChangedLanguage(editorLang);
        }
    }
#endif
}
