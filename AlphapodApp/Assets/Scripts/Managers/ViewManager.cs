using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public GameObject[] views;
    private GameObject activeView;
    public Sprite outlineSprite, coloredSprite; //VERY TEMPORARY
    private void Awake()
    {
        CodeControl.Message.AddListener<ColoringViewRequestEvent>(OnColoringViewRequested);
        CodeControl.Message.AddListener<MainViewRequestEvent>(OnMainViewRequested);
        CodeControl.Message.AddListener<LetterMenuViewRequestEvent>(OnLetterMenuRequested);
        CodeControl.Message.AddListener<PreferencesViewRequestEvent>(OnSettingsViewRequested);
    }

    private void Start()
    {
        ChangeView(View.Main, (instantiatedView) =>
        {

        });
    }

    private void OnMainViewRequested(MainViewRequestEvent obj)
    {
        ChangeView(View.Main, (instantiatedView) =>
        {

        });
    }

    private void OnColoringViewRequested(ColoringViewRequestEvent obj)
    {
        ChangeView(View.Coloring, (instantiatedView) =>
        {
            instantiatedView.GetComponent<ColoringViewController>().Initialize(outlineSprite, coloredSprite);
        });
    }

    private void OnSettingsViewRequested(PreferencesViewRequestEvent obj)
    {
        ChangeView(View.Settings, (instantiatedView) =>
        {

        });
    }

    private void OnLetterMenuRequested(LetterMenuViewRequestEvent obj)
    {
        ChangeView(View.Letter, (instantiatedView) =>
        {

        });
    }


    private void ChangeView(View view, Action<GameObject> callback)
    {
        switch (view)
        {
            case View.Main:
                if (activeView != null)
                {
                    activeView.SetActive(false);
                }
                else
                {
                    foreach (GameObject gO in views)
                    {
                        gO.SetActive(false);
                    }
                }
                activeView = views[(int)View.Main];
                activeView.SetActive(true);
                break;
            case View.Coloring:
                if (activeView != views[(int)View.Main])
                {
                    activeView.SetActive(false);
                    activeView = views[(int)View.Coloring];
                    activeView.SetActive(true);
                }
                else
                {
                    activeView = views[(int)View.Coloring];
                    activeView.SetActive(true);
                }
                break;
            case View.Settings:
                if (activeView != views[(int)View.Main])
                {
                    activeView.SetActive(false);
                    activeView = views[(int)View.Settings];
                    activeView.SetActive(true);
                }
                else
                {
                    activeView = views[(int)View.Settings];
                    activeView.SetActive(true);
                }
                break;
            case View.Letter:
                if (activeView != views[(int)View.Main])
                {
                    activeView.SetActive(false);
                    activeView = views[(int)View.Letter];
                    activeView.SetActive(true);
                }
                else
                {
                    activeView = views[(int)View.Letter];
                    activeView.SetActive(true);
                }
                break;
        }
        callback(activeView);
    }
}
