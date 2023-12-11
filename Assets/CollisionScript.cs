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


    public void SpawnBug(Vector3 pos, string childType)
    {
        if (gameState.isSpawning && currentBugs < 100 && canSpawn)
        {
            
            GameObject newBug = Instantiate(bugPrefab, pos, Quaternion.identity);
            if(childType == "BB")
            {
                newBug.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                newBug.name = "blackDom";
                gameState.currentDom++;
            }
            else if(childType == "Bb")
            {
                newBug.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                newBug.name = "Mid";
                gameState.currentMid++;
            }
            else
            {
                newBug.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                newBug.name = "White";
                gameState.currentSub++;
            }
            Debug.Log("Spawning with " + childType);
            newBug.gameObject.GetComponent<MovementScript>().allele = childType;
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

