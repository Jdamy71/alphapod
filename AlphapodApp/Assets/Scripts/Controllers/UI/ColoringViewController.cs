using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoringViewController : MonoBehaviour
{
    public Button backButton;
    public ColoringAnimalController coloringAnimalController;

    public void Initialize(Sprite animalOutlineSprite, Sprite animalColoredSprite)
    {
        coloringAnimalController.AssignSprites(animalOutlineSprite, animalColoredSprite);
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
