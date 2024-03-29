using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class FireTrap : MonoBehaviour
{
    public bool isBurning = false;
    public BoxCollider2D boxCollider2D;
    private Animator animator;
    private float minActiveTime = 1f;
    private float maxActiveTime = 2f;
    private float minActivationInterval = 2f;
    private float maxActivationInterval = 6f;

    private void Start()
    {
        boxCollider2D.enabled = false;
        animator = GetComponent<Animator>();
        StartCoroutine(ActivateTrapRepeatedly());
    }

    private void Update()
    {
        Debug.Log("isBurning: " + isBurning);
    }

    IEnumerator ActivateTrapRepeatedly()
    {
        while (true)
        {
            float activeTime = Random.Range(minActiveTime, maxActiveTime);
            float activationInterval = Random.Range(minActivationInterval, maxActivationInterval);

            yield return new WaitForSeconds(activationInterval);
            StartCoroutine(ActivateTrap(activeTime));
        }
    }

    IEnumerator ActivateTrap(float activeTime)
    {
        animator.SetBool("isActive", true);
        isBurning = true;
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(activeTime);
        animator.SetBool("isActive", false);
        boxCollider2D.enabled = false;
        isBurning = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBurning)
        {
            PlayerDead playerDead = collision.gameObject.GetComponent<PlayerDead>();
            playerDead.Die();
        }
    }
}
