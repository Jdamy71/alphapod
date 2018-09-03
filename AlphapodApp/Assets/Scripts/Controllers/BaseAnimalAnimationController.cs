using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimalAnimationController : MonoBehaviour
{

    protected Animator[] childrenAnimators;
    protected Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        childrenAnimators = new Animator[GetComponentsInChildren<Animator>().Length];
        childrenAnimators = GetComponentsInChildren<Animator>();
    }

    protected virtual void OnMouseDown()
    {
        animator.SetTrigger("Tapped");
        foreach (Animator animator in childrenAnimators)
        {
            animator.SetTrigger("Tapped");
        }
    }
}
