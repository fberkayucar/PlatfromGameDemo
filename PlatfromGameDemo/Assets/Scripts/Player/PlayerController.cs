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

    //Karakterin z�plama i�lemini ger�ekle�tirir
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //Karakterin hareketini sa�lar
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        //Karakterin y�n�n� belirler
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        //Karakterin ko�ma animasyonunu ba�lat�r
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

    //Karakterin �ilek f�rlatma i�lemini ger�ekle�tirir
    private void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.E) && isShooting && GlobalVariables.isBerryCollected)
        {
            //F�rlat�lacak y�n� belirler
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

    //f�rlatma i�leminin aktifli�ini ayarlar
    void EnableShooting()
    {
        isShooting = true;
    }

    //Z�playabilmek i�in zemine de�ip de�medi�ini kontrol eder
    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    //Karakterin x pozisyonunu s�n�rlar
    private void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
