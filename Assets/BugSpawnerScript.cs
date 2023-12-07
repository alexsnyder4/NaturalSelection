using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BugSpawnerScript : MonoBehaviour
{
    [SerializeField] 
    GameState gameState;
    public int currentBugs = 0;
    [SerializeField]
    GameObject bugPrefab;
    public bool matchStarted;
    private int calledOnce = 0;

    float rectangleMinX = -6.727f;
    float rectangleMaxX = 5.251f;
    float rectangleMinY = -2.916f;
    float rectangleMaxY = 3.314f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentBugs = gameState.numBugs;
        matchStarted = gameState.SimStarted;
        calledOnce = gameState.calledOnce;

        if (calledOnce < 1 && matchStarted)
        {
            Debug.Log("SPAWN");
            SpawnBugsInitial(gameState.startBugs);
            calledOnce++;
            gameState.calledOnce = calledOnce;
        }
    }

    public void SpawnBugsInitial(int numBugsToSpawn)
    {
        for (int i = 0; i < numBugsToSpawn; i++)
        {
            Vector3 randomPosition = GetRandomPositionInsideRectangle();
            Instantiate(bugPrefab, randomPosition, Quaternion.identity);
            gameState.numBugs++;
        }
    }

  
    

    public Vector3 GetRandomPositionInsideRectangle()
    {
        // Generate a random position
        float randomX = Random.Range(rectangleMinX, rectangleMaxX);
        float randomY = Random.Range(rectangleMinY, rectangleMaxY);
        
        return new Vector3(randomX, randomY, 0f);
    }
    
  

}
