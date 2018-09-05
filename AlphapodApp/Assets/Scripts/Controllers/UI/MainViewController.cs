using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainViewController : MonoBehaviour
{

    public Button podResetButton, preferencesButton, letterMenuButton, nextLetterButton, bucketButton;
    public Sprite[] bucketSprites;
    public Text currentAnimalText;
    public Animator currentAnimalTextAnimator;

    private void Awake()
    {
        CodeControl.Message.AddListener<ColoringFinishedEvent>(OnColoringFinished);
        CodeControl.Message.AddListener<ColoringResetRequestEvent>(OnColoringResetRequested);
        CodeControl.Message.AddListener<PodTappedEvent>(OnPodTapped);
    }

    void Start()
    {
        SetupButtons();
    }

    private void SetupButtons()
    {
        podResetButton.onClick.AddListener(() =>
        {
            DispatchPodResetRequestEvent();
            ResetCurrentAnimalText();
        });

        preferencesButton.onClick.AddListener(() =>
        {
            DispatchPreferencesViewRequestEvent();
        });

        letterMenuButton.onClick.AddListener(() =>
        {
            DispatchLetterMenuRequestEvent();
        });

        nextLetterButton.onClick.AddListener(() =>
        {
            DispatchNextLetterRequestEvent();
        });

        bucketButton.onClick.AddListener(() =>
        {
            DispatchColoringScreenRequestEvent();
        });

    }

    private void ResetCurrentAnimalText()
    {
        currentAnimalTextAnimator.SetTrigger("PodReset");
    }

    private void OnPodTapped(PodTappedEvent obj)
    {
        currentAnimalTextAnimator.SetTrigger("Tapped");
    }

    private void OnColoringFinished(ColoringFinishedEvent obj)
    {
        bucketButton.image.sprite = bucketSprites[1];
        bucketButton.onClick.RemoveAllListeners();
        bucketButton.onClick.AddListener(() =>
        {
            DispatchColoringResetRequestEvent();
        });
    }

    private void OnColoringResetRequested(ColoringResetRequestEvent obj)
    {
        bucketButton.image.sprite = bucketSprites[0];

        bucketButton.onClick.AddListener(() =>
        {
            DispatchColoringScreenRequestEvent();
        });
    }

    private void DispatchPreferencesViewRequestEvent()
    {
        CodeControl.Message.Send(new PreferencesViewRequestEvent());
    }

    private void DispatchColoringResetRequestEvent()
    {
        CodeControl.Message.Send(new ColoringResetRequestEvent());
    }

    private void DispatchNextLetterRequestEvent()
    {
        CodeControl.Message.Send(new NextLetterRequestEvent());

    }

    private void DispatchColoringScreenRequestEvent()
    {
        CodeControl.Message.Send(new ColoringViewRequestEvent());
    }

    private void DispatchLetterMenuRequestEvent()
    {
        CodeControl.Message.Send(new LetterMenuViewRequestEvent());
    }

    private void DispatchPodResetRequestEvent()
    {
        CodeControl.Message.Send(new PodResetRequestEvent());
    }
}
