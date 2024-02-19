using UnityEngine;

public class Throwable : MonoBehaviour
{
    private Rigidbody2D rb;

    public float throwForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = -transform.up * throwForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
