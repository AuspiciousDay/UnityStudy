using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;

    public bool canContinue = false;

    protected override void Awake()
    {
        base.Awake();

        continueButton.onClick.AddListener(OnClickContinue);
        newGameButton.onClick.AddListener(OnClickNewGame);
        optionButton.onClick.AddListener(OnClickOption);
    }

    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);
        firstSeleted = canContinue ? continueButton.gameObject : newGameButton.gameObject;
        base.Open();
    }

    public void OnClickContinue()
    {
        manager.Open(Windows.Difficulty);
    }

    public void OnClickNewGame()
    {
        manager.Open(Windows.Keyboard);
    }

    public void OnClickOption()
    {
        Debug.Log("OnOptionButton");
    }
}
