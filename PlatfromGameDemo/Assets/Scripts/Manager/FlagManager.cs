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
    //�z�mler toplanm��sa bayra�� aktif et de�ilse deaktif et
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

    //Son levelsa oyunu bitir de�ilse bir sonraki levela ge�
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
