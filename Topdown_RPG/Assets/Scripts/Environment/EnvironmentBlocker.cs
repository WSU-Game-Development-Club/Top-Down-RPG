using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class EnvironmentBlocker : MonoBehaviour
{
    [SerializeField] private bool isBlocking;

    private Animator animator;
    private Collider2D blockerCollider;

    void Awake()
    {
        blockerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        blockerCollider.enabled = isBlocking;
        if (animator != null) animator.SetBool("Blocking", isBlocking);
    }

    /// <summary>
    /// Set whether this environment blocker is active.
    /// </summary>
    /// <param name="isBlocking">Whether this environment is actively blocking the player.</param>
    public void SetIsBlocking(bool isBlocking)
    {
        if (this.isBlocking == isBlocking)
        {
            return;
        }

        this.isBlocking = isBlocking;
        blockerCollider.enabled = this.isBlocking;
        if (animator != null) animator.SetBool("Blocking", this.isBlocking);
    }
}
