using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    GameManager gameManager;
    private Animator animator;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //E�er �arp���lan nesne d��man ise karakter �l�r ve toplanabilirler s�f�rlan�r
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            GlobalVariables.isBerryCollected = false;
            GlobalVariables.isLevelCompleted = false;
        }
    }
    private void Die()
    {
        //�ld�kten sonra static yaparak hareket etmesini engeller
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Dead");
    }
    public void OnDeathAnimationComplete()
    {
        //�l�m animasyonu tamamland�ktan sonra oyunu yeniden ba�lat�r
        Destroy(gameObject);
        gameManager.RestartLevel();
    }

}
