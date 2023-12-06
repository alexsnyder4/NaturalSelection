using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class MovementScript : MonoBehaviour
{
     public float speed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();
        // Set the initial direction
        SetRandomDirection();
    }

    void FixedUpdate()
    {
        
    }

    private void SetRandomDirection()
    {
        // Set a random direction for the circle
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Debug.Log("Hit");

            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, normal);
            rb.velocity = reflectedVelocity.normalized * speed;

            // Optional: Apply an additional force to make the bounce more noticeable
            rb.AddForce(reflectedVelocity.normalized * speed * 10f, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, normal);
            rb.velocity = reflectedVelocity.normalized * speed;

            // Optional: Apply an additional force to make the bounce more noticeable
            rb.AddForce(reflectedVelocity.normalized * speed * 10f, ForceMode2D.Impulse);
        }
    }
}