using System.Collections;
using System.Data.Common;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;




public class MovementScript : MonoBehaviour
{
    [SerializeField]
    public string allele;
    [SerializeField]
    Vector2 origMvmnt;
    public bool spawnBugCalled = false;
    public GameState gameState;
    public float speed;
    private int calledOnce = 0;
    public bool RandomMovement;
    private float timeToMove = 0f;
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
        Debug.Log(allele);
        RandomMovement = gameState.movementType;
        speed = gameState.speed;

        if (RandomMovement)
        {
            // Use Time.deltaTime to accumulate time until it reaches 2 seconds
            timeToMove += Time.deltaTime;

            // Check if it's time to move
            if (timeToMove >= 2f)
            {
                SetRandomDirection();
                timeToMove = 0f; // Reset the timer
                Debug.Log("ready to move again");
            }
        }

        if (spawnBugCalled)
        {
            StartCoroutine(ResetSpawnBugCalled());
        }

        speed = gameState.speed;

        if(gameState.SimStarted == false)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (calledOnce < 1)
        {

            if (gameState.SimStarted)
            {
                SetRandomDirection();
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
            if(gameObject.GetComponent<MovementScript>().allele == "BB")
            {
                gameState.currentDom--;
            }
            else if(gameObject.GetComponent<MovementScript>().allele == "Bb")
            {
                gameState.currentMid--;
            }
            else
            {
                gameState.currentSub--;
            }
            Destroy(gameObject);
            gameState.numBugs--;
        }

        else if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 position = gameObject.transform.position;
            cs = collision.gameObject.GetComponent<CollisionScript>();

            if (cs.canSpawn && !spawnBugCalled)
            {
                string childType = determineAllele(collision);
                Debug.Log("Should have " + childType);
                if (position.y > 0.37f)
                {

                    position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f, gameObject.transform.position.z);
                }
                else if (position.y <= 0.37f)
                {
                    position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z);
                }
                spawnBugCalled = true;
                cs.SpawnBug(position, childType);
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
        if(allele == "BB")
        {
            gameState.currentDom--;
        }
        else if(allele == "Bb")
        {
            gameState.currentMid--;
        }
        else if(allele == "bb")
        {
            gameState.currentSub--;
        }
    }

    public void ToggleMovement()
    {
        RandomMovement = !RandomMovement;
    }

    public string determineAllele(Collision2D collision)
    {
        string myType = this.allele;
    string otherType = collision.gameObject.GetComponent<MovementScript>().allele;
    Debug.Log("other type " + otherType);
    
    int randNum = Random.Range(0, 2);
    int randNum2 = Random.Range(0, 4);
    Debug.Log(randNum2);

    switch (myType)
    {
        case "BB":
            Debug.Log(myType + " taken as BB");
            if (otherType == "BB")
                return "BB";
            else if (otherType == "Bb")
            {
                if (randNum == 0)
                    return "BB";
                else
                    return "Bb";
            }
            else
                return "Bb";

        case "Bb":
            Debug.Log(myType + " taken as Bb");
            if (otherType == "BB")
            {
                if (randNum == 0)
                    return "BB";
                else
                    return "Bb";
            }
            else if (otherType == "Bb")
            {
                if (randNum2 == 0)
                {
                    Debug.Log("Should have BB");
                    return "BB";
                }
                else if (randNum2 == 1 || randNum2 == 2)
                {
                    Debug.Log("Should have Bb");
                    return "Bb";
                }
                else
                {
                    Debug.Log("Should have bb");
                    return "bb";
                }
            }
            else
                return "Bb";

        case "bb":
            Debug.Log(myType + " taken as bb");
            if (otherType == "BB")
                return "Bb";
            else if (otherType == "Bb")
            {
                if (randNum == 0)
                    return "Bb";
                else
                    return "bb";
            }
            else
                return "bb";
    }
    Debug.Log("returned BB");
    return "BB";
    }
}


    
