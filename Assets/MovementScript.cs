using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;


public class MovementScript : MonoBehaviour
{
    [SerializeField]
    Vector2 origMvmnt;
    public bool spawnBugCalled = false;
    public GameState gameState;
    public float speed;
    private int calledOnce = 0;
    [SerializeField]
    public CollisionScript cs; // Reference to BugSpawnerScript

    private Rigidbody2D rb;

    void Start()
    {

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // Set the initial direction


    }
    private void Update()
    {
        if (spawnBugCalled)
        {
            StartCoroutine(ResetSpawnBugCalled());
        }
        speed = gameState.speed;
    }
    void FixedUpdate()
    {
        if (calledOnce < 1)
        {

            if (gameState.SimStarted)
            {
                SetRandomDirection();
                GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }

    private void SetRandomDirection()
    {
        // Set a random direction for the circle
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * speed;
        calledOnce++;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {

            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, normal);
            rb.velocity = reflectedVelocity.normalized * speed;

            // Optional: Apply an additional force to make the bounce more noticeable
            rb.AddForce(reflectedVelocity.normalized * speed * 10f, ForceMode2D.Impulse);
        }

        else if (collision.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            gameState.numBugs--;
        }

        else if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 position = gameObject.transform.position;
            cs = collision.gameObject.GetComponent<CollisionScript>();

            if (cs.canSpawn && !spawnBugCalled)
            {
                if (position.y > 0.37f)
                {
                    spawnBugCalled = true;
                    position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f, gameObject.transform.position.z);
                    cs.SpawnBug(position);
                    
                }
                else if (position.y <= 0.37f)
                {
                    spawnBugCalled = true;
                    position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z);
                    cs.SpawnBug(position);
                    
                }
            }
        }

    }
    private IEnumerator ResetSpawnBugCalled()
    {
        yield return new WaitForSeconds(2f); // Adjust the delay as needed
        spawnBugCalled = false;
    }

    public void OnMouseDown()
    {
        Destroy(gameObject);
        gameState.numBugs--;
    }
}

    
