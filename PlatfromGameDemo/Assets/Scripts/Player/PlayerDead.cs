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
        //Eðer çarpýþýlan nesne düþman ise karakter ölür ve toplanabilirler sýfýrlanýr
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            GlobalVariables.isBerryCollected = false;
            GlobalVariables.isLevelCompleted = false;
        }
    }
    private void Die()
    {
        //Öldükten sonra static yaparak hareket etmesini engeller
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Dead");
    }
    public void OnDeathAnimationComplete()
    {
        //Ölüm animasyonu tamamlandýktan sonra oyunu yeniden baþlatýr
        Destroy(gameObject);
        gameManager.RestartLevel();
    }

}
