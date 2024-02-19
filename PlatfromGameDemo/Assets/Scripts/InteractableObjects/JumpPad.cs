using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour, IInteractable
{
    public float jumpForce = 10f;

    public void Interact()
    {
        JumpPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Interact();
    }

    private void JumpPlayer()
    {
        Rigidbody2D playerRigidbody = PlayerManager.Instance.GetPlayer().GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
    }
}
