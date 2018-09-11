using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BasePodController : MonoBehaviour
{
    public Animator[] animators;

    protected virtual void Awake()
    {
        CodeControl.Message.AddListener<PodResetRequestEvent>(OnPodResetRequested);
    }

    private void OnPodResetRequested(PodResetRequestEvent obj)
    {
        ResetPod();
    }

    private void ResetPod()
    {
        foreach(Animator animator in animators)
        {
            animator.SetTrigger("Reset");
        }
    }

    private void ActivatePod()
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("Tapped");
        }
        DispatchPodTappedEvent();
    }

    private void DispatchPodTappedEvent()
    {
        CodeControl.Message.Send(new PodTappedEvent());
    }

    private void OnMouseDown()
    {
        ActivatePod();
    }

}
