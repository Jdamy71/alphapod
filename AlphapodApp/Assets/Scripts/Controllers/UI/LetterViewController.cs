
using UnityEngine;
using UnityEngine.UI;

public class LetterViewController : MonoBehaviour {

    public Button backButton;

    private void Start()
    {
        SetupButtons();

    }

    private void SetupButtons()
    {
        backButton.onClick.AddListener(() =>
        {
            DispatchMainViewRequestEvent();
        });
    }

    private void DispatchMainViewRequestEvent()
    {
        CodeControl.Message.Send(new MainViewRequestEvent());
    }
}
