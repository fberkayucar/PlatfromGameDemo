using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [SerializeField]
    StrawBerry strawBerry;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;
    private Quaternion bulletRotation;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isShooting;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("EnableShooting", 0, 3f);
    }

    private void Update()
    {
        Movement();
        Jump();
        ClampPosition();
        Shoot();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (horizontalInput > 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else if (horizontalInput < 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.E) && isShooting && GlobalVariables.isBerryCollected)
        {
            if (spriteRenderer.flipX)
            {
                bulletRotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                bulletRotation = Quaternion.Euler(0, 0, 90);
            }
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletRotation);
            isShooting = false;
        }
    }

    void EnableShooting()
    {
        isShooting = true;
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
