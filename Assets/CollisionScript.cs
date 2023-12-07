using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField]
    GameObject bugPrefab;
     [SerializeField] 
    GameState gameState;
    int currentBugs = 0;
    public bool canSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        currentBugs = gameState.numBugs;
        StartCoroutine(SpawnWaitTimer(2f));
    }

    // Update is called once per frame
    void Update()
    {
        currentBugs = gameState.numBugs;
    }


    public void SpawnBug(Vector3 pos)
    {
        if (gameState.isSpawning && currentBugs < 100 && canSpawn)
        {
            Debug.Log("Current Bugs: " + currentBugs);
            Instantiate(bugPrefab, pos, Quaternion.identity);
            gameState.numBugs++;
            canSpawn = false;
            StartCoroutine(SpawnWaitTimer(2f));
        }
    }
    IEnumerator SpawnWaitTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canSpawn = true;
    }
}
