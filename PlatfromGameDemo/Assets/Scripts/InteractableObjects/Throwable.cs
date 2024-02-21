using UnityEngine;

public class Throwable : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xBounds = 10f;
    public float throwForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Bounds();
        rb.velocity = -transform.up * throwForce;
    }

    //Düþmanla temas ettiðinde kendini ve düþmaný yok et
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    //Sýnýrlarýn dýþýna çýktýðýnda kendini yok et
    private void Bounds()
    {
        if (transform.position.x < -xBounds|| transform.position.x > xBounds)
        {
            Destroy(gameObject);
        }
    }
}
