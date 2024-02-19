using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour, IInteractable
{
    public float jumpForce = 10f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        Rigidbody2D playerRigidbody = PlayerManager.Instance.GetPlayer().GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Interact();
        animator.SetBool("isJumping", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isJumping", false);
    }
}
