using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnerScript : MonoBehaviour
{
    [SerializeField] 
    GameState gameState;
    int currentBugs =0;
    [SerializeField]
    GameObject bugPrefab;
    bool isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBugTimer(2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        currentBugs = gameState.numBugs;
    }

    void SpawnBug(Vector3 pos)
    {
        
        
        if (isSpawning && currentBugs < 100)
        {
            Debug.Log(currentBugs);
            Instantiate(bugPrefab, pos, Quaternion.identity);
            StartCoroutine(SpawnBugTimer(10f));
            gameState.numBugs++;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 position = gameObject.transform.position;
            if(position.y > 0.37f)
            {
                position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f, gameObject.transform.position.z);
                SpawnBug(position);
            }
            else if (position.y <= 0.37f)
            {
                position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z);
                SpawnBug(position);
            }


        }
    }

    IEnumerator SpawnBugTimer(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        isSpawning = true;

    }
}
