using System;
using UnityEngine;
using UnityEngine.UI;

public class PreferencesViewController : MonoBehaviour
{
    public Button backButton, resetAllLettersButton;
    public Slider soundVolumeSlider, musicVolumeSlider;

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
        resetAllLettersButton.onClick.AddListener(() =>
        {
            DispatchAllLettersResetRequestEvent();
        });
    }

    private void DispatchAllLettersResetRequestEvent()
    {
        CodeControl.Message.Send(new AllLettersResetRequestEvent());
    }

    private void DispatchMainViewRequestEvent()
    {
        CodeControl.Message.Send(new MainViewRequestEvent());
    }
}
