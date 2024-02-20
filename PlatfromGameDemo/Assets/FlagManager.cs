using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        GameManager.Instance.GameStart();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        AnimationController();
    }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GlobalVariables.isLevelCompleted)
        {
            GameManager.Instance.LoadNextLevel();
        }
    }
}
