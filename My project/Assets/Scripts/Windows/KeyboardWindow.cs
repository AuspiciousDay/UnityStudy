using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyboardWindow : GenericWindow
{
    public int maxCharacters = 7;
    public TMP_Text inputField;
    public GameObject rootKeyboard;
    private Button[] keys;
    private string inputText = string.Empty;
    private string inputTextWithCursor = "_";

    private bool isCursorVisible;
    private float blinkTimer;
    private float blinkInterval = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        keys = rootKeyboard.GetComponentsInChildren<Button>();
        foreach (Button button in keys)
        {
            TMP_Text text = button.GetComponentInChildren<TMP_Text>();
            string key = text.text;
            button.onClick.AddListener(() => OnKey(key));
        }
    }
    public override void Open()
    {
        blinkTimer = 0;
        isCursorVisible = true;
        SetText(string.Empty);
        base.Open();
    }

    private void Update()
    {
        blinkTimer += Time.deltaTime;
        if (blinkTimer > blinkInterval)
        {
            blinkTimer = 0f;
            isCursorVisible = !isCursorVisible;
            UpdateInputField();
        }
    }

    private void SetText(string text)
    {
        if (text.Length > maxCharacters)
        {
            return;
        }
        inputText = text;
        inputTextWithCursor = inputText.Length < maxCharacters ? $"{inputText}_" : inputText;
        UpdateInputField();
    }

    private void UpdateInputField()
    {
        inputField.text = isCursorVisible ? inputTextWithCursor : inputText;
    }

    public void OnKey(string key)
    {
        if (inputField.text.Length > maxCharacters)
        {
            return;
        }
        SetText($"{inputText}{key}");
    }

    public void OnCancle()
    {
        SetText(string.Empty);
    }

    public void OnDelete()
    {
        if (inputText.Length <= 0)
        {
            return;
        }
        SetText(inputText.Remove(inputText.Length - 1));
    }

    public void OnAccept()
    {
        manager.Open(Windows.Difficulty);
    }
}
