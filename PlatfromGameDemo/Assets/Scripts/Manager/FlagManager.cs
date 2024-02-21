using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        AnimationController();
    }
    //Üzümler toplanmýþsa bayraðý aktif et deðilse deaktif et
    private void AnimationController()
    {
        if (GlobalVariables.isLevelCompleted)
        {
            animator.SetBool("isBerriesCollected", true);
        }
        else
        {
            animator.SetBool("isBerriesCollected", false);
        }
    }

    //Son levelsa oyunu bitir deðilse bir sonraki levela geç
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GlobalVariables.isLevelCompleted&& GlobalVariables.currentLevel==2) 
        {
            GlobalVariables.isGameFinished = true;
        }
        if (GlobalVariables.isLevelCompleted)
        {
            GameManager.Instance.LoadNextLevel();
        }
    }
}
