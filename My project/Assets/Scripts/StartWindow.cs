using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public Button  continueButton;
    public Button  newGameButton;
    public Button  optionButton;
    
    public bool canContinue = false;

    protected override void Awake()
    {
        base.Awake();

        continueButton.onClick.AddListener(OnContinueButton);
        newGameButton.onClick.AddListener(OnNewGameButton);
        optionButton.onClick.AddListener(OnOptionButton);
    }

    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);
        firstSeleted = canContinue ? continueButton.gameObject : newGameButton.gameObject;
        base.Open();
    }

    public void OnContinueButton()
    {
        Debug.Log("OnContinueButton");
    }

    public void OnNewGameButton()
    {
        Debug.Log("OnNewGameButton");
    }

    public void OnOptionButton()
    {
        Debug.Log("OnOptionButton");
    }
}
