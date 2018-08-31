using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimalOutlineController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite outlineSprite;
    public GameObject finishedAnimal;
    private bool colored;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.sprite = outlineSprite;
    }

    private void OnEnable()
    {
        CodeControl.Message.AddListener<ColoringFinishedEvent>(OnColoringFinished);
        CodeControl.Message.AddListener<ColoringResetRequestEvent>(OnColoringResetRequested);
    }

    private void OnDisable()
    {
        CodeControl.Message.RemoveListener<ColoringFinishedEvent>(OnColoringFinished);
        CodeControl.Message.RemoveListener<ColoringResetRequestEvent>(OnColoringResetRequested);
    }

    private void OnColoringResetRequested(ColoringResetRequestEvent obj)
    {
        ResetColoring();
    }

    private void OnColoringFinished(ColoringFinishedEvent obj)
    {
        colored = true;
        spriteRenderer.enabled = false;
        finishedAnimal.SetActive(true);
    }

    public void ResetColoring()
    {
        spriteRenderer.enabled = true;
        finishedAnimal.SetActive(false);
        colored = false;
    }

    protected virtual void OnMouseDown()
    {
        DispatchDrawingViewRequestEvent();
    }

    protected void DispatchDrawingViewRequestEvent()
    {
        CodeControl.Message.Send(new ColoringViewRequestEvent());
    }
}
