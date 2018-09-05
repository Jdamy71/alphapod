using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BasePodController : MonoBehaviour
{
    private Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        CodeControl.Message.AddListener<PodResetRequestEvent>(OnPodResetRequested);
    }

    private void OnPodResetRequested(PodResetRequestEvent obj)
    {
        ResetPod();
    }

    private void ResetPod()
    {
        animator.SetTrigger("Reset");
    }

    private void ActivatePod()
    {
        animator.SetTrigger("Tapped");
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
